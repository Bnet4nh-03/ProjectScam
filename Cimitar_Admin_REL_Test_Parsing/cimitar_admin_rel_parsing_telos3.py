import pandas as pd
import csv, os, glob
import requests, json
import configparser
import time
from datetime import datetime

def get_config(header, key):
    config = configparser.ConfigParser()
    config.read('.config/config.ini')   # Read the.ini file window
    # config.read('/home/testit/SRC/SRC/src/ATV_DEV/TEST/CIMitar_Admin_REL_function/.config/config.ini')   # Read the.ini file linux
    value = config[header][key] 
    return value

def request_store_procedure(sp_name: str, param_list: list[str], arg_list: list) -> requests.Response: 
    api_link = get_config('api', 'api_link')
    validate_code = requests.post(f"{api_link}/Common/Data_Method/Get_Request_Validate_Code").text
    req_body = {
        "requestValidateCode": validate_code,
        "storeProcedureName": sp_name,
        "parametersList": param_list,
        "argumentList": arg_list
    }
    req_header = {'Content-Type': 'application/json'}
    data = requests.post(f"{api_link}/Common/Data_Method/DB/Call_Store_Procedure",
                        data=json.dumps(req_body), headers=req_header)
    return data

def set_rel_unit_data(data_list: list):
    set_rel_unit = get_config('stored', 'set_rel_unit')
    sql_getdata = request_store_procedure(set_rel_unit, 
                    ["@customercode", "@lot", "@dcc", "@operation", "@sn", "@ecid", "@starttime", "@endtime", "@result", 
                        "@product", "@familyname", "@tester", "@program ", "@retestcode", "@site", "@fail_desc ", 
                        "@hbin", "@sbin", "@testerid", "@measure_result ", "@filename", "@waferid"], data_list)
    result = sql_getdata.json()
    if len(result['spResult']) != 0:
        return result['spResult'][0]['data'][0]["Result"] 
    else: 
        return ''

def get_familyname(product):
    if 'TELOS2' in product:
        familyname = 'TELOS 2'
    elif 'TELOS3' in product:
        familyname = 'TELOS 3'
    elif 'STANZA2' in product:
        familyname = 'STANZA 2'
    else:
        familyname = ''
    return familyname

def get_operation(folder_name):
    if 'QA1FT1' in folder_name:
        operation = 'SQA1'
    elif '1FT1' in folder_name:
        operation = 'SLT1'
    else:
        operation = 'UNKNOWN'
    return operation

def get_tester(subfolder: str):
    split_list = subfolder.split('-')
    for idx, ele in enumerate(split_list):
        if 'MAC' in ele:
            tester = split_list[idx + 1].replace('#','-')
            if tester.startswith('TS'):
                tester = tester[:2] + '-' + tester[2:]
            return tester
    return ''

def filter_folder(source_path, rel_test_folder):
    rel_test_folder_parsing = []
    for folder in rel_test_folder:
        full_path = os.path.join(source_path, folder)
        if not os.path.isfile(f'{full_path}/{folder}_CSV_MERGE_2.csv') and os.path.isfile(f'{full_path}/DONE'):
            rel_test_folder_parsing.append(folder)
    return rel_test_folder_parsing

def checking_directory_rel_test(source_path):
    folders = os.listdir(source_path)
    rel_test_folder = []
    for folder in folders:
        # if folder != 'REL_HTHH_77EA-RELSLT1-1FT1':
        #     continue
        full_path = os.path.join(source_path, folder)
        if os.path.isdir(full_path) and folder[:3] == 'REL' and 'VERIFY' not in folder and 'test_new_script' not in folder:
            rel_test_folder.append(folder)
    rel_test_folder_parsing = filter_folder(source_path, rel_test_folder)
    return rel_test_folder_parsing

def parsing_data_rel_test(source_path):
    rel_test_folder_parsing = checking_directory_rel_test(source_path)
    if rel_test_folder_parsing == []:
        print(f'[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] No rel test folder found')
        return
    for folder in rel_test_folder_parsing:
        print(f'[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Parsing: {folder}')
        full_path = os.path.join(source_path, folder)
        csv_files = []
        csv_file_null = []
        for root, dirs, files in os.walk(full_path):
            if dirs:
                if 'MAC' in dirs[0]:
                    tester = get_tester(dirs[0])
            for file in files:
                if file.endswith('.csv') and 'CSV_MERGE' not in file and 'null' not in file:
                    full_file_path = os.path.join(root, file)
                    csv_files.append(full_file_path)
                elif file.endswith('.csv') and 'CSV_MERGE' not in file and 'null' in file:
                    csv_file_null.append(os.path.join(root, file))
        csv_files.extend(csv_file_null)
        try:
            df_data = merge_data(csv_files, full_path, folder)
            get_data_then_upload(df_data, folder, tester)
            print(f'[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Parsing Done: {folder}')
        except Exception as e:
            print(f'[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Parsing Error: {e}. {folder}')
        os.remove(f'{full_path}/DONE')
        break

def merge_data(csv_files, full_path, full_lot_name):
    all_content_file = []
    header_4lines = []
    for file_path in csv_files:
        with open(file_path, 'r') as file:
            filename = os.path.basename(file_path).split('.')[0]
            content_file = csv.reader(file)
            count = 0
            for line in content_file:
                count += 1
                if file_path == csv_files[0]:
                    if count == 2:
                        header = line
                    elif count > 4:
                        all_content_file.append(line)
                    if count < 5:
                        header_4lines.append(line)
                else:
                    if count > 4:
                        all_content_file.append(line)
    df = pd.DataFrame(all_content_file, columns=header)
    df_4_header = pd.DataFrame(header_4lines + all_content_file)
    filename = f"{full_lot_name}_CSV_MERGE_2.csv"
    df_4_header.to_csv(f'{full_path}/{filename}', index=False, header=False)
    print(f'[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Exported {filename}')
    return df

def get_data_then_upload(df: pd.DataFrame, folder_name: str, tester: str):
    lot = folder_name.split('REL')[1][1:-1]
    operation = get_operation(folder_name)
    filename = folder_name
    total_pass = 0 
    total_existed = 0
    for row, data in df.iterrows():
        count = row + 1
        cus_code = 0
        dcc = ''
        result = data['overallResult']
        if result == 'PASS':
            retestcode = 0
        else:
            retestcode = 1
        program = data['SW_VER']
        starttime = str(data['startTime']).replace('/', '-')
        endtime = str(data['stopTime']).replace('/', '-')
        fail_des = data['errString']
        site = data['TesterID']
        testerid = data['TesterID']
        measure_result = data['FIRST_FAILED_SPEC']
        if result == 'FAIL' and measure_result == 'NA':
            continue
        product = data['PROJECT']
        familyname = get_familyname(product)
        ecid = data['Fermat_OTP_UID']
        sn = data['SIP_SN']
        hbin = ''
        sbin = ''
        waferid = ''
        data_list = [cus_code, lot, dcc, operation, sn, ecid, starttime, endtime, result, product, familyname, tester, 
                        program, retestcode, site, fail_des, hbin, sbin, testerid, measure_result, filename, waferid]
        # print(data_list)
        #Upload to CimitarAdmin
        result_exec = set_rel_unit_data(data_list)
        if result_exec == 'FAIL':
            print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Cannot upload data. Please check error in line {count}, SN: {sn}")
            break
        elif result_exec == 'PASS':
            total_pass += 1
            # print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Parsing success. SN: {sn}")
        elif result_exec == 'EXISTED':
            total_existed += 1
            # print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Data existed. SN: {sn}")

    if result_exec == 'PASS':
        print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] All data parsing successfully. Total pass: {total_pass}. Total existed: {total_existed}")
    elif result_exec == 'EXISTED':
        print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Data existed. Total existed: {total_existed}. Total pass {total_pass}")

def main():
    print(f'[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Start parsing ')
    start_time = time.time() # Record the start time
    # source_path = r"C:\Workplace\Task\Support_TEST\CIMitar_Admin_REL_function\REL_Data_Raw"
    source_path = r"\\10.201.21.12\esicifsp\v1esisltn\DATA\Telos3\Manual_DATA"     #Window
    # source_path = r"/mnt/esi_siplet/DATA/Ego/Manual_DATA"     #Linux
    try:
        parsing_data_rel_test(source_path)
    except Exception as e:
        print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] An error occurred: {e}")
    end_time = time.time() # Record the end time
    total_time = end_time - start_time
    print(f"[{datetime.now().strftime("%Y-%m-%d %H:%M:%S")}] Total execution time: {total_time:.2f} seconds\n")

if __name__ == '__main__':
    main()

