import { eventBus } from '@/plugin/eventBus';
import _ from 'lodash';
import moment from 'moment';
import * as XLSX from 'xlsx';
const func = {
    CheckResDataLogin(resData) {
        var isCheck = true;
        if (resData['header']['code'] != 0) {
            isCheck = false;
            this.ShowMessage(resData['header']['message'], 'error');
        }
        return {
            isCheck: isCheck,
            data: resData['body']
        };
    },
    CheckResData(resData) {
        var isCheck = true;
        if (resData[0].data[0]['result'] != 0) {
            isCheck = false;
            this.ShowMessage(resData[0].data[0]['message'], 'error', '', 3000);
        }
        return {
            isCheck: isCheck,
            data: resData[0].data[0]
        };
    },
    ShowMessage(message = 'Process is completed', type = 'success', title = 'Notification', timeOut = 0) {
        var typeMsg = _.toString(type) == '' ? 'success' : type;
        var titleMsg = _.toString(title) == '' ? 'Notification' : title;
        if (timeOut == 0) {
            eventBus.toast.add({ severity: typeMsg, summary: titleMsg, detail: message });
        } else {
            eventBus.toast.add({ severity: typeMsg, summary: titleMsg, detail: message, life: timeOut });
        }
    },

    ShowMessageTest(self, message = 'xử lý thành công', type = 'success', resultCode = '', title = 'Thông báo', timeOut = 3000) {
        var typeMsg = self._.toString(type) == '' ? 'success' : type;
        var titleMsg = self._.toString(title) == '' ? 'success' : title;
        if (resultCode == self.$gVariable.resultCode.tokenExprire) {
            self.$toast.add({ severity: typeMsg, summary: titleMsg, detail: 'phiên làm việc đã hết hạn', life: timeOut });
            self.$router.replace('/auth/login');
            // self.$gVariable.CurentStatus = self.$gVariable.StatusCode.TokenExprire;
            // if (self.$router.currentRoute.value.path != '/login') {
            //     self.$router.replace('/login');
            // } else {
            //     self.$toast.add({ severity: typeMsg, summary: titleMsg, detail: message, life: timeOut });
            // }
        } else {
            toast.add({ severity: typeMsg, summary: titleMsg, detail: message, life: timeOut });
        }
    },
    ParseJwt(token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(
            window
                .atob(base64)
                .split('')
                .map(function (c) {
                    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
                })
                .join('')
        );

        return JSON.parse(jsonPayload);
    },

    ConvertDate(dateString, format = 'YYYY-MM-DD HH:mm:ss') {
        return _.toString(dateString) !== '' ? moment(dateString, 'YYYYMMDDHHmmss').format(format) : '';
    },

    CreateReqData(param) {
        return {
            header: {
                userId: 'string',
                accessToken: 'string',
                role: 'string'
            },
            body: param
        };
    },

    DownloadExcel(columnDefs, tableData, sheetName = 'Sheet1', excelName = 'data.xlsx') {
        const headers = columnDefs.map((col) => col.headerName);
        const worksheetData = [headers];
        tableData.forEach((node, index) => {
            const row = headers.map((header) => {
                if (header === 'No') {
                    return index + 1;
                }
                return node[columnDefs.find((col) => col.headerName === header).field];
            });
            worksheetData.push(row);
        });

        const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
        const workbook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workbook, worksheet, sheetName);

        XLSX.writeFile(workbook, excelName);
    },

    GetWeekNumber(date) {
        var weekNumber = 1;
        const startOfYear = new Date(date.getFullYear(), 0, 1);

        // Điều chỉnh startOfYear về thứ Hai đầu tiên của năm
        const dayOfWeek = startOfYear.getDay();
        const diffToMonday = (dayOfWeek === 0 ? -6 : 1) - dayOfWeek;
        const firstMonday = new Date(startOfYear);
        firstMonday.setDate(startOfYear.getDate() + diffToMonday);

        // Tính số ngày đã trôi qua kể từ thứ Hai đầu tiên
        const diffInMs = date - firstMonday;
        const diffInDays = Math.floor(diffInMs / 86400000);

        // Tính số tuần, cộng thêm 1 vì tuần bắt đầu từ 1
        weekNumber = Math.floor(diffInDays / 7) + 1;
        return weekNumber;
    },

    GetWWPrevious() {
        const weekNumbers = [];
        const today = new Date();
        for (let i = 3; i >= 0; i--) {
            const date = new Date(today);
            date.setDate(today.getDate() - i * 7);
            weekNumbers.push(this.GetWeekNumber(date));
        }
        return weekNumbers;
    },
    CheckItemIsObject(item) {
        return _.toString(item) == '[object Object]' || _.toString(item) == '';
    },
    BindingColorApprove(flow_status) {
        var ret = '';
        switch (flow_status) {
            case 'Approve':
                ret = 'background-color: rgb(69 155 140);border: 1px solid rgb(69 155 140); color:rgb(255 255 255);height: 100%';
                break;
            case 'Reject':
                ret = 'background-color: rgb(245, 87, 87); border: 1px solid rgb(245, 87, 87); color: rgb(255, 255, 255); height: 100%';
                break;
            case 'Consent':
                ret = 'background-color: rgb(127 23 75);border: 1px solid rgb(127 23 75); color: rgb(255 255 255);height: 100%';
                break;
            case 'Notify':
                ret = 'background-color: rgb(15 75 143);border: 1px solid rgb(15 75 143); color: rgb(255 255 255);height: 100%';
                break;
            case 'Parallel consent':
                ret = 'background-color: rgb(255, 165, 79);border: 1px solid rgb(255, 165, 79); color: rgb(255 255 255);height: 100%';
                break;
            case 'Requester':
                ret = 'background-color: rgb(93, 216, 238);border: 1px solid rgb(93, 216, 238); color: rgb(255 255 255);height: 100%';
                break;
            default:
                break;
        }
        return ret;
    },

    BindingTitleApprove(item) {
        var ret = '';
        if (_.toString(item) != '') {
            ret = item.badge_no + ' - ' + item.username + ' - ' + item.division + '/' + item.department;
            if (_.toString(item.position) != '') {
                ret += ' - ' + item.position;
            }
            if (_.toString(item.title) != '') {
                ret += ' - ' + item.title;
            }
        }
        return ret;
    },
    BindingDoorCode(item) {
        var ret = '';
        if (_.toString(item) != '') {
            ret = item.code + ' - ' + item.name + ' - ' + item.dept + '/' + item.username;
        }
        return ret;
    },


    BindingColorLineApproveNew(index, currApprSelected, lstReqHistory) {
        var ret = 'background: var(--p-red-100);';
        const currentFlowOrder = currApprSelected['flowOrder'];
        const lastFlowOrder = lstReqHistory.length > 0 ? lstReqHistory[0]['flowOrder'] : 0;

        const approvedFlowOrder = lstReqHistory.length > 0 ? lstReqHistory[0]['flowOrder'] : 0; // số thứ tự approve gần nhất

        // approve status = reject
        if (currentFlowOrder == 1001 && lastFlowOrder == 1001) {
            if (index + 1 < approvedFlowOrder + 1) {
                ret = 'background: #e2e8f0;';
            } else if (index + 1 == approvedFlowOrder + 1) {
                ret = 'background: var(--p-red-100);';
            } else {
                ret = 'background: #fff;';
            }
        } else {
            if (index < approvedFlowOrder + 1 || currentFlowOrder == 1000) {
                ret = 'background: #e2e8f0;';
            } else {
                ret = 'background: #fff;';
            }
        }

        return ret + '; width: 100%; height: auto;';
    },
    BindingColorLineApprove(index, currApprSelected, lstReqHistory) {

        var ret = 'background: var(--p-red-100);';
        const currentFlowOrder = currApprSelected['flowOrder'];
        const lastFlowOrder = lstReqHistory.length > 0 ? lstReqHistory[0]['flowOrder'] : 0;

        const approvedFlowOrder = lstReqHistory.length > 0 ? lstReqHistory[0]['flowOrder'] - 1 : 0; // số thứ tự approve gần nhất

        // approve status = reject
        if (currentFlowOrder == 1001 && lastFlowOrder == 1001) {
            if (index + 1 < approvedFlowOrder) {
                ret = 'background: #e2e8f0;';
            } else if (index + 1 == approvedFlowOrder) {
                ret = 'background: var(--p-red-100);';
            } else {
                ret = 'background: #fff;';
            }
        } else {
            if (index < approvedFlowOrder || currentFlowOrder == 1000) {
                ret = 'background: #e2e8f0;';
            } else {
                ret = 'background: #fff;';
            }
        }

        return ret + '; width: 100%; height: auto;';
    },

    BindingResultTextsearch(item, lstHisApp = '') {

        var ret = '';
        var titleApprove = '';
        if (_.toString(item) != '') {
            titleApprove = item.badge_no + ' - ' + item.username + ' - ' + item.division + '/' + item.department;
            if (_.toString(item.position) != '') {
                titleApprove += ' - ' + item.position;
            }
            if (_.toString(item.title) != '') {
                titleApprove += ' - ' + item.title;
            }
        }

        ret =
            `<div style=" height: 100%; display: flex;align-items: center;">
            <span style="font-size: 13px">` +
            titleApprove +
            `</span> </div>`;

        if (_.toString(lstHisApp) != '' && item.flowStatus != 'Notify') {
            const approveItem = _.find(lstHisApp, hisItem => hisItem.createBy == item.badge_no && hisItem.flowStatus != 'Requested');
            if (approveItem) {
                titleApprove = approveItem.update_by + ' - ' + approveItem.employee_name + ' - ' + approveItem.division + '/' + approveItem.department;
                if (_.toString(approveItem.position) != '') {
                    titleApprove += ' - ' + approveItem.position;
                }
                // if (_.toString(approveItem.title) != '') {
                //     titleApprove += ' - ' + approveItem.title;
                // }
                ret = `
                    <div class="flex">
                        <span style="font-size: 13px"><b>From:&nbsp;</b>${titleApprove}</span>
                        <div class="flex ml-auto gap-2">
                            <span style="font-size: 13px"><b>Sent:&nbsp;</b>${this.ConvertDate(approveItem['updateAt'])}</span>
                        </div>
                    </div>
                    <div class="flex">
                        <span style="font-size: 13px"><b>Comment:&nbsp;</b></span>
                        <div style="font-size: 13px" style="white-space: pre-wrap; word-break: break-word; flex-grow: 1;">${approveItem.comment}</div>
                    </div>
                `;
            }
            const approveItemRequester = _.find(lstHisApp, hisItem => hisItem.approved_badge_no == item.badge_no && hisItem.approved_status == 'Requested' && hisItem.approved_flow_order == 0 && item.flow_order <= hisItem.approved_flow_order);
            if (approveItemRequester) {
                titleApprove = approveItemRequester.update_by + ' - ' + approveItemRequester.updated_name + ' - ' + approveItemRequester.updated_division + '/' + approveItemRequester.updated_department;
                if (_.toString(approveItemRequester.updated_position) != '') {
                    titleApprove += ' - ' + approveItemRequester.updated_position;
                }
                if (_.toString(approveItemRequester.updated_title) != '') {
                    titleApprove += ' - ' + approveItemRequester.updated_title;
                }
                ret = `
                    <div class="flex">
                        <span style="font-size: 13px"><b>From:&nbsp;</b>${titleApprove}</span>
                        <div class="flex ml-auto gap-2">
                            <span style="font-size: 13px"><b>Sent:&nbsp;</b>${this.ConvertDate(approveItemRequester['update_at'])}</span>
                        </div>
                    </div>
                    <div class="flex">
                        <div style="font-size: 13px" style="white-space: pre-wrap; word-break: break-word; flex-grow: 1;">${approveItemRequester.comment}</div>
                    </div>
                `;
            }
        }
        return ret;
    },



    BindingColorStatus(colName, objData) {

        var objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer' };
        switch (colName) {
            case 'requestStatus':
                switch (objData.value) {
                    case 'Approve':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-blue-500)' };
                        break;
                    case 'Pending':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-yellow-500)' };
                        break;
                    case 'Done':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-green-500)' };
                        break;
                    case 'OK':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-green-500)' };
                        break;
                    case 'NG':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-red-500)' };
                        break;
                    case 'NA':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-gray-400)' };
                        break;
                    case 'HOLD':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-red-500)' };
                        break;
                    case 'RELEASE':
                        objRet = { alignItems: 'center', display: 'flex', textAlign: 'center', cursor: 'pointer', color: 'var(--p-green-500)' };
                        break;
                    default:
                        break;
                }
                break;

            default:
                break;
        }
        return objRet;
    }
};

export default func;
