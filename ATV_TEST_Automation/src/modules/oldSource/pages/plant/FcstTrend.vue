<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartLine from '@/modules/oldSource/components/ChartFcstTrend/ChartLine.vue';
import CpnChartCol from '@/modules/oldSource/components/ChartFcstTrend/ChartColumn.vue';

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');

// Khai báo props nhận từ component cha
const props = defineProps({
    message: "", // Prop truyền từ cha
});

const isLoading = ref(false);
const lstCust = ref([]);
const lstGroup = ref([]);
const lstVolCust = ref([]);
const lstVolGroup = ref([]);
const lstVersion = ref([]);
const currVer = ref('');
const comparedVer1 = ref('');
const comparedVer2 = ref('');

// Khai báo column cho bảng trend
const columnFcstTrendDefs = ref([]);
// Dữ liệu cho bảng trend
const rowDataFcstTrend = ref([]);
// Khai báo column cho bảng vol
const columnFcstVolDefs = ref([]);
// Dữ liệu cho bảng vol
const rowDataFcstVol = ref([]);

// start define model for charrt line
const dataLineMonaco220 = ref({
    title: 'Monaco (220)',
    chartTitle: 'Monthly Accumulate FCST V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
});

const dataLineQorvo575 = ref({
    title: 'Qorvo (575)',
    chartTitle: 'Monthly Accumulate FCST V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true
});

const dataLineKioxia78 = ref({
    title: 'Kioxia (78)',
    chartTitle: 'Monthly Accumulate FCST V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true,
    defaultSelected: [4, 7, 8, 10]
});

const dataLineQorvo948 = ref({
    title: 'Qorvo (948)',
    chartTitle: 'Monthly Accumulate FCST V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true
});
// end define model for charrt line

// start define model for charrt col

const dataColMonaco220 = ref({
    title: 'Monaco (220)',
    chartTitle: 'Monthly FCST Volume V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
});

const dataColQorvo575 = ref({
    title: 'Qorvo (575)',
    chartTitle: 'Monthly FCST Volume V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true
});

const dataColKioxia78 = ref({
    title: 'Kioxia (78)',
    chartTitle: 'Monthly FCST Volume V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true,
    defaultSelected: [4, 7, 8, 10]
});

const dataColQorvo948 = ref({
    title: 'Qorvo (948)',
    chartTitle: 'Monthly FCST Volume V2V by Device',
    chartData: [],
    chartHeight: '30vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true
});

// end define model for charrt col



const GetDataFcstTrend = async () => {
    isLoading.value = true;
    var paramReq = {
        currVer: currVer.value,
        comparedVer1: comparedVer1.value,
        comparedVer2: comparedVer2.value
    };
    var param = {
        "header": {
            "userId": "string",
            "accessToken": "string",
            "role": "string"
        },
        "body": paramReq
    }
    const response = await apiService.post('/api/PcsFcstTrend', param);
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        InitData();
        currVer.value = res.data.currVer;
        comparedVer1.value = res.data.comparedVer1;
        comparedVer2.value = res.data.comparedVer2;
        lstVersion.value = res.data.lstVersion;
        ConvertDataFcstTrend(res.data.fcstTrendData);
        ConvertDataFcstVolData(res.data.fcstVolData);
    }
    isLoading.value = false;
};

const InitData = ()=>{
    lstCust.value = [];
    lstGroup.value = [];
    lstVolCust.value = [];
    lstVolGroup.value = [];
    lstVersion.value = [];
};

const ConvertDataFcstVolData = (dataFcstVol) => {
    lstVolGroup.value = [];
    if (dataFcstVol.length > 0) {
        // int data
        columnFcstVolDefs.value = [];
        rowDataFcstVol.value = [];

        for (let index = 0; index < dataFcstVol.length; index++) {
            var row = _.cloneDeep(dataFcstVol[index]);
            if (index == 1) {
                Object.keys(row).forEach((key, index) => {
                    columnFcstVolDefs.value.push({
                        field: key,
                        headerName: index < 6 ? row[key] : row[key] + "-" + dataFcstVol[0][key],
                        width: 120,
                        sortable: true,
                        filter: true,
                        valueFormatter: (params) => {
                            const value = Number(params.value);
                            if (!isNaN(value)) {
                                return new Intl.NumberFormat('en-US').format(value);
                            }
                            return params.value;
                        }
                    })
                    // console.log(`Index: ${index}, Name: ${key}, Value: ${obj[key]}`);
                });
                columnFcstVolDefs.value.unshift({
                    headerName: 'No',
                    valueGetter: (params) => params.node.rowIndex + 1,
                    width: 80
                })
            }
            if (index > 1) {
                // set data cho grid
                dataFcstVol[index]['key'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];
                rowDataFcstVol.value.push(dataFcstVol[index]);

                // gán value cho combobox customer
                const itemVolCust = {
                    name: row['Column2'],
                    code: row['Column2'],
                };

                // Kiểm tra nếu newItem chưa tồn tại trong lstVolCust thì thêm vào
                if (!_.some(lstVolCust.value, itemVolCust)) {
                    lstVolCust.value.push(itemVolCust);
                }

                var itemVolGroup = {};
                itemVolGroup['name'] = row['Column5'] + "_" + row['Column6'];
                itemVolGroup['code'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];

                delete row["Column2"];
                delete row["Column3"];
                delete row["Column4"];
                delete row["Column5"];
                delete row["Column6"];
                delete row["Column7"];


                itemVolGroup['lineWidth'] = 2;
                itemVolGroup['showInNavigator'] = true;
                itemVolGroup['data'] = Object.entries(row).map(item => [moment(`${dataFcstVol[1][item[0]]} ${dataFcstVol[0][item[0]]}`, "MMM YYYY").startOf("month").valueOf(), item[1] !== null ? Number(item[1]) : null]);
                itemVolGroup['color'] = gVariable.borderColor[index];
                itemVolGroup['borderColor'] = gVariable.borderColor[index];
                itemVolGroup['borderWidth'] = 1;

                // Lấy timestamp đầu tiên và cuối cùng
                const firstTimestamp = itemVolGroup['data'][0][0];
                const lastTimestamp = itemVolGroup['data'][itemVolGroup['data'].length - 1][0];

                itemVolGroup['data'].unshift([moment(firstTimestamp).subtract(15, "day").valueOf(), null]);
                itemVolGroup['data'].push([moment(lastTimestamp).add(15, "day").valueOf(), null]);

                lstVolGroup.value.push(itemVolGroup);
            }
        }

        for (let index = 0; index < lstVolCust.value.length; index++) {
            const itemsToAdd = lstVolGroup.value.filter(
                (item) => item.code.startsWith(lstVolCust.value[index].code)
            );
            const itemsToAddGrid = rowDataFcstVol.value.filter(
                (item) => item['Column2'].startsWith(lstVolCust.value[index].code)
            );
            switch (lstVolCust.value[index].code) {
                case "220":
                    dataColMonaco220.value.chartData = itemsToAdd;
                    dataColMonaco220.value.tableData = itemsToAddGrid;
                    dataColMonaco220.value.columnDefs = columnFcstVolDefs;
                    break;
                case "575":
                    dataColQorvo575.value.chartData = itemsToAdd;
                    dataColQorvo575.value.tableData = itemsToAddGrid;
                    dataColQorvo575.value.columnDefs = columnFcstVolDefs;
                    break;
                case "78":
                    dataColKioxia78.value.chartData = itemsToAdd;
                    dataColKioxia78.value.tableData = itemsToAddGrid;
                    dataColKioxia78.value.columnDefs = columnFcstVolDefs;
                    break;
                case "948":
                    dataColQorvo948.value.chartData = itemsToAdd;
                    dataColQorvo948.value.tableData = itemsToAddGrid;
                    dataColQorvo948.value.columnDefs = columnFcstVolDefs;
                    break;
                default:
                    break;
            }
        }


        // lstVolCustSelected.value = [lstVolCust.value[0]];

        // const itemsToAdd = lstVolGroup.value.filter(
        //     (item) => item.code.startsWith(lstVolCust.value[0].code)
        // );
        // lstVolGroupSelected.value = itemsToAdd;

        // const itemsToAddGrid = rowDataFcstVol.value.filter(
        //     (item) => item['Column2'].startsWith(lstVolCust.value[0].code)
        // );

        // rowDataFcstVolFilter.value = itemsToAddGrid;
    }
};
const ConvertDataFcstTrend = (dataFcstTrend) => {
    if (dataFcstTrend.length > 0) {
        // int data
        columnFcstTrendDefs.value = [];
        rowDataFcstTrend.value = [];

        for (let index = 0; index < dataFcstTrend.length; index++) {
            var row = _.cloneDeep(dataFcstTrend[index]);
            if (index == 1) {
                Object.keys(row).forEach((key, index) => {
                    columnFcstTrendDefs.value.push({
                        field: key,
                        headerName: index < 6 ? row[key] : row[key] + "-" + dataFcstTrend[0][key],
                        width: 120,
                        sortable: true,
                        filter: true,
                        valueFormatter: (params) => {
                            const value = Number(params.value);
                            if (!isNaN(value)) {
                                return new Intl.NumberFormat('en-US').format(value);
                            }
                            return params.value;
                        }
                    })
                    // console.log(`Index: ${index}, Name: ${key}, Value: ${obj[key]}`);
                });
                columnFcstTrendDefs.value.unshift({
                    headerName: 'No',
                    valueGetter: (params) => params.node.rowIndex + 1,
                    width: 80
                })
            }
            if (index > 1) {
                // set data cho grid
                dataFcstTrend[index]['key'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];
                rowDataFcstTrend.value.push(dataFcstTrend[index]);

                // gán value cho combobox customer
                const itemCust = {
                    name: row['Column2'],
                    code: row['Column2'],
                };

                // Kiểm tra nếu newItem chưa tồn tại trong lstCust thì thêm vào
                if (!_.some(lstCust.value, itemCust)) {
                    lstCust.value.push(itemCust);
                }

                var itemGroup = {};
                itemGroup['name'] = row['Column5'] + "_" + row['Column6'];
                itemGroup['code'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];

                delete row["Column2"];
                delete row["Column3"];
                delete row["Column4"];
                delete row["Column5"];
                delete row["Column6"];
                delete row["Column7"];


                itemGroup['lineWidth'] = 2;
                itemGroup['showInNavigator'] = true;
                itemGroup['data'] = Object.entries(row).map(item => [moment(`${dataFcstTrend[1][item[0]]} ${dataFcstTrend[0][item[0]]}`, "MMM YYYY").startOf("month").valueOf(), item[1] !== null ? Number(item[1]) : null]);
                itemGroup['color'] = gVariable.borderColor[index];
                // Lấy timestamp đầu tiên và cuối cùng
                const firstTimestamp = itemGroup['data'][0][0];
                const lastTimestamp = itemGroup['data'][itemGroup['data'].length - 1][0];

                itemGroup['data'].unshift([moment(firstTimestamp).subtract(15, "day").valueOf(), null]);
                itemGroup['data'].push([moment(lastTimestamp).add(15, "day").valueOf(), null]);

                lstGroup.value.push(itemGroup);
            }
        }

        // add item to chart
        for (let index = 0; index < lstCust.value.length; index++) {
            const itemsToAdd = lstGroup.value.filter(
                (item) => item.code.startsWith(lstCust.value[index].code)
            );

            const itemsToAddGrid = rowDataFcstTrend.value.filter(
                (item) => item['Column2'].startsWith(lstCust.value[index].code)
            );

            switch (lstCust.value[index].code) {
                case "220":
                    dataLineMonaco220.value.chartData = itemsToAdd;
                    dataLineMonaco220.value.tableData = itemsToAddGrid;
                    dataLineMonaco220.value.columnDefs = columnFcstTrendDefs;
                    break;
                case "575":
                    dataLineQorvo575.value.chartData = itemsToAdd;
                    dataLineQorvo575.value.tableData = itemsToAddGrid;
                    dataLineQorvo575.value.columnDefs = columnFcstTrendDefs;
                    break;
                case "78":
                    dataLineKioxia78.value.chartData = itemsToAdd;
                    dataLineKioxia78.value.tableData = itemsToAddGrid;
                    dataLineKioxia78.value.columnDefs = columnFcstTrendDefs;
                    break;
                case "948":
                    dataLineQorvo948.value.chartData = itemsToAdd;
                    dataLineQorvo948.value.tableData = itemsToAddGrid;
                    dataLineQorvo948.value.columnDefs = columnFcstTrendDefs;
                    break;
                default:
                    break;
            }
        }
    }
}
// watch(currVer, async (newValue, oldValue) => {
//     if (newValue != oldValue && _.toString(oldValue) != '') {
//         GetDataFcstTrend();
//     }
// }, { immediate: true });
onMounted(() => {
    GetDataFcstTrend();
});
</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">
        <div class="flex items-center mt-2">
            <label for="name" class="mx-4 text-left">Current Version</label>
            <Select v-model="currVer" :options="lstVersion" filter optionLabel="value" optionValue="key"
                placeholder="Select version" class="w-1/6" size="small" />

            <label for="name" class="mx-4 text-left">Compared Ver 1</label>
            <Select v-model="comparedVer1" :options="lstVersion" showClear filter optionLabel="value" optionValue="key"
                placeholder="Select version" class="w-1/6" size="small" />

            <label for="name" class="mx-4 text-left">Compared Ver 2</label>
            <Select v-model="comparedVer2" :options="lstVersion" showClear filter optionLabel="value" optionValue="key"
                placeholder="Select version" class="w-1/6" size="small" />

            <div class="flex ml-auto gap-2">
                <Button label="Search" :loading="isLoading" v-on:click="GetDataFcstTrend()"
                    icon="pi pi-search px-1" size="small"></Button>
            </div>
        </div>
    </div>
    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="50vh" class="mb-2"></Skeleton>
    </div>
    <div v-else class="grid grid-cols-12 gap-4">

        <CpnChartLine :data="dataLineMonaco220"></CpnChartLine>
        <CpnChartCol :data="dataColMonaco220"></CpnChartCol>

        <CpnChartLine :data="dataLineQorvo575"></CpnChartLine>
        <CpnChartCol :data="dataColQorvo575"></CpnChartCol>

        <CpnChartLine :data="dataLineKioxia78"></CpnChartLine>
        <CpnChartCol :data="dataColKioxia78"></CpnChartCol>

        <CpnChartLine :data="dataLineQorvo948"></CpnChartLine>
        <CpnChartCol :data="dataColQorvo948"></CpnChartCol>

    </div>
</template>

<style>
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

.highcharts-legend-navigation {
    fill: var(--text-color) !important;
    /* Màu của số trang */
    font-weight: bold;
    /* Kiểu chữ của số trang */
}
</style>
