# === import all helpers from your module ===
from src.utility.sqlite_utils.sqlite_helpers import *  # assuming you saved it as sqlite_helpers.py

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
conn = open_connection(DB_PATH)

try:
    # === CRUD ===
    uid = insert_row(conn, "users", {"name": "Alice", "email": "alice@example.com"})
    pid = insert_row(conn, "posts", {"user_id": uid, "title": "Hello World", "content": "First post!"})
    print("Inserted user_id:", uid, "post_id:", pid)

    rows = select_rows(conn, "users", columns=["id", "name"], where_clause="id=?", where_params=(uid,))
    print("Selected user:", [dict(r) for r in rows])

    update_count = update_rows(conn, "users", {"name": "Alice Smith"}, "id=?", (uid,))
    print("Updated rows:", update_count)

    delete_count = delete_rows(conn, "posts", "id=?", (pid,))
    print("Deleted posts:", delete_count)

    # 1) Dictionary form (automatic AND)
    rows = select_rows(conn, "socket_close", where={"site": 101, "site_open": 1})

    # 2) Manual SQL form
    rows = select_rows(conn, "socket_close",
                    where=("site = ? AND close_rate > ?", (101, 0.5)))

    # 3) Updating with multiple conditions
    update_rows(conn, "socket_close",
                data={"close_rate": 0.9},
                where={"site": 101, "site_open": 1})

    # 4) Deleting with manual WHERE
    delete_rows(conn, "socket_close",
                where=("time_change < ?", ("2025-01-01T00:00:00Z",)))

    # === Schema Management ===
    print("Tables:", list_tables(conn))
    print("Users table info:", get_table_info(conn, "users"))

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

    # === Data Querying ===
    print("User count:", count_rows(conn, "users"))
    print("User exists?", exists(conn, "users", "name=?", ("Alice Smith",)))
    print("Distinct names:", select_distinct(conn, "users", "name"))
    print("Name length max:", aggregate(conn, "users", "MAX", "LENGTH(name)"))
    print("Search 'Ali':", [dict(r) for r in search(conn, "users", "name", "Ali")])

    # === Transactions & Bulk ===
    begin_transaction(conn)
    bulk_insert(conn, "users", [
        {"name": "Bob", "email": "bob@example.com"},
        {"name": "Charlie", "email": "charlie@example.com"}
    ], commit=False)
    commit_transaction(conn)
    print("Users after bulk insert:", [dict(r) for r in select_rows(conn, "users")])

    # === Safety & Utilities ===
    backup_database(DB_PATH, "demo_backup.db")
    vacuum_database(conn)
    set_foreign_keys(conn, True)
    print("PRAGMA foreign_keys:", pragma_info(conn, "foreign_keys"))

    # === Debugging ===
    print("Explain query:", explain_query(conn, "SELECT * FROM users WHERE name LIKE ?", ("%Bob%",)))
    print("Last insert ID:", get_last_insert_id(conn))

finally:
    conn.close()