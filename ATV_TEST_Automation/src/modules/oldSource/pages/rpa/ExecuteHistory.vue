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

// const fromDate = ref(new Date());
// const toDate = ref(new Date());

// const fromDate = ref(new Date());
// fromDate.value.setHours(0, 0, 0, 0);

// const toDate = ref(new Date());
// toDate.value.setHours(23, 59, 59, 999);


const lstExecHis = ref([]);

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
    },
    // {
    //     headerName: "bat_file_path", field: "bat_file_path",
    //     flex: 1
    // },
    {
        headerName: "log_path", field: "log_path",
        flex: 1
    },
]);


async function GetListSchedule() {
    isLoading.value = true;
    var paramReq = {
        job_id: "",
        job_name: "",
        schedule_type: "",
        bat_content: "",
        schedule_type: "daily",
        start_time: "08:00",
        interval_minutes: 30,
        days_of_week: null,
        days_of_month: null,
        delete_flag: false,
    };
    const response = await apiService.post('/api/Rpa/GetListSchedule', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        lstExecHis.value = res.data;
    }
    isLoading.value = false;
}



onMounted(async () => {
    await GetListSchedule();
});

</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">
        <div class="flex items-center mt-3 gap-3">



          <!--<FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Day'">
                <DatePicker v-model="fromDate" dateFormat="dd/mm/yy" />
                <label for="chartType">From day</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Day'">
                <DatePicker v-model="toDate" dateFormat="dd/mm/yy" />
                <label for="chartType">To day</label>
            </FloatLabel>
            -->


            <div class="flex ml-auto gap-2">
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
                :style="'width: 100%; height:' + (lstExecHis.length * Number(gridOptions.rowHeight) + Number(gridOptions.headerHeight) + Number(50)) + 'px'"
                :rowData="lstExecHis" :columnDefs="columnDef" :gridOptions="gridOptions"
                :defaultColDef="defaultColDef" />
        </div>
    </div>

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
