<template>
    <button v-if="props.params.tableId == 'rpa-listSchedule-execHis'" class="p-button p-component p-button-sm h-[25px]"
        @click="handleClick">
        <span class="p-button-icon p-button-icon-left pi pi-book" data-p="left" data-pc-section="icon"></span>
    </button>
    <button v-if="props.params.tableId == 'rpa-listSchedule-batContent'"
        class="p-button p-component p-button-sm h-[25px]" @click="handleClick">
        <span class="p-button-icon p-button-icon-left pi pi-info-circle" data-p="left" data-pc-section="icon"></span>
    </button>

    <span v-if="props.params.tableId == 'rpa-listSchedule-Action'" class="p-buttongroup p-component" role="group"
        data-pc-name="buttongroup" data-pc-section="root">
        <button class="p-button p-component p-button-sm p-button-info h-[25px] mr-1" type="button" aria-label="edit"
            @click="ActionClick('edit')" data-pc-name="button" data-pc-section="root"><span
                class="p-button-icon p-button-icon-left pi pi-pen-to-square" data-p="left"
                data-pc-section="icon"></span>
        </button>
        <button class="p-button p-component p-button-sm p-button-danger h-[25px]" type="button" aria-label="delete"
            @click="ActionClick('delete')" data-pc-name="button" data-pc-section="root"><span
                class="p-button-icon p-button-icon-left pi pi-trash" data-p="left" data-pc-section="icon"></span>
        </button>
    </span>


    <Dialog v-model:visible="isShowBatContent" modal header="Content .bat file" :style="{ width: '50vw' }"
        :breakpoints="{ '1199px': '75vw', '575px': '90vw' }">
        <pre><code>{{ batContent }}</code></pre>
    </Dialog>

    <Dialog v-model:visible="isShowExecHis" modal header="History Execute" :style="{ width: '50vw' }"
        :breakpoints="{ '1199px': '75vw', '575px': '90vw' }">
        <ag-grid-vue class="ag-theme-alpine"
            :style="'width: 100%; height:' + (lstHisExec.length * Number(gridOptions.rowHeight) + Number(gridOptions.headerHeight) + Number(50)) + 'px'"
            :rowData="lstHisExec" :columnDefs="columnHisExecDef" :gridOptions="gridOptions"
            :defaultColDef="defaultColDef" />
    </Dialog>
</template>

<script setup>
import { useLayout } from "@/layout/composables/layout";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import { apiService } from "@/modules/core/services/BaseService";
import { inject, onMounted, ref, watch, nextTick } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import _ from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');


const props = defineProps(["data", "tableId", "onEdit", "onDelete"]);


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
const columnHisExecDef = ref([
    {
        headerName: "No",
        field: "No",
        valueGetter: "node.rowIndex + 1",
        cellStyle: { textAlign: 'center' },
        width: 80
    },

    {
        headerName: "job_id", field: "job_id",
        width: 200,
        cellStyle: { textAlign: 'right' },
    },
    {
        headerName: "status", field: "status",
        width: 140,
        cellStyle: { textAlign: 'center' },
    },
    {
        headerName: "start_time", field: "start_time",
        width: 180,
        cellStyle: { textAlign: 'right' },
    },
    {
        headerName: "end_time", field: "end_time",
        width: 180,
        cellStyle: { textAlign: 'right' },
    },
    {
        headerName: "run_time (s)", field: "run_time",
        flex: 1,
        cellStyle: { textAlign: 'right' },
    }
]);

const isShowBatContent = ref(false);
const isShowExecHis = ref(false);
const batContent = ref("");
const lstHisExec = ref([]);


function handleClick() {
    var data = props.params.data;
    var tableId = props.params.tableId;
    switch (tableId) {
        case "rpa-listSchedule-batContent":
            batContent.value = data.bat_content;
            isShowBatContent.value = true;
            //  console.log("Chi tiết của:", props.props.params);
            break;
        case "rpa-listSchedule-execHis":
            GetListHistory(data);
            break;
        default:
            break;
    }
}

const ActionClick = (action) => {
    switch (action) {
        case "edit":
            // callback to parent component
            if (typeof props.params.onEdit === 'function') {
                props.params.onEdit(props.params.data);
            }
            break;
        case "delete":
            // callback to parent component
            if (typeof props.params.onDelete === 'function') {
                props.params.onDelete(props.params.data)
            }
            break;

        default:
            break;
    }
}


const GetListHistory = async (data) => {
    var paramReq = {
        job_id: data.job_id,
        job_name: data.job_name,
        schedule_type: data.schedule_type,
        bat_content: data.bat_content,
        schedule_type: data.schedule_type,
        start_time: data.start_time,
        interval_minutes: data.interval_minutes,
        days_of_week: data.days_of_week,
        days_of_month: data.days_of_month,
        delete_flag: data.delete_flag,
    }
    const response = await apiService.post('/api/Rpa/GetListHistory', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        lstHisExec.value = res.data;
        isShowExecHis.value = true;
    }
};
</script>
