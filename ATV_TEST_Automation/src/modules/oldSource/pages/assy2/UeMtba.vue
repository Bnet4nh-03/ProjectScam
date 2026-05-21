<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import { useAuthStore } from "@/stores/useAuthStore";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartLine from '@/modules/oldSource/components/ChartUeMtba/ChartLine.vue';
import CpnDropDownTarget from '@/modules/oldSource/components/ChartUeMtba/DropDownTarget.vue';
import varialbe from "@/utils/variable";
import { pull } from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();

const isLoading = ref(false);

// Khai báo column cho table
const columnDaDefs = ref([]);
const columnWbDefs = ref([]);


// Khai báo column cho bảng Mtba
const columnMtbaDefs = ref([]);

// start define model for charrt line

const ueTarget = ref({
    systemType: 'Assy2',
    targetType: 'UE',
    targetVal: 0,
});

const mtbaTarget = ref({
    systemType: 'Assy2',
    targetType: 'MTBA',
    targetVal: 0,
});


const dataWbMtba = ref({
    title: '',
    chartTitle: 'WB MTBA Summary',
    chartData: [],
    chartLable: [],
    chartHeight: '35vh',
    tableData: [],
    tableHeight: '80px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
});

const dataWbUe = ref({
    title: '',
    chartTitle: 'WB UE Summary',
    chartData: [],
    chartLable: [],
    chartHeight: '35vh',
    tableData: [],
    tableHeight: '80px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
});


const dataDaMtba = ref({
    title: '',
    chartTitle: 'DA MTBA Summary',
    chartData: [],
    chartLable: [],
    chartHeight: '35vh',
    tableData: [],
    tableHeight: '80px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
});

const dataDaUe = ref({
    title: '',
    chartTitle: 'DA UE Summary',
    chartData: [],
    chartLable: [],
    chartHeight: '35vh',
    tableData: [],
    tableHeight: '80px',
    columnDefs: [],
    isShowFilter: true,
    legendStyle: 'horizontal',
});

const chartType = ref({
    code: 'Week',
    name: 'Week',
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

const GetdataApi = async () => {
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
    isLoading.value = true;
    var paramReq = {
        lineCode: "VB31000",
        equipType: "DA,WB",
        operCode: "-1",
        equipLineNo: "-1",
        strCode: "-1",
        fromDate: moment(fromDate.value).hour(8).minute(0).second(0).format(varialbe.formatDate.YYYYMMDDHHmmss),
        toDate: moment(toDate.value).add(1, 'days').hour(7).minute(59).second(0).format(varialbe.formatDate.YYYYMMDDHHmmss),
        chartType: chartType.value.code
    };

    const response = await apiService.post('/api/UeMtba/Assy2GetDataMTBA', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        InitData();
        Convertdata(res.data);
    }
    isLoading.value = false;
};

const InitData = () => {
    dataDaUe.value.chartLable = [];
    dataDaMtba.value.chartLable = [];
    dataWbUe.value.chartLable = [];
    dataWbMtba.value.chartLable = [];

    columnWbDefs.value = [];
    columnDaDefs.value = [];
};


const Convertdata = (resData) => {
    var chartDaUe = {
        name: "DA UE",
        data: [],
        color: gVariable.borderColor[9],
        borderColor: gVariable.borderColor[9],
    };
    var chartDaMtba = {
        name: "DA MTBA",
        data: [],
        color: gVariable.borderColor[9],
        borderColor: gVariable.borderColor[9],
    };

    var chartWbUe = {
        name: "WB UE",
        data: [],
        color: gVariable.borderColor[9],
        borderColor: gVariable.borderColor[9],
    };
    var chartWbMtba = {
        name: "WB MTBA",
        data: [],
        color: gVariable.borderColor[9],
        borderColor: gVariable.borderColor[9],
    };

    var objRowdataDaUe = {};
    var objRowdataDaMtba = {};
    var objRowdataWbUe = {};
    var objRowdataWbMtba = {};

    // convert data
    for (let index = 0; index < resData.length; index++) {

        // set data for process DA
        if (resData[index].equipType == 'DA') {

            // binding col for table
            columnDaDefs.value.push({
                field: (resData[index].key).toString(),
                headerName: chartType.value.code == "Day" ? resData[index].lable : resData[index].lable,
                width: 150,
                // flex: 1,
                cellStyle: { textAlign: 'center' },
                valueFormatter: (params) => {
                    const value = Number(params.value);
                    if (!isNaN(value)) {
                        if (params.colDef['dataType'] == "UE") {
                            return value.toFixed(2) + " %";
                        } else {
                            return value.toFixed(2);
                        }
                    }
                    return params.value;
                }
            })

            // set data for chart
            chartDaUe.data.push(resData[index].daUe);
            chartDaMtba.data.push(resData[index].daMtba);

            // set label for chart
            dataDaUe.value.chartLable.push(resData[index].lable);
            dataDaMtba.value.chartLable.push(resData[index].lable);

            // set data for table
            objRowdataDaUe[(resData[index].key).toString()] = resData[index].daUe;
            objRowdataDaMtba[(resData[index].key).toString()] = resData[index].daMtba;
        }

        // set data for process WB
        if (resData[index].equipType == 'WB') {

            // binding col for table
            columnWbDefs.value.push({
                field: (resData[index].key).toString(),
                headerName: chartType.value.code == "Day" ? resData[index].lable : resData[index].lable,
                width: 150,
                // flex: 1,
                cellStyle: { textAlign: 'center' },
                valueFormatter: (params) => {
                    const value = Number(params.value);
                    if (!isNaN(value)) {
                        if (params.colDef['dataType'] == "UE") {
                            return value.toFixed(2) + " %";
                        } else {
                            return value.toFixed(2);
                        }
                    }
                    return params.value;
                }
            })


            // set data for chart
            chartWbUe.data.push(resData[index].wbUe);
            chartWbMtba.data.push(resData[index].wbMtba);

            // set label for chart
            dataWbUe.value.chartLable.push(resData[index].lable);
            dataWbMtba.value.chartLable.push(resData[index].lable);

            // set data for table
            objRowdataWbUe[(resData[index].key).toString()] = resData[index].wbUe;
            objRowdataWbMtba[(resData[index].key).toString()] = resData[index].wbMtba;
        }
    }

    // set column for table
    dataDaUe.value.columnDefs = _.map(columnDaDefs.value, (item) => {
        return _.assign({}, item, { dataType: 'UE' });
    });
    dataDaMtba.value.columnDefs = columnDaDefs;

    dataWbUe.value.columnDefs = _.map(columnWbDefs.value, (item) => {
        return _.assign({}, item, { dataType: 'UE' });
    });
    dataWbMtba.value.columnDefs = columnWbDefs;

    const chartTargetUe = {
        name: "TARGET",
        color: gVariable.borderColor[0],
        borderColor: gVariable.borderColor[0],
        data: new Array(chartDaUe.data.length).fill(ueTarget.targetVal),
    }

    const chartTargetMtba = {
        name: "TARGET",
        color: gVariable.borderColor[0],
        borderColor: gVariable.borderColor[0],
        data: new Array(chartDaMtba.data.length).fill(mtbaTarget.targetVal),
    }


    // set chart data
    dataDaUe.value.chartData = [chartDaUe, chartTargetUe];
    dataWbUe.value.chartData = [chartWbUe, chartTargetUe];

    dataDaMtba.value.chartData = [chartDaMtba, chartTargetMtba];
    dataWbMtba.value.chartData = [chartWbMtba, chartTargetMtba];

    // set table data
    dataDaUe.value.tableData = [objRowdataDaUe];
    dataDaMtba.value.tableData = [objRowdataDaMtba];
    dataWbUe.value.tableData = [objRowdataWbUe];
    dataWbMtba.value.tableData = [objRowdataWbMtba];
}

function getWeekNumber(date, type) {

    const startOfYear = new Date(date.getFullYear(), 0, 1);

    // Điều chỉnh startOfYear về thứ Hai đầu tiên của năm
    const dayOfWeek = startOfYear.getDay();
    const diffToMonday = (dayOfWeek === 0 ? -6 : 1) - dayOfWeek;
    const firstMonday = new Date(startOfYear);
    firstMonday.setDate(startOfYear.getDate() + diffToMonday);

    // Tính số ngày đã trôi qua kể từ thứ Hai đầu tiên
    const diffInMs = date - firstMonday;
    const diffInDays = Math.floor(diffInMs / 86400000);

    // Sử dụng:
    if (type === 'fromWeek') {
        // Tính số tuần, cộng thêm 1 vì tuần bắt đầu từ 1
        fromWeek.value = Math.floor(diffInDays / 7) + 1;
    } else {
        // Tính số tuần, cộng thêm 1 vì tuần bắt đầu từ 1
        toWeek.value = Math.floor(diffInDays / 7) + 1;
    }
}


const HandleTargetChange = (data) => {
    if (data.targetType == 'UE') {
        ueTarget.targetVal = data.targetVal;
    }
    if (data.targetType == 'MTBA') {
        mtbaTarget.targetVal = data.targetVal;
    }
    if (dataDaUe.value.chartData.length > 0) {
        const chartTarget = {
            name: "TARGET",
            color: gVariable.borderColor[0],
            data: new Array(dataDaUe.value.chartData[0].data.length).fill(data.targetVal),
        };
        // set chart data
        if (data.targetType == 'UE') {
            dataDaUe.value.chartData[1] = chartTarget;
            dataWbUe.value.chartData[1] = chartTarget;
        }
        if (data.targetType == 'MTBA') {
            dataDaMtba.value.chartData[1] = chartTarget;
            dataWbMtba.value.chartData[1] = chartTarget;
        }
    }
};


const SearchData = async () => {
    await GetdataApi();
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


onMounted(async () => {
    await SearchData();
});


</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">
        <div class="flex items-center mt-3 gap-3">
            <FloatLabel class="w-[150px]" variant="on">
                <Select v-model="chartType" inputId="chartType" :options="lstChartType" optionLabel="name"
                    class="w-full" size="small" />
                <label for="chartType">Chart type</label>
            </FloatLabel>

            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Day'">
                <DatePicker v-model="fromDate" dateFormat="dd/mm/yy" size="small" />
                <label for="chartType">From day</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Day'">
                <DatePicker v-model="toDate" dateFormat="dd/mm/yy" size="small" />
                <label for="chartType">To day</label>
            </FloatLabel>

            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Week'">
                <DatePicker v-model="fromDate" dateFormat="dd/mm/yy" size="small" weekNumbers="iso" />
                <label for="chartType">From week {{ fromWeek }}</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Week'">
                <DatePicker v-model="toDate" dateFormat="dd/mm/yy" size="small" weekNumbers="iso" />
                <label for="chartType">To week {{ toWeek }}</label>
            </FloatLabel>

            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Month'">
                <DatePicker v-model="fromDate" view="month" dateFormat="mm/yy" size="small" />
                <label for="chartType">From month</label>
            </FloatLabel>
            <FloatLabel class="w-[150px]" variant="on" v-if="chartType.code == 'Month'">
                <DatePicker v-model="toDate" view="month" dateFormat="mm/yy" size="small" />
                <label for="chartType">To month</label>
            </FloatLabel>

            <CpnDropDownTarget :data="ueTarget" @onTargetChange="HandleTargetChange"></CpnDropDownTarget>
            <CpnDropDownTarget :data="mtbaTarget" @onTargetChange="HandleTargetChange"></CpnDropDownTarget>

            <div class="flex ml-auto gap-2">
                <Button label="Search" :loading="isLoading" v-on:click="SearchData()" icon="pi pi-search px-1"
                    size="small"></Button>
            </div>
        </div>
    </div>
    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="48vh" class="mb-2"></Skeleton>
    </div>
    <div v-else class="grid grid-cols-12 gap-4">
        <div class="col-span-12 lg:col-span-6 xl:col-span-6">
            <CpnChartLine :data="dataWbUe"></CpnChartLine>
        </div>
        <div class="col-span-12 lg:col-span-6 xl:col-span-6">
            <CpnChartLine :data="dataWbMtba"></CpnChartLine>
        </div>


        <div class="col-span-12 lg:col-span-6 xl:col-span-6">
            <CpnChartLine :data="dataDaUe"></CpnChartLine>
        </div>
        <div class="col-span-12 lg:col-span-6 xl:col-span-6">
            <CpnChartLine :data="dataDaMtba"></CpnChartLine>
        </div>

    </div>
</template>
