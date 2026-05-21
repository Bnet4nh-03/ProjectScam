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
const lstDevice = ref([]);
const lstGroup = ref([]);
const lstVolCust = ref([]);
const lstVolGroup = ref([]);
const lstVersion = ref([]);

// Khai báo column cho bảng trend
const columnAssy2Defs = ref([]);
// Dữ liệu cho bảng trend
const rowAssy2Data = ref([]);

// start define model for charrt line


const dataAssyOutputPlan = ref({
    title: '',
    chartTitle: 'ESI Output Result',
    chartData: [],
    chartLable: [],
    chartHeight: '40vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
    defaultSelected: [2, 3, 6, 7]
});

const dataEsiIOFcst = ref({
    title: '',
    chartTitle: 'ESI IO - Shipment vs FCST',
    chartData: [],
    chartLable: [],
    chartHeight: '60vh',
    tableData: [],
    tableHeight: '230px',
    columnDefs: [],
    isShowFilter: true,
    defaultSelected: [2, 3, 4, 7,8, 11,12,15,16,19,20]
});

// end define model for charrt line

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
    const response = await apiService.post('/api/InputLoading/GetDataAssy1InputLoading', param);
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        InitData();
        // ConvertDataAssy1(res.data.assy1Data);
        ConvertDataAssy1(res.data.assy1Data);
        ConvertDataEsiIOFcst(res.data.esiIOFcst);
    }
    isLoading.value = false;
};

const InitData = () => {
    lstDevice.value = [];
    lstGroup.value = [];
    lstVolCust.value = [];
    lstVolGroup.value = [];
    lstVersion.value = [];
};

const ConvertDataAssy1 = (resData) => {
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
                dataAssyOutputPlan.value.chartLable = Object.entries(row).map(item => _.toString(item[1]) != '' ? item[1] : null);
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
        dataAssyOutputPlan.value.chartData = lstDevice;
        dataAssyOutputPlan.value.tableData = rowDataTable;
        dataAssyOutputPlan.value.columnDefs = columnTableDefs;
    }
}

const ConvertDataEsiIOFcst = (resData) => {
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
                dataEsiIOFcst.value.chartLable = Object.entries(row).map(item => _.toString(item[1]) != '' ? item[1] : null);
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
                if (row['Column1'] == 'CUM' || row['Column1'] == 'Input plan') {
                    itemDevice['type'] = 'line';
                    // set type of line
                    if (row['Column1'] == 'Input plan') {
                        itemDevice['dashStyle'] = 'Dash';
                    }else{
                        itemDevice['dashStyle'] = 'Solid';
                    }

                } else {
                    itemDevice['type'] = 'column';
                    itemDevice['dashStyle'] = 'Solid';
                }

                // set name of item chart
                itemDevice['name'] = "(" + typeData + ") " +  row['Column1'];
                // if (row['Column1'] == 'CUM') {
                //     itemDevice['name'] = typeData;
                // } else if (row['Column1'] == 'Plan' || row['Column1'] == 'Actual') {
                //     itemDevice['name'] = row['Column1'].toUpperCase();
                // } else {
                //     itemDevice['name'] = itemDevice['name'].replace("OUTPUT", "");
                // }

                // set color for chart

                itemDevice['color'] = gVariable.borderColor[index];

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
        dataEsiIOFcst.value.chartData = lstDevice;
        dataEsiIOFcst.value.tableData = rowDataTable;
        dataEsiIOFcst.value.columnDefs = columnTableDefs;
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
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <CpnChartMixColumnLine :data="dataEsiIOFcst"></CpnChartMixColumnLine>
        </div>
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <CpnChartMixColumnLine :data="dataAssyOutputPlan"></CpnChartMixColumnLine>
        </div>
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
</style>
