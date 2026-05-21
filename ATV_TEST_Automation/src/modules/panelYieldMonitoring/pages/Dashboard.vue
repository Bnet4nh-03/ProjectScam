<script setup>
import { inject, onMounted, onUnmounted, ref, watch, onBeforeMount } from 'vue';
import BaseTable from '@/modules/holdLotManagement/component/BaseTable.vue';
import _ from "lodash";
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import { eCimWebService } from '@/modules/panelYieldMonitoring/services/EcimWebService';
const authStore = useAuthStore();
const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');

const tableListLotColumns = [
    { label: 'indate',field: 'indate' },
    { label: 'lot',field: 'lot' },
    { label: 'device',field: 'device' },
    { label: 'tester',field: 'tester' },
    { label: 'pass',field: 'pass' },
    { label: 'fail',field: 'fail' },
    { label: 'yield',field: 'yield' },
];
const tableListPanelColumns = [
    { label: 'indate', field: 'indate' },    
    { label: 'lot', field: 'lot' },
    { label: 'panel', field: 'panel' },
    { label: 'pass', field: 'pass' },
    { label: 'fail', field: 'fail' },
    { label: 'yield', field: 'yield' },
];
const listLot = ref([]);
const lotSelected = ref ();
const listPanel = ref([]);
const isShowListPanel = ref(false);
const eCimUrl = import.meta.env.VITE_API_ECIM_URL
const listSN = ref([]);
const listSnFromEcim = ref([]);
const tableListUnitColumns = [
    { label: 'sn', field:'sn' },
];
const listMixedSN = ref([]);
async function getListLot() {
    try {
        var response = await apiClient.callSp('TestDB..USP_PanelMonitor_GetListLot',{});
        if (response){
            listLot.value = response[0]['data'];
        }
    } catch (error) {
        gFunc.ShowMessage("Failed to get list lot.", "error","",3000);
    }
};

async function getListPanel(lot){
    try {
        var params = {
            "@lot": lot
        }
        var response = await apiClient.callSp('TestDB..USP_PanelMonitor_GetListPanel',params);
        if (response){
            if (response[0]['data']){
                isShowListPanel.value = true;                  
                return response[0]['data'];
            }
        }
        return [];
    } catch (error) {
        gFunc.ShowMessage("Failed to get list panel.", "error","",3000);
        return [];
    }
};

async function getListUnit(lot){
    try {
        var params = {
            "@lot": lot
        }
        var response = await apiClient.callSp('TestDB..USP_PanelMonitor_GetListUnit',params);
        if (response){
            if (response[0]['data']){
                return response[0]['data'];
            }
        }
        return [];
    } catch (error) {
        gFunc.ShowMessage("Failed to get list unit.", "error","",3000);
        return [];
    }
};

async function setSN(lot,listSN)
{
    try {
        var params = {
            "@lot": lot,
            "@list_sn": listSN
        }
        var response = await apiClient.callSp('TestDB..USP_PanelMonitor_SetSN',params);
        if (response){

        }
    } catch (error) {
        gFunc.ShowMessage("Failed to set SN.", "error","",3000);
    }
};

async function getListSnFromEcim(lot){
    try {
        // Check lot has 2DID data or not
        var params = {
            "@lot": lot
        }
        var response = await apiClient.callSp('TestDB..USP_PanelMonitor_GetListSN',params);
        if (response){
            if (response[0]['data'].length > 0)
                return response[0]['data'];
            else{
                // Call Ecim webservice to get 2DID data
                params = {
                    url: eCimUrl+"EcimWebServiceAtv/lot_info/get_2did_by_lot",
                    method: "GET",
                    data_input: {
                        lot_no: lot,
                        dcc: ""
                    }
                };
                const response = await eCimWebService.post('/api/v1/ecim_webservice',params);
                if (response){
                    // Set 2DID data to lot
                    await setSN(lot,response['2didList']);
                    return response['2didList'];            
                }    
            }        
        }

    } catch (error) {
        gFunc.ShowMessage("Failed to get list SN.", "error","",3000);
    }
    return null;
};

async function onLotDoubleClicked(item) {
    lotSelected.value = item;
    listPanel.value =await getListPanel(lotSelected.value['lot']);
    listSnFromEcim.value = await getListSnFromEcim(lotSelected.value['lot']);
    listMixedSN.value = await checkMixedLot(lotSelected.value['lot'])
};

async function checkMixedLot(lot){
    // Get list sn from test data
    listSN.value = await getListUnit(lot)
    // Check listSN and listSnFromEcim data
    if (!listSN.value?.length || !listSnFromEcim.value?.length){
        return [];
    }
    // Check listSN's item in listSnFromEcim or not
    var ecimSnSet = new Set(listSnFromEcim.value
    .map(item => (typeof item === 'object' && item !== null) ? item['sn'] : item)
    .filter(sn => sn) 
    );
    return listSN.value.filter(item => !ecimSnSet.has(item['sn']));
}

onMounted(async () => {

    await getListLot();
});

</script>
<template>
    <div class="card" v-if="listLot?.length == 0">
        <h1 class="text-3xl font-bold">No lot data</h1>
    </div>    
    <div class="card" v-else>
        <h1 class="text-3xl font-bold">List lot summary</h1>
        <BaseTable title="" :columns=tableListLotColumns :rowData=listLot @row-dblclick="onLotDoubleClicked"/>
    </div>
    <Dialog v-model:visible="isShowListPanel" modal :style="{ width: '95vw' }">
        <BaseTable title="List panel summary" :columns="tableListPanelColumns" :rowData=listPanel />
        <BaseTable title="List mixed SN" :columns="tableListUnitColumns" :rowData="listMixedSN" v-if="listMixedSN?.length > 0"/>
        <div class="mt-4 table-title" v-else>
            <h1>No mixed lot</h1>
        </div>

    </Dialog>
</template>
<style lang="css">
.table-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2d3748;
}
</style>