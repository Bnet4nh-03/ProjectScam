import os
import tkinter as tk
from tkinter import filedialog, messagebox, scrolledtext
import tkinter.ttk as ttk
import json
import openpyxl

from src.apps.module_base import ModuleBase
from src.modules.updateData.map_excel_to_db import ExcelDBMapper
from src.modules.updateData.excel_update_processor import ExcelUpdateProcessor



class MappingModule(ModuleBase):
    def __init__(self, app):
        super().__init__(app)
        self.frame = None
        self.mapping_entries = {}
        self.file_path = ""
        self.db_columns = []
        self.excel_info = {}
        self.table_name_var = tk.StringVar(value=self.app.config["EXCEL_UPDATE"].get("table_name", ""))
        self.key_columns_var = tk.StringVar(value=",".join(self.app.config["EXCEL_UPDATE"].get("key_columns", [])))

    def name(self):
        return "Update Data"

    def build(self, parent):
        self.frame = tk.Frame(parent, bg="#f4f6f8")
        self.frame.pack(fill="both", expand=True)

        top_frame = tk.Frame(self.frame, bg="#f4f6f8")
        top_frame.pack(fill="x", padx=10, pady=10)

        tk.Button(top_frame, text="Chọn Excel", width=14, command=self.choose_file).pack(side="left")
        self.lbl_file = tk.Label(top_frame, text="Chưa chọn file", bg="#f4f6f8", anchor="w")
        self.lbl_file.pack(side="left", padx=10, fill="x", expand=True)
        tk.Button(top_frame, text="MAPPING", width=14, command=self.run).pack(side="right")

        config_frame = tk.LabelFrame(self.frame, text="Cấu hình", bg="#f4f6f8", fg="#333333", padx=10, pady=10)
        config_frame.pack(fill="x", padx=10, pady=6)

        tk.Label(config_frame, text="Table name:", bg="#f4f6f8", width=12, anchor="w").grid(row=0, column=0, sticky="w")
        tk.Entry(config_frame, textvariable=self.table_name_var, width=46).grid(row=0, column=1, sticky="w")

        tk.Label(config_frame, text="Key columns:", bg="#f4f6f8", width=12, anchor="w").grid(row=1, column=0, sticky="w", pady=8)
        tk.Entry(config_frame, textvariable=self.key_columns_var, width=46).grid(row=1, column=1, sticky="w", pady=8)

        tk.Label(config_frame, text="Nhập nhiều khóa bằng dấu phẩy", fg="#555555", bg="#f4f6f8").grid(row=2, column=0, columnspan=2, sticky="w")

        self.mapping_container = tk.LabelFrame(self.frame, text="Mapping Editor", bg="#f4f6f8", fg="#333333", padx=8, pady=8)
        self.mapping_container.pack(fill="both", padx=10, pady=6, expand=True)

        action_frame = tk.Frame(self.frame, bg="#f4f6f8")
        action_frame.pack(fill="x", padx=10, pady=4)
        tk.Button(action_frame, text="SUBMIT", width=14, command=self.submit).pack(side="left")
        tk.Button(action_frame, text="XÓA LOG", width=14, command=self.clear_log).pack(side="right")

        self.info_box = scrolledtext.ScrolledText(self.frame, height=10, wrap="word")
        self.info_box.pack(fill="both", padx=10, pady=6, expand=True)

    def _log(self, msg):
        if self.info_box:
            self.info_box.insert(tk.END, msg + "\n")
            self.info_box.see(tk.END)

    def choose_file(self):
        path = filedialog.askopenfilename(title="Chọn file Excel", filetypes=[("Excel files", "*.xlsx *.xlsm *.xltx *.xltm")])
        if path:
            if isinstance(path, (list, tuple)):
                path = path[0]
            self.file_path = path
            # keep app-level file_path in sync for older code paths
            try:
                self.app.file_path = path
            except Exception:
                pass
            self.lbl_file.config(text=path)
            self._log(f"Chọn file: {path}")

    def clear_log(self):
        if self.info_box:
            self.info_box.delete('1.0', tk.END)

    def run(self):
        if not self.file_path:
            messagebox.showerror("Lỗi", "Vui lòng chọn file Excel")
            return

        table_name = self.table_name_var.get().strip()
        key_columns = [item.strip() for item in self.key_columns_var.get().split(",") if item.strip()]
        if not table_name or not key_columns:
            messagebox.showerror("Lỗi", "Vui lòng nhập table_name và key_columns")
            return

        self.app.config["EXCEL_UPDATE"]["table_name"] = table_name
        self.app.config["EXCEL_UPDATE"]["key_columns"] = key_columns

        self.run_module(self.file_path, table_name, key_columns)

    def show_mapping_editor(self, mapping, key_columns, scores):
        for widget in self.mapping_container.winfo_children():
            widget.destroy()

        self.mapping_entries = {}
        if not mapping:
            tk.Label(self.mapping_container, text="Không tìm thấy tiêu đề để mapping.", bg="#f4f6f8").pack(anchor="w")
            return

        tk.Label(self.mapping_container, text="Excel Header", bg="#f4f6f8", font=(None, 10, "bold")).grid(row=0, column=0, sticky="w", padx=4, pady=4)
        tk.Label(self.mapping_container, text="DB Column", bg="#f4f6f8", font=(None, 10, "bold")).grid(row=0, column=1, sticky="w", padx=4, pady=4)

        self.db_columns = self.db_columns or []
        db_options = [""] + self.db_columns
        sorted_items = sorted(mapping.items(), key=lambda item: (item[0] not in key_columns, item[0].lower()))
        for row, (excel_col, db_col) in enumerate(sorted_items, start=1):
            score = scores.get(excel_col, 0.0)

            tk.Label(self.mapping_container, text=excel_col, bg="#f4f6f8", anchor="w").grid(row=row, column=0, sticky="w", padx=4, pady=2)
            combobox = ttk.Combobox(self.mapping_container, values=db_options, width=42, state="readonly")
            combobox.set(db_col or "")
            combobox.grid(row=row, column=1, sticky="w", padx=4, pady=2)

            if score < 0.85 and db_col:
                combobox.config(background="#fff3cd")

            self.mapping_entries[excel_col] = combobox

    def _build_review_headers(self, final_mapping):
        seen = set()
        headers = []
        for excel_col, entry in self.mapping_entries.items():
            db_col = final_mapping.get(excel_col, "").strip()
            if not db_col:
                continue

            if db_col.lower() == "no":
                continue

            if db_col not in seen:
                seen.add(db_col)
                headers.append(db_col)
        return headers

    def _load_review_rows(self, final_mapping, review_headers):
        if not self.file_path:
            return []

        workbook = openpyxl.load_workbook(self.file_path)
        worksheet = workbook.active

        normalized_mapping = {
            str(excel_header).strip().lower(): str(db_col).strip()
            for excel_header, db_col in final_mapping.items()
            if str(db_col).strip()
        }

        header_to_index = {}
        for col_idx, cell in enumerate(worksheet[1], start=1):
            header = str(cell.value).strip() if cell.value else ""
            normalized_header = header.lower()
            if normalized_header in normalized_mapping:
                header_to_index[col_idx] = normalized_mapping[normalized_header]

        rows = []
        for row_idx, row in enumerate(worksheet.iter_rows(min_row=2), start=2):
            record = {header: None for header in review_headers}
            has_value = False
            for col_idx, cell in enumerate(row, start=1):
                db_col = header_to_index.get(col_idx)
                if not db_col:
                    continue
                record[db_col] = cell.value
                if cell.value is not None:
                    has_value = True
            if has_value:
                rows.append(record)

        return rows
    
    def _build_review_payloads(
        self,
        final_mapping,
        review_headers
    ):

        # =====================================================
        # Validate file path
        # =====================================================
        if not self.file_path:
            return []

        # =====================================================
        # Load workbook
        # =====================================================
        workbook = openpyxl.load_workbook(
            self.file_path
        )

        worksheet = workbook.active

        # =====================================================
        # Excel Header -> DB Column
        # final_mapping:
        # {
        #     "Customer": "customer_name",
        #     "Board No": "boardno"
        # }
        # =====================================================
        header_mapping = {

            excel_header: db_col

            for excel_header, db_col
            in final_mapping.items()

            if db_col
        }

        # =====================================================
        # Column Index -> DB Column
        #
        # Example:
        # {
        #     1: "barcode",
        #     2: "boardno"
        # }
        # =====================================================
        header_to_index = {}

        for col_idx, cell in enumerate(
            worksheet[1],
            start=1
        ):

            header = cell.value

            if header in header_mapping:

                header_to_index[col_idx] = (
                    header_mapping[header]
                )

        # =====================================================
        # Config
        # =====================================================
        payloads = []

        key_headers = set(
            self.app.config[
                "EXCEL_UPDATE"
            ][
                "key_columns"
            ]
        )

        table_name = (
            self.app.config[
                "EXCEL_UPDATE"
            ][
                "table_name"
            ]
        )

        database_name = (
            self.app.config[
                "EXCEL_UPDATE"
            ].get(
                "database"
            )
        )

        # =====================================================
        # Read Excel Rows
        # =====================================================
        for row_idx, row in enumerate(
            worksheet.iter_rows(min_row=2),
            start=2
        ):

            keys = {}

            data = {}

            # =================================================
            # Read each cell
            # =================================================
            for col_idx, cell in enumerate(
                row,
                start=1
            ):

                db_col = header_to_index.get(
                    col_idx
                )

                # ---------------------------------------------
                # Column not mapped
                # ---------------------------------------------
                if not db_col:
                    continue

                value = cell.value

                # ---------------------------------------------
                # Key columns
                # ---------------------------------------------
                if db_col in key_headers:

                    if value is not None:

                        keys[db_col] = value

                    continue

                # ---------------------------------------------
                # Only review headers
                # ---------------------------------------------
                if db_col not in review_headers:
                    continue

                data[db_col] = value

            # =================================================
            # Skip empty update
            # =================================================
            if not data:
                continue

            # =================================================
            # Missing keys
            # =================================================
            if len(keys) != len(key_headers):
                continue

            # =================================================
            # Build payload object
            # =================================================
            payload = {

                "table": table_name,

                "keys": keys,

                "data": data
            }

            # =================================================
            # Optional database
            # =================================================
            if database_name:

                payload["database"] = (
                    database_name
                )

            # =================================================
            # Append to bulk payload list
            # =================================================
            payloads.append(payload)

        # =====================================================
        # Return:
        #
        # [
        #     {...},
        #     {...},
        #     {...}
        # ]
        # =====================================================
        return payloads

    def show_review_window(self, final_mapping):
        review_headers = self._build_review_headers(final_mapping)
        if not review_headers:
            messagebox.showerror("Lỗi", "Không có cột DB nào để hiển thị trong review.")
            return

        rows = self._load_review_rows(final_mapping, review_headers)
        if not rows:
            messagebox.showwarning("Chú ý", "Không tìm thấy dữ liệu nào để review.")
            return

        review_window = tk.Toplevel(self.frame)
        review_window.title("Review dữ liệu trước khi Submit")
        review_window.geometry("1000x550")
        review_window.transient(self.frame.winfo_toplevel())
        review_window.grab_set()

        info_label = tk.Label(review_window, text="Data.", anchor="w")
        info_label.pack(fill="x", padx=10, pady=6)

        search_frame = tk.Frame(review_window)
        search_frame.pack(fill="x", padx=10, pady=(0, 6))

        tk.Label(search_frame, text="Tìm kiếm:", width=10, anchor="w").pack(side="left")
        search_var = tk.StringVar()
        search_entry = tk.Entry(search_frame, textvariable=search_var, width=40)
        search_entry.pack(side="left", padx=(0, 8))

        def filter_rows():
            query = search_var.get().strip().lower()
            tree.delete(*tree.get_children())
            for index, record in enumerate(rows, start=1):
                line = " ".join([str(record.get(col, "") or "").lower() for col in review_headers])
                if not query or query in line:
                    values = [index] + [record.get(col, "") for col in review_headers]
                    tree.insert("", "end", values=values)

        tk.Button(search_frame, text="Search", width=10, command=filter_rows).pack(side="left")
        tk.Button(search_frame, text="Clear", width=10, command=lambda: (search_var.set(""), filter_rows())).pack(side="left", padx=(8, 0))

        container = tk.Frame(review_window)
        container.pack(fill="both", expand=True, padx=10, pady=6)

        columns = ["No"] + review_headers
        tree = ttk.Treeview(container, columns=columns, show="headings")
        tree.pack(side="left", fill="both", expand=True)

        vsb = ttk.Scrollbar(container, orient="vertical", command=tree.yview)
        vsb.pack(side="right", fill="y")
        tree.configure(yscrollcommand=vsb.set)

        hsb = ttk.Scrollbar(review_window, orient="horizontal", command=tree.xview)
        hsb.pack(fill="x", padx=10)
        tree.configure(xscrollcommand=hsb.set)

        for col in columns:
            tree.heading(col, text=col)
            tree.column(col, width=150, anchor="w")

        def on_mouse_wheel(event):
            tree.yview_scroll(int(-1*(event.delta/120)), "units")

        tree.bind("<MouseWheel>", on_mouse_wheel)

        filter_rows()

        self.review_payloads = self._build_review_payloads(final_mapping, review_headers)

        
        self._log(f"Loading model: {self.review_payloads}")
    

        button_frame = tk.Frame(review_window)
        button_frame.pack(fill="x", padx=10, pady=8)

        tk.Button(button_frame, text="Hủy", width=12, command=review_window.destroy).pack(side="left")
        tk.Button(button_frame, text="Submit", width=12, command=lambda: self.final_submit(final_mapping, review_window, self.review_payloads)).pack(side="right")

    def final_submit(self, final_mapping, review_window=None, payloads=None):
        excel_conf = self.app.config["EXCEL_UPDATE"]
        excel_conf["header_mapping"] = final_mapping

        try:
            if payloads is None:
                processor = ExcelUpdateProcessor(excel_conf, self.app.logger)
                payloads = processor.process_file(self.file_path)

            if not payloads:
                messagebox.showwarning("Chú ý", "Không có dữ liệu nào để gửi. Vui lòng kiểm tra màu cell và key columns.")
                return

            sp_query_str = json.dumps(payloads)
            result = self.app.enco_api_client.call_sp(excel_conf["stored_update"], {"@p_payload": sp_query_str})
            self._log(f"✅ SP RESULT: {result}")
            messagebox.showinfo("Hoàn thành", "Stored procedure đã được gọi thành công.")
            if review_window:
                review_window.destroy()
        except Exception as exc:
            self._log(f"❌ SUBMIT ERROR: {exc}")
            messagebox.showerror("Lỗi", f"Không thể gửi dữ liệu: {exc}")

    def run_module(self, file_path, table_name, key_columns):
        try:
            # TODO: use stored_getHeader when API is available
            # client = self.app.enco_api_client
            # header_data = client.call_sp(self.app.config["EXCEL_UPDATE"]["stored_getHeader"], {"@table_name": table_name})
            header_data = [
                {"data": [{"COLUMN_NAME": "No"}]},
                {"data": [{"COLUMN_NAME": "Barcode"}]},
                {"data": [{"COLUMN_NAME": "Customer"}]},
                {"data": [{"COLUMN_NAME": "BoardNo"}]},
                {"data": [{"COLUMN_NAME": "BoardSerial"}]},
                {"data": [{"COLUMN_NAME": "MFG"}]},
                {"data": [{"COLUMN_NAME": "Type"}]},
                {"data": [{"COLUMN_NAME": "Pkg_Type"}]},
                {"data": [{"COLUMN_NAME": "Sites"}]},
                {"data": [{"COLUMN_NAME": "Equip"}]},
                {"data": [{"COLUMN_NAME": "Handler Type"}]},
                {"data": [{"COLUMN_NAME": "Prod_rmk"}]},
                {"data": [{"COLUMN_NAME": "Opcode"}]},                
                {"data": [{"COLUMN_NAME": "Equip"}]},
                {"data": [{"COLUMN_NAME": "Handler"}]},
                {"data": [{"COLUMN_NAME": "Prod"}]},
                {"data": [{"COLUMN_NAME": "Op"}]},
            ]
            db_columns = [item["data"][0]["COLUMN_NAME"] for item in header_data]
            self._log(f"DB columns: {db_columns}")

            mapper = ExcelDBMapper(db_columns)
            self._log(f"Attempting to read Excel: {file_path!r}")
            excel_info = mapper.get_excel_headers_with_color(file_path)
            self.excel_info = excel_info
            headers_for_mapping = excel_info["update_headers"] or excel_info["all_headers"]
            headers_for_mapping = list(set(headers_for_mapping + key_columns))
            self._log(f"Excel headers: {headers_for_mapping}")

            result = mapper.map(file_path, key_columns)
            mapping = result.get("header_mapping", {})
            scores = result.get("scores", {})
            self.db_columns = db_columns
            self.show_mapping_editor(mapping, key_columns, scores)
            for source, target in mapping.items():
                score = scores.get(source, 0.0)
                self._log(f"{source} → {target or '<no match>'} (score={score:.3f})")
        except Exception as exc:
            self._log(f"ERROR: {exc}")

    def submit(self):
        if not self.mapping_entries:
            messagebox.showwarning("Cảnh báo", "Chưa có mapping để gửi")
            return

        final_mapping = {}
        for excel_col, entry in self.mapping_entries.items():
            value = entry.get().strip()
            if value or excel_col in self.app.config["EXCEL_UPDATE"]["key_columns"]:
                final_mapping[excel_col] = value

        if not final_mapping:
            messagebox.showerror("Lỗi", "Mapping không hợp lệ")
            return

        self._log("=== FINAL MAPPING ===")
        for source, target in final_mapping.items():
            self._log(f"{source} → {target or '<empty>'}")

        excel_conf = self.app.config["EXCEL_UPDATE"]
        excel_conf["header_mapping"] = final_mapping
        excel_conf["update_headers"] = self.excel_info.get("update_headers", [])

        self.show_review_window(final_mapping)
