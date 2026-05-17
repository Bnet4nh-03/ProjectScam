# ExcelDBMapper Architecture

## System Overview

`ExcelDBMapper` là hệ thống semantic schema mapping dùng AI embedding để tự động ánh xạ:

```text
Excel Headers
→
Database Columns
```

Hệ thống kết hợp:

- Exact Matching
- Embedding Similarity
- Hungarian Optimization
- Confidence Threshold
- Manual Review Queue

---

# Architecture Flow

```text
                ┌──────────────────────┐
                │ ExcelDBMapper Init   │
                └──────────┬───────────┘
                           │
                           ▼
          ┌────────────────────────────────┐
          │ Load Embedding Model           │
          │ SentenceTransformer            │
          └──────────────┬─────────────────┘
                         │
                         ▼
          ┌────────────────────────────────┐
          │ Precompute DB Embeddings       │
          │ Encode DB columns into vectors │
          └──────────────┬─────────────────┘
                         │
                         ▼
                 ┌───────────────┐
                 │ map()         │
                 └──────┬────────┘
                        │
                        ▼
      ┌──────────────────────────────────┐
      │ Read Excel Headers               │
      │ get_excel_headers_with_color()   │
      └────────────────┬─────────────────┘
                       │
                       ▼
              ┌─────────────────┐
              │ build_config()  │
              └────────┬────────┘
                       │
          ┌────────────┴────────────┐
          ▼                         ▼

 ┌──────────────────┐    ┌────────────────────┐
 │ Exact Match      │    │ Remaining Columns  │
 │ for key columns  │    │ Semantic Matching  │
 └────────┬─────────┘    └─────────┬──────────┘
          │                        │
          ▼                        ▼

 normalize compare      embedding_similarity_matrix()
                                   │
                                   ▼

                     ┌────────────────────────┐
                     │ Excel Embeddings       │
                     │ Vector Representation  │
                     └──────────┬─────────────┘
                                │
                                ▼

                     ┌────────────────────────┐
                     │ Cosine Similarity      │
                     │ Similarity Matrix      │
                     └──────────┬─────────────┘
                                │
                                ▼

                     ┌────────────────────────┐
                     │ Cost Matrix            │
                     │ cost = 1 - similarity  │
                     └──────────┬─────────────┘
                                │
                                ▼

                     ┌────────────────────────┐
                     │ Hungarian Assignment   │
                     │ linear_sum_assignment  │
                     └──────────┬─────────────┘
                                │
                                ▼

                     ┌────────────────────────┐
                     │ Confidence Threshold   │
                     │ HIGH / MED / LOW       │
                     └──────────┬─────────────┘
                                │
                                ▼

                     ┌────────────────────────┐
                     │ Manual Review Queue    │
                     │ Human Validation       │
                     └──────────┬─────────────┘
                                │
                                ▼

                     ┌────────────────────────┐
                     │ Final Mapping Config   │
                     └────────────────────────┘
```

---

# Architecture Layers

| Layer | Responsibility |
|---|---|
| Exact Match | Deterministic mapping using normalized text |
| Embedding Similarity | Semantic understanding using AI embeddings |
| Hungarian Algorithm | Global optimal assignment optimization |
| Confidence Threshold | Uncertainty estimation and scoring |
| Manual Review | Human validation for uncertain mappings |

---

# Core Design Philosophy

Hệ thống được thiết kế theo tư duy:

```text
Deterministic First
AI Second
Human Validation Last
```

Ý nghĩa:

1. Ưu tiên exact match trước
2. Dùng semantic AI cho các trường hợp khó
3. Tối ưu global matching bằng Hungarian algorithm
4. Đánh giá độ tin cậy
5. Đưa các mapping không chắc chắn vào review queue

---

# Main Components

## 1. Exact Match Layer

Mục tiêu:

- Match các key columns quan trọng
- Tránh AI đoán sai các trường critical

Ví dụ:

```text
Board No
→
board_no
```

Thông qua normalize:

```text
boardno == boardno
```

---

## 2. Embedding Similarity Layer

Sử dụng:

```python
SentenceTransformer
```

để encode text thành semantic vectors.

Ví dụ:

```text
cust_name
customer_name
client_name
```

sẽ nằm gần nhau trong vector space.

---

## 3. Cosine Similarity

Đo semantic similarity giữa vectors.

Công thức:

```math
Similarity(A,B)=\frac{A\cdot B}{||A|| ||B||}
```

Output:

| Excel | DB | Similarity |
|---|---|---|
| cust_name | customer_name | 0.93 |
| tel | phone_number | 0.88 |
| dob | date_of_birth | 0.91 |

---

## 4. Hungarian Assignment

Hungarian algorithm giải bài toán:

```text
Global Optimal Bipartite Matching
```

Đảm bảo:

```text
1 Excel Column
↔
1 DB Column
```

Không dùng greedy matching.

---

## 5. Confidence Threshold

Sau khi match:

| Score | Confidence |
|---|---|
| >= 0.85 | HIGH |
| >= 0.70 | MED |
| < 0.70 | LOW |

---

## 6. Manual Review Queue

Các mapping:

- MED
- LOW

sẽ được đưa vào:

```text
needs_review
```

để human validation.

---

# Final Output Example

```python
{
    "header_mapping": {
        "Tel": "phone_number",
        "DOB": "date_of_birth"
    },

    "scores": {
        "Tel": 0.88,
        "DOB": 0.91
    },

    "confidence": {
        "Tel": "MED",
        "DOB": "HIGH"
    },

    "needs_review": [
        "Tel"
    ]
}
```

---

# AI Pipeline Summary

```text
Excel Headers
    │
Preprocessing
    │
Embedding Encoding
    │
Semantic Similarity
    │
Cost Matrix
    │
Hungarian Optimization
    │
Confidence Evaluation
    │
Human Review
    │
Final Mapping
```

---

# System Classification

Hệ thống này thuộc nhóm:

- Semantic Schema Matching
- AI-Powered Data Mapping
- Intelligent ETL
- Auto Schema Integration
- Semantic Data Harmonization
- Enterprise Data Ingestion