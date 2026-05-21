import { Request } from "../models/Request";
import { EnCoApiClientService } from '@/modules/core/services/EnCoApiClientService';
import gFunc from '@/utils/func';
const apiClient = new EnCoApiClientService(import.meta.env.VITE_API_AUTH_URL);
export const hccCommonFunc = {
    CheckHccResData(resData) {
        var isCheck = true;
        if (resData[0].data[0]['result'] == 0) {
            isCheck = false;
            gFunc.ShowMessage(resData[0].data[0]['message_data'], 'error', '', 3000);
        }
        return {
            isCheck: isCheck,
            data: resData[0].data[0]
        };
    },
    /**
     * @param {string} flag The flag to set the request info.
     * @param {Request} Request The request object.
     * @param {any} hwSelected The selected hardware list.
     */
    async SetRequestHwInfo(flag, Request, hwSelected) {
        var params = {
            "@flag": flag,// VARCHAR(100),
            "@request_id": Request.request_id,// BIGINT = NULL,
            "@scode_id": Request.scode_id,// INT = NULL,
            "@location_id": Request.location_id,// BIGINT = NULL,
            "@request_type_id": Request.request_type_id,// INT = NULL,
            "@is_urgent": Request.is_urgent,// TINYINT = NULL,
            "@purpose": Request.purpose || '',// NVARCHAR(MAX) = '',
            "@comment": Request.comment || '',// NVARCHAR(MAX) = '',
            "@hcc_comment": Request.hcc_comment,// NVARCHAR(MAX) = '',
            "@need_datetime": Request.need_datetime,// DATETIME = NULL,
            "@return_plan": Request.return_plan,// DATETIME = NULL,
            "@status_type_id": Request.status_type_id,// INT = NULL,
            "@status_sub_type_id": Request.status_sub_type_id,// INT = NULL,
            "@req_by_badge": Request.req_by_badge,// VARCHAR(50) = NULL,
            "@hcc_by_badge": Request.hcc_by_badge,// VARCHAR(50) = NULL,
            "@sub_scode_id": Request.sub_scode_id,// INT = NULL
        }
        try {
            var response = await apiClient.callSp("ATV_Common..USP_Set_HCC_RequestInOut_RequestHwInfo", params);
            response = this.CheckHccResData(response);
            if (response.isCheck) {
                var request_id = response.data.request_id;
                for (const [key, value] of Object.entries(hwSelected.value)) {
                    for (const item of value) {
                        await this.SetHwListRequested(flag, request_id, item, Request.status_type_id, Request.status_sub_type_id);
                    }
                }
                gFunc.ShowMessage(response.data.message_data, 'success', 'Notification', 5000);
            }
        }
        catch (error) {
            gFunc.ShowMessage(error.message, 'error', 'Notification', 5000);
        }
    },
    async SetHwListRequested(flag, requestId, mHwItem, statusTypeId, statusSubTypeId) {
        var params = {}
        if (flag == "INSERT") {
            params = {
                "@flag": flag, // VARCHAR(100),
                "@request_hw_id": mHwItem.request_hw_id || null, // BIGINT = NULL,
                "@request_id": requestId, // BIGINT = NULL,
                "@status_type_id": 1, // INT = NULL,
                "@status_sub_type_id": 0, // INT = NULL,
                "@hw_id": mHwItem.id, // BIGINT = NULL,
                "@hw_type": mHwItem.hwtype, // BIGINT = NULL,
                "@hw_type_id": mHwItem.typeid, // BIGINT = NULL,
                "@hw_sub_id": mHwItem.subtypeid, // BIGINT = NULL,
                "@scode_id": mHwItem.scodeid, // INT = NULL,
                "@location_id": mHwItem.scodelocationid, // BIGINT = NULL,
                "@state_id": mHwItem.stateid, // BIGINT = NULL,
                "@inout_actions": mHwItem.ioactions, // VARCHAR(MAX) = 'N/A',
                "@inout_comment": mHwItem.iocomment, // NVARCHAR(MAX) = '',
                "@memo": mHwItem.memo, // NVARCHAR(MAX) = '',
                "@notice": mHwItem.notice, // NVARCHAR(MAX) = '',
                "@extra": mHwItem.extra, // NVARCHAR(MAX) = '',
                "@tester_id": 0, // INT = 0
            }
        }
        else if (flag == "UPDATE") {
            params = {
                "@flag": flag, // VARCHAR(100),
                "@request_hw_id": mHwItem.request_hw_id || null, // BIGINT = NULL,
                "@request_id": requestId, // BIGINT = NULL,
                "@status_type_id": statusTypeId, // INT = NULL,
                "@status_sub_type_id": statusSubTypeId, // INT = NULL,
                "@hw_id": mHwItem.hw_id, // BIGINT = NULL,
                "@hw_type": mHwItem.hw_type, // BIGINT = NULL,
                "@hw_type_id": mHwItem.hw_type_id, // BIGINT = NULL,
                "@hw_sub_id": mHwItem.hw_sub_id, // BIGINT = NULL,
                "@scode_id": mHwItem.scode_id, // INT = NULL,
                "@location_id": mHwItem.location_id, // BIGINT = NULL,
                "@state_id": mHwItem.state_id, // BIGINT = NULL,
                "@inout_actions": mHwItem.inout_actions, // VARCHAR(MAX) = 'N/A',
                "@inout_comment": mHwItem.inout_comment, // NVARCHAR(MAX) = '',
                "@memo": mHwItem.memo, // NVARCHAR(MAX) = '',
                "@notice": mHwItem.notice, // NVARCHAR(MAX) = '',
                "@extra": mHwItem.extra, // NVARCHAR(MAX) = '',
                "@tester_id": 0, // INT = 0
            }
        }
        try {
            var response = await apiClient.callSp("ATV_Common..USP_Set_HCC_RequestInOut_HwListRequested", params);
            response = this.CheckHccResData(response);
            // if (response.isCheck) {
            // }
        }
        catch (error) {
            gFunc.ShowMessage(error.message, 'error', 'Notification', 5000);
        };
    },
};

// export default hccCommonFunc;