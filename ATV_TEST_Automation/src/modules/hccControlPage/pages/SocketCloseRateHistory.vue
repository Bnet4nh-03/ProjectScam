<script setup>
import { ref, onMounted, inject, watch } from 'vue';
import BaseChart from '@/modules/holdLotManagement/component/BaseChart.vue';
import BaseTable from '@/modules/holdLotManagement/component/BaseTable.vue';
import DatePicker from 'primevue/datepicker';
import Button from 'primevue/button';
const apiClient = inject('apiClient');
const gFunc = inject('gFunc');
const gVariable = inject('gVariable');
const listPlatforms = ref([]);
const selectedPlatformName = ref(null);
const listHandlers = ref([]);
const selectedHandlerName = ref(null);
const fromDate = ref();
const toDate = ref();
const tableData = ref([]);
const loading = ref(false);
const chartData = ref();
const chartOptions = ref({
    maintainAspectRatio: false,
    scales: {
        y: {
            title: {
                display: true,
                text: 'Close Rate (%)'
            }
        },
        x: {
            grid: {
                color: 'transparent'
            }
        }
    },
    plugins: {
        legend: {
            position: 'bottom'
        },
        datalabels: {
            display: false
        }
    }
});

const tableColumns = [
    { label: 'Tester', field: 'machine_name' },
    { label: 'Top board', field: 'top_board' },
    { label: 'Site', field: 'site' },
    { label: 'Site Open', field: 'site_open' },
    { label: 'Manual Closed', field: 'manual_closed' },
    { label: 'Auto Close XC', field: 'auto_close_xc' },
    { label: 'Auto Close XY', field: 'auto_close_xy' },
    { label: 'Contact Maps', field: 'contact_maps' },
    { label: 'Close Rate', field: 'close_rate' },
    { label: 'Update Time', field: 'created_at' }
];
const colors = [gVariable.backgroundColorAmkor[0], gVariable.backgroundColorAmkor[3], gVariable.backgroundColorAmkor[6],
gVariable.backgroundColorAmkor[9], gVariable.backgroundColorAmkor[12], gVariable.backgroundColorAmkor[15],
gVariable.backgroundColorAmkor[18], gVariable.backgroundColorAmkor[21], gVariable.backgroundColorAmkor[24]];
async function fetchlistPlatformsInfo() {
    const params = {
        "@flag": "GET_Platform_INFO"
    };
    var response = await apiClient.callSp('CIMitar_Master..USP_MA_getTesterInfo', params);
    listPlatforms.value = response[0]['data'];
};

async function fetchlistHandlersInfo() {
    if (!selectedPlatformName.value) {
        gFunc.ShowMessage('Please select a platform.', 'error', '', 5000);
        return;
    }
    const params = {
        "@platformno": selectedPlatformName.value['platformno']
    };
    var response = await apiClient.callSp('TestDB..USP_HCC_GetListHandlerByTesterPlatform', params);
    if (response.length > 0) {
        listHandlers.value = response[0]['data'];
        listHandlers.value.unshift({ hanhostnm: 'All' });
    }
    else {
        listHandlers.value = [];
        gFunc.ShowMessage('No handlers found for the selected platform.', 'error', '', 5000);
    }
};

async function fetchHistory() {
    loading.value = true;
    try {
        const params = {
            '@start_date': gFunc.ConvertDate(fromDate.value, 'YYYY-MM-DD') + ' 00:00:00',
            '@end_date': gFunc.ConvertDate(toDate.value),
            '@platformno': selectedPlatformName.value['platformno']
        };
        // Get socket close history
        const response = await apiClient.callSp('TestDB..USP_HCC_KIOXIA_GetSocketClose', params);
        if (response[0]['data'].length > 0) {
            // Filter data by selected handler
            if (selectedHandlerName.value['hanhostnm'] == 'All') {
                tableData.value = response[0]['data'];
            } else {
                tableData.value = response[0]['data'].filter((item) => item.machine_name == selectedHandlerName.value['hanhostnm']);
            }
            chartData.value = setChartData();
        } else {
            gFunc.ShowMessage(selectedPlatformName.value['platformname'] + ' has no data to display.', 'error', '', 5000);
        }
    } catch (error) {
        console.error('Error fetching socket close history:', error);
        gFunc.ShowMessage('Error fetching socket close history.', 'error', '', 5000);
        tableData.value = [];
    }
    loading.value = false;
};

function setChartData() {
    if (!tableData.value || tableData.value.length === 0) {
        return { labels: [], datasets: [] };
    }

    const sortedData = [...tableData.value].sort((a, b) => new Date(a.created_at) - new Date(b.created_at));
    const labels = [...new Set(sortedData.map((item) => gFunc.ConvertDate(item.created_at, 'YYYY-MM-DD HH:mm')))];
    const machines = [...new Set(sortedData.map((item) => item.machine_name))];
    const datasets = machines.map((machine, index) => {
        const machineDataMap = new Map();
        sortedData
            .filter((item) => item.machine_name === machine)
            .forEach((item) => {
                machineDataMap.set(gFunc.ConvertDate(item.created_at, 'YYYY-MM-DD HH:mm'), item.close_rate);
            });

        const dataPoints = labels.map((label) => machineDataMap.get(label) ?? null);

        return {
            label: machine,
            data: dataPoints,
            fill: false,
            borderColor: colors[index % colors.length],
            tension: 0.1
        };
    });
    return {
        labels: labels,
        datasets: datasets
    };
}

onMounted(async () => {
    // Fetch list of platforms
    await fetchlistPlatformsInfo();
    selectedPlatformName.value = listPlatforms.value[9];
    // Fetch list of handlers
    await fetchlistHandlersInfo();
    selectedHandlerName.value = listHandlers.value[0];
    // Set default date range
    const today = new Date();
    toDate.value = today;
    const yesterday = new Date(today);
    yesterday.setDate(today.getDate() - 1);
    fromDate.value = yesterday;
    // Fetch socket close history
    await fetchHistory();
});

watch(selectedPlatformName, async () => {
    // Fetch list of handlers
    await fetchlistHandlersInfo();
    selectedHandlerName.value = listHandlers.value[0];
});
</script>

<template>
    <div class="card">
        <div class="p-4">
            <h1 class="text-3xl font-bold mb-4">Socket Close Rate History</h1>
            <div class="flex items-center gap-4 mb-4">
                <div>
                    <FloatLabel variant="on">
                        <Select v-model="selectedPlatformName" inputId="platformname" :options="listPlatforms"
                            optionLabel="platformname" class="w-full" />
                        <label for="platformname">Platform</label>
                    </FloatLabel>
                </div>
                <div>
                    <FloatLabel variant="on">
                        <Select v-model="selectedHandlerName" inputId="handlername" :options="listHandlers"
                            optionLabel="hanhostnm" class="w-full" />
                        <label for="handlername">Handler</label>
                    </FloatLabel>
                </div>
                <div>
                    <FloatLabel variant="on">
                        <label for="from-date" class="font-bold mb-2 block">From</label>
                        <DatePicker id="from-date" v-model="fromDate" showIcon />
                    </FloatLabel>
                </div>
                <div>
                    <FloatLabel variant="on">
                        <label for="to-date" class="font-bold mb-2 block">To</label>
                        <DatePicker id="to-date" v-model="toDate" showIcon />
                    </FloatLabel>
                </div>
                <div class="self-end">
                    <Button label="Search" icon="pi pi-search" :loading="loading" @click="fetchHistory" />
                </div>
            </div>
            <BaseTable :columns="tableColumns" :row-data="tableData" table-height="calc(100vh - 600px)"
                v-if="tableData.length" />
            <BaseChart type="line" :data="chartData" :options="chartOptions" title="Machine Close Rate Over Time"
                v-if="tableData.length" />
        </div>
    </div>
</template>