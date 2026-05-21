<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import { useAuthStore } from "@/stores/useAuthStore";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartColumn from '@/modules/oldSource/components/ChartBase/ChartColumn.vue';
import CpnChartPie from '@/modules/oldSource/components/ChartBase/ChartPie.vue';
import varialbe from "@/utils/variable";
import { pull } from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();

const isLoading = ref(false);
const isLoadingRunning = ref(false);


const chartType = ref({
    code: 'Day',
    name: 'Day',
});

const fromWeek = ref("");
const toWeek = ref("");
const fromDate = ref(moment().subtract(7, 'days').toDate());
const toDate = ref(moment().toDate());
const lstChartType = ref([
    {
        code: 'Day',
        name: 'Day',
    },
    {
        code: 'Week',
        name: 'Week',
    },
    {
        code: 'Month',
        name: 'Month',
    }
])

const shippedData = ref({
    lstProject: [],
    dataPíeShipped: []
});

const runningData = ref({
    lstProject: [],
    dataPíeRunning: {}
});


const colDefSetting = ref({
    field: "prjName",
    headerName: "Project",
    width: 120,
    pinned: 'left',
    // flex: 1,
    cellStyle: { textAlign: 'left' },
    valueFormatter: (params) => {
        return params.value;
    }
})
const GetdataApi = async () => {
    isLoading.value = true;
    var paramReq = {
        startDate: moment(fromDate.value).hour(0).minute(0).second(0).format(varialbe.formatDate.YYYYMMDD),
        endDate: moment(toDate.value).add(0, 'days').hour(23).minute(59).second(0).format(varialbe.formatDate.YYYYMMDD),
        chartType: chartType.value.code
    };

    const response = await apiService.post('/api/Qre/GetDataNpiLotShipping', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        shippedData.value.lstProject = [];
        shippedData.value.dataPíeShipped = [];
        Convertdata(res.data);
    }
    isLoading.value = false;
};

const GetdataRunningApi = async () => {
    isLoadingRunning.value = true;
    var paramReq = {
        startDate: moment(fromDate.value).hour(0).minute(0).second(0).format(varialbe.formatDate.YYYYMMDD),
        endDate: moment(toDate.value).add(0, 'days').hour(23).minute(59).second(0).format(varialbe.formatDate.YYYYMMDD),
        chartType: chartType.value.code
    };

    const response = await apiService.post('/api/Qre/GetDataNpiLotRunning', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        var itemAssy = {
            labels: [],
            series: [],
        };
        var itemTest = {
            labels: [],
            series: [],
        };
        for (let index = 0; index < res.data.series.length; index++) {
            if (res.data.series[index].station == "Assy") {
                itemAssy.labels = res.data.labels;
                itemAssy.series.push(res.data.series[index]);
            } else {
                itemTest.labels = res.data.labels;
                itemTest.series.push(res.data.series[index]);
            };
        }
        runningData.value.lstProject = [];
        runningData.value.dataPíeShipped = [];
        Convertdata(itemAssy, "AssyRunning");
        Convertdata(itemTest, "TestRunning");
    }
    isLoadingRunning.value = false;
};




const Convertdata = (resData, typeData = "") => {
    var strChartColTitle = "NPI LOTS SHIPPED TO CUSTOMLER";
    var strChartPieTitle = "SHIPPED PERCENTAGE BY PROJECT";
    switch (typeData) {
        case "AssyRunning":
            strChartColTitle = "NPI LOTS RUNNING AT ATV (Station ASSY)";
            strChartPieTitle = "RUNNING PERCENTAGE BY PROJECT (Station ASSY)";
            break;
        case "TestRunning":
            strChartColTitle = "NPI LOTS RUNNING AT ATV (Station TEST)";
            strChartPieTitle = "RUNNING PERCENTAGE BY PROJECT (Station TEST)";
            break;
        default:
            break;
    }

    if (resData.series.length > 0) {
        var itemProject = {
            title: "",
            chartTitle: strChartColTitle,
            // name: "NPI LOTS SHIPPED TO CUSTOMLER",
            // code: resData.series[index].name,
            chartHeight: '35vh',
            tableHeight: '150px',
            target: 80,
            chartLable: resData.labels,
            chartData: [],
            columnDefs: [_.cloneDeep(colDefSetting.value)],
            tableData: [],
            legendStyle: 'horizontal',
            isShowTableFilter: true,
        };

        var itemChartPie = {
            title: '',
            chartTitle: strChartPieTitle,
            chartData: [],
            chartLable: [],
            chartHeight: '35vh',
            tableData: [],
            tableHeight: '150px',
            columnDefs: [_.cloneDeep(colDefSetting.value)],
        }

        for (let index = 0; index < resData.series.length; index++) {
            itemProject.chartData.push({
                borderColor: gVariable.borderColor[index + 1],
                color: gVariable.borderColor[index + 1],
                data: resData.series[index].data,
                name: resData.series[index].name,
                type: "column",
                // pointWidth: 30,
            });
            itemChartPie.chartData.push({
                name: resData.series[index].name,
                y: resData.series[index].data.reduce((sum, num) => sum + num, 0),
                color: gVariable.borderColor[index + 1]
            });
        }


        // init col for agrid
        for (let colIndex = 0; colIndex < resData.labels.length; colIndex++) {
            itemProject.columnDefs.push({
                field: colIndex.toString(),
                headerName: resData.labels[colIndex],
                //width: 120,
                flex: 1,
                cellStyle: { textAlign: 'right' },
                valueFormatter: (params) => {
                    const value = Number(params.value);
                    if (!isNaN(value)) {
                        return Intl.NumberFormat('en-US').format(value);
                    }
                    return params.value;
                }
            });

        }

        for (let index = 0; index < resData.series.length; index++) {
            // init data for grid
            let objData = resData.series[index].data.reduce((acc, value, index) => {
                acc[index] = value;
                return acc;
            }, {});
            objData['prjName'] = resData.series[index].name;
            itemProject.tableData.push(objData);
        }


        // set column for chart pie
        itemChartPie.columnDefs.push({
            field: "total",
            headerName: "Total",
            // width: 120,
            flex: 1,
            cellStyle: { textAlign: 'right' },
            valueFormatter: (params) => {
                const value = Number(params.value);
                if (!isNaN(value)) {
                    return Intl.NumberFormat('en-US').format(value);
                }
                return params.value;
            }
        }
        );

        itemChartPie.columnDefs.push({
            field: "percent",
            headerName: "Percent",
            // width: 120,
            flex: 1,
            cellStyle: { textAlign: 'right' },
            valueFormatter: (params) => {
                const value = Number(params.value);
                if (!isNaN(value)) {
                    return Intl.NumberFormat('en-US').format(value);
                }
                return params.value;
            }
        }
        );


        // Tính tổng y
        const totalY = _.sumBy(itemChartPie.chartData, 'y');

        // Tạo mảng mới với phần trăm
        const transformedData = itemChartPie.chartData.map(item => ({
            prjName: item.name,
            total: item.y,
            percent: ((item.y / totalY) * 100).toFixed(0) + '%' // Tính phần trăm và làm tròn 2 chữ số
        }));
        itemChartPie.tableData = transformedData;



        switch (typeData) {
            case "AssyRunning":
            case "TestRunning":
                runningData.value.lstProject.push(_.cloneDeep(itemProject));
                runningData.value.dataPíeShipped.push(_.cloneDeep(itemChartPie));
                break;
            case "":
                shippedData.value.lstProject.push(_.cloneDeep(itemProject));
                shippedData.value.dataPíeShipped.push(_.cloneDeep(itemChartPie));
            default:

                break;
        }
    }

}



function getWeekNumber(date, type) {
    const weekNum = gFunc.getWeekNumber(date);
    // Sử dụng:
    if (type === 'fromWeek') {
        fromWeek.value = weekNum;
    } else {
        toWeek.value = weekNum;
    }
}



watch(chartType, async (newValue, oldValue) => {
    if (newValue != oldValue && newValue.code == 'Week') {
        // 6 tuần gần nhất
        fromDate.value = moment().subtract(6, 'weeks').startOf('isoWeek').toDate();
        toDate.value = moment().endOf('isoWeek').toDate();
        getWeekNumber(fromDate.value, "fromWeek");
        getWeekNumber(toDate.value, "toWeek");
    }
    if (newValue != oldValue && newValue.code == 'Day') {
        fromDate.value = moment().subtract(7, 'days').toDate();
        toDate.value = moment().toDate();
    }
    if (newValue != oldValue && newValue.code == 'Month') {
        // 6 tháng gần nhất
        fromDate.value = moment().subtract(6, 'months').startOf('month').toDate();
        toDate.value = moment().endOf('month').toDate();
    }
}, { immediate: true });


watch(fromDate, async (newValue, oldValue) => {
    if (newValue != oldValue && chartType.value.code == 'Week') {
        getWeekNumber(fromDate.value, "fromWeek");
    }
}, { immediate: true });

watch(toDate, async (newValue, oldValue) => {
    if (newValue != oldValue && chartType.value.code == 'Week') {
        getWeekNumber(toDate.value, "toWeek");
    }
}, { immediate: true });

const SearchData = async () => {

    if (fromDate.value >= toDate.value) {
        gFunc.ShowMessage(`From date must be earlier than To date.`, gVariable.messageType.error);
        return;
    }
    const sixMonthsLater = _.cloneDeep(fromDate.value);
    sixMonthsLater.setMonth(sixMonthsLater.getMonth() + 7);
    if (toDate.value > sixMonthsLater) {
        gFunc.ShowMessage(`Date range must not exceed 6 months.`, gVariable.messageType.error);
        return;
    }

    GetdataRunningApi();
    GetdataApi();

}

onMounted(async () => {
    await SearchData();
});

</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">
        <div class="flex items-center mt-3 gap-3">
            <FloatLabel class="w-[150px]" variant="on">
                <Select v-model="chartType" inputId="chartType" :options="lstChartType" optionLabel="name"
                    class="w-full" />
                <label for="chartType">Chart type</label>
            </FloatLabel>

            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Day'">
                <DatePicker v-model="fromDate" dateFormat="dd/mm/yy" />
                <label for="chartType">From day</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Day'">
                <DatePicker v-model="toDate" dateFormat="dd/mm/yy" />
                <label for="chartType">To day</label>
            </FloatLabel>

            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Week'">
                <DatePicker v-model="fromDate" dateFormat="dd/mm/yy" weekNumbers="iso" />
                <label for="chartType">From week {{ fromWeek }}</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Week'">
                <DatePicker v-model="toDate" dateFormat="dd/mm/yy" weekNumbers="iso" />
                <label for="chartType">To week {{ toWeek }}</label>
            </FloatLabel>

            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Month'">
                <DatePicker v-model="fromDate" view="month" dateFormat="mm/yy" />
                <label for="chartType">From month</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Month'">
                <DatePicker v-model="toDate" view="month" dateFormat="mm/yy" />
                <label for="chartType">To month</label>
            </FloatLabel>


            <div class="flex ml-auto gap-2">
                <Button label="Search" :loading="isLoading == true || isLoadingRunning == true"
                    v-on:click="SearchData()" icon="pi pi-search px-1"></Button>
            </div>
        </div>
    </div>

    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="5vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="20vh" class="mb-2"></Skeleton>
    </div>
    <div v-else v-for="(item, index) in shippedData.lstProject" class="grid grid-cols-12 gap-4">
        <div class="col-span-12 lg:col-span-4 xl:col-span-4">
            <CpnChartPie :data="shippedData.dataPíeShipped[index]"></CpnChartPie>
        </div>
        <div class="col-span-12 lg:col-span-8 xl:col-span-8">
            <CpnChartColumn :data="item"></CpnChartColumn>
        </div>
    </div>

    <div v-if="isLoadingRunning" class="flex flex-wrap mt-3">
        <Skeleton width="100vw" height="5vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="20vh" class="mb-2"></Skeleton>
    </div>
    <div v-else v-for="(item, index) in runningData.lstProject" class="grid grid-cols-12 gap-4 mt-3">
        <div class="col-span-12 lg:col-span-4 xl:col-span-4">
            <CpnChartPie :data="runningData.dataPíeShipped[index]"></CpnChartPie>
        </div>
        <div class="col-span-12 lg:col-span-8 xl:col-span-8">
            <CpnChartColumn :data="item"></CpnChartColumn>
        </div>
    </div>


</template>
