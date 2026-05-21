<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import { useAuthStore } from "@/stores/useAuthStore";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartMixStackLine from '@/modules/oldSource/components/ChartUeMtba/ChartMixStackLine.vue';
import varialbe from "@/utils/variable";
import { pull } from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();

const isLoading = ref(false);

const chartDataSetting = ref([
    {
        name: "Idle Time",
        type: 'column',
        color: gVariable.backgroundColor[23],
        borderColor: gVariable.borderColor[23],
        data: []
    },
    {
        name: "Wating Time",
        type: 'column',
        color: gVariable.backgroundColor[8],
        borderColor: gVariable.borderColor[8],
        data: []
    },
    {
        name: "Setup Time",
        type: 'column',
        color: gVariable.backgroundColor[9],
        borderColor: gVariable.borderColor[9],
        data: []
    },
    {
        name: "Comm Down Time",
        type: 'column',
        color: gVariable.backgroundColor[10],
        borderColor: gVariable.borderColor[10],
        data: []
    },
    {
        name: "Run Time",
        type: 'column',
        color: gVariable.backgroundColor[21],
        borderColor: gVariable.borderColor[21],
        data: []
    },
    {
        name: "Lot Down Time",
        type: 'column',
        color: gVariable.backgroundColor[19],
        borderColor: gVariable.borderColor[19],
        data: []
    },
    {
        name: "Trouble Time",
        type: 'column',
        color: gVariable.backgroundColor[16],
        borderColor: gVariable.borderColor[16],
        data: []
    },
    {
        name: "Ue",
        yAxis: 1,
        color: gVariable.borderColor[57],
        borderColor: gVariable.borderColor[57],
        type: 'line',
        data: [],
        marker: {
            symbol: 'circle'
        }

    },
    {
        name: "Target",
        yAxis: 1,
        color: gVariable.borderColor[0],
        borderColor: gVariable.borderColor[0],
        type: 'line',
        data: [],
        dashStyle: 'Dash',
        marker: {
            symbol: 'diamond'
        }
    }
])

const tblDataSetting = ref([
    {
        timeType: "Idle Time",
    },
    {
        timeType: "Wating Time",
    },
    {
        timeType: "Setup Time",
    },
    {
        timeType: "Comm Down Time",
    },
    {
        timeType: "Run Time",
    },
    {
        timeType: "Lot Down Time",
    },
    {
        timeType: "Trouble Time",
    },
    {
        timeType: "Ue",
    }
    ,
    {
        timeType: "Target",
    }
]);

const colDefSetting = ref({
    field: "timeType",
    headerName: "Type",
    width: 160,
    pinned: 'left',
    // flex: 1,
    cellStyle: { textAlign: 'left' },
    valueFormatter: (params) => {
        return params.value;
    }
})

const chartDefine = [
    {
        title: '',
        chartTitle: 'SMT 1',
        name: 'SMT 1',
        equipLineNo: "S1CM-A01-3,S1CM-A01,S1CM-A01-2,S1CM-A02-5,S1CM-A02-6,S1CM-A02-7,S1CM-A02,S1CM-A02-2,S1CM-A02-3,S1CM-A02-4,S1CM-A03,S1CM-A03-2,S1CM-A03-3,S1CM-A03-4,S1CM-A03-5,S1CM-A03-6,S1CM-A03-7,S1CM-A04,S1CM-A04-2,S1CM-A04-3,S1CM-A04-4,S1CM-A04-5,S1CM-A04-6,S1CM-A04-7,S1CM-A05,S1CM-A05-2,S1CM-A05-3,S1CM-A05-4",
        processCode: 'SMT_1',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 80,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'SMT 2',
        name: 'SMT 2',
        equipLineNo: "S2CM-A01,S2CM-A01-2,S2CM-A01-3,S2CM-A02-3,S2CM-A02-2,S2CM-A02,S2CM-A02-4,S2CM-A02-7,S2CM-A02-8,S2CM-A02-5,S2CM-A02-6,S2CM-A03,S2CM-A03-2,S2CM-A03-3,S2CM-A03-4,S2CM-A03-5,S2CM-A03-6,S2CM-A03-7,S2CM-A03-8,S2CM-A04-9,S2CM-A04-8,S2CM-A04-7,S2CM-A04-6,S2CM-A04-5,S2CM-A04-4,S2CM-A04,S2CM-A04-2,S2CM-A04-3",
        processCode: 'SMT_2',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 80,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Mold 1',
        name: 'Mold 1',
        equipLineNo: "MD-A01,MD-A03",
        processCode: 'Mold_1',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 60,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Mold 2',
        name: 'Mold 2',
        equipLineNo: "MD-A02,MD-A04",
        processCode: 'Mold_2',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 65,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Laser Marking',
        name: 'Laser Marking',
        equipLineNo: "LM-A02,LM-A03",
        processCode: 'Laser_Marking',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 75,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'PKG Saw',
        name: 'PKG Saw',
        processCode: 'PKG_Saw',
        equipLineNo: "PS-A01,PS-A03,PS-A04,PS-A05,PS-A08,PS-A07",
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 80,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Conformal Shield',
        name: 'Conformal Shield',
        processCode: 'Conformal_Shield',
        equipLineNo: "CS-A01,CS-A02,CS-A03",
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 78,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Scan Inspection',
        name: 'Scan Inspection',
        processCode: 'Scan_Inspection',
        equipLineNo: "AVI-A01,AVI-A04,AVI-A05",
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 80,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'SMT 3',
        name: 'SMT 3',
        processCode: 'SMT_3',
        equipLineNo: "S3SJ-A01,S3SJ-A02",
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 80,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'AOI',
        name: 'AOI',
        equipLineNo: "AAOI-A02,AAOI-A04,ANG-A06,AAOI-A01,AAOI-A03,ANG-A05",
        processCode: 'AOI',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 85,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Solder Ball Attach_IP',
        name: 'Solder Ball Attach_IP',
        equipLineNo: "SBA-A01",
        processCode: 'Solder_Ball_Attach_IP',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 65,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Tape Attach 1',
        name: 'Tape Attach 1',
        equipLineNo: "TMA-A02,TMA-A04",
        processCode: 'Tape_Attach_1',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 70,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Tape Attach 2',
        name: 'Tape Attach 2',
        equipLineNo: "TMA-A01,TMA-A05,TMA-A07",
        processCode: 'Tape_Attach_2',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 70,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Tape Attach 3',
        name: 'Tape Attach 3',
        equipLineNo: "TMA-A08,TMA-A03,TMA-A06",
        processCode: 'Tape_Attach_3',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 70,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Laser Cavity Cut',
        name: 'Laser Cavity Cut',
        equipLineNo: "LFC-A01,LFC-A02",
        processCode: 'Laser_Cavity_Cut',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 70,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'PnP Loading 1',
        name: 'PnP Loading 1',
        equipLineNo: "ATA-A02,ATA-A03",
        processCode: 'PnP_Loading_1',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 75,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'PnP Loading 2',
        name: 'PnP Loading 2',
        equipLineNo: "ATA-A01,ATA-A04",
        processCode: 'PnP_Loading_2',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 75,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Tape Detach 1',
        name: 'Tape Detach 1',
        equipLineNo: "TMD-A01,TMD-A03,TMD-A06",
        processCode: 'Tape_Detach_1',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 70,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Tape Detach 2',
        name: 'Tape Detach 2',
        equipLineNo: "TMD-A02,TMD-A04,TMD-A05,TMD-A07",
        processCode: 'Tape_Detach_2',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 70,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'PnP Unloading 1',
        name: 'PnP Unloading 1',
        equipLineNo: "DET-A01,DET-A04,DET-A06",
        processCode: 'PnP_Unloading_1',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 75,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'PnP Unloading 2',
        name: 'PnP Unloading 2',
        equipLineNo: "DET-A02,DET-A03,DET-A05",
        processCode: 'PnP_Unloading_2',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 75,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
    {
        title: '',
        chartTitle: 'Scan Inspection_IP',
        name: 'Scan Inspection_IP',
        equipLineNo: "AVI-A02,AVI-A03",
        processCode: 'Scan_Inspection_IP',
        chartHeight: '35vh',
        tableHeight: '280px',
        target: 80,
        chartLable: [],
        chartData: _.cloneDeep(chartDataSetting.value),
        columnDefs: [_.cloneDeep(colDefSetting.value)],
        tableData: _.cloneDeep(tblDataSetting.value),
        legendStyle: 'horizontal',
        isShowTableFilter: true,
    },
]

const lstProcess = ref(_.cloneDeep(chartDefine));

const lstProcessSelected = ref([_.cloneDeep(chartDefine[0]), _.cloneDeep(chartDefine[1]), _.cloneDeep(chartDefine[2]), _.cloneDeep(chartDefine[3])]);
const lstProcessForView = ref([]);

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

    const strEquipLineNo = _.join(_.map(lstProcessSelected.value, "equipLineNo"), ",");
    isLoading.value = true;
    var paramReq = {
        lineCode: "VB11000",
        equipType: "-1",
        operCode: "-1",
        equipLineNo: _.toString(strEquipLineNo) == "" ? "-1" : _.toString(strEquipLineNo),

        fromDate: moment(fromDate.value).hour(8).minute(0).second(0).format(varialbe.formatDate.YYYYMMDDHHmmss),
        toDate: moment(toDate.value).add(1, 'days').hour(7).minute(59).second(0).format(varialbe.formatDate.YYYYMMDDHHmmss),
        chartType: chartType.value.code
    };

    const response = await apiService.post('/api/UeMtba/Assy1GetDataUe', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        InitData();
        // console.log(res.data);
        Convertdata(res.data);
    }
    isLoading.value = false;
};

const HandleSelectProcess = () => {
    if (lstProcessSelected.value.length > 6) {
        gFunc.ShowMessage("You cannot select more than 6 items.", gVariable.messageType.error);
        lstProcessSelected.value.pop();
    }
}

const InitData = () => {
    lstProcess.value = _.cloneDeep(chartDefine);
    for (let index = 0; index < lstProcessSelected.value.length; index++) {
        lstProcessSelected.value[index].chartLable = [];
        lstProcessSelected.value[index].chartData = _.cloneDeep(chartDataSetting.value);
        lstProcessSelected.value[index].columnDefs = [_.cloneDeep(colDefSetting.value)];
        lstProcessSelected.value[index].tableData = _.cloneDeep(tblDataSetting.value);
    }
};

const Convertdata = (resData) => {
    // convert data
    for (let index = 0; index < resData.length; index++) {
        const indexProcess = _.findIndex(lstProcess.value, item => item.processCode == resData[index].processCode.toString());
        // is exist data in process list
        if (indexProcess >= 0) {
            // binding col for table
            lstProcess.value[indexProcess].columnDefs.push({
                field: (resData[index].key).toString(),
                headerName: resData[index].lable,
                width: 150,
                // flex: 1,
                cellStyle: { textAlign: 'right' },
                valueFormatter: (params) => {
                    const value = Number(params.value);
                    if (!isNaN(value)) {
                        if (params.data.timeType == 'Ue' || params.data.timeType == 'Target') {
                            return value + " %";
                        } else {
                            return Intl.NumberFormat('en-US').format(value);
                        }

                    }
                    return params.value;
                }
            })

            // set data for chart
            lstProcess.value[indexProcess].chartData[0].data.push(resData[index].idleTime);
            lstProcess.value[indexProcess].chartData[1].data.push(resData[index].waitingTime);
            lstProcess.value[indexProcess].chartData[2].data.push(resData[index].setupTime);
            lstProcess.value[indexProcess].chartData[3].data.push(resData[index].commDownTime);
            lstProcess.value[indexProcess].chartData[4].data.push(resData[index].runTime);
            lstProcess.value[indexProcess].chartData[5].data.push(resData[index].lotDownTime);
            lstProcess.value[indexProcess].chartData[6].data.push(resData[index].troubleTime);
            lstProcess.value[indexProcess].chartData[7].data.push((resData[index].ue * 100 / resData[index].totalTime));
            lstProcess.value[indexProcess].chartData[8].data.push(lstProcess.value[indexProcess].target);

            // set label for chart
            lstProcess.value[indexProcess].chartLable.push(resData[index].lable);

            // set data for table
            lstProcess.value[indexProcess].tableData[0][(resData[index].key).toString()] = resData[index].idleTime;
            lstProcess.value[indexProcess].tableData[1][(resData[index].key).toString()] = resData[index].waitingTime;
            lstProcess.value[indexProcess].tableData[2][(resData[index].key).toString()] = resData[index].setupTime;
            lstProcess.value[indexProcess].tableData[3][(resData[index].key).toString()] = resData[index].commDownTime;
            lstProcess.value[indexProcess].tableData[4][(resData[index].key).toString()] = resData[index].runTime;
            lstProcess.value[indexProcess].tableData[5][(resData[index].key).toString()] = resData[index].lotDownTime;
            lstProcess.value[indexProcess].tableData[6][(resData[index].key).toString()] = resData[index].troubleTime;
            lstProcess.value[indexProcess].tableData[7][(resData[index].key).toString()] = (resData[index].ue * 100 / resData[index].totalTime).toFixed(1);
            lstProcess.value[indexProcess].tableData[8][(resData[index].key).toString()] = lstProcess.value[indexProcess].target;

            // objRowdataDaUe[(resData[index].key).toString()] = resData[index].daUe;
            // objRowdataDaMtba[(resData[index].key).toString()] = resData[index].daMtba;
        }
    }

    // check lstProcessSelected
    if (lstProcessSelected.length == 0) {
        lstProcessSelected.value = [lstProcess.value[0], lstProcess.value[1]];
    } else {
        for (let index = 0; index < lstProcessSelected.value.length; index++) {
            const indexProcess = _.findIndex(lstProcess.value, { processCode: lstProcessSelected.value[index].processCode });
            if (indexProcess >= 0) {
                lstProcessSelected.value[index] = _.cloneDeep(lstProcess.value[indexProcess]);
            }
        }
    }

    lstProcessForView.value = _.cloneDeep(lstProcessSelected.value);
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

            <FloatLabel class="w-1/2" variant="on">
                <MultiSelect id="on_label" v-model="lstProcessSelected" :options="lstProcess" :maxSelectedLabels="6"
                    display="chip" optionLabel="name" trackBy="operCode" :filter="true" showClear
                    @change="HandleSelectProcess" class="w-full" />
                <label for="on_label">Select Process</label>
            </FloatLabel>


            <!-- <CpnDropDownTarget :data="ueTarget" @onTargetChange="HandleTargetChange"></CpnDropDownTarget>
            <CpnDropDownTarget :data="mtbaTarget" @onTargetChange="HandleTargetChange"></CpnDropDownTarget> -->

            <div class="flex ml-auto gap-2">
                <Button label="Search" :loading="isLoading" v-on:click="SearchData()" icon="pi pi-search px-1"></Button>
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
        <div v-for="item in lstProcessForView" :key="item.operCode" class="col-span-12 lg:col-span-6 xl:col-span-6">
            <CpnChartMixStackLine :data="item"></CpnChartMixStackLine>
        </div>
    </div>
</template>
