<script setup>
import { ref, onMounted, inject, watch } from 'vue';
import BaseTable from '@/modules/holdLotManagement/component/BaseTable.vue';
import { useConfirm } from "primevue/useconfirm";
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import { hccCommonFunc } from '@/modules/hccControlPage/utils/hccCommonFunc';
import { Request } from '../models/Request';
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');
const part = ref([
    { name: 'In', code: '1' },
    { name: 'Out', code: '2' }
]);
const partInOut = ref(part.value[1]);
const hwTypeId = ref();
const hwType = ref([]);
const hwFilterCategory = ref();
const hwFilterFromDate = ref();
const hwIdxContent = ref();
const hwList = ref([]);
const hwListTableColumns = [
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
const hwSelected = ref({});
const btnFindLoading = ref(false);
const descInOutLocation = ref();
const listLocation = ref();
const outLocation = ref();
const listHwRequestType = ref();
const hwRequestType = ref();
const isUrgent = ref(false);
const purpose = ref();
const comment = ref();
const needDatetime = ref();
const returnPlanDate = ref();
const btnSubmitLoading = ref(false);
const confirm = useConfirm();
const authStore = useAuthStore();

function refreshData() {
    // Reset data
    hwList.value = [];
    initHwSelected();
    // Reset filter params
    hwTypeId.value = null;
    hwFilterCategory.value = null;
    hwFilterFromDate.value = null;
    hwIdxContent.value = null;
    // Reset request params
    hwRequestType.value = null;
    isUrgent.value = false;
    purpose.value = null;
    comment.value = null;
    needDatetime.value = null;
    returnPlanDate.value = null;
    // Update out location
    outLocation.value = getInOutLocation();
};

async function getHwTypeNo() {
    var response = await apiClient.callSp("CIMitar_HCC..USP_Get_HwTypeNo", {});
    return response[0]['data'];
};

async function getHwInfoViewMode() {
    btnFindLoading.value = true;
    var params = {
        "@hwType": hwTypeId.value ? hwTypeId.value['id'] : "1",
        "@category": hwFilterCategory.value ? hwFilterCategory.value['label'] : "Barcode",
        "@idxDesc": hwIdxContent.value ? hwIdxContent.value : "",
        "@idxDesc2": hwFilterFromDate.value ? gFunc.ConvertDate(hwFilterFromDate.value, "YYYY-MM-DD HH:mm:ss.SSS") : ""
    }
    var response = await apiClient.callSp("CIMitar_HCC..USP_Get_HwInfo_ViewMode", params);

    // Check response data
    if (response.length) {
        if (response[0]['data'].length) {
            // Filter data based on partInOut
            if (partInOut.value.code == "1") {
                hwList.value = response[0]['data'].filter(i => i.scodeid == "2");
            }
            else {
                hwList.value = response[0]['data'].filter(i => i.scodeid == "1");
            }
            if (hwList.value.length == 0) {
                refreshData();
                gFunc.ShowMessage('No data found.', 'error', '', 5000);
            }
        }
        else {
            refreshData();
            gFunc.ShowMessage('No data found.', 'error', '', 5000);
        }
    }
    else {
        refreshData();
        gFunc.ShowMessage('No data found.', 'error', '', 5000);
    }
    btnFindLoading.value = false;
};

function initHwSelected() {
    hwSelected.value = {};
    hwType.value.forEach(item => {
        hwSelected.value[item.hwdesc] = [];
    });
};

function handleSelectionChange(selectedItems) {
    const currentTableBarcodes = new Set(hwList.value.map(i => i.barcode));
    // Get hwType value
    const hwTypeValue = hwType.value.find(i => i.id === hwTypeId.value.id);
    const hwTypeDesc = hwTypeValue.hwdesc;
    const preservedItems = hwSelected.value[hwTypeDesc].filter(i => !currentTableBarcodes.has(i.barcode));
    hwSelected.value[hwTypeDesc] = [...preservedItems, ...selectedItems];

};

async function getDescInOutLocation() {
    var response = await apiClient.callSp("TestDB..USP_HCC_GetDescInOutLocation", {});
    return response[0]['data'];
};

function getInOutLocation() {
    if (!descInOutLocation.value) return;
    listLocation.value = descInOutLocation.value.filter(i => i.locationid == partInOut.value.code);
    return listLocation.value[0];
};

async function getHwRequestType() {
    var response = await apiClient.callSp("TestDB..USP_HCC_GetRequestType", {});
    return response[0]['data'];
};

async function requireConfirm() {
    btnSubmitLoading.value = true;
    confirm.require({
        group: 'headless',
        header: 'Are you sure to submit these information?',
        accept: async () => {
            await setRequestHwInfo();
        },
        reject: () => {

        }
    });
    btnSubmitLoading.value = false;
};

function checkHccResData(resData) {
    var isCheck = true;
    if (resData[0].data[0]['result'] == 0) {
        isCheck = false;
        gFunc.ShowMessage(resData[0].data[0]['message'], 'error', '', 3000);
    }
    return {
        isCheck: isCheck,
        data: resData[0].data[0]
    };
};

async function setRequestHwInfo() {
    const request = new Request({
        request_id: null,
        scode_id: outLocation.value.scodeid,
        location_id: outLocation.value.locationid,
        request_type_id: hwRequestType.value.request_type_id,
        is_urgent: isUrgent.value ? 1 : 0,
        purpose: purpose.value,
        comment: comment.value,
        hcc_comment: null,
        need_datetime: gFunc.ConvertDate(needDatetime.value),
        return_plan: gFunc.ConvertDate(returnPlanDate.value, 'YYYY-MM-DD') + ' 23:59:59',
        status_type_id: 1,
        status_sub_type_id: 0,
        req_by_badge: authStore.userInfo.badge_no,
        hcc_by_badge: null,
        sub_scode_id: null
    });
    
    // Set request hw info
    await hccCommonFunc.SetRequestHwInfo("INSERT", request, hwSelected);
    refreshData();
};

onMounted(async () => {
    hwType.value = await getHwTypeNo();
    initHwSelected();
    descInOutLocation.value = await getDescInOutLocation();
    outLocation.value = getInOutLocation();
    listHwRequestType.value = await getHwRequestType();
});

watch(partInOut, () => {
    refreshData();
}, { immediate: true });

watch(needDatetime, async (newNeedDatetime) => {
    if (newNeedDatetime) {
        const today = new Date();
        if (newNeedDatetime < today) {
            gFunc.ShowMessage('Need datetime must be greater than today.', 'error', '', 5000);
            // await nextTick();
            needDatetime.value = null;
        }
    }
});
</script>
<template>
    <div class="card grid grid-cols-2 gap-4">
        <h1 class="text-3xl font-bold">HCC Request Hardware</h1>
        <div class="flex justify-end">
            <FloatLabel variant="on" class="w-full max-w-xs">
                <Select v-model="partInOut" inputId="part_type" :options="part" optionLabel="name" class="w-full" />
                <label for="part_type">Part In/Out</label>
            </FloatLabel>
        </div>

        <FloatLabel variant="on">
            <Select v-model="hwTypeId" inputId="hw_type" :options="hwType" optionLabel="hwdesc" class="w-full" />
            <label for="hw_type">Hardware type</label>
        </FloatLabel>

        <FloatLabel variant="on">
            <Select v-model="hwFilterCategory" inputId="hw_category" :options="hwListTableColumns" optionLabel="label"
                class="w-full" />
            <label for="hw_category">Category</label>
        </FloatLabel>
        <FloatLabel variant="on">
            <DatePicker v-model="hwFilterFromDate" inputId="hw_date" showButtonBar class="w-full" />
            <label for="hw_date">From date</label>
        </FloatLabel>

        <FloatLabel variant="on">
            <InputText v-model="hwIdxContent" inputId="hw_index" class="w-full" />
            <label for="hw_index">Index content</label>
        </FloatLabel>
        <div>
            <Button label="Find" @click="getHwInfoViewMode" :loading="btnFindLoading"></Button>
        </div>
        <div class="col-span-2">
            <BaseTable :columns="hwListTableColumns" v-model:row-data="hwList" :selection="true" :searching="true"
                :title="hwTypeId?.hwdesc" @selection-change="handleSelectionChange" v-if="hwList?.length" />
        </div>
    </div>
    <div class="card" v-if="Object.values(hwSelected).some(arr => arr.length > 0)">
        <h1 class="text-3xl font-bold">List hardwares request {{ partInOut?.name }}</h1>
        <template v-for="(row, key) in hwSelected" :key="key">
            <div v-if="row.length > 0">
                <BaseTable :columns="hwListTableColumns" :row-data="row" :title="key" />
            </div>
        </template>
        <div class="grid grid-cols-2 gap-4 mt-4">
            <FloatLabel variant="on">
                <Select v-model="outLocation" inputId="out_location" :options="listLocation" optionLabel="locationdesc"
                    class="w-full" />
                <label for="out_location">In/Out location</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <Select v-model="hwRequestType" inputId="hw_request_type" :options="listHwRequestType"
                    optionLabel="request_type" class="w-full" />
                <label for="hw_request_type">Request type</label>
            </FloatLabel>
        </div>
        <div class="flex items-center gap-2 mt-4">
            <Checkbox v-model="isUrgent" inputId="is_urgent" binary />
            <label for="is_urgent">Is Urgent?</label>
        </div>
        <FloatLabel variant="on" class="mt-4">
            <Textarea v-model="purpose" inputId="purpose" size="large" class="w-full" />
            <label for="purpose">Purpose</label>
        </FloatLabel>
        <FloatLabel variant="on" class="mt-4">
            <Textarea v-model="comment" inputId="comment" size="large" class="w-full" />
            <label for="comment">Comment</label>
        </FloatLabel>
        <div class="grid grid-cols-2 gap-4 mt-4">
            <FloatLabel variant="on">
                <DatePicker v-model="needDatetime" inputId="need_datetime" showButtonBar show-time class="w-full" />
                <label for="need_datetime">Need datetime</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <DatePicker v-model="returnPlanDate" inputId="return_plan_date" showButtonBar class="w-full" />
                <label for="return_plan_date">Return plan date</label>
            </FloatLabel>
        </div>
        <div class="flex items-center gap-2 mt-4">
            <Button label="Submit" @click="requireConfirm" :loading="btnSubmitLoading"></Button>
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
<style scoped></style>
