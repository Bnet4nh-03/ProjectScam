import tkinter as tk
from tkinter import filedialog, messagebox, scrolledtext
import json

from src.core.base_app import BaseApp
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient
from src.core.map_excel_to_db import ExcelDBMapper
from src.core.excel_update_processor import ExcelUpdateProcessor


class CommonBaseApp(BaseApp):

    def __init__(self, config_path: str, config_type: str):
        super().__init__(self.__class__.__name__, config_path, config_type)

        self.enco_api_client = EnCoApiClient(
            self.config["API_Common"]["api_link_1"],
            self.logger
        )

        self.file_path = ""
        self.mapping_entries = {}

        # === UI ===
        self.root = tk.Tk()
        self.root.title("Excel Update Tool")
        self.root.geometry("800x600")

        self._build_ui()

    # =========================
    # ✅ UI Layout
    # =========================
    def _build_ui(self):
        frame = tk.Frame(self.root)
        frame.pack(padx=10, pady=10, fill="x")

        tk.Button(frame, text="Chọn Excel", command=self.choose_file).pack(side="left")

        self.lbl_file = tk.Label(frame, text="Chưa chọn file", anchor="w")
        self.lbl_file.pack(side="left", padx=10, fill="x", expand=True)

        tk.Button(frame, text="RUN", command=self.run_main).pack(side="right")

        # Mapping editor
        self.mapping_frame = tk.Frame(self.root)
        self.mapping_frame.pack(fill="both", padx=10, pady=5)

        tk.Button(self.root, text="SUBMIT", command=self.submit_mapping).pack(pady=5)

        # Log box
        self.log_box = scrolledtext.ScrolledText(self.root, height=15)
        self.log_box.pack(fill="both", padx=10, pady=10, expand=True)

    # =========================
    # ✅ Choose file
    # =========================
    def choose_file(self):
        path = filedialog.askopenfilename(
            title="Chọn file Excel",
            filetypes=[("Excel files", "*.xlsx *.xls")]
        )

        if path:
            self.file_path = path
            self.lbl_file.config(text=path)

    # =========================
    # ✅ Log
    # =========================
    def log(self, msg):
        self.log_box.insert(tk.END, msg + "\n")
        self.log_box.see(tk.END)

    # =========================
    # ✅ Show mapping UI
    # =========================
    def show_mapping_editor(self, mapping, key_columns):

        for widget in self.mapping_frame.winfo_children():
            widget.destroy()

        self.mapping_entries = {}

        row = 0
        for excel_col, db_col in mapping.items():

            tk.Label(self.mapping_frame, text=excel_col).grid(row=row, column=0, sticky="w")

            entry = tk.Entry(self.mapping_frame, width=30)
            entry.insert(0, db_col)
            entry.grid(row=row, column=1)

            # disable key column
            if excel_col in key_columns:
                entry.config(state="disabled")

            self.mapping_entries[excel_col] = entry
            row += 1

    # =========================
    # ✅ RUN mapping
    # =========================
    def run_main(self):

        if not self.file_path:
            messagebox.showerror("Error", "Vui lòng chọn file Excel")
            return

        self.log("=== START ===")

        try:
            excel_conf = self.config["EXCEL_UPDATE"]

            # ✅ call DB
            header_data = self.enco_api_client.call_sp(
                excel_conf["stored_getHeader"],
                {"@table_name": excel_conf["table_name"]}
            )

            db_columns = [item["data"][0]["COLUMN_NAME"] for item in header_data]

            self.log(f"DB: {db_columns}")

            # ✅ mapping
            mapper = ExcelDBMapper(db_columns)

            excel_info = mapper.get_excel_headers_with_color(self.file_path)

            self.log(f"Excel: {excel_info['update_headers']}")

            headers_for_mapping = list(
                set(excel_info["update_headers"] + excel_conf["key_columns"])
            )

            result = mapper.map(headers_for_mapping, excel_conf["key_columns"])

            # ✅ show UI
            self.show_mapping_editor(result["mapped"], excel_conf["key_columns"])

            self.log("=== MAPPING ===")
            for k, v in result["mapped"].items():
                self.log(f"{k} → {v}")

            if result["ambiguous"]:
                self.log(f"⚠️ Ambiguous: {result['ambiguous']}")

            if result["unmapped"]:
                self.log(f"❌ Unmapped: {result['unmapped']}")

        except Exception as e:
            self.log(f"ERROR: {str(e)}")
            
        
    def submit_mapping(self):

        try:
            final_mapping = {}

            for excel_col, entry in self.mapping_entries.items():
                final_mapping[excel_col] = entry.get()

            self.log("=== FINAL ===")

            for k, v in final_mapping.items():
                self.log(f"{k} → {v}")

            # ✅ lấy config
            excel_conf = self.config["EXCEL_UPDATE"]

            # ✅ add mapping vào config
            excel_conf["header_mapping"] = final_mapping

            # ✅ xử lý excel
            processor = ExcelUpdateProcessor(excel_conf, self.logger)

            payloads = processor.process_file(self.file_path)

            # ✅ convert payload
            sp_query_str = json.dumps(payloads)

            # ✅ call SP
            result = self.enco_api_client.call_sp(
                excel_conf["stored_update"],
                {"@p_payload": sp_query_str}
            )

            self.log(f"✅ SP RESULT: {result}")

        except Exception as e:
            self.log(f"❌ SUBMIT ERROR: {str(e)}")
    # =========================
    # ✅ Start app
    # =========================
    def run(self):
        self.root.mainloop()

# from src.core.base_app import BaseApp
# from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient
# from src.core.excel_update_processor import ExcelUpdateProcessor
# from src.core.map_excel_to_db import ExcelDBMapper
# import json


# class CommonBaseApp(BaseApp):

#     def __init__(self, config_path: str, config_type: str):
#         super().__init__(self.__class__.__name__, config_path, config_type)

#         self.enco_api_client = EnCoApiClient(
#             self.config["API_Common"]["api_link_1"],
#             self.logger
#         )
        

#     def run(self):
#         self.logger.info("=== START EXCEL UPDATE APP ===")

#         try:
#             file_path = self.config["INPUT_FILE"]["path"]
#             excel_conf = self.config["EXCEL_UPDATE"]


#             header_data = self.enco_api_client.call_sp(
#                 self.config["EXCEL_UPDATE"]["stored_getHeader"]
#                 , {"@table_name": self.config["EXCEL_UPDATE"]["table_name"]}
#             )
#             headers_table = [item["data"][0]["COLUMN_NAME"] for item in header_data]


#             mapper = ExcelDBMapper(headers_table)
#             header_ex = mapper.get_excel_headers_with_color(file_path)

            
            
#             mapping = mapper.map(header_ex["update_headers"], self.config["EXCEL_UPDATE"]["key_columns"])
            
#             self.logger.info(f"Calling SP with payload: {mapping}")
            
#             # processor = ExcelUpdateProcessor(excel_conf, self.logger)
#             # payloads = processor.process_file(file_path)
            
            

#             # for payload in payloads:
#             # try:
#             #     result = self.enco_api_client.call_sp(
#             #         self.config["EXCEL_UPDATE"]["stored_update"]
#             #         , {"@p_payload": sp_query_str}
#             #     )

#             #     self.logger.info(f"SP result: {result}")


#             # except Exception as e:
#             #     self.logger.error(f"SP failed: {str(e)}", exc_info=True)
            
#             self.logger.info(f"Done → Success")

#         except Exception as e:
#             self.logger.error(f"APP ERROR: {str(e)}", exc_info=True)


