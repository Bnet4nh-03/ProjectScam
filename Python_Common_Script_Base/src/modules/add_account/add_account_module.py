import os
import tkinter as tk
from tkinter import filedialog, messagebox, scrolledtext

import pandas as pd
import requests

from src.apps.module_base import ModuleBase

DEFAULT_PASSWORD_HASH = "$2a$11$KfwME1tVFsF4eJRRyW1XneX3awhQrZQ5KJtlZdammhS4/bVJstfLu"
DEFAULT_USER_ROLE = "User"
DEFAULT_USER_CONFIG = "T_FB_PSP_C2DID"
DEFAULT_LOGIN_METHOD = "Local"
DEFAULT_SITE_LOGIN = ""
DEFAULT_ONFLAG = 1
PASSWORD_HASH_ENDPOINT = "http://10.201.12.31:8004/Common/BCrypt_Hash"


class AddAccountModule(ModuleBase):
    def __init__(self, app):
        super().__init__(app)
        self.frame = None
        self.file_path = ""
        self.file_label = None
        self.output_box = None
        self.user_group_var = tk.StringVar()
        self.user_config_var = tk.StringVar(value=DEFAULT_USER_CONFIG)
        self.password_cache = {}
        self.requests_session = requests.Session()

    def name(self):
        return "Add Account"

    def build(self, parent):
        self.frame = tk.Frame(parent, bg="#f4f6f8")
        self.frame.pack(fill="both", expand=True)

        top_frame = tk.Frame(self.frame, bg="#f4f6f8")
        top_frame.pack(fill="x", padx=10, pady=10)

        tk.Button(top_frame, text="Chọn file Excel", width=16, command=self.choose_file).pack(side="left")
        self.file_label = tk.Label(top_frame, text="Chưa chọn file", bg="#f4f6f8", anchor="w")
        self.file_label.pack(side="left", padx=12, fill="x", expand=True)

        config_frame = tk.LabelFrame(self.frame, text="Nhập tham số", bg="#f4f6f8", fg="#333333", padx=10, pady=10)
        config_frame.pack(fill="x", padx=10, pady=6)

        tk.Label(config_frame, text="User group:", bg="#f4f6f8", width=12, anchor="w").grid(row=0, column=0, sticky="w")
        tk.Entry(config_frame, textvariable=self.user_group_var, width=54).grid(row=0, column=1, sticky="w")

        tk.Label(config_frame, text="User config:", bg="#f4f6f8", width=12, anchor="w").grid(row=1, column=0, sticky="w", pady=8)
        tk.Entry(config_frame, textvariable=self.user_config_var, width=54).grid(row=1, column=1, sticky="w", pady=8)

        action_frame = tk.Frame(self.frame, bg="#f4f6f8")
        action_frame.pack(fill="x", padx=10, pady=4)

        tk.Button(action_frame, text="Tạo SQL", width=14, command=self.generate_query).pack(side="left")
        tk.Button(action_frame, text="Sao chép", width=14, command=self.copy_output).pack(side="right")
        tk.Button(action_frame, text="XÓA OUTPUT", width=14, command=self.clear_output).pack(side="right", padx=(0, 8))

        self.output_box = scrolledtext.ScrolledText(self.frame, height=18, wrap="word")
        self.output_box.pack(fill="both", padx=10, pady=6, expand=True)

    def choose_file(self):
        path = filedialog.askopenfilename(
            title="Chọn file Excel hoặc CSV",
            filetypes=[("Excel files", "*.xlsx *.xlsm *.xltx *.xltm *.csv")],
        )
        if path:
            self.file_path = path
            self.file_label.config(text=path)

    def clear_output(self):
        if self.output_box:
            self.output_box.delete("1.0", tk.END)

    def copy_output(self):
        if not self.output_box:
            return
        sql_text = self.output_box.get("1.0", tk.END).strip()
        if not sql_text:
            messagebox.showinfo("Thông báo", "Không có nội dung để sao chép.")
            return
        try:
            self.app.root.clipboard_clear()
            self.app.root.clipboard_append(sql_text)
            messagebox.showinfo("Thông báo", "Đã sao chép SQL vào clipboard.")
        except Exception as exc:
            messagebox.showerror("Lỗi", f"Không thể sao chép nội dung: {exc}")

    def generate_query(self):
        if not self.file_path:
            messagebox.showerror("Lỗi", "Vui lòng chọn file Excel hoặc CSV.")
            return

        user_group = self.user_group_var.get().strip()
        if not user_group:
            messagebox.showerror("Lỗi", "Vui lòng nhập user_group.")
            return

        user_config = self.user_config_var.get().strip() or DEFAULT_USER_CONFIG

        try:
            rows = self._read_input_rows(self.file_path)
            if not rows:
                raise ValueError("Không tìm thấy dữ liệu hợp lệ trong file.")

            sql = self._build_insert_query(rows, user_group, user_config)
            self.output_box.delete("1.0", tk.END)
            self.output_box.insert(tk.END, sql)
        except Exception as exc:
            messagebox.showerror("Lỗi", f"Không thể tạo SQL: {exc}")

    def _read_input_rows(self, file_path):
        _, ext = os.path.splitext(file_path)
        ext = ext.lower()

        if ext == ".csv":
            df = pd.read_csv(file_path, header=None, dtype=str, keep_default_na=False)
        else:
            df = pd.read_excel(file_path, header=None, dtype=str)

        if df.empty:
            raise ValueError("File không có dữ liệu.")

        if self._looks_like_header(df.iloc[0].tolist()):
            df = df.iloc[1:].reset_index(drop=True)

        rows = []
        for _, row in df.iterrows():
            badgeno = self._normalize_cell(row.iloc[0] if len(row) > 0 else "")
            user_id = self._normalize_cell(row.iloc[1] if len(row) > 1 else "")
            username = self._normalize_cell(row.iloc[2] if len(row) > 2 else "")
            user_title = self._normalize_cell(row.iloc[3] if len(row) > 3 else "")

            if not badgeno and not user_id:
                continue

            rows.append({
                "badgeno": badgeno,
                "user_id": user_id,
                "username": username,
                "user_title": user_title,
            })

        return rows

    def _looks_like_header(self, row_values):
        headers = [self._normalize_cell(value).lower() for value in row_values]
        known_headers = {
            "badgeno",
            "badge",
            "badge_no",
            "badge no",
            "user_id",
            "userid",
            "username",
            "user name",
            "name",
            "user_title",
            "title",
            "role",
        }
        return any(header in known_headers for header in headers if header)

    @staticmethod
    def _normalize_cell(value):
        if value is None:
            return ""
        if isinstance(value, float) and pd.isna(value):
            return ""
        return str(value).strip()

    @staticmethod
    def _quote_sql(value):
        if value is None:
            return "''"
        text_value = str(value)
        text_value = text_value.replace("'", "''")
        return f"'{text_value}'"

    def _fetch_password_hash(self, text):
        normalized = str(text).strip()
        if not normalized:
            return DEFAULT_PASSWORD_HASH

        if normalized in self.password_cache:
            return self.password_cache[normalized]

        try:
            response = self.requests_session.get(PASSWORD_HASH_ENDPOINT, params={"text": normalized}, timeout=10)
            if response.status_code == 200:
                password_hash = response.text.strip()
                if password_hash:
                    self.password_cache[normalized] = password_hash
                    return password_hash
        except Exception:
            pass

        return DEFAULT_PASSWORD_HASH

    def _build_insert_query(self, rows, user_group, user_config):
        header = (
            "INSERT INTO [ATV_Common].[dbo].[Common_API_User]\n"
            "  ([badgeno], [user_id], [username], [password], [user_title], [user_role], [user_group], "
            "[email], [user_config], [login_method], [site_login], [onflag], [created_at], [updated_at])\n"
            "VALUES\n"
        )

        value_lines = []
        for row in rows:
            password_hash = self._fetch_password_hash(row["user_id"])
            values = [
                self._quote_sql(row["badgeno"]),
                self._quote_sql(row["user_id"]),
                self._quote_sql(row["username"]),
                self._quote_sql(password_hash),
                self._quote_sql(row["user_title"]),
                self._quote_sql(DEFAULT_USER_ROLE),
                self._quote_sql(user_group),
                "''",
                self._quote_sql(user_config),
                self._quote_sql(DEFAULT_LOGIN_METHOD),
                self._quote_sql(DEFAULT_SITE_LOGIN),
                str(DEFAULT_ONFLAG),
                "getdate()",
                "getdate()",
            ]
            value_lines.append(f"  ({', '.join(values)})")

        sql = header + ",\n".join(value_lines) + ";\n"
        return sql

    def run_module(self, file_path, table_name, key_columns):
        # This module is driven by its own UI buttons.
        self.generate_query()
