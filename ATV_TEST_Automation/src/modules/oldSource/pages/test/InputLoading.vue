<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartMixColumnLine from '@/modules/oldSource/components/ChartInputLoading/ChartMixColumnLine.vue';

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');

// Khai báo props nhận từ component cha
const props = defineProps({
    message: "", // Prop truyền từ cha
});

const isLoading = ref(false);
const lstGroup = ref([]);
const lstVolCust = ref([]);
const lstVolGroup = ref([]);
const lstVersion = ref([]);



// start define model for chart


const dataTestAssy2 = ref({
    title: '',
    chartTitle: 'KIOXIA Actual Output',
    chartData: [],
    chartLable: [],
    chartHeight: '64vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
    defaultSelected: [2, 3, 6, 7]
});

const dataTestAssy1 = ref({
    title: '',
    chartTitle: 'ESI Actual Output',
    chartData: [],
    chartLable: [],
    chartHeight: '64vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
    defaultSelected: [2, 3, 6, 7]
});
// end define model for chart

const GetDataInputLoading = async () => {
    isLoading.value = true;
    var paramReq = {
    };
    var param = {
        "header": {
            "userId": "string",
            "accessToken": "string",
            "role": "string"
        },
        "body": paramReq
    }
    const response = await apiService.post('/api/InputLoading/GetDataTestInputLoading', param);
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        InitData();
        ConvertDataTestAssy(res.data.assy2TestData, "Assy2");
        ConvertDataTestAssy(res.data.assy1TestData, "Assy1");
        // ConvertDataFcstVolData(res.data.fcstVolData);
    }
    isLoading.value = false;
};

const InitData = () => {
    lstGroup.value = [];
    lstVolCust.value = [];
    lstVolGroup.value = [];
    lstVersion.value = [];
};

const ConvertDataTestAssy = (resData, type) => {
    if (resData.length > 0) {
        // int data
        var columnTableDefs = [];
        var lstDevice = [];
        var rowDataTable = [];
        var typeData = "";
        for (let index = 0; index < resData.length; index++) {
            var row = _.cloneDeep(resData[index]);
            if (index == 0) {
                Object.keys(row).forEach((key, index) => {
                    columnTableDefs.push({
                        field: key,
                        headerName: key != "Column0" ? row[key] : 'Type',
                        pinned: key == "Column0" || key == "Column1"  ? 'left' : '',
                        width: 150,
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
                });
                delete row["Column0"];
                delete row["Column1"];
                // add lable for chart
                if (type == 'Assy2') {
                    dataTestAssy2.value.chartLable = Object.entries(row).map(item => _.toString(item[1]) != '' ? item[1] : null);
                }else{
                    dataTestAssy1.value.chartLable = Object.entries(row).map(item => _.toString(item[1]) != '' ? item[1] : null);
                }
                columnTableDefs.unshift({
                    headerName: 'No',
                    valueGetter: (params) => params.node.rowIndex + 1,
                    width: 80,
                    pinned: 'left',
                })
            }
            if (index > 0) {
                if (_.toString(row['Column0']) != '') {
                    typeData = row['Column0'];
                }

                // set key cho grid
                resData[index]['key'] = row['Column1'] + "_" + typeData;
                resData[index]['Column0'] = typeData;

                rowDataTable.push(resData[index]);

                // gán value cho combobox customer
                const itemDevice = {
                    name: row['Column1'] + "_" + typeData,
                    code: row['Column1'] + "_" + typeData,
                };

                // set type of chart (column or line)
                if (row['Column1'] == 'CUM') {
                    itemDevice['type'] = 'line';
                    itemDevice['name'] = typeData
                } else {
                    itemDevice['type'] = 'column';
                }

                // set name of item chart
                if (row['Column1'] == 'CUM') {
                    itemDevice['name'] = typeData;
                } else if (row['Column1'] == 'Plan' || row['Column1'] == 'Actual') {
                    itemDevice['name'] = row['Column1'].toUpperCase();
                } else {
                    itemDevice['name'] = itemDevice['name'].replace("OUTPUT", "");
                }

                // set color for chart
                if (typeData == "OUTPUT PLAN" && (row['Column1'] == 'CUM' || row['Column1'] == 'Plan')) {
                    itemDevice['color'] = gVariable.borderColor[65];
                } else if (typeData == "OUTPUT ACTUAL" && (row['Column1'] == 'CUM' || row['Column1'] == 'Actual')) {
                    itemDevice['color'] = gVariable.borderColor[52];
                    ;
                } else {
                    itemDevice['color'] = gVariable.borderColor[index];
                }



                delete row["Column0"];
                delete row["Column1"];

                itemDevice['lineWidth'] = 2;
                itemDevice['marker'] = {
                    radius: 2
                };
                itemDevice['data'] = Object.entries(row).map(item => _.toString(item[1]) != '' ? Number(item[1]) : 0);



                // Lấy timestamp đầu tiên và cuối cùng

                // Kiểm tra nếu newItem chưa tồn tại trong lstDevice thì thêm vào
                if (!_.some(lstDevice, itemDevice)) {
                    lstDevice.push(itemDevice);
                }

            }
        }
        if (type == 'Assy2') {
            dataTestAssy2.value.chartData = lstDevice;
            dataTestAssy2.value.tableData = rowDataTable;
            dataTestAssy2.value.columnDefs = columnTableDefs;
        } else {
            dataTestAssy1.value.chartData = lstDevice;
            dataTestAssy1.value.tableData = rowDataTable;
            dataTestAssy1.value.columnDefs = columnTableDefs;
        }
    }
}


onMounted(() => {
    GetDataInputLoading();
});
</script>
<template>
    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="50vh" class="mb-2"></Skeleton>
    </div>
    <div v-else class="grid grid-cols-12 gap-4">
        <div class="col-span-6 lg:col-span-6 xl:col-span-6">
            <CpnChartMixColumnLine :data="dataTestAssy1"></CpnChartMixColumnLine>
        </div>
        <div class="col-span-6 lg:col-span-6 xl:col-span-6">
            <CpnChartMixColumnLine :data="dataTestAssy2"></CpnChartMixColumnLine>
        </div>
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
