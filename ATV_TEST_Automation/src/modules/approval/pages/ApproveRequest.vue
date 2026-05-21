<script setup>
import { inject, onMounted, ref, watch,computed } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/modules/core/services/BaseService";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import { EnCoApiClientService} from "@/modules/core/services/EnCoApiClientService";
import { useConfirm } from "primevue/useconfirm";
import _ from "lodash";
import moment from "moment";
import axios from 'axios'
const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();
const confirm = useConfirm();
const apprComment = ref("");
const lstApprover = ref([]);
const lstRequest = ref([]);
const requestDetails = ref([]);
const attachFiles = ref([]);
const historyRequest = ref([]);
const currApprSelected = ref({});
const apiClient = new EnCoApiClientService(import.meta.env.VITE_API_AUTH_URL);
const fileInput = ref(null);
// Khai báo props nhận từ component cha
const props = defineProps({
    message: "", // Prop truyền từ cha
});

const typeSendEmail = ref(1);
const optionsSendEmail = ref([
    { name: 'APPROVE', value: 0 },
    { name: 'TO', value: 1 },
    { name: 'CC', value: 2 },
    { name: 'BCC', value: 3 }
]);

const isLoading = ref(false);
const isLockButton = ref(false);

const lstVolGroupSelected = ref([]);

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
        field: "request_status",
        width: 80,
        // pinned: 'left',
        cellClass: () => {
            return 'link-item'
        },
        cellStyle: (params) => gFunc.BindingColorStatus("flow_status", params),
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
        width: 80
    },
    {
        headerName: "Employee ID", field: "user_requested_id",
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Full Name", field: "requested_name",
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Division", field: "division",
        cellStyle: { textAlign: 'center' },
        width: 130
    },
    {
        headerName: "Department", field: "department",
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Type", field: "item_name",
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Asset code", field: "asset_code",
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Mac Address", field: "mac_address",
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Start time", field: "start_time",
        valueFormatter: (params) => ConvertExcelDate(params),
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "End time", field: "end_time",
        valueFormatter: (params) => ConvertExcelDate(params),
        cellStyle: { textAlign: 'center' },
        width: 150
    },
    {
        headerName: "Purpose", field: "purpose",
        width: 150
    },
    {
        headerName: "Remark", field: "comment",
        valueFormatter: (params) => FormatData("comment", params),
        width: 150
    }
]);
// Dữ liệu cho bảng
const rowDataRegist = ref([]);

// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: true,
};
const gridOptions = {
    headerHeight: 35,
    rowHeight: 90,
}

const gridDetailsOptions = {
    headerHeight: 35,
    rowHeight: 30,
}
watch(lstVolGroupSelected, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        chartOptionsCol.value.series = newValue;

        rowDataFcstVolFilter.value = [];
        for (let index = 0; index < newValue.length; index++) {
            // Lọc ra những item có `code` bắt đầu bằng addedItems.code và chưa tồn tại trong lstGroupFilter
            const itemsToAdd = rowDataFcstVol.value.filter(
                (item) => item.key === newValue[index]['code']
            );
            if (itemsToAdd.length > 0) {
                rowDataFcstVolFilter.value.push(itemsToAdd[0]);
            }
        }
    } else {
        chartOptionsCol.value.series = [];
        rowDataFcstVolFilter.value = [];
    }
});

const FormatData = (colname, data) => {
    var ret = "";
    switch (colname) {
        case "comment":
            ret = _.toString(data.value['comment']);
            break;

        default:
            break;
    }
    return ret;
}

const BindingTitleApprove = (params) => {
    if (params) {
        return `
        <div>
          <p style="font-weight: bold">${params.value}</p>
          <p>Requester: ${params["data"]["requester_name"]}</p>
           <p>Request date: ${gFunc.ConvertDate(params["data"]["request_date"])}</p>
           <p>Id: ${params["data"]["request_id"]}</p>
        </div>
      `;
    }

};

const ValidateItem = (type) => {
    if (_.toString(apprComment.value) == '') {
        gFunc.ShowMessage("Comment is required", gVariable.messageType.error,"",3000);
        return;
    }

    confirm.require({
        group: 'ConfirmQuestion',
        header: 'Are you sure?',
        message: 'Please confirm to proceed.',
        accept: () => {
            // call api for submit request
            constActionClick(type);
        },
        reject: () => {
        }
    });

}


const constActionClick = async (type) => {
    // Set infor to update request
    isLockButton.value = true;
    const flowOrder = parseInt(currApprSelected.value["flow_order"], 10);
    var param = {
        // var request_info: {
            "@request_id": currApprSelected.value["request_id"],
            "@request_title": currApprSelected.value["request_title"],
            "@badgeno": authStore.userInfo.badge_no,
            "@flow_id": currApprSelected.value["flow_id"],
            "@comment": apprComment.value,
            "@flow_order": type == "Reject" ? 1001 : (isNaN(flowOrder) ? 0 : flowOrder) + 1,
            "@to": "",
            "@cc": "",
            "@bcc": "",
            "@lot": "TESTLOTWIP",
            "@dcc": ""
        // },
        // "request_details": [],
        // "request_attachments": []
    }

    const response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_SetRequest]",param,"CIMitar",false);
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        confirm.require({
            group: 'ConfirmSuccess',
            header: 'Successfully',
            message: 'Your request has been successfully submitted!',
            accept: () => {
                ClearData();
                GetCommonData("USP_HoldLotManagement_GetRequestList", {
                    "@badge_no": authStore.userInfo.badge_no,
                    "@flag": "APPROVER",
                    "@title": apprComment.value == "" ? "" : apprComment.value
                    }
                );

            },
            reject: () => {
            }
        });
    }
    isLockButton.value = false;
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

const GetDetailsData = (detailsData) => {
    currApprSelected.value = detailsData.data;
    // GetCommonData("GetSecurityRequestDetail", { request_id: detailsData.data.request_id });
    // GetCommonData("GetSecurityDetailApproverList", { request_id: detailsData.data.request_id });
    GetCommonData("USP_HoldLotManagement_GetDetailApproverList", { "@request_id": detailsData.data.request_id });
    // GetCommonData("GetSecurityRequestAttachement", { request_id: detailsData.data.request_id });
    GetCommonData("USP_HoldLotManagement_GetRequestHistoryList", { "@request_id": detailsData.data.request_id });

}

const ClearData = () => {
    apprComment.value = "";
    lstRequest.value = [];
    requestDetails.value = [];
    attachFiles.value = [];
    historyRequest.value = [];
    currApprSelected.value = {};
}

const ConvertExcelDate = (excelDate) => {
    return moment(excelDate.value).format('YYYY-MMM-DD')
}

const GetFileInfo = async (item) => {
    var objParam = {
        file_name: item.file_name,
        file_path: item.file_path,
    };

    const response = await apiService.postGetFile('/GetFile', objParam);
    const url = window.URL.createObjectURL(new Blob([response]));
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', item.file_name);
    document.body.appendChild(link);
    link.click();
};

const GetCommonData = async (fncName, objParam) => {
    // if (fncName == "GetSecurityRequestList") {
    //     isLoading.value = true;
    // }
    // var param = {
    //     func: fncName,
    //     param_arg: objParam
    // };
    // const response = await apiService.post('/api/HRGA/Security/Execute', param);

    const response = await apiClient.callSp("TestDB.."+fncName, objParam);
    var res = response[0];
    // if (res.isCheck) {
        switch (fncName) {
            case "USP_HoldLotManagement_GetRequestList":
                lstRequest.value = res.data;
                break;
    //         case "GetSecurityRequestDetail":
    //             requestDetails.value = res.data;
    //             break;
            case "USP_HoldLotManagement_GetDetailApproverList":
                lstApprover.value = res.data;
                break;
    //         case "GetSecurityRequestAttachement":
    //             attachFiles.value = res.data;
    //             break;
            case "USP_HoldLotManagement_GetRequestHistoryList":
                historyRequest.value = res.data;
                break;
    //         case "SetSecurityRequestInfo":
    //             gFunc.ShowMessage("Success");
    //             break;
            default:
                break;
        }
    // }
    isLoading.value = false;
};

const SelectFileAttach = () => {
    fileInput.value.click();
}

const handleFileUpload = (event) => {
    attachFiles.value = [];
    const files = event.target.files;
    if (files.length > 0) {
        for (let i = 0; i < files.length; i++) {
            const file = files[i];
            const reader = new FileReader();
            reader.onload = (e) => {
                const base64String = e.target.result;
                attachFiles.value.push({
                    file_name: file.name,
                    file_mime_type: file.type,
                    file_content_json: base64String,
                });
            };
            reader.readAsDataURL(file);

        }
    }
};

const RemoveItemAttach = (index) => {
    attachFiles.value.splice(index, 1);
}
async function UploadFile(){
    var metadata = {
        AppName: "EsiMonacoHoldLotManagement",
        SaveMode: "KeepName",
        uploadedBy: authStore.userInfo.badge_no,
        uploadTimestamp: new Date().toISOString(),
    };
    var response = apiClient.uploadFile(attachFiles.value[0].file_content_json, metadata);
    
};
onMounted(() => {
    // GetCommonData("GetSecurityRequestList", { badge_no: authStore.userInfo.badge_no, flag: "APPROVER" });
    GetCommonData("USP_HoldLotManagement_GetRequestList", { "@badge_no": authStore.userInfo.badge_no, "@flag": "APPROVER", "@title":"" });
    // GetCommonData("GetSecurityRequestList", { badge_no: '70971', flag: "APPROVER" });

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
                <div class="w-full m-2 flex flex-col gap-2" v-if="_.toString(currApprSelected['request_id']) != ''">
                    <div class="items-center text-center gap-2">
                        <label for="name" class="text-center"> <b>Details approve</b></label>
                    </div>
                    <div class="flex items-center gap-2">
                        <label for="name" class="w-[120px] text-left">Title</label>
                        <InputText id="name" disabled v-model="currApprSelected['request_title']" class="w-full"
                            size="small" />

                        <div class="flex ml-auto gap-2">
                            <Button :loading="isLockButton" label="Reject" severity="danger" size="small"
                                v-on:click="ValidateItem('Reject')" icon="pi pi-times-circle"></Button>
                            <Button :loading="isLockButton" label="Approve" size="small"
                                v-on:click="ValidateItem('Approve')" icon="pi pi-verified"></Button>
                        </div>
                    </div>
                    <div class="flex items-center gap-2">
                        <label for="name" class="w-[95px] text-left">Requester</label>
                        <div class="history-approve">
                            <div v-for="(item, index) in historyRequest">
                                <div v-if="item['approved_flow_order'] != 1 && item.approved_status == 'Requested'">
                                    <div class="flex">
                                        <span><b>From:&nbsp;</b> {{ item.approved_name }}&nbsp; <span class="link-item">
                                                <{{ item.approved_email }}>
                                            </span>
                                        </span>
                                        <div class="flex ml-auto gap-2">
                                            <span><b>Sent:&nbsp;</b>{{ gFunc.ConvertDate(item.update_at) }}</span>
                                        </div>
                                    </div>
                                    <div class="flex">
                                        <span><b>Comment:&nbsp;</b></span>
                                        <div v-html="item.comment"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div style="overflow-y: auto;">
                        <div class="flex items-center gap-2">
                            <label for="name" class="w-[95px] text-left">Approvers</label>
                            <div class="w-full p-1" id="lst-approve">
                                <InputGroup v-for="(item, index) in lstApprover">
                                    <InputGroupAddon class="p-2" >
                                        <Button
                                            :icon="_.toString(item.flow_status) != '' && (index + 1) < currApprSelected['flow_order'] ? 'pi pi-check' : ''"
                                            style="width: 80px;" :style="gFunc.BindingColorApprove(item.flow_status)"
                                            :label="item.flow_status" severity="secondary" size="small" />
                                    </InputGroupAddon>
                                    <div  :style="gFunc.BindingColorLineApprove(index, currApprSelected, historyRequest)"
                                        class="editable-div"
                                        v-html="gFunc.BindingResultTextsearch(item, historyRequest)">
                                    </div>
                                </InputGroup>
                            </div>
                        </div>
                        <!-- <div class="flex items-center gap-2" v-if="attachFiles.length > 0">
                            <label for="name" class="w-[100px] text-left">Attach file</label>

                            <span v-for="(item, index) in attachFiles" class="p-1 link-item"
                                v-on:click="GetFileInfo(item)">
                                {{ item.file_name }}
                            </span>
                        </div> -->
                        <div class="flex items-center mt-2 mb-2">
                            <label for="name" class="w-[100px] text-left">Attach file<b class="requied-color"> *</b></label>
                            <div class="flex">
                                <Button label="Choose" v-on:click="SelectFileAttach()" icon="pi pi-paperclip px-1"
                                    size="small"></Button>
                            </div>
                            <input type="file" ref="fileInput" style="display: none;" @change="handleFileUpload" multiple />
                            <div>
                                <p v-for="(item, index) in attachFiles">
                                    {{ item.file_name }}<Button icon="pi pi-times" v-on:click="RemoveItemAttach(index)"
                                        style="color: var(--p-red-500)" size="small" variant="text" rounded
                                        aria-label="Cancel" />
                                </p>
                            </div>
                            <!-- <div>
                                <Button label="Submit" v-on:click="UploadFile"></Button>
                            </div> -->
                        </div>
                        <div class="flex items-center gap-2 mt-2" v-if="requestDetails.length > 0">
                            <label for="name" class="w-[100px] text-left">Details data</label>
                            <ag-grid-vue class="ag-theme-alpine" style="width: 100%; height:20vh"
                                :rowData="requestDetails" :columnDefs="columnDetailsApproveDefs"
                                :gridOptions="gridDetailsOptions" :defaultColDef="defaultColDef" />
                        </div>
                        <div class="flex items-center gap-2 mt-2">
                            <label for="name" class="w-[95px] text-left">Comment<b class="requied-color"> *</b></label>
                            <Editor v-model="apprComment" class="w-full" editorStyle="height: 100px" />
                        </div>

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
    </div>

</template>

<style>
.link-item {
    color: var(--p-blue-500);
    cursor: pointer;
    text-decoration: underline;
}
</style>
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
    width: 99% !important;
    max-height: 180px;
    border: 1px solid #babfc7;
    border-radius: 7px;
    overflow-y: auto;
    padding: 7px;
}
</style>
