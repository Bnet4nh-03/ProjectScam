from src.core.base_app import BaseApp
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient
from src.utility.file_folder_utils.utils import list_folders, find_files_with_patterns
import os
import glob
import re
import pandas as pd

class PanelParsing(BaseApp):

    VALID_LETTERS = [
        c for c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ" if c not in ("I", "O")]
    LETTER_TO_INDEX = {c: i for i, c in enumerate(VALID_LETTERS)}

    def __init__(self, config_path: str, config_type: str):
        super().__init__(self.__class__.__name__, config_path, config_type)
        self.enco_api_client = EnCoApiClient(self.config["API_Common"].get("api_link_1"), self.logger)
        # self.list_unit_data = None
        self.qxm_path = self.config["Source_Path"].get("qxm_path")
        self.list_lots = None
        self.usp_set_lot = self.config["Stored_procedure"].get("set_lot")
        self.usp_set_panel = self.config["Stored_procedure"].get("set_panel")
        self.usp_set_unit = self.config["Stored_procedure"].get("set_unit")

    def run(self):
        self.logger.info(f"Starting {self.__class__.__name__} application")
        # Get list folder v1qtiqxm
        list_device_folders = list_folders(self.qxm_path)
        if not list_device_folders:
            self.logger.error(f"No device folder found in {self.qxm_path}")
            return
        # Loop for each device folder
        for current_device_folder in list_device_folders:
            self.logger.info(f"Processing device folder: {current_device_folder}")
            # Get list tester folder in device folder
            list_tester_folders = list_folders(current_device_folder)
            if not list_tester_folders:
                self.logger.error(f"No tester folder found in {current_device_folder}") 
                continue
            # Loop for each tester folder
            for current_tester_folder in list_tester_folders:
                self.logger.info(f"Processing tester folder: {current_tester_folder}")
                # Get list folder in tester folder
                list_fodlers = list_folders(current_tester_folder)
                if not list_fodlers:
                    self.logger.error(f"No folder found in {current_tester_folder}") 
                    continue
                # Loop for each folder
                for current_folder in list_fodlers:
                    # Check folder name is MINMAX or not
                    if current_folder.name.upper() == "MINMAX":
                        self.logger.info(f"Processing folder: {current_folder}")
                        # Get list lots in folder path
                        self.list_lots = self.get_all_file_names(current_folder)
                        # Get model type
                        model_type = current_device_folder.name.split('_')[0]
                        # v1qtiqxm1103 -> QXM1103
                        model_type = model_type[-7:].upper()
                        # Loop for each lot
                        for lot in self.list_lots:
                            self.logger.info(f"Processing lot: {lot}")
                            # Read csv files for lot
                            list_unit_data = self.read_csv_files_for_lot(lot,current_folder)
                            if not list_unit_data.empty:
                                panel_yield_data,lot_yield_data = None,None
                                # Get panel yield data and lot yield data
                                panel_yield_data,lot_yield_data = self.yield_caculate(list_unit_data)
                                # Set lot yield data
                                if lot_yield_data is not None:
                                    params = {
                                        "@lot": lot,# VARCHAR(50),
                                        "@tester": current_tester_folder.name,# VARCHAR(50),
                                        "@device": model_type,# VARCHAR(50),
                                        "@pass": lot_yield_data['Total_Pass'],# FLOAT,
                                        "@fail": lot_yield_data['Total_Fail'],# FLOAT,
                                        "@yield": lot_yield_data['Total_Yield'],# FLOAT
                                    }
                                    lot_response = self.set_data(params,self.usp_set_lot)
                                    if lot_response:
                                        # Set panel yield data
                                        for index,panel_data in panel_yield_data.iterrows():
                                            params = {
                                                "@lot": lot, # VARCHAR(50),
                                                "@panel": panel_data['Panel'], # VARCHAR(50),
                                                "@pass": panel_data['Pass'], # FLOAT,
                                                "@fail": panel_data['Fail'], # FLOAT,
                                                "@yield": panel_data['Yield'], # FLOAT
                                            }
                                            self.set_data(params,self.usp_set_panel)
                                        # Set unit data
                                        for index,unit_data in list_unit_data.iterrows():
                                            params = {
                                                "@lot": lot,# VARCHAR(50),
                                                "@sn": unit_data.iloc[0],# VARCHAR(50),
                                                "@product": model_type,# VARCHAR(50),
                                                "@result": unit_data.iloc[1],# VARCHAR(50),
                                                "@panel": unit_data.iloc[2],# VARCHAR(50)
                                            }
                                            self.set_data(params,self.usp_set_unit)
                                else:
                                    self.logger.error(f"{lot}:{lot_yield_data}")

        self.logger.info(f"{self.__class__.__name__} application finished")

    def get_all_file_names(self,folder_path):
        with os.scandir(folder_path) as entries:
            list_lot = {
                parts[2] 
                for entry in entries 
                if entry.is_file() and entry.name.lower().endswith('.csv')
                for parts in [entry.name.split('_')]
                if len(parts) > 2
            }
        return list_lot
   
    def clean_token(self,s):
        if s is None:
            return None
        s = str(s).strip().upper()
        return s if s != "" else None

    def decode_xy(self,token):
        """Chuyển '01-99', 'A0-Z9', '5', '103', 'A03' -> int; None nếu không hợp lệ."""
        t = self.clean_token(token)
        if not t:
            return None

        # Int
        if re.fullmatch(r"\d{1,3}", t):
            return int(t.lstrip("0") or "0")

        # Define
        m = re.fullmatch(r"([A-Z])([0-9])", t)
        if m:
            letter, d = m.groups()
            if letter not in self.LETTER_TO_INDEX:
                return None
            base = 100 + self.LETTER_TO_INDEX[letter] * 10
            return base + int(d)

        # #########
        m = re.fullmatch(r"([A-Z])(\d{2})", t)
        if m:
            letter, two = m.groups()
            if letter not in self.LETTER_TO_INDEX:
                return None
            base = 100 + self.LETTER_TO_INDEX[letter] * 10
            return base + int(two[-1])

        return None

    def encode_xy(self,value):

        if value is None:
            return None
        try:
            n = int(value)
        except Exception:
            return None

        if 0 <= n <= 99:
            return f"{n:02d}"
        if 100 <= n <= 339:
            off = n - 100
            letter_idx = off // 10
            digit = off % 10
            if 0 <= letter_idx < len(self.VALID_LETTERS):
                return f"{self.VALID_LETTERS[letter_idx]}{digit}"
        return None

    def read_csv_files_for_lot(self,lot,folder_path):
        pattern = os.path.join(folder_path, f"MinMax_Output_{lot}_*.csv")
        files = glob.glob(pattern)

        if not files:
            return None

        collected = []  # All data

        for path in files:
            # delimiter ';'
            df = pd.read_csv(
                path, sep=';', header=None, engine='python',
                dtype=str, na_filter=False, encoding='utf-8-sig'
            )
            if df is None:
                self.logger.error(f"Error reading file: {path}")
                continue
            idx = next((i for i, v in df[0].items() 
                        if isinstance(v, str) and "Measurements:" in v), None)
            if idx is None:
                self.logger.error(f"No Measurements found in file: {path}")
                continue
            header_row = df.loc[idx].tolist()
            cols = [(h or '').strip()
                    or f'col_{j}' for j, h in enumerate(header_row)]

            meas = df.loc[idx + 1:].reset_index(drop=True)
            meas.columns = cols[:meas.shape[1]]
            first = meas.columns[0]

            # Lọc Result
            mask_real = (
                meas[first].str.match(r'^\d+:', na=False)
                & ~meas[first].str.contains(r':\s*Result\b', na=False)
            )
            real = meas.loc[mask_real].copy()

            # Parse token: "cycle:x | y | panel | pick | site"
            def parse_tokens(s: str):
                toks = [t.strip() for t in re.split(r'[|\n]+', s) if t.strip()]
                cycle, X = None, None
                if len(toks) >= 1 and ':' in toks[0]:
                    parts = toks[0].split(':', 1)
                    cycle = parts[0].strip()
                    X = parts[1].strip()
                Y = toks[1].strip() if len(toks) >= 2 else None
                panel = toks[2].strip() if len(toks) >= 3 else None
                return pd.Series({'Cycle': cycle, 'X': X, 'Y': Y, 'Panel': panel})

            # meta = real[first].apply(parse_tokens)
            # real = pd.concat([real.reset_index(drop=True),
            #                 meta.reset_index(drop=True)], axis=1)
            meta_cols = real[first].apply(parse_tokens)
            real = pd.concat([real.reset_index(drop=True), meta_cols.reset_index(drop=True)], axis=1)
            if 'X' not in real.columns:
                self.logger.error(f"Failed to parse 'X' from column {first}")
                continue
            # convert X/Y
            real['X_val'] = real['X'].apply(lambda x: self.decode_xy(x) if pd.notna(x) else None)
            real['Y_val'] = real['Y'].apply(lambda x: self.decode_xy(x) if pd.notna(x) else None)
            real['X_std'] = real['X_val'].apply(self.encode_xy)
            real['Y_std'] = real['Y_val'].apply(self.encode_xy)


            # Panel + X_std + Y_std
            real['2DID'] = real.apply(
                lambda r: f"{self.clean_token(r['Panel'])}{self.clean_token(r['X_std'])}{self.clean_token(r['Y_std'])}"
                if self.clean_token(r['Panel']) and self.clean_token(r['X_std']) and self.clean_token(r['Y_std']) else None,
                axis=1
            )

            # Final Result
            final_col = next(
                (c for c in real.columns if c.strip().lower() == 'final result?'), None)
            if final_col:
                pass_fail = (real[final_col].str.strip().str.lower()
                            .map({'yes': 'Pass', 'y': 'Pass', '1': 'Pass'}).fillna('Fail'))
            else:
                pass_fail = pd.Series(['Unknown'] * len(real))
            
            out = pd.DataFrame({
                '2DID': real['2DID'],
                'Pass/Fail': pass_fail,
                'Panel': real['Panel'],
                # 'Module_Type': module_type,
            }).dropna(subset=['2DID'])

            collected.append(out)

        # Combine
        final = pd.concat(collected, ignore_index=True)

        # duplicate
        final = final.drop_duplicates(
            subset=['2DID'], keep='last').reset_index(drop=True)

        return final

    def yield_caculate(self,list_unit_data):
        df = list_unit_data

        # check 2DID condition
        did_col = "2DID" if "2DID" in df.columns else df.columns[0]

        # Pass/Fail panel
        panel_counts = (
            df.pivot_table(index="Panel", columns="Pass/Fail", values=did_col,
                            aggfunc="count", fill_value=0)
            # .reset_index()
        )
        panel_counts = panel_counts.reindex(columns=["Pass", "Fail"], fill_value=0).reset_index()
        panel_counts["Total"] = panel_counts["Pass"] + panel_counts["Fail"]
        panel_counts["Yield"] = (panel_counts["Pass"] / panel_counts["Total"] * 100).round(2)

        # Yield tabel
        panel_data = panel_counts[["Panel","Pass","Fail", "Yield"]]

        # Sum
        total_pass = (df["Pass/Fail"] == "Pass").sum()
        # total = len(df)
        # total_fail = total - total_pass
        total_fail = (df["Pass/Fail"] == "Fail").sum()
        # total_yield = round(total_pass / total * 100, 2)
        total_yield = float((total_pass / (total_pass + total_fail) * 100).round(2))
        total_summary = {
            # "Total": int(total),            
            "Total_Pass": int(total_pass),
            "Total_Fail": int(total_fail),
            "Total_Yield": total_yield
        }
        return panel_data, total_summary
    
    def set_data(self, params,usp_name):
        try:
            response = self.enco_api_client.call_sp(usp_name,params)
            if response:
                response = response[0]['data'][0]  
                if response['result'] == 0:
                    return True
                else:
                    self.logger.error(f"{response['message']}")
        except Exception as e:
            self.logger.error(e)
            self.logger.error(f"Error processing {params}")
        return False