import re
import logging
from rapidfuzz import fuzz
from openpyxl import load_workbook

logging.basicConfig(level=logging.INFO)


class ExcelDBMapper:
    def __init__(self, db_columns):
        self.db_columns = db_columns
        self.db_norm = {col: self._normalize(col) for col in db_columns}

    def _normalize(self, text):
        text = str(text or "").lower()
        return re.sub(r'[^a-z0-9]', '', text)

    def _tokens(self, text):
        return [token for token in re.split(r'[\s_]+', str(text).lower()) if token]

    def _token_score(self, a, b):
        a_set = set(self._tokens(a))
        b_set = set(self._tokens(b))
        return len(a_set & b_set) / max(len(a_set | b_set), 1)

    def _ngram(self, text, n=3):
        text = str(text)
        return [text[i:i+n] for i in range(len(text) - n + 1)] if len(text) >= n else [text]

    def _ngram_score(self, a, b):
        a_set = set(self._ngram(a))
        b_set = set(self._ngram(b))
        return len(a_set & b_set) / max(len(b_set), 1)

    def _fuzzy_score(self, a, b):
        return fuzz.partial_ratio(self._normalize(a), self._normalize(b)) / 100

    def _score(self, excel_col, db_col):
        token = self._token_score(excel_col, db_col)
        ngram = self._ngram_score(excel_col, db_col)
        fuzzy_score = self._fuzzy_score(excel_col, db_col)
        return 0.45 * token + 0.35 * ngram + 0.20 * fuzzy_score

    def _find_exact(self, excel_col, candidates):
        normalized = self._normalize(excel_col)
        for db_col in candidates:
            if normalized == self.db_norm.get(db_col):
                return db_col
        return None

    def get_excel_headers_with_color(self, file_path):
        workbook = load_workbook(file_path)
        worksheet = workbook.active

        headers = []
        colored_headers = []

        for col in worksheet.iter_cols(min_row=1, max_row=1):
            cell = col[0]
            header = str(cell.value).strip() if cell.value else ""
            headers.append(header)

            fill = cell.fill
            color = fill.start_color
            if color and color.index not in ("00000000", "FFFFFFFF"):
                colored_headers.append(header)

        return {
            "all_headers": headers,
            "update_headers": colored_headers,
        }

    def map(self, excel_headers, key_columns=None):
        key_columns = key_columns or []
        mapped = {}
        scores = {}
        ambiguous = []
        unmapped = []
        used_db = set()

        for key in key_columns:
            match = self._find_exact(key, self.db_columns)
            if not match:
                raise Exception(f"Key column '{key}' không tồn tại trong DB")
            mapped[key] = match
            scores[key] = 1.0
            used_db.add(match)

        for excel_col in excel_headers:
            if not excel_col or excel_col in mapped:
                continue

            candidates = [col for col in self.db_columns if col not in used_db]
            if not candidates:
                mapped[excel_col] = ""
                scores[excel_col] = 0.0
                unmapped.append((excel_col, 0.0))
                continue

            exact_match = self._find_exact(excel_col, candidates)
            if exact_match:
                mapped[excel_col] = exact_match
                scores[excel_col] = 1.0
                used_db.add(exact_match)
                continue

            best_col = None
            best_score = 0.0
            for db_col in candidates:
                score = self._score(excel_col, db_col)
                if score > best_score:
                    best_score = score
                    best_col = db_col

            if best_score >= 0.85:
                mapped[excel_col] = best_col
                scores[excel_col] = round(best_score, 3)
                used_db.add(best_col)
            elif best_score >= 0.70:
                mapped[excel_col] = best_col or ""
                scores[excel_col] = round(best_score, 3)
                used_db.add(best_col)
                ambiguous.append((excel_col, best_col, round(best_score, 3)))
            else:
                mapped[excel_col] = ""
                scores[excel_col] = round(best_score, 3)
                unmapped.append((excel_col, round(best_score, 3)))

        return {
            "mapped": mapped,
            "scores": scores,
            "ambiguous": ambiguous,
            "unmapped": unmapped,
        }

    def build_config(self, file_path, key_columns):
        excel_info = self.get_excel_headers_with_color(file_path)
        headers_for_mapping = list(set(excel_info["update_headers"] + key_columns))
        result = self.map(headers_for_mapping, key_columns)
        if result["ambiguous"]:
            raise Exception(f"Ambiguous mapping: {result['ambiguous']}")

        config = {
            "key_columns": key_columns,
            "header_mapping": result["mapped"],
        }
        logging.info(f"Mapping success: {len(result['mapped'])}")
        logging.info(f"Unmapped: {result['unmapped']}")
        return config