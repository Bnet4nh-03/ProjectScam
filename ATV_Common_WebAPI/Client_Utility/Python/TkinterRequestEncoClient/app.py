import tkinter as tk
from tkinter import ttk, filedialog, scrolledtext
import json
import os
import threading
import queue

# Import the core logic from the api modules
import api_file
import api_sql
import config # Import the new config module

class App(tk.Tk):
    def __init__(self):
        super().__init__()

        self.title("Encrypted API Test Client")
        self.geometry("960x750")

        # --- Data --- #
        self.file_path = tk.StringVar()
        self.api_queue = queue.Queue()
        self.api_base_url_var = tk.StringVar(value=config.API_BASE_URL) # Initialize with current config value

        self.default_payloads = {
            "File Upload": {
                "url": "/Common/File_Method/Set",
                "payload": {
                    "appName": "TkinterClient",
                    "saveMode": "Rename",
                    "fileName": "",
                    "fileSize": 0
                }
            },
            "File Download": {
                "url": "/Common/File_Method/Get",
                "payload": {
                    "filePath": "some_folder/your_file.txt",
                    "fileName": "your_actual_filename.txt"
                }
            },
            "FileOps: List": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "list",
                    "operation": {
                        "sourcePath": "some_folder",
                        "filePattern": "*",
                        "paginate": True,
                        "pageNumber": 1,
                        "pageSize": 100,
                        "orderBy": "name",
                        "ascending": True
                    }
                }
            },
            "FileOps: Move": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "move",
                    "operation": {
                        "sourcePath": "some_folder/file.txt",
                        "destinationPath": "another_folder/file.txt"
                    }
                }
            },
            "FileOps: Copy": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "copy",
                    "operation": {
                        "sourcePath": "some_folder/file.txt",
                        "destinationPath": "another_folder/file_copy.txt"
                    }
                }
            },
            "FileOps: Delete File": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "delete",
                    "operation": {
                        "sourcePath": "some_folder/file_to_delete.txt",
                        "recursive": False
                    }
                }
            },
            "FileOps: Delete Folder": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "delete",
                    "operation": {
                        "sourcePath": "folder_to_delete",
                        "recursive": True
                    }
                }
            },
            "FileOps: Rename": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "rename",
                    "operation": {
                        "sourcePath": "some_folder/old_name.txt",
                        "newName": "new_name.txt"
                    }
                }
            },
            "FileOps: Create Directory": {
                "url": "/Common/File_Method/File_Ops",
                "payload": {
                    "command": "createdirectory",
                    "operation": {
                        "sourcePath": "some_folder/new_directory"
                    }
                }
            },
            "DB Call SP": {
                "url": "/Common/Data_Method/DB_EnCo/Call_SP",
                "payload": {
                    "dbKey": "CIMitar",
                    "spName": "[ATV_Common].[dbo].[TEST_Common]",
                    "spQuery": { "@user_id": "112", "@badgeno": "abca" },
                    "logSave": False
                }
            },
            "DB Call SC": {
                "url": "/Common/Data_Method/DB_EnCo/Call_SC",
                "payload": {
                    "dbKey": "CIMitar",
                    "scQuery": "SELECT GETDATE() AS CurrentTime",
                    "logSave": False
                }
            }
        }

        # --- UI Creation --- #
        main_frame = ttk.Frame(self, padding="10")
        main_frame.pack(fill=tk.BOTH, expand=True)

        self.create_config_frame(main_frame)
        self.create_log_frame(main_frame)

        self.update_ui_for_endpoint_type()
        self.process_api_queue()

    def create_config_frame(self, parent):
        config_frame = ttk.LabelFrame(parent, text="Configuration", padding="10")
        config_frame.pack(fill=tk.X, pady=5)

        # Endpoint Type
        ttk.Label(config_frame, text="Endpoint Type:").pack(fill=tk.X)
        self.endpoint_type_var = tk.StringVar(value=list(self.default_payloads.keys())[0])
        endpoint_dropdown = ttk.Combobox(config_frame, textvariable=self.endpoint_type_var, values=list(self.default_payloads.keys()), state="readonly")
        endpoint_dropdown.pack(fill=tk.X, pady=(0, 10))
        endpoint_dropdown.bind("<<ComboboxSelected>>", self.update_ui_for_endpoint_type)

        # API Base URL
        ttk.Label(config_frame, text="API Base URL:").pack(fill=tk.X)
        ttk.Entry(config_frame, textvariable=self.api_base_url_var).pack(fill=tk.X, pady=(0, 10))

        # File Input Frame (for Upload)
        self.file_input_frame = ttk.Frame(config_frame)
        self.file_input_frame.pack(fill=tk.X)
        ttk.Label(self.file_input_frame, text="File to Upload:").pack(fill=tk.X)
        file_entry_frame = ttk.Frame(self.file_input_frame)
        file_entry_frame.pack(fill=tk.X, pady=(0, 10))
        ttk.Entry(file_entry_frame, textvariable=self.file_path, state="readonly").pack(side=tk.LEFT, fill=tk.X, expand=True)
        ttk.Button(file_entry_frame, text="Browse...", command=self.browse_file).pack(side=tk.LEFT, padx=(5, 0))

        # Payload
        self.payload_label = ttk.Label(config_frame, text="Request Payload (JSON):")
        self.payload_label.pack(fill=tk.X)
        self.payload_text = scrolledtext.ScrolledText(config_frame, height=10, wrap=tk.WORD)
        self.payload_text.pack(fill=tk.BOTH, expand=True, pady=(0, 10))

        # Send Button
        self.send_button = ttk.Button(config_frame, text="Send Request", command=self.send_request)
        self.send_button.pack(fill=tk.X)

    def create_log_frame(self, parent):
        log_frame = ttk.LabelFrame(parent, text="Logs", padding="10")
        log_frame.pack(fill=tk.BOTH, expand=True, pady=5)

        self.log_text = scrolledtext.ScrolledText(log_frame, height=15, wrap=tk.WORD, state="disabled")
        self.log_text.pack(fill=tk.BOTH, expand=True)

    def browse_file(self):
        path = filedialog.askopenfilename()
        if path:
            self.file_path.set(path)
            try:
                payload = json.loads(self.payload_text.get("1.0", tk.END))
                payload["fileName"] = os.path.basename(path)
                payload["fileSize"] = os.path.getsize(path)
                self.payload_text.delete("1.0", tk.END)
                self.payload_text.insert(tk.END, json.dumps(payload, indent=4))
            except json.JSONDecodeError:
                pass

    def update_ui_for_endpoint_type(self, event=None):
        endpoint_type = self.endpoint_type_var.get()
        config = self.default_payloads[endpoint_type]

        self.payload_text.delete("1.0", tk.END)
        self.payload_text.insert(tk.END, json.dumps(config["payload"], indent=4))

        if endpoint_type == "File Upload":
            self.file_input_frame.pack(fill=tk.X)
            self.payload_label.config(text='Request Metadata (JSON for "Set-File-Info" header):')
        else:
            self.file_input_frame.pack_forget()
            self.payload_label.config(text="Request Payload (JSON):")

    def log(self, message):
        self.log_text.config(state="normal")
        self.log_text.insert(tk.END, message + "\n\n")
        self.log_text.see(tk.END)
        self.log_text.config(state="disabled")

    def send_request(self):
        self.send_button.config(state="disabled", text="Sending...")
        self.log_text.config(state="normal")
        self.log_text.delete("1.0", tk.END)
        self.log_text.config(state="disabled")

        endpoint_type = self.endpoint_type_var.get()
        try:
            payload = json.loads(self.payload_text.get("1.0", tk.END))
        except json.JSONDecodeError as e:
            self.log(f"ERROR: Invalid JSON payload.\n{e}")
            self.send_button.config(state="normal", text="Send Request")
            return

        thread = threading.Thread(target=self.run_api_call, args=(endpoint_type, payload))
        thread.start()

        # Update the API_BASE_URL in the config module
        config.API_BASE_URL = self.api_base_url_var.get()

    def run_api_call(self, endpoint_type, payload):
        try:
            if endpoint_type == "File Upload":
                local_path = self.file_path.get()
                if not local_path:
                    raise ValueError("No file selected for upload.")
                result = api_file.upload_file(local_path, payload)
                self.api_queue.put(("Success", f"File Upload Successful:\n{json.dumps(result, indent=2)}"))

            elif endpoint_type == "File Download":
                remote_path = payload.get("filePath")
                if not remote_path:
                    raise ValueError("'filePath' not provided in payload.")
                save_path = filedialog.asksaveasfilename(initialfile=os.path.basename(remote_path))
                if save_path:
                    api_file.download_file(remote_path, save_path)
                    self.api_queue.put(("Success", f"File downloaded successfully to:\n{save_path}"))
                else:
                    self.api_queue.put(("Info", "File download cancelled."))

            elif endpoint_type.startswith("FileOps:"):
                result = api_file.file_operation(payload)
                self.api_queue.put(("Success", f"File Operation Successful:\n{json.dumps(result, indent=2)}"))
            
            elif endpoint_type == "DB Call SP":
                result = api_sql.call_sp(payload)
                self.api_queue.put(("Success", f"DB Stored Procedure Successful:\n{json.dumps(result, indent=2)}"))

            elif endpoint_type == "DB Call SC":
                result = api_sql.call_sc(payload)
                self.api_queue.put(("Success", f"DB SQL Command Successful:\n{json.dumps(result, indent=2)}"))

        except Exception as e:
            self.api_queue.put(("Error", f"An error occurred:\n{e}"))

    def process_api_queue(self):
        try:
            level, message = self.api_queue.get_nowait()
            self.log(f"{level.upper()}: {message}")
            self.send_button.config(state="normal", text="Send Request")
        except queue.Empty:
            pass
        finally:
            self.after(100, self.process_api_queue)

if __name__ == "__main__":
    app = App()
    app.mainloop()
