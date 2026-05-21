<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/modules/core/services/BaseService";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnButtonAction from '@/modules/oldSource/components/AgridAction/ButtonAction.vue';
import { useConfirm } from "primevue/useconfirm";

import varialbe from "@/utils/variable";
import { pull } from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();
const confirm = useConfirm();
const isLoading = ref(false);

const scheduleName = ref(null);
const isShowDialogCud = ref(false);


const HeaderDialogCud = ref("Add new data");
const scheduleType = ref({
    code: 'daily',
    name: 'daily',
});

const lstScheduleType = ref([
    {
        code: 'daily',
        name: 'daily',
    },
    {
        code: 'weekly',
        name: 'weekly',
    },
    {
        code: 'monthly',
        name: 'monthly',
    }
])

const lstDayOfWeek = ref(["MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"]);


const selectedSchedule = ref({
    job_id: "",
    job_name: "",
    bat_content: "",
    schedule_type: "daily",
    start_time: new Date(),
    interval_minutes: 60,
    days_of_week: null,
    days_of_month: null,
    delete_flag: false,
    log_path: "",
})


const lstSchedule = ref([]);

// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: false,
};
const gridOptions = {
    headerHeight: 35,
    rowHeight: 30,
}

const columnDef = ref([
    {
        headerName: "No",
        field: "No",
        valueGetter: "node.rowIndex + 1",
        cellStyle: { textAlign: 'center' },
        width: 80
    },
    {
        headerName: "job_id", field: "job_id",
        width: 200
    },
    {
        headerName: "job_name", field: "job_name",
        width: 150,
        cellStyle: { textAlign: 'right' },
    },
    {
        headerName: "status", field: "status",
        width: 90,
        cellStyle: { textAlign: 'center' },
    },
    {
        headerName: "schedule_type", field: "schedule_type",
        width: 180,
        cellStyle: { textAlign: 'center' },
    },

    {
        headerName: "start_time", field: "start_time",
        width: 140,
        cellStyle: { textAlign: 'right' },
    },
    {
        headerName: "interval_minutes", field: "interval_minutes",
        width: 150,
        cellStyle: { textAlign: 'right' },
        valueFormatter: params => {
            return params.value === 0 ? '' : params.value;
        }
    },
    // {
    //     headerName: "bat_file_path", field: "bat_file_path",
    //     flex: 1
    // },
    {
        headerName: "log_path", field: "log_path",
        flex: 1
    },
    {
        headerName: "bat_content", field: "bat_content",
        // width: 120
        // cellRenderer: (params) => BindingButtonBatContent(params),
        cellRenderer: CpnButtonAction,
        cellRendererParams: (params) => ({ data: params.data, tableId: "rpa-listSchedule-batContent" }),
        cellStyle: { textAlign: 'center' },
        width: 120
    },
    {
        headerName: "Exec his", field: "Exec his",
        cellRenderer: CpnButtonAction,
        cellRendererParams: (params) => ({
            data: params.data,
            tableId: "rpa-listSchedule-execHis"
        }),
        cellStyle: { textAlign: 'center' },
        width: 100
    },
    {
        headerName: "Action", field: "Action",
        cellRenderer: CpnButtonAction,
        // cellRendererParams: (params) => ({ data: params.data, tableId: "rpa-listSchedule-Action" }),
        cellRendererParams: (params) => ({
            data: params.data,
            tableId: "rpa-listSchedule-Action",
            onEdit: handleEdit, // Truyền function vào `cellRendererParams`
            onDelete: handleDelete
        }),

        cellStyle: { textAlign: 'center' },
        width: 120
    }
]);


const GetListSchedule = async () => {
    isLoading.value = true;
    isShowDialogCud.value = false;
    var paramReq = {
        job_id: "",
        job_name: scheduleName.value,
        schedule_type: scheduleType.code,
        bat_content: "",
        schedule_type: "daily",
        start_time: "08:00",
        interval_minutes: 30,
        days_of_week: null,
        days_of_month: null,
        delete_flag: false,
    }
    const response = await apiService.post('/api/Rpa/GetListSchedule', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        lstSchedule.value = res.data;
    }
    isLoading.value = false;
};

const CrudSchedule = async (item, flag) => {
    var itemReq = _.cloneDeep(item);
    isLoading.value = true;
    if (itemReq.schedule_type == 'weekly' && Array.isArray(itemReq.days_of_week)) {
        itemReq.days_of_week = itemReq.days_of_week.join(",");
        item.interval_minutes = 0;
    }
    if (itemReq.schedule_type == 'monthly' && Array.isArray(itemReq.days_of_month)) {
        itemReq.days_of_month = itemReq.days_of_month.join(",");
        item.interval_minutes = 0;
    }

    // if (moment(itemReq.days_of_month).isValid) {
    //     itemReq.days_of_month = itemReq.days_of_month.getDate();
    // }
    if (moment(itemReq.start_time).isValid) {
        itemReq.start_time = moment(itemReq.start_time).format("HH:mm");
    }
    var paramReq = itemReq;
    const response = await apiService.post('/api/Rpa/CrudSchedule', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        GetListSchedule();
    }
    isLoading.value = false;
};

const AddNewData = () => {
    HeaderDialogCud.value = "Add new data";
    isShowDialogCud.value = true;
    selectedSchedule.value = {
        job_id: "",
        job_name: "",
        bat_content: "",
        schedule_type: "daily",
        start_time: new Date(),
        interval_minutes: 60,
        days_of_week: null,
        days_of_month: null,
        delete_flag: false,
        log_path: "",
    }
}

const handleEdit = async (data) => {
    HeaderDialogCud.value = "Edit data";
    selectedSchedule.value = data;
    if (data.days_of_week) {
        selectedSchedule.value.days_of_week = data.days_of_week.split(",");
    }
    if (data.days_of_month) {
        selectedSchedule.value.days_of_month = moment().date(data.days_of_month).toDate();
    }

    isShowDialogCud.value = true;
    console.log(data);
};

const handleDelete = async (data) => {
    confirm.require({
        message: 'Do you want to delete this record?',
        header: 'Confirm',
        icon: 'pi pi-info-circle',
        rejectLabel: 'Cancel',
        rejectProps: {
            label: 'Cancel',
            severity: 'secondary',
            outlined: true
        },
        acceptProps: {
            label: 'Delete',
            severity: 'danger'
        },
        accept: () => {
            //delete item
            data.delete_flag = true;
            data.update_user = authStore.userInfo.badge_no;
            CrudSchedule(data);

        },
        reject: () => {
        }
    });
};

watch(() =>
    selectedSchedule.value.schedule_type, (newValue, oldValue) => {
        if (oldValue && newValue !== oldValue) {
        }
    },
    { immediate: true }
);




onMounted(async () => {
    await GetListSchedule();
});

</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">
        <div class="flex items-center mt-3 gap-3">
            <FloatLabel class="w-[150px]" variant="on">
                <Select v-model="scheduleType" inputId="scheduleType" :options="lstScheduleType" optionLabel="name"
                    class="w-full" />
                <label for="scheduleType">Schedule type</label>
            </FloatLabel>
            <FloatLabel class="w-[300px]" variant="on">
                <InputText id="on_label" v-model="scheduleName" />
                <label for="scheduleType">Schedule name</label>
            </FloatLabel>



            <div class="flex ml-auto gap-2">
                <Button label="Add new" :loading="isLoading == true" v-on:click="AddNewData()" icon="pi pi-plus px-1"
                    severity="info"></Button>
                <Button label="Search" :loading="isLoading == true" v-on:click="GetListSchedule()"
                    icon="pi pi-search px-1"></Button>
            </div>
        </div>
    </div>

    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="5vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="20vh" class="mb-2"></Skeleton>
    </div>
    <div v-else class="grid grid-cols-12 gap-4">
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <ag-grid-vue class="ag-theme-alpine"
                :style="'width: 100%; height:' + (lstSchedule.length * Number(gridOptions.rowHeight) + Number(gridOptions.headerHeight) + Number(50)) + 'px'"
                :rowData="lstSchedule" :columnDefs="columnDef" :gridOptions="gridOptions"
                :defaultColDef="defaultColDef" />
        </div>
    </div>

    <ConfirmDialog></ConfirmDialog>

    <Dialog v-model:visible="isShowDialogCud" modal :header="HeaderDialogCud" :style="{ width: '80rem' }" class="px-1"
        :breakpoints="{ '1199px': '75vw', '575px': '90vw' }">
        <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">

            <div class="flex items-center mt-3 gap-3">
                <FloatLabel class="w-full" variant="on">
                    <InputText id="on_label" class="w-full" v-model="selectedSchedule.job_name" />
                    <label for="scheduleType">Schedule Name</label>
                </FloatLabel>
            </div>

            <div class="flex items-center mt-3 gap-3">
                <FloatLabel class="w-1/4" variant="on">
                    <Select v-model="selectedSchedule.schedule_type" inputId="scheduleType" :options="lstScheduleType"
                        optionLabel="name" option-value="code" class="w-full" />
                    <label for="scheduleType">Schedule type</label>
                </FloatLabel>
                <FloatLabel class="w-1/5" variant="on">
                    <DatePicker v-model="selectedSchedule.start_time" showIcon fluid iconDisplay="input" timeOnly>
                        <template #inputicon="slotProps">
                            <i class="pi pi-clock" @click="slotProps.clickCallback" />
                        </template>
                    </DatePicker>
                    <label for="scheduleType">Start time</label>
                </FloatLabel>

                <FloatLabel class="w-1/2" variant="on" v-if="selectedSchedule.schedule_type == 'daily'">
                    <InputNumber v-model="selectedSchedule.interval_minutes" inputId="minmax" :min="0" :max="1440"
                        fluid />
                    <label for="scheduleType">interval minutes</label>
                </FloatLabel>

                <div class="card flex flex-wrap justify-center gap-4 p-0"
                    v-if="selectedSchedule.schedule_type == 'weekly'">
                    <div class="flex items-center gap-2" v-for="(item, index) in lstDayOfWeek">
                        <Checkbox v-model="selectedSchedule.days_of_week" :inputId="item" :name="item" :value="item" />
                        <label for="ingredient1"> {{ item }} </label>
                    </div>
                </div>

                <FloatLabel class="w-1/5" variant="on" v-if="selectedSchedule.schedule_type == 'monthly'">
                    <DatePicker v-model="selectedSchedule.days_of_month" showIcon fluid iconDisplay="input"
                        dateFormat="d">
                    </DatePicker>
                    <label for="scheduleType">Day of month</label>
                </FloatLabel>


            </div>
            <div class="flex items-center mt-3 gap-3">
                <FloatLabel class="w-full" variant="on">
                    <InputText id="on_label" class="w-full" v-model="selectedSchedule.log_path" />
                    <label for="scheduleType">Log path</label>
                </FloatLabel>
            </div>
            <div class="flex items-center mt-3 gap-3">
                <FloatLabel class="w-full" variant="on">
                    <Textarea v-model="selectedSchedule.bat_content" rows="5" class="w-full" />
                    <label for="scheduleType">Bat content</label>
                </FloatLabel>
            </div>


            <div class="flex items-center mt-3 gap-3">
                <div class="flex ml-auto gap-2">
                    <Button label="Cancel" icon="pi pi-times px-1 " outlined class="w-32"
                        v-on:click="isShowDialogCud = false"></Button>
                    <Button label="Save" icon="pi pi-save px-1" class="w-32"
                        v-on:click="CrudSchedule(selectedSchedule)"></Button>
                </div>
            </div>
        </div>
    </Dialog>
</template>
<style scoped>
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
</style>
