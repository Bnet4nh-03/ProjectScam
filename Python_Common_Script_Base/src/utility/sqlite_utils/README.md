**Composing the final README.md**

I’ll make sure the module code is included as-is with larger code blocks. I'll also ensure the function return types are indicated and keep the example usage script in line with earlier versions. A few details to highlight: `select_distinct` currently returns all column values, and `pragma_info` returns rows. I’ll also mention that `vacuum_database` can’t run inside a transaction, plus the open connection setting for `Row` with `pragma_info`. Let’s get this all together!
# SQLite Helper for Python

A small, dependency‑free utility that wraps common SQLite operations with a clean, safe API. It covers database creation, schema management, CRUD, selects with filters, transactions, batch operations, diagnostics, and utilities like backups and vacuum.

---

## Features

- Safe CRUD: insert, select, update, delete with bound parameters
- Flexible selects: columns, where, order, limit
- Schema management: list, inspect, create, drop, rename, add column
- Query helpers: count, exists, distinct, aggregates, search
- Transactions: begin, commit, rollback; bulk insert
- Diagnostics: explain query plan, last insert id
- Utilities: backup file, vacuum, PRAGMA toggles
- Identifier validation to prevent injection via table/column names

---

## Requirements

- Python 3.8+ (uses the standard library only)
- SQLite (bundled with Python via sqlite3)

---

## Installation

This is a drop‑in helper. Save the module below as sqlite_helpers.py in your project.

---

## Quick start

```python
from sqlite_helpers import *

DB_PATH = "quickstart.db"

# 1) Define schema and create DB on first run
tables = [
    """
    CREATE TABLE IF NOT EXISTS users (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        email TEXT UNIQUE NOT NULL
    )
    """
]
create_sqlite_db_if_not_exists(DB_PATH, tables)

# 2) Connect
conn = open_connection(DB_PATH)

try:
    # 3) INSERT
    user_id = insert_row(conn, "users", {"name": "Auto", "email": "auto@example.com"})
    print("Inserted user_id:", user_id)

    # 4) SELECT
    rows = select_rows(conn, "users", columns=["id", "name"], where_clause="id = ?", where_params=(user_id,))
    print([dict(r) for r in rows])

    # 5) UPDATE
    update_rows(conn, "users", {"name": "Auto Updated"}, "id = ?", (user_id,))

    # 6) DELETE
    delete_rows(conn, "users", "id = ?", (user_id,))

finally:
    conn.close()
```

---

## Module: sqlite_helpers.py

```python
import os
import re
import sqlite3
from typing import Dict, Iterable, Sequence, Any, Optional, List

# --- Internal validation ---
_IDENTIFIER_RE = re.compile(r"^[A-Za-z_][A-Za-z0-9_]*$")

def _validate_identifier(name: str) -> None:
    if not _IDENTIFIER_RE.match(name):
        raise ValueError(f"Invalid identifier: {name!r}")

def _validate_identifiers(names: Iterable[str]) -> None:
    for n in names:
        _validate_identifier(n)

# --- Connection ---
def open_connection(db_path: str) -> sqlite3.Connection:
    """
    Open a connection with Row factory so you can access columns by name.
    """
    conn = sqlite3.connect(db_path)
    conn.row_factory = sqlite3.Row
    return conn

# --- Create DB if missing ---
def create_sqlite_db_if_not_exists(db_path: str, table_definitions: Sequence[str]) -> None:
    """
    Creates the database file if missing and executes the given CREATE TABLE statements.
    """
    if os.path.exists(db_path):
        return
    conn = open_connection(db_path)
    try:
        with conn:
            for ddl in table_definitions:
                conn.execute(ddl)
    finally:
        conn.close()

# --- CRUD ---
def insert_row(conn: sqlite3.Connection, table: str, data: Dict[str, Any], *, commit: bool = True) -> int:
    """
    Insert one row and return the new row id.
    """
    if not data:
        raise ValueError("data must not be empty")
    _validate_identifier(table)
    _validate_identifiers(data.keys())

    cols = list(data.keys())
    sql = f"INSERT INTO {table} ({', '.join(cols)}) VALUES ({', '.join(['?']*len(cols))})"
    cur = conn.cursor()
    try:
        cur.execute(sql, [data[c] for c in cols])
        if commit:
            conn.commit()
        return cur.lastrowid
    except Exception:
        conn.rollback()
        raise
    finally:
        cur.close()

def select_rows(
    conn: sqlite3.Connection,
    table: str,
    columns: Optional[Sequence[str]] = None,
    where_clause: Optional[str] = None,
    where_params: Sequence[Any] = (),
    order_by: Optional[str] = None,
    limit: Optional[int] = None
) -> List[sqlite3.Row]:
    """
    Select rows and return a list of sqlite3.Row (dict-like).
    """
    _validate_identifier(table)
    col_str = "*"
    if columns:
        _validate_identifiers(columns)
        col_str = ", ".join(columns)

    sql = f"SELECT {col_str} FROM {table}"
    if where_clause:
        sql += f" WHERE {where_clause}"
    if order_by:
        sql += f" ORDER BY {order_by}"
    if limit is not None:
        sql += f" LIMIT {limit}"

    cur = conn.cursor()
    try:
        cur.execute(sql, where_params)
        return cur.fetchall()
    finally:
        cur.close()

def update_rows(
    conn: sqlite3.Connection,
    table: str,
    data: Dict[str, Any],
    where_clause: str,
    where_params: Sequence[Any] = (),
    *,
    commit: bool = True
) -> int:
    """
    Update rows matching where_clause and return affected row count.
    """
    if not data:
        raise ValueError("data must not be empty")
    if not where_clause.strip():
        raise ValueError("where_clause must not be empty")

    _validate_identifier(table)
    _validate_identifiers(data.keys())

    set_expr = ", ".join([f"{c} = ?" for c in data.keys()])
    sql = f"UPDATE {table} SET {set_expr} WHERE {where_clause}"
    params = list(data.values()) + list(where_params)

    cur = conn.cursor()
    try:
        cur.execute(sql, params)
        if commit:
            conn.commit()
        return cur.rowcount
    except Exception:
        conn.rollback()
        raise
    finally:
        cur.close()

def delete_rows(
    conn: sqlite3.Connection,
    table: str,
    where_clause: str,
    where_params: Sequence[Any] = (),
    *,
    commit: bool = True
) -> int:
    """
    Delete rows matching where_clause and return affected row count.
    """
    if not where_clause.strip():
        raise ValueError("where_clause must not be empty")

    _validate_identifier(table)
    sql = f"DELETE FROM {table} WHERE {where_clause}"

    cur = conn.cursor()
    try:
        cur.execute(sql, where_params)
        if commit:
            conn.commit()
        return cur.rowcount
    except Exception:
        conn.rollback()
        raise
    finally:
        cur.close()

# --- Schema Management ---
def list_tables(conn: sqlite3.Connection) -> List[str]:
    """
    Return names of all tables in the database.
    """
    return [row[0] for row in conn.execute("SELECT name FROM sqlite_master WHERE type='table'")]

def get_table_info(conn: sqlite3.Connection, table: str) -> List[sqlite3.Row]:
    """
    Return PRAGMA table_info for a table (cid, name, type, notnull, dflt_value, pk).
    """
    _validate_identifier(table)
    return conn.execute(f"PRAGMA table_info({table})").fetchall()

def execute_script(conn: sqlite3.Connection, script: str, *, commit: bool = True) -> None:
    """
    Execute multiple SQL statements at once (e.g., from a .sql file).
    """
    try:
        conn.executescript(script)
        if commit:
            conn.commit()
    except Exception:
        conn.rollback()
        raise

def drop_table(conn: sqlite3.Connection, table: str, *, commit: bool = True) -> None:
    """
    Drop a table if it exists.
    """
    _validate_identifier(table)
    conn.execute(f"DROP TABLE IF EXISTS {table}")
    if commit:
        conn.commit()

def rename_table(conn: sqlite3.Connection, old_name: str, new_name: str, *, commit: bool = True) -> None:
    """
    Rename a table.
    """
    _validate_identifier(old_name)
    _validate_identifier(new_name)
    conn.execute(f"ALTER TABLE {old_name} RENAME TO {new_name}")
    if commit:
        conn.commit()

def add_column(conn: sqlite3.Connection, table: str, column_def: str, *, commit: bool = True) -> None:
    """
    Add a new column to a table. column_def is raw SQL like: 'age INTEGER DEFAULT 0'.
    """
    _validate_identifier(table)
    conn.execute(f"ALTER TABLE {table} ADD COLUMN {column_def}")
    if commit:
        conn.commit()

# --- Data Querying ---
def count_rows(conn: sqlite3.Connection, table: str, where_clause: Optional[str] = None, where_params: Sequence[Any] = ()) -> int:
    """
    Return the number of rows in a table, optionally filtered.
    """
    _validate_identifier(table)
    sql = f"SELECT COUNT(*) FROM {table}"
    if where_clause:
        sql += f" WHERE {where_clause}"
    return conn.execute(sql, where_params).fetchone()[0]

def exists(conn: sqlite3.Connection, table: str, where_clause: str, where_params: Sequence[Any] = ()) -> bool:
    """
    Return True if any row matches the filter.
    """
    return count_rows(conn, table, where_clause, where_params) > 0

def select_distinct(conn: sqlite3.Connection, table: str, column: str) -> List[Any]:
    """
    Return distinct values from a single column.
    """
    _validate_identifier(table)
    _validate_identifier(column)
    return [row[0] for row in conn.execute(f"SELECT DISTINCT {column} FROM {table}")]

def aggregate(
    conn: sqlite3.Connection,
    table: str,
    function: str,
    column: str,
    where_clause: Optional[str] = None,
    where_params: Sequence[Any] = ()
) -> Any:
    """
    Run an aggregate function like SUM, AVG, MIN, MAX on a column.
    """
    _validate_identifier(table)
    _validate_identifier(column)
    sql = f"SELECT {function}({column}) FROM {table}"
    if where_clause:
        sql += f" WHERE {where_clause}"
    return conn.execute(sql, where_params).fetchone()[0]

def search(conn: sqlite3.Connection, table: str, column: str, keyword: str) -> List[sqlite3.Row]:
    """
    Case-insensitive search using LIKE on one column.
    """
    _validate_identifier(table)
    _validate_identifier(column)
    return conn.execute(
        f"SELECT * FROM {table} WHERE {column} LIKE ?", (f"%{keyword}%",)
    ).fetchall()

# --- Transactions & Bulk ---
def begin_transaction(conn: sqlite3.Connection) -> None:
    conn.execute("BEGIN")

def commit_transaction(conn: sqlite3.Connection) -> None:
    conn.commit()

def rollback_transaction(conn: sqlite3.Connection) -> None:
    conn.rollback()

def bulk_insert(conn: sqlite3.Connection, table: str, list_of_dicts: List[Dict[str, Any]], *, commit: bool = True) -> None:
    """
    Insert many rows efficiently. All dicts must share the same keys.
    """
    if not list_of_dicts:
        return
    _validate_identifier(table)
    _validate_identifiers(list_of_dicts[0].keys())
    cols = list(list_of_dicts[0].keys())
    sql = f"INSERT INTO {table} ({', '.join(cols)}) VALUES ({', '.join(['?']*len(cols))})"
    params = [tuple(d[c] for c in cols) for d in list_of_dicts]
    conn.executemany(sql, params)
    if commit:
        conn.commit()

# --- Safety & Utilities ---
def backup_database(source_db_path: str, backup_path: str) -> None:
    """
    Copy the database file to a backup path (uses shutil.copy2).
    """
    import shutil
    shutil.copy2(source_db_path, backup_path)

def vacuum_database(conn: sqlite3.Connection) -> None:
    """
    Reclaims space and defragments the DB file. Avoid calling inside a transaction.
    """
    conn.execute("VACUUM")

def set_foreign_keys(conn: sqlite3.Connection, on: bool = True) -> None:
    """
    Enable/disable enforcement of foreign key constraints for the connection.
    """
    conn.execute(f"PRAGMA foreign_keys = {'ON' if on else 'OFF'}")

def pragma_info(conn: sqlite3.Connection, name: str) -> List[sqlite3.Row]:
    """
    Read PRAGMA info, e.g., pragma_info(conn, 'foreign_keys').
    """
    return conn.execute(f"PRAGMA {name}").fetchall()

# --- Debugging ---
def explain_query(conn: sqlite3.Connection, sql: str, params: Sequence[Any] = ()) -> List[sqlite3.Row]:
    """
    Return the execution plan for a SELECT.
    """
    return conn.execute(f"EXPLAIN QUERY PLAN {sql}", params).fetchall()

def get_last_insert_id(conn: sqlite3.Connection) -> int:
    """
    Return last inserted row id for the current connection.
    """
    return conn.execute("SELECT last_insert_rowid()").fetchone()[0]
```

---

## Full demonstration script

This script exercises all functions in a realistic flow. Save it as demo.py and run it after saving sqlite_helpers.py.

```python
from sqlite_helpers import *

DB_PATH = "demo.db"

# 1) Define schema and create DB
tables = [
    """
    CREATE TABLE IF NOT EXISTS users (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        email TEXT UNIQUE NOT NULL
    )
    """,
    """
    CREATE TABLE IF NOT EXISTS posts (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        user_id INTEGER NOT NULL,
        title TEXT NOT NULL,
        content TEXT,
        FOREIGN KEY(user_id) REFERENCES users(id)
    )
    """
]
create_sqlite_db_if_not_exists(DB_PATH, tables)

# 2) Connect
conn = open_connection(DB_PATH)

try:
    # --- CRUD ---
    uid = insert_row(conn, "users", {"name": "Alice", "email": "alice@example.com"})
    pid = insert_row(conn, "posts", {"user_id": uid, "title": "Hello World", "content": "First post!"})
    print("Inserted user_id:", uid, "post_id:", pid)

    selected = select_rows(conn, "users", columns=["id", "name"], where_clause="id=?", where_params=(uid,))
    print("Selected user:", [dict(r) for r in selected])

    updated = update_rows(conn, "users", {"name": "Alice Smith"}, "id=?", (uid,))
    print("Updated rows:", updated)

    deleted = delete_rows(conn, "posts", "id=?", (pid,))
    print("Deleted posts:", deleted)

    # --- Schema management ---
    print("Tables:", list_tables(conn))
    print("Users table info:", [dict(r) for r in get_table_info(conn, "users")])

    execute_script(conn, """
    CREATE TABLE IF NOT EXISTS comments (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        post_id INTEGER,
        content TEXT
    );
    """)
    print("Tables after adding comments:", list_tables(conn))

    add_column(conn, "comments", "author TEXT")
    rename_table(conn, "comments", "blog_comments")
    drop_table(conn, "blog_comments")
    print("Tables after rename + drop:", list_tables(conn))

    # --- Data querying ---
    print("User count:", count_rows(conn, "users"))
    print("User exists? name='Alice Smith':", exists(conn, "users", "name=?", ("Alice Smith",)))
    print("Distinct names:", select_distinct(conn, "users", "name"))
    print("Max name length:", aggregate(conn, "users", "MAX", "LENGTH(name)"))
    print("Search 'Ali':", [dict(r) for r in search(conn, "users", "name", "Ali")])

    # --- Transactions & bulk ---
    begin_transaction(conn)
    bulk_insert(conn, "users", [
        {"name": "Bob", "email": "bob@example.com"},
        {"name": "Charlie", "email": "charlie@example.com"},
    ], commit=False)
    commit_transaction(conn)
    print("Users after bulk insert:", [dict(r) for r in select_rows(conn, "users")])

    # --- Safety & utilities ---
    backup_database(DB_PATH, "demo_backup.db")
    vacuum_database(conn)
    set_foreign_keys(conn, True)
    print("PRAGMA foreign_keys:", [tuple(r) for r in pragma_info(conn, "foreign_keys")])

    # --- Debugging ---
    print("Explain LIKE query:", [tuple(r) for r in explain_query(conn, "SELECT * FROM users WHERE name LIKE ?", ("%Bob%",))])
    print("Last insert ID:", get_last_insert_id(conn))

finally:
    conn.close()
```

---

## API reference

| Function | Purpose |
|---|---|
| open_connection(db_path) | Open a connection with row_factory=Row for dict-like rows |
| create_sqlite_db_if_not_exists(db_path, table_definitions) | Create DB and run CREATE TABLE statements if missing |
| insert_row(conn, table, data, commit=True) | Insert a row dict and return last row id |
| select_rows(conn, table, columns=None, where_clause=None, where_params=(), order_by=None, limit=None) | Flexible SELECT |
| update_rows(conn, table, data, where_clause, where_params=(), commit=True) | Update rows and return affected count |
| delete_rows(conn, table, where_clause, where_params=(), commit=True) | Delete rows and return affected count |
| list_tables(conn) | List all table names |
| get_table_info(conn, table) | PRAGMA table_info for a table |
| execute_script(conn, script, commit=True) | Execute multiple SQL statements |
| drop_table(conn, table, commit=True) | DROP TABLE IF EXISTS |
| rename_table(conn, old_name, new_name, commit=True) | Rename a table |
| add_column(conn, table, column_def, commit=True) | ALTER TABLE ADD COLUMN |
| count_rows(conn, table, where_clause=None, where_params=()) | Count rows with optional filter |
| exists(conn, table, where_clause, where_params=()) | Boolean existence check |
| select_distinct(conn, table, column) | Distinct values of a column |
| aggregate(conn, table, function, column, where_clause=None, where_params=()) | Aggregates like SUM, AVG, MIN, MAX |
| search(conn, table, column, keyword) | LIKE search on a column |
| begin_transaction(conn) | Begin a transaction |
| commit_transaction(conn) | Commit current transaction |
| rollback_transaction(conn) | Roll back current transaction |
| bulk_insert(conn, table, list_of_dicts, commit=True) | Batch insert many rows |
| backup_database(source_db_path, backup_path) | Copy DB file to backup |
| vacuum_database(conn) | Reclaim space, compact DB |
| set_foreign_keys(conn, on=True) | Toggle foreign key enforcement |
| pragma_info(conn, name) | Read PRAGMA info |
| explain_query(conn, sql, params=()) | Query plan via EXPLAIN QUERY PLAN |
| get_last_insert_id(conn) | Last inserted row id for the connection |

---

## Notes and tips

- Safety
  - Identifiers (table/column) are validated against a strict regex. Values are always bound with placeholders (?), preventing injection.
  - Keep where_clause strings static and pass dynamic values via where_params.

- Transactions
  - For multiple writes, set commit=False on helpers and wrap with begin_transaction/commit_transaction for atomic batches.
  - Use rollback_transaction on error to revert partial changes.

- Foreign keys
  - SQLite requires PRAGMA foreign_keys = ON per connection to enforce constraints. Call set_foreign_keys(conn, True) after connecting.

- Performance
  - Use bulk_insert for large loads.
  - Create indexes for frequent filters and joins (via execute_script with CREATE INDEX statements).
  - VACUUM occasionally to compact the file after large deletions.

- Backups
  - backup_database performs a file copy. For online backups while writing, consider locking or using SQLite’s backup API (advanced).

---

If you want this packaged as a class (SQLiteHelper) so you don’t pass the connection around, say the word and I’ll refactor it neatly.
