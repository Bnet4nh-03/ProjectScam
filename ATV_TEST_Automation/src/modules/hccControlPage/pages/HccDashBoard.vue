<script setup>
import { ref, onMounted, onUnmounted, inject, watch, computed } from 'vue';
import BaseTable from '@/modules/holdLotManagement/component/BaseTable.vue';
import PartInOut from '@/modules/hccControlPage/component/PartInOut.vue';
import { useConfirm } from "primevue/useconfirm";
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import { hccCommonFunc } from '@/modules/hccControlPage/utils/hccCommonFunc';
import { Request } from '../models/Request';
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');
const gVariable = inject('gVariable');
// Get hardware info
const descInOutAction = ref();
const descInOutLocation = ref();
// Get hardware request info
const hwRequestType = ref("");
const outLocation = ref("");
const isUrgent = ref(false);
const purpose = ref();
const comment = ref();
const needDatetime = ref();
const returnPlanDate = ref();
const hwRequestStatusType = ref();
const hwRequestStatusSubType = ref();
const hwRequestedProgressing = ref();
const hwRequestStatusOverview = ref([]);
const requestList = ref([]);
const selectedRequestItem = ref();
const requestHwHistory = ref([]);
//  Request status info
const requestStatusFlowOut = ref([1, 2, 3, 5, 6, 7]);
const requestStatusFlowIn = ref([1, 2, 3, 4, 6, 7]);
const requestStatusReject = ref([7]);
const currentRequestStatus = ref("");
const nextRequestStatus = ref("");
const nextRequestStatusSub = ref([]);
const statusDescList = ref([]);
const selectedRequestStatusSub = ref("");

// show_request_status_counter
const diffTotal = ref();
const diffRequest = ref();

//
const listRequestStatus = ref(["All", "Processing", "Done"]);
const filterRequestStatus = ref(listRequestStatus.value[0])
const listRealtimeUpdate = ref(["Yes", "No"]);
const filterRealtimeUpdate = ref(listRealtimeUpdate.value[1])
const filterStartCreateTime = ref()
const filterEndCreateTime = ref()
const filterStatus = ref("Request")
const filterPriority = ref("All")
//
const intervalTime = 20 * 1000;
var timer = null;
// HCC part in out action information
const hwPartInOutScodeId = ref();
const hwPartInOutLocationId = ref();
const hwPartInOutActionInfo = ref({});
const hwRequestedIdList = ref([]);
const hccComment = ref('');
// Store hardware items requested in request info
const hwType = ref([]);
const requestHwItems = ref({});
const confirm = useConfirm();
const btnSubmitLoading = ref(false);
const authStore = useAuthStore();
const requestStatusColor = ref({
    'Request': '#99cfff',
    'Preparing': '#ffe680',
    'Ready to delivery': '#99e699',
    'In': '#80dfff',
    'Out': '#b3b3b3',
    'Received': '#b3ff99',
    'Reject': '#ff9999',
    'Cancel': '#d9d9d9'
})

const requestTableColumns = ref([
    { label: 'In/Out', field: 'In/Out' },
    { label: 'Location', field: 'Location' },
    { label: 'Request Type', field: 'Request Type' },
    { label: 'Urgent?', field: 'Urgent?' },
    { label: 'Status', field: 'Status', type: 'status' },
    { label: 'Request Hardware List', field: 'Request Hardware List' },
    { label: 'Purpose', field: 'Purpose' },
    { label: 'Comment', field: 'Comment' },
    { label: 'HCC Comment', field: 'HCC Comment' },
    { label: 'Requester Badge',field: 'Requester Badge'},	
    { label: 'Requester',field: 'Requester'},
    { label: 'HCC Emp Badge', field: 'HCC Emp Badge' },
    { label: 'HCC Emp', field: 'HCC Emp' },
    { label: 'Sub status', field: 'Sub status' },
    { label: 'Sub Location', field: 'Sub Location' },
    { label: 'Need Datetime', field: 'Need Datetime' },
    { label: 'Return Plan', field: 'Return Plan' },
    { label: 'Create Time', field: 'Create Time' },
    { label: 'Update Time', field: 'Update Time' },
    { label: 'Request ID', field: 'Request ID' },
    { label: 'Scode Id', field: 'scode_id' },
    // { label: 'Location Id', field: 'location_id' },
    // { label: 'Request By Badge', field: 'req_by_badge' },
    // // { field: 'request_type_id' },
    // { field: 'sub_scode_id' },

])

const requestHwTableColumn = ref([
    { label: 'Status', field: 'Status', type: 'status' },
    { label: 'Sub Status', field: 'Sub Status' },
    { label: 'HCC Comment', field: 'HCC Comment' },
    { label: 'Requester Badge', field: 'Requester Badge' },
    { label: 'Requester', field: 'Requester' },
    { label: 'HCC Emp Badge', field: 'HCC Emp Badge' },
    { label: 'HCC Emp', field: 'HCC Emp' },
    { label: 'Action Date', field: 'Action Date' }
]);

const hwItemTableColumns = [
    { label: "Barcode", field: 'barcode' },
    { label: "Location", field: 'hclocation' },
    { label: "Customer code", field: 'customer' },
    // {field: 'scodedesc' },
    { label: "Customer name", field: 'customername' },
    { label: "Nickname", field: 'nickname' },
    { label: "Device", field: 'device' },
    { label: "Memo", field: 'memo' },
    { label: "Notice", field: 'notice' },
    { label: "Package type", field: 'pkgtype' },
    // {field: 'typedesc' },
    { label: "PDL", field: 'pdl' },
    // {field: 'statusdesc' }
];
async function refreshData() {
    gFunc.ShowMessage('Refreshing data...', 'success', '', 3000);
    selectedRequestItem.value = null;
    requestHwHistory.value = [];
    // initRequestHwItems();
    var params = {
        "@start_time": null,
        "@end_time": null,
    }
    if (filterStartCreateTime.value && filterEndCreateTime.value) {
        if (filterStartCreateTime.value > filterEndCreateTime.value) {
            gFunc.ShowMessage('Start time must be less than end time', 'error', '', 5000);
            return;
        }
        params = {
            "@start_time": gFunc.ConvertDate(filterStartCreateTime.value, 'YYYY-MM-DD') + ' 00:00:00',
            "@end_time": gFunc.ConvertDate(filterEndCreateTime.value),
        }
    }
    hwRequestStatusOverview.value = await getReqHwStatusOverview(params);
    params = {
        "@start_create_time": params['@start_time'],
        "@end_create_time": params['@end_time'],
        "@flag": filterRequestStatus.value
    }
    requestList.value = await getHccRequestInOutRequestList(params);
    if (requestList.value.length) {

    }
    else {
        gFunc.ShowMessage('No data found in this time range', 'error', '', 5000);
    }
};

async function getReqHwStatusOverview(params) {
    try {
        var response = await apiClient.callSp('ATV_Common..USP_Get_HCC_RequestInOut_RequestHwStatusOverview', params);
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get request status overview', 'error', '', 5000);
    }
};

async function getHccRequestInOutRequestList(params) {
    try {
        var response = await apiClient.callSp('ATV_Common..USP_Get_HCC_RequestInOut_RequestList_P2', params);
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get request list', 'error', '', 5000);
    }
};

const getDynamicStyle = (statusType) => {
    const baseStyle = {
        borderRadius: '0.5rem',
        padding: 'calc(-1px + 1rem)',
    };
    // Add conditional logic based on status
    return { ...baseStyle, borderLeft: '10px solid ' + requestStatusColor.value[statusType] };
};

async function getRequestStatusType() {
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_GetRequestStatusType', {});
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get request status type', 'error', '', 5000);
    }
};

async function getRequestStatusSubType() {
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_GetRequestStatusSubType', {});
        return response[0]['data'];
    } catch (error) {
        gFunc.ShowMessage('Error get request status sub type', 'error', '', 5000);
    }
};

function handleSelectionChange(selectedItems) {
    requestHwHistory.value = [];
    selectedRequestItem.value = selectedItems;
};

async function getHwTypeNo() {
    var response = await apiClient.callSp("CIMitar_HCC..USP_Get_HwTypeNo", {});
    return response[0]['data'];
};

function initRequestHwItems() {

    requestHwItems.value = {};
    hwType.value.forEach(item => {
        requestHwItems.value[item['hwdesc']] = [];
    });
};

async function handleRequestClicked() {
    if (selectedRequestItem.value) {
        // Get request hw history
        requestHwHistory.value = await getHccRequestInOutRequestHwHistory();
        // Get list hw's id requested
        hwRequestedIdList.value = await getHwRequestedIdList();
        // Get hw requested info
        initRequestHwItems();
        if (hwRequestedIdList.value) {
            hwRequestedIdList.value.forEach(async (item) => {
                var hwInfo = await getHwRequestedInfo(item['request_hw_id']);
                requestHwItems.value[hwInfo[0]["hw_type_desc"]].push(hwInfo[0]);
            })
        }
        // Set hw requested info
        outLocation.value = selectedRequestItem.value['Location'];
        hwRequestType.value = selectedRequestItem.value['Request Type'];
        isUrgent.value = selectedRequestItem.value['Urgent?'] == 1;
        purpose.value = selectedRequestItem.value['Purpose'];
        comment.value = selectedRequestItem.value['Comment'];
        needDatetime.value = selectedRequestItem.value['Need Datetime'];
        returnPlanDate.value = selectedRequestItem.value['Return Plan'];
        storeRequestStatusInfo();
    }
    else {
        gFunc.ShowMessage('Please select a request', 'error', '', 5000);
    }
};

async function getHccRequestInOutRequestHwHistory() {
    var params = {
        "@request_id": selectedRequestItem.value['Request ID']
    }
    try {
        var response = await apiClient.callSp('ATV_Common..USP_Get_HCC_RequestInOut_RequestHwHistory', params);
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get request hw history', 'error', '', 5000);
    }
};

async function getHwRequestedIdList() {
    var params = {
        "@request_id": selectedRequestItem.value['Request ID']
    }
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_GetHwRequestedIdList', params);
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get request hw requested id list', 'error', '', 5000);
    }
};

async function getHwRequestedInfo(requestHwId) {
    var params = {
        "@request_hw_id": requestHwId
    }
    try {
        var response = await apiClient.callSp('ATV_Common..USP_Get_HCC_RequestInOut_HwRequestedInfo', params);
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get request hw requested info: ' + requestHwId, 'error', '', 5000);
    }
};

function storeRequestStatusInfo() {
    const inOut = selectedRequestItem.value["In/Out"];
    var flowIds = [];

    if (inOut === "OUT") {
        flowIds = requestStatusFlowOut.value;
        hwPartInOutScodeId.value = selectedRequestItem.value['scode_id'];
        hwPartInOutLocationId.value = selectedRequestItem.value['location_id'];

    } else if (inOut === "IN") {
        flowIds = requestStatusFlowIn.value;
    }

    statusDescList.value = flowIds
        .map(id => hwRequestStatusType.value.find(status => status.status_type_id === id))
        .filter(item => item !== undefined);
    currentRequestStatus.value = selectedRequestItem.value["Status"];
    var currentRowIndex = statusDescList.value.findIndex(item => item.status_type == currentRequestStatus.value);
    nextRequestStatus.value = currentRowIndex + 1 < statusDescList.value.length ? statusDescList.value[currentRowIndex + 1]["status_type"] : "";
};

async function requireConfirm(statusType) {
    btnSubmitLoading.value = true;
    gFunc.ShowMessage(statusType, 'success', '', 3000);
    // Check status type and user permission
    if (statusType == "Received" && authStore.userInfo.badge_no == selectedRequestItem.value['Requester Badge']) {
        if (!authStore.HasPermission(gVariable.permission.hcc.hcc_io_hcc_action)) {
            gFunc.ShowMessage("Can not 'Received' action. You are not requester of this request.", 'error', '', 3000);
        }
    }

    confirm.require({
        group: 'headless',
        header: 'Are you sure to submit these information?',
        accept: async () => {
            var statusTypeId = hwRequestStatusType.value.find(item => item.status_type == statusType)['status_type_id'];
            await setRequestHwInfo(statusTypeId);
        },
        reject: () => {

        }
    });
    btnSubmitLoading.value = false;
};

async function setRequestHwInfo(statusTypeId) {
    var statusSubType = hwRequestStatusSubType.value.find(item => item.status_type_id == statusTypeId);
    var statusSubTypeId = statusSubType ? statusSubType['status_sub_type_id'] : 0;
    const request = new Request({
        request_id: selectedRequestItem.value['Request ID'],
        scode_id: selectedRequestItem.value['scode_id'],
        location_id: selectedRequestItem.value['location_id'],
        request_type_id: selectedRequestItem.value['request_type_id'],
        is_urgent: selectedRequestItem.value['Urgent?'],
        purpose: selectedRequestItem.value['Purpose'],
        comment: selectedRequestItem.value['Comment'],
        hcc_comment: hccComment.value || '',
        need_datetime: selectedRequestItem.value['Need Datetime'],
        return_plan: selectedRequestItem.value['Return Plan'],
        status_type_id: statusTypeId,
        status_sub_type_id: statusSubTypeId,
        req_by_badge: selectedRequestItem.value['Requester Badge'],
        hcc_by_badge: authStore.userInfo.badge_no,
        sub_scode_id: null
    });

    // Set request hw info
    await hccCommonFunc.SetRequestHwInfo("UPDATE", request, requestHwItems);
    if (nextRequestStatus == "Out") {
        // Update hw state info
        for (const [key, value] of Object.entries(requestHwItems.value)) {
            for (const row of value) {

            }
        }
    }

    await refreshData();
};

async function setHccUpdateStateInfo() {

    var params = {
        // "@hwTypeNo": ,// BIGINT,
        // "@barcode": ,// VARCHAR(50),
        // "@s_code_id": ,// BIGINT,
        // "@s_code_location": ,// BIGINT,
        // "@inoutActions": ,// VARCHAR(MAX) = 'N/A',
        // "@inoutComment": ,// NVARCHAR(MAX) = '',
        // "@memo": ,// NVARCHAR(MAX) = '',
        // "@notice": ,// NVARCHAR(MAX) = '',
        // "@lic_Hcc": ,// NVARCHAR(50) = '',
        // "@lic_Req": ,// NVARCHAR(50) = '',
        // "@extra": ,// NVARCHAR(MAX) = '',
        // "@testerId": ,// INT = 0
    };
    var response = await apiClient.callSp('CIMitar_HCC.dbo.USP_Update_StateInfo', params);
};

async function getDescInOutAction() {
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_GetDescInOutActions', {});
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get desc in out action', 'error', '', 5000);
    }
};

async function getDescInOutLocation() {
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_GetDescInOutLocation', {});
        return response[0]['data'] || [];
    } catch (error) {
        gFunc.ShowMessage('Error get desc in out location', 'error', '', 5000);
    }
};

function getActionsForHwType(hwType) {
    return descInOutAction.value
        .filter(a => a.hwtype === hwType && a.onflag === 1)
        .map(a => a.actdesc);
};

function handleUpdate({ hwTypeDesc, stateInfo }) {
    hwPartInOutActionInfo[hwTypeDesc] = stateInfo;
};

onMounted(async () => {
    // Set default date range
    const today = new Date();
    const yesterday = new Date(today);
    yesterday.setDate(today.getDate() - 1);
    filterStartCreateTime.value = yesterday;
    filterEndCreateTime.value = today;
    // Get hw type
    hwType.value = await getHwTypeNo();
    // Get desc in out action
    descInOutAction.value = await getDescInOutAction();
    // Get desc in out location
    descInOutLocation.value = await getDescInOutLocation();
    // Get request status type: Request, Preparing, Ready to delivery , In, Out, Received, Reject, Cancel, Return
    hwRequestStatusType.value = await getRequestStatusType();
    // Get request status sub type: Out by CIMitar HCC, Out by HCC Request Page, In by CIMitar HCC, In by HCC Request Page
    hwRequestStatusSubType.value = await getRequestStatusSubType();
    // await refreshData();
    // diffRequest.value = hwRequestStatusOverview.value[0].row_count;
});

onUnmounted(() => {
    clearInterval(timer);
    timer = null;
});

watch([filterRequestStatus, filterStartCreateTime, filterEndCreateTime, filterStatus, filterPriority], async () => {
    await refreshData();
});

watch(filterRealtimeUpdate, (newVal) => {

    if (newVal === 'Yes') {
        timer = setInterval(refreshData, intervalTime);
    } else {
        clearInterval(timer);
        timer = null;
    }
});
</script>
<template>
    <div class="card">
        <h1 class="text-3xl font-bold mb-4">HCC Dashboard</h1>
        <div class="grid gap-4"
            :style="{ gridTemplateColumns: `repeat(${hwRequestStatusOverview.length}, minmax(0, 1fr))` }">
            <div v-for="(value, index) in hwRequestStatusOverview" :key="index" class="col-12 md:col-4">
                <!-- PrimeVue Card replaces metric_col.container -->
                <Card :style="getDynamicStyle(value.status_type)">
                    <template #title>
                        {{ value.status_type }}
                    </template>
                    <template #content>
                        <span class="text-2xl font-bold">
                            {{ value.row_count || 0 }}
                        </span>
                    </template>
                </Card>
            </div>
        </div>
        <div class="grid grid-cols-2 gap-4 mt-4 mb-4">
            <FloatLabel variant="on">
                <Select v-model="filterRequestStatus" :options="listRequestStatus" class="w-full" />
                <label>Request status</label>
            </FloatLabel>

            <FloatLabel variant="on">
                <Select v-model="filterRealtimeUpdate" :options="listRealtimeUpdate" class="w-full" />
                <label>Realtime update</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <DatePicker v-model="filterStartCreateTime" showButtonBar showIcon class="w-full" />
                <label>From date</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <DatePicker v-model="filterEndCreateTime" showButtonBar showIcon class="w-full" />
                <label>To date</label>
            </FloatLabel>
        </div>
        <BaseTable :row-data="requestList" :columns="requestTableColumns" :selection=true
            @selection-change="handleSelectionChange" selectionMode="single" @request-clicked="handleRequestClicked"
            v-if="requestList?.length" />
        <BaseTable :row-data="requestHwHistory" :columns="requestHwTableColumn" title="Request History"
            v-if="requestHwHistory?.length" />
        <div v-if="requestHwHistory?.length">
            <h1 class="table-title mb-4">Request Detail</h1>
            <template v-for="(row, key) in requestHwItems" :key="key">
                <div v-if="row.length > 0">
                    <BaseTable :columns="hwItemTableColumns" :row-data="row" :title="key" />
                    <PartInOut :item="row[0]" :inoutActions="getActionsForHwType(row[0]['hw_type'])"
                        :userInfor
                        @update-state="handleUpdate" v-if="nextRequestStatus == 'Out'" />
                </div>
            </template>
            <div class="grid grid-cols-2 gap-4 mt-4">
                <FloatLabel variant="on">
                    <Select disabled v-model="outLocation" :options="[outLocation]" class="w-full" />
                    <label>Out location</label>
                </FloatLabel>
                <FloatLabel variant="on">
                    <Select disabled v-model="hwRequestType" :options="[hwRequestType]" class="w-full" />
                    <label>Request type</label>
                </FloatLabel>
            </div>
            <div class="flex items-center gap-2 mt-4">
                <Checkbox disabled v-model="isUrgent" binary />
                <label>Is Urgent?</label>
            </div>
            <FloatLabel variant="on" class="mt-4">
                <Textarea disabled v-model="purpose" size="large" class="w-full" />
                <label>Purpose</label>
            </FloatLabel>
            <FloatLabel variant="on" class="mt-4">
                <Textarea disabled v-model="comment" size="large" class="w-full" />
                <label>Comment</label>
            </FloatLabel>
            <div class="grid grid-cols-2 gap-4 mt-4">
                <FloatLabel variant="on">
                    <DatePicker disabled v-model="needDatetime" class="w-full" />
                    <label>Need datetime</label>
                </FloatLabel>
                <FloatLabel variant="on">
                    <DatePicker disabled v-model="returnPlanDate" class="w-full" />
                    <label>Return plan date</label>
                </FloatLabel>
            </div>
            <FloatLabel variant="on" class="mt-4">
                <Textarea v-model="hccComment" size="large" class="w-full" />
                <label>HCC Comment</label>
            </FloatLabel>
        </div>

        <div class="grid gap-4 mt-4" :style="{
            gridTemplateColumns: `repeat(${statusDescList.length}, minmax(0, 1fr))`
        }" v-if="requestHwHistory?.length">
            <div v-for="(row, key) in statusDescList" :key="key">
                <Button :label="row.status_type" severity="secondary" size="large"
                    :style="{ backgroundColor: requestStatusColor[row.status_type] }"
                    :disabled="row.status_type != nextRequestStatus" @click="requireConfirm(row.status_type)"
                    :loading="btnSubmitLoading" />
            </div>
        </div>
    </div>
    <ConfirmDialog group="headless">
        <template #container="{ message, acceptCallback, rejectCallback }">
            <div class="p-4 bg-white dark:bg-gray-800 rounded-lg shadow-lg">
                <div class="font-semibold text-lg mb-2">{{ message.header }}</div>
                <p class="mb-4">{{ message.message }}</p>
                <div class="flex justify-end gap-2">
                    <Button label="Cancel" severity="secondary" @click="rejectCallback" />
                    <Button label="Confirm" @click="acceptCallback" />
                </div>
            </div>
        </template>
    </ConfirmDialog>
</template>
<style scoped>
.table-title {
    font-size: 1.5rem;
    font-weight: 600;
    color: #2d3748;
}
</style>
