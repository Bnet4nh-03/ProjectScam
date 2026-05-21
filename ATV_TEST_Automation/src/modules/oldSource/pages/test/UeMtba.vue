<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import { useAuthStore } from "@/stores/useAuthStore";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartMixStackLineFixed from '@/modules/oldSource/components/ChartUeMtba/ChartMixStackLineFixed.vue';
import varialbe from "@/utils/variable";
import { pull } from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();

const isLoading = ref(false);
const lstPlatformSelected = ref([]);
const lstPlatform = ref([]);

const colDefSetting = ref({
    field: "Type",
    headerName: "Data Type",
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
    var paramReq = {};
    const response = await apiService.post('/api/UeMtba/TestGetDataUe', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        Convertdata(res.data);
    }
    isLoading.value = false;
};

// const HandleSelectPlatform = () => {
//     if (lstPlatformSelected.value.length > 6) {
//         gFunc.ShowMessage("You cannot select more than 6 items.", gVariable.messageType.error);
//         lstPlatformSelected.value.pop();
//     }
// }


const Convertdata = (resData) => {
    lstPlatform.value = [];
    lstPlatformSelected.value = [];
    if (resData.series.length > 0) {
        for (let index = 0; index < resData.series.length; index += 5) {

            var itemPlatform = {
                title: "",
                chartTitle: BindingPlatformName(resData.series[index].name),
                name: BindingPlatformName(resData.series[index].name),
                code: resData.series[index].name,
                chartHeight: '35vh',
                tableHeight: '180px',
                target: 80,
                chartLable: resData.labels,
                chartData: [
                    {
                        borderColor: gVariable.borderColor[16],
                        color: gVariable.backgroundColor[16],
                        data: resData.series[index + 2].data,
                        name: resData.series[index + 2].key.replace(`${resData.series[index + 2].name}_`, ""),
                        type: "column",
                        stack: 'group1',
                        pointWidth: 30,
                    },
                    {
                        borderColor: gVariable.borderColor[8],
                        color: gVariable.backgroundColor[8],
                        data: resData.series[index + 1].data,
                        name: resData.series[index + 1].key.replace(`${resData.series[index + 1].name}_`, ""),
                        type: "column",
                        stack: 'group1',
                         pointWidth: 30,
                    },
                    {
                        borderColor: gVariable.borderColor[21],
                        color: gVariable.backgroundColor[21],
                        data: resData.series[index].data,
                        name: resData.series[index].key.replace(`${resData.series[index].name}_`, ""),
                        type: "column",
                        stack: 'group1',
                         pointWidth: 30,
                    },
                    {
                        borderColor: gVariable.borderColor[12],
                        color: gVariable.borderColor[12],
                        data: resData.series[index + 3].data,
                        name: resData.series[index + 3].key.replace(`${resData.series[index + 3].name}_`, ""),
                        type: "column",
                        stack: 'group2',
                        pointPadding: 0.4,
                        pointPlacement: -0.3,
                        yAxis: 1,
                         pointWidth: 20,
                    },
                    // chart week
                    {
                        borderColor: gVariable.borderColor[19],
                        color: gVariable.borderColor[19],
                        data: resData.series[index + 4].data.map((value, index) => index < 5 ? value : null),
                        name: resData.series[index + 4].key.replace(`${resData.series[index + 4].name}_`, "") + " (WW)",
                        type: "line",
                        marker: {
                            symbol: 'circle'
                        },
                        pointPlacement: -0.15,
                    },
                    // chart day
                    {
                        borderColor: gVariable.borderColor[19],
                        color: gVariable.borderColor[19],
                        data: resData.series[index + 4].data.map((value, index) => index >= 5 ? value : null),
                        name: resData.series[index + 4].key.replace(`${resData.series[index + 4].name}_`, "") + " (DD)",
                        type: "line",
                        marker: {
                            symbol: 'diamond'
                        },
                        pointPlacement: -0.15,
                    }
                ],
                columnDefs: [_.cloneDeep(colDefSetting.value)],
                tableData: [],
                legendStyle: 'horizontal',
                isShowTableFilter: true,
            };
            // init col for agrid
            for (let colIndex = 0; colIndex < 11; colIndex++) {
                itemPlatform.columnDefs.push({
                    field: colIndex.toString(),
                    headerName: resData.labels[colIndex],
                    width: 120,
                    // flex: 1,
                    cellStyle: { textAlign: 'right' },
                    valueFormatter: (params) => {
                        const value = Number(params.value);
                        if (!isNaN(value)) {
                            if (params.data.Type == 'OUTPUT') {
                                return Intl.NumberFormat('en-US').format(value);
                            } else {
                                return value + " %";
                            }
                        }
                        return params.value;
                    }
                })
            }

            for (let tblIndex = 0; tblIndex < 5; tblIndex++) {
                let objData = resData.series[tblIndex + index].data.reduce((acc, value, index) => {
                    acc[index] = value;
                    return acc;
                }, {});
                objData['Type'] = itemPlatform.chartData[tblIndex].name.replace("(WW)", "");
                itemPlatform.tableData.push(objData);
            }

            lstPlatform.value.push(_.cloneDeep(itemPlatform));
        }
    }

    if (lstPlatformSelected.value.length == 0) {
        lstPlatformSelected.value = [_.cloneDeep(lstPlatform.value[0]),
        _.cloneDeep(lstPlatform.value[1]),
        _.cloneDeep(lstPlatform.value[2]),
        _.cloneDeep(lstPlatform.value[9]),
        _.cloneDeep(lstPlatform.value[10]),
        ];
    }
}

const BindingPlatformName = (strName) => {
    var ret = strName
    if (_.toString(strName) != "") {
        switch (strName.trim()) {
            case "MAGNUM-V":
                ret = "Kioxia Tester_Magnum V";
                break;
            case "SBS22020":
                ret = "Kioxia Burn In_SBS";
                break;
            case "TWSL301N":
                ret = "Monaco_Handler";
                break;
            case "PAX":
                ret = "Qorvo Tester_PAX";
                break;
            case "T5832":
                ret = "Siplet Hanlder_SLT";
                break;
            default:
                break;
        }
    }
    return ret;
}

const SearchData = async () => {
    await GetdataApi();
}

onMounted(async () => {
    await SearchData();
});

</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">
        <div class="flex items-center mt-3 gap-3">
            <FloatLabel class="w-1/2" variant="on">
                <MultiSelect id="on_label" v-model="lstPlatformSelected" :options="lstPlatform" :maxSelectedLabels="6"
                    display="chip" optionLabel="name" trackBy="code" :filter="true" showClear class="w-full" />
                <label for="on_label">Select Platform</label>
            </FloatLabel>

            <div class="flex ml-auto gap-2">
                <Button label="Reload Data" severity="info" :loading="isLoading" v-on:click="SearchData()" icon="pi pi-refresh px-1"></Button>
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
        <div v-for="item in lstPlatformSelected" :key="item.code" class="col-span-12 lg:col-span-6 xl:col-span-6">
            <CpnChartMixStackLineFixed :data="item"></CpnChartMixStackLineFixed>
        </div>
    </div>
</template>
