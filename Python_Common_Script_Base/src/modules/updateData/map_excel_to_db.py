import re
import logging
from pathlib import Path
from typing import List, Dict, Any, Optional

import numpy as np
from openpyxl import load_workbook
from scipy.optimize import linear_sum_assignment
from sklearn.metrics.pairwise import cosine_similarity
from sentence_transformers import SentenceTransformer

logging.basicConfig(level=logging.INFO)


def _normalize_text(text: Any) -> str:
    s = str(text or "").lower()
    return re.sub(r'[^a-z0-9]', '', s)


def _preprocess_for_embedding(text: Any) -> str:
    s = str(text or "").lower()
    s = re.sub(r'[_\-\.]', ' ', s)
    s = re.sub(r'[^a-z0-9\s]', '', s)
    return re.sub(r'\s+', ' ', s).strip()


class ExcelHeaderExtractor:
    """Extracts headers from an Excel file and detects colored headers for update."""

    ALLOWED_EXT = {'.xlsx', '.xlsm', '.xltx', '.xltm'}

    def get_excel_headers_with_color(self, file_path: Path) -> Dict[str, List[str]]:
        if isinstance(file_path, (list, tuple)):
            file_path = file_path[0]

        file_path = Path(str(file_path))
        if file_path.suffix.lower() not in self.ALLOWED_EXT:
            raise ValueError(f"Unsupported Excel format: {file_path.suffix}")

        wb = load_workbook(file_path)
        ws = wb.active

        headers: List[str] = []
        colored: List[str] = []

        for col in ws.iter_cols(min_row=1, max_row=1):
            cell = col[0]
            h = str(cell.value).strip() if cell.value is not None else ""
            headers.append(h)

            fill = getattr(cell, 'fill', None)
            start = getattr(fill, 'start_color', None)
            if start is not None:
                idx = getattr(start, 'index', None)
                if idx and idx not in ("00000000", "FFFFFFFF"):
                    colored.append(h)

        wb.close()
        return {"all_headers": headers, "update_headers": colored}


class HeaderMappingBuilder:
    """Builds header mapping between Excel headers and DB columns using embeddings.

    Responsibilities:
    - exact match for keys
    - semantic similarity for remaining headers
    - confidence assignment and manual-review queue
    """

    def __init__(self, db_columns: List[str], embedding_model: str = "all-MiniLM-L6-v2"):
        self.db_columns = list(db_columns)
        self.db_norm = {c: _normalize_text(c) for c in self.db_columns}

        logging.info(f"Loading embedding model: {embedding_model}")
        self.model = SentenceTransformer(embedding_model)
        self.db_embeddings = self.model.encode([
            _preprocess_for_embedding(c) for c in self.db_columns
        ], convert_to_numpy=True, normalize_embeddings=True)

    def find_exact(self, excel_col: str, candidates: List[str]) -> Optional[str]:
        norm = _normalize_text(excel_col)
        for c in candidates:
            if self.db_norm.get(c) == norm:
                return c
        return None

    def embedding_similarity_matrix(self, excel_headers: List[str], db_subset: List[str]) -> np.ndarray:
        if not excel_headers or not db_subset:
            return np.array([])

        excel_emb = self.model.encode([
            _preprocess_for_embedding(h) for h in excel_headers
        ], convert_to_numpy=True, normalize_embeddings=True)

        db_idx = [self.db_columns.index(c) for c in db_subset]
        db_emb = self.db_embeddings[db_idx]

        return cosine_similarity(excel_emb, db_emb)

    def build_matrix_and_assign(self, excel_headers: List[str], db_subset: List[str]) -> List[Dict[str, Any]]:
        if not excel_headers or not db_subset:
            return []

        sim = self.embedding_similarity_matrix(excel_headers, db_subset)
        cost = 1 - sim
        row_idx, col_idx = linear_sum_assignment(cost)

        out: List[Dict[str, Any]] = []
        for r, c in zip(row_idx, col_idx):
            score = float(sim[r][c])
            if score >= 0.85:
                conf = 'HIGH'
            elif score >= 0.70:
                conf = 'MED'
            else:
                conf = 'LOW'

            out.append({
                'excel_column': excel_headers[r],
                'db_column': db_subset[c],
                'score': round(score, 4),
                'confidence': conf
            })

        return out

    def build_config(self, excel_headers: List[str], key_columns: List[str]) -> Dict[str, Any]:
        key_columns = key_columns or []
        header_mapping: Dict[str, str] = {}
        scores: Dict[str, float] = {}
        confidence: Dict[str, str] = {}
        needs_review: List[str] = []
        used_db = set()

        # Exact match for keys
        for k in key_columns:
            match = self.find_exact(k, self.db_columns)
            if match:
                header_mapping[k] = match
                scores[k] = 1.0
                confidence[k] = 'HIGH'
                used_db.add(match)
            else:
                logging.warning(f"Key column '{k}' not found in DB columns")

        remaining_excel = [h for h in excel_headers if h not in header_mapping]
        remaining_db = [d for d in self.db_columns if d not in used_db]

        assignments = self.build_matrix_and_assign(remaining_excel, remaining_db)
        for item in assignments:
            excel_col = item['excel_column']
            db_col = item['db_column']
            header_mapping[excel_col] = db_col
            scores[excel_col] = item['score']
            confidence[excel_col] = item['confidence']
            if item['confidence'] in ('MED', 'LOW'):
                needs_review.append(excel_col)

        # Ensure all headers present
        for h in excel_headers:
            if h not in header_mapping:
                header_mapping[h] = ''
                scores[h] = 0.0
                confidence[h] = 'LOW'
                needs_review.append(h)

        return {
            'key_columns': key_columns,
            'header_mapping': header_mapping,
            'scores': scores,
            'confidence': confidence,
            'needs_review': needs_review
        }


class ExcelDBMapper:
    """Facade that combines header extraction and mapping builder.

    Public methods:
    - get_excel_headers_with_color(file_path)
    - map(file_path, key_columns)
    """

    def __init__(self, db_columns: List[str], embedding_model: str = "all-MiniLM-L6-v2"):
        self.db_columns = list(db_columns)
        self.extractor = ExcelHeaderExtractor()
        self.builder = HeaderMappingBuilder(self.db_columns, embedding_model)

    def get_excel_headers_with_color(self, file_path: Path) -> Dict[str, List[str]]:
        return self.extractor.get_excel_headers_with_color(file_path)

    def map(self, file_path: Path, key_columns: Optional[List[str]] = None) -> Dict[str, Any]:
        key_columns = key_columns or []
        excel_info = self.extractor.get_excel_headers_with_color(file_path)
        excel_headers = list(set(excel_info.get('update_headers', []) + key_columns))
        return self.builder.build_config(excel_headers, key_columns)
