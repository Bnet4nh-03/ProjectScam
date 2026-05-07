from __future__ import annotations
from typing import Dict
import pandas as pd
import os
from typing import Dict
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient
from src.apps.common_base_parsing import CommonBaseParsing
import glob
from src.utility.file_folder_utils.utils import list_folders
from concurrent.futures import ThreadPoolExecutor
import io

class ParsingSummaryTsv(CommonBaseParsing):
    """
    Model_1:
    - Lấy dữ liệu từ file_summary.txt (key=value)
    - Có thể enrich từ DB (call SP khác) nếu cần
    - Cuối cùng insert bằng call_summary_insert() dùng chung từ base
    """

    def __init__(self, config_path: str, config_type: str):
        super().__init__(config_path, config_type)
        self.summary_file_path = '' #self.config["Source_Path"].get("qxm_path")

    def populate_attributes(self, reel_file) -> None:
        # 1) Default attribute
        self.sumDirectory = ''
        self.temperature = '25'
        self.operation = 'FT1'
        self.handlerType = ''
        self.editOperatorID = ''
        self.comment = ''
        self.testProgramExcel = ''
        self.testProgramRev = ''
        self.channelMap = ''
        
        # 2) Attribute from file summary
        content_file = self.get_data_from_summary_file(reel_file)

        self.sumName = content_file['sum_name']
        self.lotName = content_file['lot_name']
        self.dcc = content_file['dcc']
        self.createTime = content_file['create_time']
        self.PUIversion = content_file['PUI_version']
        self.loadBoardNo = content_file['load_board']
        self.goodBin = content_file['good_bin']
        self.goodYield = content_file['good_yield']
        self.failBin = content_file['fail_bin']
        self.failYield = content_file['fail_yield']
        self.totalBin = content_file['total_bin']
        self.hardBin = content_file['hard_bin'] #'0,1,3313,99.94/1,0,1,0.03/5,0,1,0.03/'
        self.softBin = content_file['soft_bin'] #'0,0,GUTZAHL,3313,3315,99.94/4010,1,MESSAUS,0,1,0.03/4050,5,TTAL,0,1,0.03/'
        self.summaryText = content_file['summary_text']

        # 3) Get attribute from eMES
        data = self.get_tsv_summary_data()

        if data is not None:    
            self.customer = data['customer']
            self.platform = data['platformnm']
            self.device = data['device']
            self.deviceMA = data['device_ma']
            self.handlerId = data['handler']
            self.operatorId = data['operid']
            self.testProgram = data['test_program']
            self.tester = data['hostname']

        else:
            return
        
        # 4) Others attribute


    def get_tsv_summary_data(self):

        param = {
            "@lotname" : self.lotName,
            "@dcc": self.dcc
            }
        result = self.enco_api_client.call_sp(
            "TSV.dbo.USP_Get_TSV_Summary_Data", param)
        
        if result[0]['data']:
            # self.logger.info(f"Get data success")
            # Check new hold lot list not empty
            data_list = result[0]['data'][0]
            return data_list
        else:
            self.logger.error(f"[Fail] Cannot get lot {self.lotName} from eMES. Data not exist!!") 
            return None

    def get_lot_parsing(self, df: pd.DataFrame) -> str:
        #Create list and get last 2 lot to checking data TSV
        lot_list = []
        for idx in reversed(df.index):
            row = df.loc[idx]
            if row['Lot No'] not in lot_list:
                lot_list.append(row['Lot No'])  
                # print(idx, row['Lot No'])
            if len(lot_list) == 1: break
        return lot_list[0]

    def get_summary_text(self, file_path, lot, column_name):
        #Create summary text
        with open(file_path, 'r', encoding='utf-8', errors='replace') as f:
            raw_lines = []
            clean_lines = []
   
            for line in f:
                if not line.strip():
                    continue

                stripped = line.rstrip('\n').strip('\t')
                raw_lines.append(stripped + '\n')   # giữ newline
                clean_lines.append(stripped)

            # raw_lines = f.read().splitlines(keepends=True)

        SKIP = 1
        df = pd.read_csv(io.StringIO("\n".join(clean_lines)), sep='\t',names=column_name, skiprows=SKIP,engine='python').reset_index(drop=True)

        summary_txt = ""
        for pos in range(len(df) - 1, -1, -1):
            original_line = raw_lines[pos + SKIP] if (pos + SKIP) < len(raw_lines) else ""
            lot_infile = original_line.split('\t')[0]
            if lot_infile != lot:
                break
            summary_txt = original_line + summary_txt   # prepend để giữ thứ tự từ dưới lên
        return summary_txt

    def make_soft_bin_str(self, total_quantity: int, bin_no: int, bin_quantity: int, softbin_str: str) -> str:
        """
        Trả về chuỗi 'bin_no,is_true,bin_quantity,yield_pct' nếu bin_quantity != 0
        hoặc trả về '' (chuỗi rỗng) nếu bin_quantity == 0.

        is_true = 1 chỉ với bin 0, còn lại = 0.
        yield_pct = (bin_quantity / total_quantity) * 100, có 2 chữ số thập phân.
        """
        if total_quantity <= 0:
            # Đảm bảo tránh chia 0 (có thể raise hoặc trả rỗng tuỳ nhu cầu)
            return ""

        if bin_quantity == 0:
            return ""

        is_true = 1 if bin_no == 0 else 0
        yield_pct = (bin_quantity / total_quantity) * 100
        return f"{bin_no},{bin_no},{softbin_str},{is_true},{bin_quantity},{yield_pct:.2f}/"

    def make_hard_bin_str(self, total_quantity: int, bin_no: int, bin_quantity: int) -> str:
        """
        Trả về chuỗi 'bin_no,is_true,bin_quantity,yield_pct' nếu bin_quantity != 0
        hoặc trả về '' (chuỗi rỗng) nếu bin_quantity == 0.

        is_true = 1 chỉ với bin 0, còn lại = 0.
        yield_pct = (bin_quantity / total_quantity) * 100, có 2 chữ số thập phân.
        """
        if total_quantity <= 0:
            # Đảm bảo tránh chia 0 (có thể raise hoặc trả rỗng tuỳ nhu cầu)
            return ""

        if bin_quantity == 0:
            return ""

        is_true = 1 if bin_no == 0 else 0

        if bin_no == 7:
            yield_pct = (bin_quantity / (total_quantity + bin_quantity)) * 100
        else:
            yield_pct = (bin_quantity / total_quantity) * 100
        return f"{bin_no},{is_true},{bin_quantity},{yield_pct:.2f}/"

    def build_hard_soft_bins(self, bins_dict: Dict[int, int]) -> str:
        """
        Tạo danh sách chuỗi hard_bin cho các bin (0..16) dựa trên bins_dict = {bin_no: bin_quantity}.
        Bỏ qua bin có quantity = 0 (trả về chuỗi rỗng, nhưng không đưa vào danh sách kết quả).
        """
        hard_bin = ''
        soft_bin = ''

        # Tính total_quantity
        total_quantity = sum(bins_dict.get(i, 0) for i in range(17) if i != 7)

        if total_quantity <= 0:
            return None, None  # Không có dữ liệu hoặc total = 0

        for i in range(17):  # bin0..bin16
            hb = self.make_hard_bin_str(total_quantity, i, bins_dict.get(i, 0))
            if hb:  # chỉ add khi không rỗng
                hard_bin = hard_bin + hb

            if i == 7:
                continue

            if i == 0: softbin_str = 'PASS_GOOD'
            else: softbin_str = f'SOFTBIN_{i}'
            
            sb = self.make_soft_bin_str(total_quantity, i, bins_dict.get(i, 0), softbin_str)
            if sb:
                soft_bin = soft_bin + sb

        return hard_bin, soft_bin

    def get_data_from_summary_file(self, file_path=''):

        # file_path = r"C:\Workplace\Task\Support_TEST\QXM\Document\ReelTracking_133_000046062BB.1400#.txt"

        file_name, ext = os.path.splitext(os.path.basename(file_path))
        
        column_name = [
            'Lot No', 'REEL','ANLASS','PAXFILE','JIG','DATETIME','MODULTYP','MESSPLATZ',
            'FILTERZAHL','GUTZAHL','MESSAUS','TTAL','STATUS','DATE_CODE','MA_TYP',
            'STEMPEL','BE_FAUFNR','TAPE_NO','QUALITY','PAT','Laser',
            'Software_Version','PURGE','FP',  # ← put them exactly where they belong
            'ProcessID','FirstGood','FirstPAT','FirstSFA','FirstTRE','FirstPurge',
            'AprWaiting','TapeBin','PurgeBin','Bin1','Bin2','Bin3','Bin4','Bin5',
            'Bin6','Bin7','Bin8','Bin9','Bin10','Bin11','Bin12','Bin13','Bin14','Bin15','Bin16'
            # add any remaining names to fully match the number of columns in the file
        ]

            
        with open(file_path, encoding='utf-8', errors='ignore') as f:
            clean_lines = [
                line.strip('\n').strip('\t')
                for line in f
                if line.strip()  # bỏ dòng trống
            ]
            
        df = pd.read_csv(
            # file_path,
            io.StringIO("\n".join(clean_lines)),
            sep='\t',
            names=column_name,  # enforce correct schema
            header=None,        # don't treat any row as header
            skiprows=1,         # skip the broken header line in the file
            engine='python'
        )

        # Strip whitespace from column names and values if neeeded
        df.columns = df.columns.str.strip()
        
        # df.insert(21, 'PACE_Version', np.nan)
        # df.insert(22, 'column_w', np.nan)
        # df.insert(23, 'column_x', np.nan)

        df = df.map(lambda x: x.strip() if isinstance(x, str) else x)
        
        lot = self.get_lot_parsing(df)
        
        data_mapping = {
            'sum_name'      :   '',
            'lot_name'      :   '',
            'dcc'           :   '',
            'create_time'   :   '',
            'PUI_version'   :   '',
            'load_board'    :   '',
            'good_bin'      :   0,
            'good_yield'    :   0,
            'fail_bin'      :   0,
            'fail_yield'    :   0,
            'total_bin'     :   0,
            'hard_bin'      :   '',
            'soft_bin'      :   '',
            'summary_text'  :   '',
            }
        
        create_time = ''
        pui_version = ''
        loadboard_no = ''
        total_qty = 0
        good_qty = 0
        bin_0 = bin_1 = bin_2 = bin_3 = bin_4 = bin_5 = bin_6 = bin_7 = bin_8 = 0
        bin_9 = bin_10 = bin_11 = bin_12 = bin_13 = bin_14 = bin_15 = bin_16 = 0
        
        for idx in reversed(df.index):
            row = df.loc[idx]
            if row['Lot No'] == lot:
                # if str(row['ANLASS']).upper() == 'REEL END':
                bin_0 += int(row['TapeBin'])
                bin_1 += int(row['Bin1'])
                bin_2 += int(row['Bin2'])
                bin_3 += int(row['Bin3'])
                bin_4 += int(row['Bin4'])
                bin_5 += int(row['Bin5'])
                bin_6 += int(row['Bin6'])
                bin_7 += int(row['FP'])
                bin_8 += int(row['Bin8'])
                bin_9 += int(row['Bin9'])
                bin_10 += int(row['Bin10'])
                bin_11 += int(row['Bin11'])
                bin_12 += int(row['Bin12'])
                bin_13 += int(row['Bin13'])
                bin_14 += int(row['Bin14'])
                bin_15 += int(row['Bin15'])
                bin_16 += int(row['Bin16'])
                create_time = row['DATETIME']
                pui_version = row['Software_Version']
                loadboard_no = str(row['JIG'])
            else: break
        good_qty = bin_0
        total_qty = bin_0 + bin_1 + bin_2 + bin_3 + bin_4 + bin_5 + bin_6 + bin_8 + bin_9 + bin_10 + bin_11 + bin_12 + bin_13 + bin_14 + bin_15 + bin_16
        fail_qty = total_qty - good_qty
        
        bins_dict = {
            0: bin_0, 1: bin_1, 2: bin_2, 3: bin_3, 4: bin_4, 5: bin_5,
            6: bin_6, 7: bin_7, 8: bin_8, 9: bin_9, 10: bin_10, 11: bin_11,
            12: bin_12, 13: bin_13, 14: bin_14, 15: bin_15, 16: bin_16
        }

        hard_bin, soft_bin = self.build_hard_soft_bins(bins_dict)

        # data_mapping['sum_name'] = os.path.basename(file_path)
        data_mapping['sum_name'] = f"{file_name}_{lot}{ext}"     #12/3/2026 250707 - Dung.Nguyenkhoi: update sum_name include lot_name
        data_mapping['lot_name'] = lot
        data_mapping['create_time'] = create_time.replace('-', '') + '00'
        data_mapping['PUI_version'] = pui_version
        data_mapping['load_board'] = loadboard_no
        data_mapping['good_bin'] = good_qty
        data_mapping['good_yield'] = round((good_qty/total_qty)*100,2) if total_qty > 0 else 0   #12/3/2026 250707 - Dung.Nguyenkhoi: update yeild if lot dont have unit
        data_mapping['fail_bin'] = fail_qty
        data_mapping['fail_yield'] = round((fail_qty/total_qty)*100, 2) if total_qty > 0 else 0    #12/3/2026 250707 - Dung.Nguyenkhoi: update yeild if lot dont have unit
        data_mapping['total_bin'] = total_qty
        data_mapping['summary_text'] = self.get_summary_text(file_path, lot, column_name)
        data_mapping['hard_bin'] = hard_bin
        data_mapping['soft_bin'] = soft_bin

        return data_mapping

    #check lotname have existed IN Summary
    def check_lot_exist(self):
        param = {
            "@lotname" : self.lotName
            }
        result = self.enco_api_client.call_sp(
            "TSV..USP_TSV_CheckExistSummary", param)
        existed = result[0]["data"][0]["Result"]
        return existed

    # #12/3/2026 250707 - Dung.Nguyenkhoi: new "run" function to parsing on multi machine
    def run(self):
        """
        General Workflow:
        1) reset default attribute
        2) populate attribute (model-specific)
        3) insert summary (common)
        """
        self.logger.info(f"Starting {self.__class__.__name__} application")
        machine_list = []

        #get path share folder
        for k in self.config["Machine"]:
            machine_list.append((k, self.config["Machine"].get(k)))

        for machine_name, machine_dir in machine_list:
            folders_list = list_folders(machine_dir)

            #get reeltracking file by machine
            for folder_path in folders_list:      
                if "TS-ZN8" not in folder_path.name:
                    continue

                reel_dir = os.path.join(folder_path, "ReelTracking")
                pattern = os.path.join(reel_dir, "*.txt")
                reel_files = sorted(glob.glob(pattern))
       
                if not reel_files:
                    continue

                #parsing reeltracking file
                for file in reel_files:
                    try:
                        self.reset_attributes()
                        self.populate_attributes(file)
                        if self.check_lot_exist() == 0:
                            data = self.call_summary_insert()
                            # self.logger.info(f"Finished {self.__class__.__name__}")
                            self.logger.info(f"{data} application finished") 
                        else:
                            # self.logger.error(f"[Fail] Lot {self.lotName} have existed on TSV!!") 
                            continue
                    except Exception as e:
                        self.logger.exception(f"Parsing failed: Machine {machine_name} {e}")

        self.logger.info(f"{self.__class__.__name__} application finished")