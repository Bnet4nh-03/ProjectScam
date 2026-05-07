import requests, json
import re
import datetime

def request_store_procedure(sp_name: str, param_list: list[str], arg_list: list) -> requests.Response: 
    api_link = 'http://10.201.12.31:8004'
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



def set_unit_data(data_list: list):
    sql_getdata = request_store_procedure('ATV_Common.dbo.USP_Test_Kioxia_Fullcombinelot_Advantest', 
                    ["@CONDITION", "@LOT_NO", "@DCC", "@PROGRAM"], data_list)
    result = sql_getdata.json()
    if len(result['spResult']) != 0:
        data_list_result = result['spResult'][0]['data']
        if not data_list_result:
            return None
        return result['spResult'][0]['data'][0]
    else:
        return ''

def get_dcc_data(data_list: list):
    sql_getdata = request_store_procedure('ATV_Common.dbo.USP_Test_Kioxia_Fullcombinelot_Advantest', 
                    ["@CONDITION", "@TRACE_CODE"], data_list)
    result = sql_getdata.json()


    sp = result.get('spResult') or []
    if not sp:
        return '' 

    data_list_result = sp[0].get('data') or []
    if not data_list_result:
        return None 

    # --- Lọc DCC là số ---
    def _clean(v):
        return '' if v is None else str(v).strip()

    numeric_rows = [
        row for row in data_list_result
        if re.fullmatch(r'[0-9]+', _clean(row.get('WPDCC')))
    ]

    if numeric_rows:
        return numeric_rows[0]  # Ưu tiên dòng có WPDCC numeric

    return None

def get_lot_from_keyno(keyno: str):
    resp = request_store_procedure('TSV.dbo.USP_Summary_GetLotFromKeyno', ["@KEYNO"], [keyno])
    if resp.status_code != 200:
        return {'error': f'HTTP {resp.status_code}', 'detail': resp.text}

    result = resp.json()
    if len(result['spResult']) != 0:
            data_list_result = result['spResult'][0]['data']
            if not data_list_result:
                return None
            return result['spResult'][0]['data'][0]
    else:
        return ''
    
def check_testing_status( data_list: list):
    resp = request_store_procedure('ATV_Common.dbo.FullCombineLot_Check_Testing_Status', ["@DATETIME_ASC", "@MACHINE"], data_list)
    if resp.status_code != 200:
        return {'error': f'HTTP {resp.status_code}', 'detail': resp.text}

    result = resp.json()
    if len(result['spResult']) != 0:
            data_list_result = result['spResult'][0]['data'][0]['Result']
            return(data_list_result)

if __name__ == "__main__":
    data_list = ['get_temperature', 'J04JPY00', '04', 'BK02VKTT','']
    get_opr_temp = set_unit_data(data_list)
    print(get_opr_temp)
    if get_opr_temp:
        code_station = str(get_opr_temp.get('WPOPR'))
        test_station = str(get_opr_temp.get('WPOPRN'))
        get_temperature = str(get_opr_temp.get('WPCOND')).strip().split('+')[0] + '.00'

        print(code_station)
        print(test_station)
        print(get_temperature)
    else:
        print("rong")

    # tracecode = 'WH4037'
    # data_list = ['get_lot_dcc', '', '', '', tracecode]

    # result_exec = set_rel_unit_data(data_list)
    # print(result_exec)
    # lot_no = result_exec.get('WPLOT#')
    # dcc = result_exec.get('WPDCC')\
    
    # print(f'lot: {lot_no}')
    # print(f'dcc: {dcc}')

    # keyno = 'TA0285'
    # data = get_lot_from_keyno(keyno)
    # if data:
    #     lot_name = str(data.get('SMLOT#'))
    #     if '.' in lot_name:
    #         lot_name = lot_name.split('.')[0]
    #     dcc = str(data.get('SMDCC'))
    #     opr = str(data.get('SMOPRN'))
    # print(lot_name)
    # print(dcc)
    # print(opr)
    # data_list = ['20250304070015', 'TS-MAG-001']
    # status = check_testing_status(data_list)
