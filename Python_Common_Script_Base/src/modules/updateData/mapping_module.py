import tkinter as tk
from tkinter import filedialog, messagebox, scrolledtext
import json

from src.apps.module_base import ModuleBase
from src.modules.updateData.map_excel_to_db import ExcelDBMapper
from src.modules.updateData.excel_update_processor import ExcelUpdateProcessor

class MappingModule(ModuleBase):
    def __init__(self, app):
        super().__init__(app)
        self.frame = None
        self.mapping_entries = {}
        self.file_path = ""
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
        tk.Button(top_frame, text="RUN", width=14, command=self.run).pack(side="right")

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
        path = filedialog.askopenfilename(title="Chọn file Excel", filetypes=[("Excel files", "*.xlsx *.xls")])
        if path:
            self.file_path = path
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
        tk.Label(self.mapping_container, text="Score", bg="#f4f6f8", font=(None, 10, "bold")).grid(row=0, column=2, sticky="w", padx=4, pady=4)

        sorted_items = sorted(mapping.items(), key=lambda item: (item[0] not in key_columns, item[0].lower()))
        for row, (excel_col, db_col) in enumerate(sorted_items, start=1):
            score = scores.get(excel_col, 0.0)
            score_text = f"{score:.3f}" if score else ""

            tk.Label(self.mapping_container, text=excel_col, bg="#f4f6f8", anchor="w").grid(row=row, column=0, sticky="w", padx=4, pady=2)
            entry = tk.Entry(self.mapping_container, width=44)
            entry.insert(0, db_col or "")
            entry.grid(row=row, column=1, sticky="w", padx=4, pady=2)

            if excel_col in key_columns:
                entry.config(state="disabled")
            elif score < 0.85:
                entry.config(bg="#fff3cd")

            tk.Label(self.mapping_container, text=score_text, bg="#f4f6f8").grid(row=row, column=2, sticky="w", padx=4, pady=2)
            self.mapping_entries[excel_col] = entry

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
                {"data": [{"COLUMN_NAME": "Prod_emk"}]},
                {"data": [{"COLUMN_NAME": "Opcode"}]},                
                {"data": [{"COLUMN_NAME": "Equip"}]},
                {"data": [{"COLUMN_NAME": "Handler"}]},
                {"data": [{"COLUMN_NAME": "Prod"}]},
                {"data": [{"COLUMN_NAME": "Op"}]},
            ]
            db_columns = [item["data"][0]["COLUMN_NAME"] for item in header_data]
            self._log(f"DB columns: {db_columns}")

            mapper = ExcelDBMapper(db_columns)
            excel_info = mapper.get_excel_headers_with_color(file_path)
            headers_for_mapping = excel_info["update_headers"] or excel_info["all_headers"]
            headers_for_mapping = list(set(headers_for_mapping + key_columns))
            self._log(f"Excel headers: {headers_for_mapping}")

            result = mapper.map(headers_for_mapping, key_columns)
            self.show_mapping_editor(result["mapped"], key_columns, result.get("scores", {}))
            for source, target in result["mapped"].items():
                score = result.get("scores", {}).get(source, 0.0)
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

        try:
            processor = ExcelUpdateProcessor(excel_conf, self.app.logger)
            payloads = processor.process_file(self.app.file_path)
            sp_query_str = json.dumps(payloads)
            result = self.app.enco_api_client.call_sp(excel_conf["stored_update"], {"@p_payload": sp_query_str})
            self._log(f"✅ SP RESULT: {result}")
        except Exception as exc:
            self._log(f"❌ SUBMIT ERROR: {exc}")
