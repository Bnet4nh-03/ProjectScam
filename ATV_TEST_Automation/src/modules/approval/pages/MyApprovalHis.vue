<script setup>
import { inject, onMounted, ref, watch,computed } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/modules/core/services/BaseService";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import { useConfirm } from "primevue/useconfirm";
import * as XLSX from "xlsx";
import _ from "lodash";
import moment from "moment";
import axios from 'axios'
const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();
const confirm = useConfirm();
const apprComment = ref("");
const lstApprover = ref([]);
const countFlowOrder=ref("");
const lstRequest = ref([]);
const requestDetails = ref([]);
const requestSummarys = ref([]);
const historyRequest = ref([]);
const currApprSelected = ref({});
const selectedType = ref("1");
const isLoading = ref(false);
const isLockButton = ref(false);
const templates = ref([]);
const items = ref([]);
const deviceTypes = ref([]);
const devices = ref([]);
const users = ref([]);
// Khai báo column cho bảng
const columnNameDefs = ref([
    {
        headerName: "No",
        field: "No",
        valueGetter: "node.rowIndex + 1",
        width: 60,
        filter: false,
        cellStyle: { display: 'flex', justifyContent: 'center', alignItems: 'center' },
        // pinned: 'left'

    },
    {
        headerName: "Status",
        field: "requestStatus",
        width: 100,
        // pinned: 'left',
        cellClass: () => {
            return 'link-item'
        },
        cellStyle: (params) => gFunc.BindingColorStatus("requestStatus", params),
        onCellClicked: (params) => GetDetailsData(params),
    },
    {
        headerName: "Title", field: "request_title",
        cellRenderer: (params) => BindingTitleApprove(params),
        flex: 1,
        filter: true,
    },
]);

const columnDetailsApproveDefs = ref([
{
        headerName: "No",
        field: "No",
        valueGetter: "node.rowIndex + 1",
        cellStyle: { textAlign: 'center' },
        width: 60
    },
     {
        headerName: "Template Name",
        field: "templateName",
        cellStyle: { textAlign: 'center' },
        width: 170,  
    },
    {
        headerName: "Device Code",
        field: "deviceCode",
        cellStyle: { textAlign: 'center' },
        width: 170,
        
    },
    {
        headerName: "Item Text", field: "itemText",
        width: 190,
        cellStyle: { borderBottom: '1px solid #ccc' },
    },
    {
        headerName: "Status", field: "status",
        width: 140,
        cellStyle: (params) => {
            if (params.value === "OK") {
                return {  fontWeight: "bold", color: "#10B981", textAlign: "center",borderBottom: '1px solid #ccc' }; // Màu xanh nhạt cho Completed
            }
            else if(params.value==="NG")
            {
                return { fontWeight: "bold", color: "#F43F5E", textAlign: "center",borderBottom: '1px solid #ccc' };
            }
            return {}; // Giữ nguyên style cho trạng thái khác
        },
    },
    {
        headerName: "Check Time Stamp", field: "checkTimestamp",
        width: 120,
          cellStyle: { borderBottom: '1px solid #ccc' },
        valueFormatter: (params) => FormatData("checkTimestamp", params),
    }
]);
const columnDetailsApproveDefsNG = ref([
{
        headerName: "No",
        field: "No",
        valueGetter: "node.rowIndex + 1",
        cellStyle: { textAlign: 'center' },
        width: 60
    },
     {
        headerName: "Template Name",
        field: "templateName",
        cellStyle: { textAlign: 'center' },
        width: 160,  
    },
    {
        headerName: "Device Code",
        field: "deviceCode",
        cellStyle: { textAlign: 'center' },
        width: 150,
        
    },
    {
        headerName: "Item Text", field: "itemText",
        width: 170,
        cellStyle: { borderBottom: '1px solid #ccc' },
    },
    {
        headerName: "Status", field: "status",
        width: 100,
        cellStyle: (params) => {
            if (params.value === "OK") {
                return {  fontWeight: "bold", color: "#10B981", textAlign: "center",borderBottom: '1px solid #ccc' }; // Màu xanh nhạt cho Completed
            }
            else if(params.value==="NG")
            {
                return { fontWeight: "bold", color: "#F43F5E", textAlign: "center",borderBottom: '1px solid #ccc' };
            }
            return {}; // Giữ nguyên style cho trạng thái khác
        },
    },
     {
        headerName: "NG Reason", field: "nG_Reason",
        width: 120,
        cellStyle: { borderBottom: '1px solid #ccc' },
    },
     {
        headerName:"NG Image", field: "nG_ImageBase64",
        width: 120,
        cellStyle: { borderBottom: '1px solid #ccc' },
         cellRenderer: (params) => {
        if (!params.value || typeof params.value !== "string") return " ";
        return `<img src="${params.value}" style="max-height:80px;max-width:100%;object-fit:contain;"
        onclick="window.openImageDialog('${params.value}')" />`;
    }
    },
      {
        headerName: "Fixed Comment", field: "fixed_Comment",
        width: 120,
        cellStyle: { borderBottom: '1px solid #ccc' },
    },
     {
        headerName:"Fixed Image", field: "fixed_ImagePath64",
        width: 120,
        cellStyle: { borderBottom: '1px solid #ccc' },
         cellRenderer: (params) => {
        if (!params.value || typeof params.value !== "string") return " ";
        return `<img src="${params.value}" style="max-height:80px;max-width:100%;object-fit:contain;"
        onclick="window.openImageDialog('${params.value}')" />`;
    }
    },
    {
        headerName: "Check Time Stamp", field: "checkTimestamp",
        width: 120,
          cellStyle: { borderBottom: '1px solid #ccc' },
        valueFormatter: (params) => FormatData("checkTimestamp", params),
    }
]);
// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: false,
};
const gridOptions = {
    headerHeight: 30,
    rowHeight: 65,
}

const gridDetailsOptions = {
    headerHeight: 35,
    rowHeight: 30,
    singleClickEdit: true,
}
const gridDetailsOptionsNG = {
    headerHeight: 35,
    rowHeight: 60,
    singleClickEdit: true,
}
const gridHeight = computed(() => {
  const count = requestDetails.value.length || 1;
  return `${(count * 30)+50}px`;
});
const gridHeightNG = computed(() => {
  const count = requestDetails.value.length || 1;
  return `${(count * 60)+50}px`;
});
window.openImageDialog = function (src) {
  const dialog = document.createElement("div");
  dialog.innerHTML = `
    <div style="position:fixed;top:0;left:0;width:100vw;height:100vh;
                background:rgba(0,0,0,0.6);display:flex;justify-content:center;align-items:center;
                z-index:9999;" onclick="this.remove()">
      <img src="${src}" style="max-width:80vw;max-height:80vh;border:5px solid white;border-radius:10px" />
    </div>
  `;
  document.body.appendChild(dialog);
};

const BindingTitleApprove = (params) => {
    
    if (params) {
        return `
        <div style="font-size: 14px;">
          <p style="font-weight: bold">${params["data"]["templateName"]}-${params["data"]["deviceCode"]}</p>
          <p>Requester: ${params["data"]["employee_name"]}</p>
           <p>Request date: ${gFunc.ConvertDate(params["data"]["checkTimestamp"])}</p>
        </div>
      `;
    }

};




const FormatData = (colname, data) => {
    var ret = "";
    switch (colname) {
        case "comment":
            ret = _.toString(data.value);
            break;
        case "serving_time":
            ret = moment(data.value, 'HH:mm:ss').format('HH:mm');
            break;
        case "checkTimestamp":
            ret = moment(data.value).format(gVariable.formatDate.YYYY_MM_DD);
            break;
        case "start_time":
            ret = moment(data.value).format(gVariable.formatDate.YYYY_MMM_DD);
            break;
        case "end_time":
            ret = moment(data.value).format(gVariable.formatDate.YYYY_MMM_DD);
            break;    
        case "vendor_birthday":
            ret = moment(data.value).format(gVariable.formatDate.YYYY_MMM_DD);
            break;    
        case "unit_price":
            ret = gFunc.FormatCurrency(data.value);
            break;
        default:
            break;
    }
    return ret;
}


const replacer = () => {
    const seen = new WeakSet();
    return (key, value) => {
        if (typeof value === "object" && value !== null) {
            if (seen.has(value)) {
                return;
            }
            seen.add(value);
        }
        return value;
    };
}

const GetDetailsData = async (detailsData) => {
    
    currApprSelected.value = detailsData.data;
    const responseApprovalHistory = await apiService.post("/api/Safety/CheckResultDetails/get-approval-history", {body:{CheckResultID:currApprSelected.value.checkResultID}});
    var res = gFunc.CheckResData(responseApprovalHistory);
    historyRequest.value=res.data;
    historyRequest.value.forEach(hr => {
    const matchedUser = users.value.find(user => user.badge_id === hr.createBy);
    const matchedFlowOrder = lstApprover.value.find(appr => appr.flowOrder === hr.flowOrder);    
    hr.employee_name = matchedUser?.employee_name || 'Không xác định';
    hr.division = matchedUser?.division || 'Không xác định';
    hr.department = matchedUser?.department || 'Không xác định';
    hr.flowStatus = matchedFlowOrder?.flowStatus || 'Không xác định';
    });

    const responseDetails = await apiService.post("/api/Safety/CheckResultDetails/get-all", {body:""});
    var res = gFunc.CheckResData(responseDetails);
    //requestDetails.value=res.data;
    requestDetails.value = res.data.filter(item => item.checkResultID === currApprSelected.value.checkResultID);
    requestDetails.value = requestDetails.value.map(detail => {
    const matchedRequest = lstRequest.value.find(req => req.checkResultID === detail.checkResultID);
    const matchedItem = items.value.find(item => item.itemID === detail.itemID);

    if (matchedRequest && matchedItem ) {
        return {
        ...detail,
        deviceCode: matchedRequest.deviceCode,
        templateName: matchedRequest.templateName,
        overallStatus: matchedRequest.overallStatus,
        checkTimestamp: matchedRequest.checkTimestamp,
        itemText: matchedItem.itemText,
        };
    }

    return detail; // Nếu không tìm thấy thì giữ nguyên
    });
}

const ClearData = () => {
    apprComment.value = "";
    lstRequest.value = [];
    requestDetails.value = [];
    historyRequest.value = [];
    currApprSelected.value = {};
}

// const DownloadExcel = () => {
//     const headers = columnDetailsApproveDefs.value.map(col => col.headerName);
//     const worksheetData = [headers];
//     requestDetails.value.forEach((node, index) => {
//         const row = headers.map(header => {
//             if (header === 'No') {
//                 return index + 1;
//             }
//             const field = columnDetailsApproveDefs.value.find(col => col.headerName === header).field;
//             const value = node[field];

//             if (field === 'start_time' || field === 'end_time') {
//                 return moment(value).format('YYYY-MM-DD');
//             }
//             return node[columnDetailsApproveDefs.value.find(col => col.headerName === header).field];
//         });
//         worksheetData.push(row);
//     });
   

//     const colWidths = headers.map((header, colIndex) => {
//     const maxLength = worksheetData.reduce((max, row) => {
//       const cell = row[colIndex];
//       const len = cell ? cell.toString().length : 0;
//       return Math.max(max, len);
//     }, header.length);
//     return { wch: maxLength + 2 };
//   });

//     const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
//     worksheet['!cols'] = colWidths;
//     const workbook = XLSX.utils.book_new();
//     XLSX.utils.book_append_sheet(workbook, worksheet, 'Sheet1');

//     XLSX.writeFile(workbook, 'data_details.xlsx');
// }

const GetCommonData = async (fncName, objParam) => {
    if (fncName == "2_GetVendorDeviceRequestList") {
        isLoading.value = true;
    }
    var param = {
        func: fncName,
        param_arg: objParam
    };
    const response = await apiService.post('/api/HRGA/VendorDevice/Execute', param);
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        switch (fncName) {
            case "2_GetVendorDeviceRequestList":
                lstRequest.value = res.data;
                break;
            case "5_GetVendorDeviceRequestDetail":
                requestDetails.value = res.data;
                break;
        //     case "4_GetVendorDeviceDetailApproverList":
        //         const data = res.data;
        //     const requester = historyRequest.value.find(item => item.approved_status === 'Requested'
        //     );

        //     // Nếu tìm thấy requester, tạo object mới và thêm vào đầu danh sách
        //     if (requester) {
        //         const requesterObj = {
        //             ...requester,
        //             isRequester: true,
        //             badge_no: requester.approved_badge_no,
        //             username: requester.approved_name,
        //             division: requester.approved_division,
        //             department: requester.approved_deparment,
        //             position: requester.updated_position,
        //             title: requester.updated_title,
        //             comment: requester.comment,
        //             update_at : requester.update_at,
        //             flow_order:0,
        //             flow_status:'Requester'
        //         };
        //         data.unshift(requesterObj);
        //     }
        //         lstApprover.value = res.data;
        //         countFlowOrder.value = lstApprover.value.filter(item => item.flow_order === 3).length;
        //         break;
            case "3_GetVendorDeviceRequestHistoryList":
                historyRequest.value = res.data;
                break;
            case "6_SetVendorDeviceRequestInfo":
                gFunc.ShowMessage("Success");
                break;

            default:
                break;
        }
    }
    isLoading.value = false;
}

onMounted(async() => {
    
    // const response = await axios.get(`http://10.201.12.31:8019/api/approver/240794/Test%20api`)
    lstApprover.value = response.data
    var param = {
        body: "",
    }
    const responseTemplate = await apiService.post("/api/Safety/Checklists/get-all", param)
    templates.value = gFunc.CheckResData(responseTemplate).data;
    const responseItem = await apiService.post("/api/Safety/ChecklistsItem/get-all", param)
    items.value = gFunc.CheckResData(responseItem).data;
    const responseDevice = await apiService.post("/api/core/devices/get-all", param);
    devices.value = gFunc.CheckResData(responseDevice).data;
    const responseUsers = await apiService.post("/api/core/users/get-all", param);
    users.value = gFunc.CheckResData(responseUsers).data;
    const responseSite = await apiService.post("/api/Safety/CheckListResults/get-all", param);
    var res = gFunc.CheckResData(responseSite);
    lstRequest.value=res.data;
    // lstRequest.value = res.data.filter(item => String(item.userID) === authStore.userInfo.badge_no);
    lstRequest.value.forEach(Result => {
    const matchedDevice = devices.value.find(core => core.deviceID === Result.deviceID);
    Result.deviceCode = matchedDevice ? matchedDevice.deviceCode : 'Không xác định';
    const matchedTemplate = templates.value.find(core => core.templateID === Result.templateID);
    Result.templateName = matchedTemplate ? matchedTemplate.templateName : 'Không xác định';
    const matchedUser = users.value.find(core => core.badge_id === String(Result.userID));
    Result.employee_name = matchedUser ? matchedUser.employee_name : 'Không xác định';
  });

});
</script>
<template>

    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="50vh" class="mb-2"></Skeleton>
    </div>
    <div v-else class="card" style="padding: 1rem;">
        <Splitter style="height: calc(100vh - 13rem)">
            <SplitterPanel class="flex" :size="30" :minSize="10">
                <div class="w-full m-2 flex flex-col gap-2">
                    <div class="items-center text-center gap-2">
                        <label for="name" class="text-center"  ><b>List approve</b></label>
                    </div>
                    <div class="gap-2">
                        <ag-grid-vue class="ag-theme-alpine" style="width: 100%; height:calc(100vh - 17rem)"
                            :rowData="lstRequest" :columnDefs="columnNameDefs" :gridOptions="gridOptions"
                            :defaultColDef="defaultColDef" />
                    </div>
                </div>
            </SplitterPanel>
            <SplitterPanel class="flex" :size="70">
                <div class="w-full m-2 flex flex-col gap-2" v-if="_.toString(currApprSelected['checkResultID']) != ''">
                    <div class="items-center text-center gap-2"style="font-size: 14px;">
                        <label for="name" class="text-center"> <b>Details approve</b></label>
                    </div>
                    <label for="name" class="w-[120px] text-left"  >Title</label>
                    <div class="flex items-center gap-2">
                        <InputText id="name" disabled :value="`${currApprSelected.templateName}-${currApprSelected.deviceCode}`" class="w-full"
                            size="small"   />
                        
                    </div>
                    <!-- <div class="flex items-center gap-2">
                        <label for="name" class="w-[95px] text-left"   >Requester</label>
                        <div class="history-approve w-full">
                            <div v-for="(item, index) in historyRequest">
                                <div v-if="item['approved_flow_order'] != 1 && item.approved_status == 'Requested'">
                                    <div class="flex"  >
                                        <span><b>From:&nbsp;</b> {{ item.approved_name }}&nbsp; <span class="link-item">
                                                <{{ item.approved_email }}>
                                            </span>
                                        </span>
                                        <div class="flex ml-auto gap-2"  >
                                            <span><b>Sent:&nbsp;</b>{{ gFunc.ConvertDate(item.update_at) }}</span>
                                        </div>
                                    </div>
                                    <div class="flex"  >
                                        <span><b>Comment:&nbsp;</b></span>
                                        <div v-html="item.comment"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> -->

                    <div style="overflow-y: auto;">
                        <label for="name" class="w-[95px] text-left"  >Approvers</label>
                        <div class="flex items-center gap-2">
                            <div class="w-full p-1" id="lst-approve">
                                <InputGroup v-for="(item, index) in lstApprover">
                                    <InputGroupAddon class="p-2" >
                                        <Button
                                            :icon="_.toString(item.flowStatus) != '' && (index+1) < currApprSelected['flowOrder'] ? 'pi pi-check' : ''"
                                            style="width: 90px;font-size: 13px;" :style="gFunc.BindingColorApprove(item.flowStatus)"
                                            :label="item.flowStatus" severity="secondary" size="small" />
                                    </InputGroupAddon>
                                    <div  :style="gFunc.BindingColorLineApprove(index, currApprSelected, historyRequest)"
                                        class="editable-div"
                                        v-html="gFunc.BindingResultTextsearch(item, historyRequest)">
                                    </div>
                                </InputGroup>
                            </div>
                        </div>
                        <div class="flex items-center gap-2 mt-2">
                            <label for="name" class="w-[100px] text-left"  >Detail Data</label>
                            <!-- <div class="flex ml-auto gap-2">
                                <Button icon="pi pi-file-excel"  label="Download" v-on:click="DownloadExcel"
                                style="font-size: 13px; padding: 4px 8px;"
                                size="small" />
                            </div> -->
                        </div>
                        <div class="items-center gap-2 mt-2">
                            <ag-grid-vue v-if="_.toString(currApprSelected['overallStatus'])==='OK'" class="ag-theme-alpine" :style="{width: '100%', height:gridHeight}"
                                :rowData="requestDetails" :columnDefs="columnDetailsApproveDefs"
                                :gridOptions="gridDetailsOptions" :defaultColDef="defaultColDef" />
                            <ag-grid-vue v-if="_.toString(currApprSelected['overallStatus'])==='NG'" class="ag-theme-alpine" :style="{width: '100%', height:gridHeightNG}"
                                :rowData="requestDetails" :columnDefs="columnDetailsApproveDefsNG"
                                :gridOptions="gridDetailsOptionsNG" :defaultColDef="defaultColDef" />    
                        </div>
                        <!-- <div class="flex items-center gap-2 mt-2 comment-section">
                            <label for="name" class="w-[95px] text-left"  >Comment<b class="requied-color"> *</b></label>
                            <Editor v-model="apprComment" class="w-full" editorStyle="height: 100px" />
                        </div> -->
                    </div>
                </div>
            </SplitterPanel>
        </Splitter>

        <ConfirmDialog group="ConfirmSuccess">
            <template #container="{ message, acceptCallback, rejectCallback }">
                <div class="flex flex-col items-center p-8 bg-surface-0 dark:bg-surface-900 rounded">
                    <div
                        class="rounded-full bg-primary text-primary-contrast inline-flex justify-center items-center h-24 w-24 -mt-20">
                        <i class="pi pi-check-circle" style="font-size: 2.5rem"></i>
                    </div>
                    <span class="font-bold text-2xl block mb-2 mt-6">{{ message.header }}</span>
                    <p class="mb-0">{{ message.message }}</p>
                    <div class="flex items-center gap-2 mt-6">
                        <Button label="OK" @click="acceptCallback" class="w-32"></Button>
                    </div>
                </div>
            </template>
        </ConfirmDialog>

        <ConfirmDialog group="ConfirmQuestion">
            <template #container="{ message, acceptCallback, rejectCallback }">
                <div class="flex flex-col items-center p-8 bg-surface-0 dark:bg-surface-900 rounded">
                    <div
                        class="rounded-full bg-primary text-primary-contrast inline-flex justify-center items-center h-24 w-24 -mt-20">
                        <i class="pi pi-question" style="font-size: 2.5rem"></i>
                    </div>
                    <span class="font-bold text-2xl block mb-2 mt-6">{{ message.header }}</span>
                    <p class="mb-0">{{ message.message }}</p>
                    <div class="flex items-center gap-2 mt-6">
                        <Button label="Save" @click="acceptCallback" class="w-32"></Button>
                        <Button label="Cancel" outlined @click="rejectCallback" class="w-32"></Button>
                    </div>
                </div>
            </template>
        </ConfirmDialog>
        <ConfirmDialog group="ConfirmError">
            <template #container="{ message, acceptCallback, rejectCallback }">
                <div class="flex flex-col items-center p-8 bg-red-100 text-red-800 rounded">
                <div
                    class="rounded-full bg-red-500 text-white inline-flex justify-center items-center h-24 w-24 -mt-20">
                    <i class="pi pi-times-circle" style="font-size: 2.5rem"></i>
                </div>
                <span class="font-bold text-2xl block mb-2 mt-6">{{ message.header }}</span>
                <p class="mb-0">{{ message.message }}</p>
                <div class="flex items-center gap-2 mt-6">
                    <Button label="Yes" @click="acceptCallback" class="w-32" severity="danger"></Button>
                    <Button label="No" outlined @click="rejectCallback" class="w-32" severity="danger"></Button>
                </div>
                </div>
            </template>
            </ConfirmDialog>

    </div>

</template>

<style scoped>

.highcharts-button-box {
    fill: var(--surface-card) !important;
    /* Màu chữ */
}

.highcharts-credits {
    display: none;
}

.card {
    padding: 1.5rem;
}

.editable-div {
    border-top: 1px solid #ccc;
    border-right: 1px solid #ccc;
    border-radius: 0px 5px 5px 0px;
    padding: 0px 8px;
    min-height: 33px;
    overflow: auto;
    color: #64748b;
}
.ag-header,
.ag-row,
.ag-paging-panel,
.ag-center-cols-viewport,
.ag-cell-label-container {
    /* Màu nền */
    background-color: var(--surface-card) !important;
    color: var(--text-color) !important;
}

.ag-cell-label-container,
.ag-icon-filter {
    color: var(--primary-color) !important;
}


#lst-approve {
    border: 1px solid #babfc7;
    border-radius: 7px;
}

.p-accordionheader {
    padding: 0.5rem 1rem 0.5rem 0px !important;
}

.p-accordioncontent-content {
    padding: 0.5rem 0rem 0.5rem 0px !important;
}

.requied-color {
    color: var(--p-red-500);
}

#lst-approve .p-inputgroup button,
#lst-approve .p-inputgroup input {
    padding: 2px 4px;
}

.link-item {
    color: var(--p-blue-500);
    cursor: pointer;
    text-decoration: underline;
}

.ag-theme-alpine .ag-header-cell {
    padding: 0px 5px;
    /* Padding cho header */
}

.ag-theme-alpine .ag-cell-value {
    padding: 0px 5px;
    /* Padding cho row */
}

.ag-theme-alpine .ag-header-cell-label {
    justify-content: center;
    /* Căn giữa theo chiều ngang */
    align-items: center;
    /* Căn giữa theo chiều dọc */
}

.history-approve {
    max-height: 180px;
    border: 1px solid #babfc7;
    border-radius: 7px;
    overflow-y: auto;
    padding: 7px;
}
</style>
<style>
.cell-span {
  background-color: #ffffff;
  vertical-align: middle;
}
.ag-cell {
    border-right: 1px solid #ccc !important; /* Hien thi duong ke o cot */
}
.ag-header-cell {
    border-right: 1px solid #ccc !important; /* Loại bỏ đường kẻ ở cột cuối cùng */
}
.ag-row:last-child .ag-cell {
    border-right: none; /* Loại bỏ đường kẻ ở cột cuối cùng */
}
.ag-theme-alpine .ag-header-cell-label {
    justify-content: center;
    font-size: 13px;
    align-items: center;
    /* Căn giữa theo chiều dọc */
}
.ag-theme-alpine .ag-cell {
  font-size: 13px;
}
</style>
