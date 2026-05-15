import tkinter as tk
from tkinter import ttk

from src.core.base_app import BaseApp
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient
from src.modules.updateData.mapping_module import MappingModule


class CommonBaseApp(BaseApp):
    def __init__(self, config_path: str, config_type: str):
        super().__init__(self.__class__.__name__, config_path, config_type)

        self.enco_api_client = EnCoApiClient(self.config["API_Common"]["api_link_1"], self.logger)
        self.file_path = ""
        self.root = tk.Tk()
        self.root.title("Excel Update Tool")
        self.root.geometry("950x720")
        self.root.configure(bg="#f4f6f8")

        self.modules = []
        self._build_ui()

    def _build_ui(self):
        self.notebook = ttk.Notebook(self.root)
        self.notebook.pack(fill="both", expand=True, padx=12, pady=12)

        # register modules here
        self._register_module(MappingModule)

    def _register_module(self, module_cls):
        frame = tk.Frame(self.notebook, bg="#f4f6f8")
        module = module_cls(self)
        module.build(frame)
        self.modules.append(module)
        self.notebook.add(frame, text=module.name())


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


