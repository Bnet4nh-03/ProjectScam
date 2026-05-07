import os
import re
import sqlite3
from typing import Dict, Iterable, Sequence, Tuple, Any, Optional, List

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
    conn = sqlite3.connect(db_path)
    conn.row_factory = sqlite3.Row
    return conn

# --- Create DB if missing ---
def create_sqlite_db_if_not_exists(db_path: str, table_definitions: Sequence[str]) -> None:
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
def insert_row(conn: sqlite3.Connection, table: str, data: Dict[str, Any], *, commit=True) -> int:
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
    except:
        conn.rollback()
        raise
    finally:
        cur.close()

def _build_where_clause(where: Optional[Dict[str, Any]]):
    """
    Builds a WHERE clause string and params from a dictionary.
    Returns: (where_clause_str, params_tuple)
    """
    if not where:
        return "", ()
    _validate_identifiers(where.keys())
    clause_parts = [f"{col} = ?" for col in where.keys()]
    where_clause = " AND ".join(clause_parts)
    params = tuple(where.values())
    return where_clause, params

def select_rows(conn: sqlite3.Connection, table: str, columns=None, where=None, order_by=None, limit=None):
    """
    where can be:
        - None (no filter)
        - a dict {col: value, ...} for automatic AND conditions
        - a string (manual clause) with separate params
    """
    _validate_identifier(table)
    col_str = ", ".join(columns) if columns else "*"
    if columns:
        _validate_identifiers(columns)

    if isinstance(where, dict):
        where_clause, where_params = _build_where_clause(where)
    elif isinstance(where, tuple) and len(where) == 2:
        where_clause, where_params = where
    else:
        where_clause, where_params = "", ()

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

def update_rows(conn: sqlite3.Connection, table: str, data: Dict[str, Any], where=None, *, commit=True):
    """
    where: same flexible options as select_rows
    """
    if not data:
        raise ValueError("data must not be empty")
    _validate_identifier(table)
    _validate_identifiers(data.keys())

    set_expr = ", ".join([f"{c} = ?" for c in data.keys()])
    params = list(data.values())

    if isinstance(where, dict):
        where_clause, where_params = _build_where_clause(where)
    elif isinstance(where, tuple) and len(where) == 2:
        where_clause, where_params = where
    else:
        raise ValueError("where must be provided as dict or (clause, params)")

    sql = f"UPDATE {table} SET {set_expr} WHERE {where_clause}"
    params.extend(where_params)

    cur = conn.cursor()
    try:
        cur.execute(sql, params)
        if commit:
            conn.commit()
        return cur.rowcount
    except:
        conn.rollback()
        raise
    finally:
        cur.close()

def delete_rows(conn: sqlite3.Connection, table: str, where=None, *, commit=True):
    """
    where: same flexible options
    """
    _validate_identifier(table)
    if isinstance(where, dict):
        where_clause, where_params = _build_where_clause(where)
    elif isinstance(where, tuple) and len(where) == 2:
        where_clause, where_params = where
    else:
        raise ValueError("where must be provided as dict or (clause, params)")

    sql = f"DELETE FROM {table} WHERE {where_clause}"

    cur = conn.cursor()
    try:
        cur.execute(sql, where_params)
        if commit:
            conn.commit()
        return cur.rowcount
    except:
        conn.rollback()
        raise
    finally:
        cur.close()

# --- Schema Management ---
def list_tables(conn: sqlite3.Connection) -> List[str]:
    return [row[0] for row in conn.execute("SELECT name FROM sqlite_master WHERE type='table'")]

def get_table_info(conn: sqlite3.Connection, table: str):
    _validate_identifier(table)
    return conn.execute(f"PRAGMA table_info({table})").fetchall()

def execute_script(conn: sqlite3.Connection, script: str, *, commit=True):
    try:
        conn.executescript(script)
        if commit:
            conn.commit()
    except:
        conn.rollback()
        raise

def drop_table(conn: sqlite3.Connection, table: str, *, commit=True):
    _validate_identifier(table)
    conn.execute(f"DROP TABLE IF EXISTS {table}")
    if commit:
        conn.commit()

def rename_table(conn: sqlite3.Connection, old_name: str, new_name: str, *, commit=True):
    _validate_identifier(old_name)
    _validate_identifier(new_name)
    conn.execute(f"ALTER TABLE {old_name} RENAME TO {new_name}")
    if commit:
        conn.commit()

def add_column(conn: sqlite3.Connection, table: str, column_def: str, *, commit=True):
    _validate_identifier(table)
    conn.execute(f"ALTER TABLE {table} ADD COLUMN {column_def}")
    if commit:
        conn.commit()

# --- Data Querying ---
def count_rows(conn: sqlite3.Connection, table: str, where_clause=None, where_params=()):
    _validate_identifier(table)
    sql = f"SELECT COUNT(*) FROM {table}"
    if where_clause:
        sql += f" WHERE {where_clause}"
    return conn.execute(sql, where_params).fetchone()[0]

def exists(conn: sqlite3.Connection, table: str, where_clause: str, where_params=()):
    return count_rows(conn, table, where_clause, where_params) > 0

def select_distinct(conn: sqlite3.Connection, table: str, column: str):
    _validate_identifier(table)
    _validate_identifier(column)
    return [row[0] for row in conn.execute(f"SELECT DISTINCT {column} FROM {table}")]

def aggregate(conn: sqlite3.Connection, table: str, function: str, column: str, where_clause=None, where_params=()):
    _validate_identifier(table)
    _validate_identifier(column)
    sql = f"SELECT {function}({column}) FROM {table}"
    if where_clause:
        sql += f" WHERE {where_clause}"
    return conn.execute(sql, where_params).fetchone()[0]

def search(conn: sqlite3.Connection, table: str, column: str, keyword: str):
    _validate_identifier(table)
    _validate_identifier(column)
    return conn.execute(
        f"SELECT * FROM {table} WHERE {column} LIKE ?", (f"%{keyword}%",)
    ).fetchall()

# --- Transactions & Bulk ---
def begin_transaction(conn: sqlite3.Connection): conn.execute("BEGIN")
def commit_transaction(conn: sqlite3.Connection): conn.commit()
def rollback_transaction(conn: sqlite3.Connection): conn.rollback()

def bulk_insert(conn: sqlite3.Connection, table: str, list_of_dicts: List[Dict[str, Any]], *, commit=True):
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
def backup_database(source_db_path: str, backup_path: str):
    import shutil
    shutil.copy2(source_db_path, backup_path)

def vacuum_database(conn: sqlite3.Connection): conn.execute("VACUUM")

def set_foreign_keys(conn: sqlite3.Connection, on=True): conn.execute(f"PRAGMA foreign_keys = {'ON' if on else 'OFF'}")

def pragma_info(conn: sqlite3.Connection, name: str): return conn.execute(f"PRAGMA {name}").fetchall()

# --- Debugging ---
def explain_query(conn: sqlite3.Connection, sql: str, params=()):
    return conn.execute(f"EXPLAIN QUERY PLAN {sql}", params).fetchall()

def get_last_insert_id(conn: sqlite3.Connection):
    return conn.execute("SELECT last_insert_rowid()").fetchone()[0]