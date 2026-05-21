<script setup>
import { ref, onMounted, inject } from 'vue';

import BaseTable from '@/modules/holdLotManagement/component/BaseTable.vue';
import BaseChart from '@/modules/holdLotManagement/component/BaseChart.vue';
const gFunc = inject('gFunc');
const gVariable = inject('gVariable');
const apiClient = inject('apiClient');
const listPlatforms = ref([]);
const selectedPlatformName = ref();
const listTesters = ref([]);
const tableData = ref([]);
const chartData = ref([]);
const chartOptions = ref({});
const loading = ref(false);
const viewModes = ref([
    { name: 'Monitor', code: 'Monitor' },
    { name: 'Daily', code: 'Daily' },
    { name: 'Weekly', code: 'Weekly' }
    // { name: 'Monthly', code: 'Monthly' }
]);
const selectedViewMode = ref(viewModes.value[0]);
const testerTableColumns = [
    { label: 'Handler', field: 'machine_name' },
    { label: 'Top board', field: 'top_board' },
    { label: 'Site', field: 'site' },
    { label: 'Site Open', field: 'site_open' },
    { label: 'Manual Closed', field: 'manual_closed' },
    { label: 'Auto Close XC', field: 'auto_close_xc' },
    { label: 'Auto Close XY', field: 'auto_close_xy' },
    { label: 'Close Rate', field: 'close_rate' }
];
const colors = [gVariable.backgroundColorAmkor[32], gVariable.backgroundColorAmkor[33], gVariable.backgroundColorAmkor[34]];

async function getSocketCloseRateLimit() {
    var params = {
        "@platformname": selectedPlatformName.value['platformname'],
    };
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_GetSocketCloseRateLimit', params);
    }
    catch (error) {
        gFunc.ShowMessage('Error fetching socket close rate limit.', 'error', '', 5000);
        loading.value = false;
        return;
    }
    if (response.length) {
        response = response[0]['data'];
        response = response[0]['limit'];
    }
    return response;
};

async function initDataset(testers) {
    const platformLimit = await getSocketCloseRateLimit();
    const limitData = testers.map((tester) => platformLimit);
    return [{
        type: 'line',
        label: 'Limit',
        borderColor: gVariable.backgroundColorAmkor[2],
        data: limitData,
        pointRadius: 0,
        pointStyle: 'line',
        datalabels: {
            display: false
        }
    }];
}

async function setChartData(testers) {
    const labels = testers.map((tester) => tester.machine_name);
    const data = testers.map((tester) => tester.close_rate);
    const limitDatasets = await initDataset(testers);
    return {
        labels: labels,
        datasets: [...limitDatasets, {
            label: 'Close rate (%)',
            data: data,
            pointStyle: 'rect',
            backgroundColor: gVariable.backgroundColorAmkor[31]
        }]
    };
};

function setChartOptions() {
    const documentStyle = getComputedStyle(document.documentElement);
    const borderColor = documentStyle.getPropertyValue('--surface-border');

    return {
        maintainAspectRatio: false,
        aspectRatio: 0.8,
        layout: {
            padding: {
                top: 30  // Add padding at the top for the labels
            }
        },
        plugins: {
            legend: {
                position: 'bottom',
                labels: {
                    usePointStyle: true
                }
            },
            // Add this datalabels configuration
            datalabels: {
                anchor: 'end',
                align: 'top',
            }
        },
        scales: {
            x: {
                grid: {
                    color: 'transparent'
                }
            },
            y: {
                grid: {
                    color: borderColor,
                    borderColor: 'transparent'
                }
            }
        }
    };
};

function getMondayDateOfTwoWeeksAgo() {
    const today = new Date();
    const dayOfWeek = today.getDay();
    const daysSinceMonday = (dayOfWeek + 6) % 7;
    const thisMonday = new Date(today);
    thisMonday.setDate(today.getDate() - daysSinceMonday);
    const startDate = new Date(thisMonday);
    startDate.setDate(thisMonday.getDate() - 14);
    return startDate;
}

async function processDailyData(data) {
    const map = new Map();
    data.forEach((item) => {
        if (!map.has(item.machine_name)) {
            map.set(item.machine_name, { totalRate: 0, count: 0 });
        }
        const machineStats = map.get(item.machine_name);
        machineStats.totalRate += item.close_rate;
        machineStats.count += 1;
    });
    const machines = [...new Set(data.map((d) => d.machine_name))];
    const dataPoints = machines.map((machine) => {
        const machineStats = map.get(machine);
        return parseFloat((machineStats.totalRate / machineStats.count).toFixed(2));
    });
    const limitDatasets = await initDataset(machines);
    return {
        labels: machines,
        datasets: [...limitDatasets, {
            label: 'Close rate (%)',
            data: dataPoints,
            backgroundColor: gVariable.backgroundColorAmkor[31],
            pointStyle: 'rect'
        }]
    };
};

async function processWeeklyData(data) {
    const map = new Map();
    data.forEach((item) => {
        const date = new Date(item.created_at);
        const weekKey = gFunc.GetWeekNumber(date);
        if (!map.has(weekKey)) {
            map.set(weekKey, new Map());
        }
        const weekMap = map.get(weekKey);
        if (!weekMap.has(item.machine_name)) {
            weekMap.set(item.machine_name, { totalRate: 0, count: 0 });
        }
        const machineStats = weekMap.get(item.machine_name);
        machineStats.totalRate += item.close_rate;
        machineStats.count += 1;
    });

    const machines = [...new Set(data.map((d) => d.machine_name))];
    const weeks = gFunc.GetWWPrevious().slice(-3);

    const limitDatasets = await initDataset(machines);

    const datasets = weeks.map((week, index) => {
        const weekMap = map.get(week);
        const dataPoints = machines.map((machine) => {
            if (!weekMap) return null;
            const stats = weekMap.get(machine);
            return stats ? parseFloat((stats.totalRate / stats.count).toFixed(2)) : null;
        });
        return {
            label: `Week ${week}`,
            data: dataPoints,
            backgroundColor: colors[index % colors.length],
            pointStyle: 'rect'
        };
    });

    return {
        labels: machines,
        datasets: [...limitDatasets, ...datasets]
    };
}

async function fetchHistory() {
    loading.value = true;
    await fetchlistTestersInfo();
    if (listTesters.value.length) {
        if (selectedViewMode.value.code == 'Monitor') {
            chartData.value = await setChartData(listTesters.value);
        }
        else if (selectedViewMode.value.code == 'Daily') {
            chartData.value = await processDailyData(listTesters.value);
        }
        else {
            chartData.value = await processWeeklyData(listTesters.value);
        }
        chartOptions.value = setChartOptions();
        tableData.value = listTesters.value;
    }
    else {
        gFunc.ShowMessage(selectedPlatformName.value['platformname'] + ' has not data to display yet.', 'error', '', 5000);
    }

    loading.value = false;
}

async function fetchlistTestersInfo() {
    let params = {
        '@end_date': gFunc.ConvertDate(new Date()),
        '@platformno': selectedPlatformName.value['platformno']
    };
    if (selectedViewMode.value.code == 'Daily') {
        params['@start_date'] = gFunc.ConvertDate(new Date(), 'YYYY-MM-DD') + ' 00:00:00.000';
    }
    else if (selectedViewMode.value.code == 'Weekly') {
        params['@start_date'] = gFunc.ConvertDate(getMondayDateOfTwoWeeksAgo());
    }
    try {
        var response = await apiClient.callSp('TestDB..USP_HCC_KIOXIA_GetSocketClose', params);
    }
    catch (error) {
        gFunc.ShowMessage('Error fetching testers.', 'error', '', 5000);
        loading.value = false;
    }
    if (response.length > 0) {
        listTesters.value = response[0]['data'];
    }
    else {
        listTesters.value = [];
        gFunc.ShowMessage('Error fetching testers.', 'error', '', 5000);
        loading.value = false;
    }
};

async function fetchlistPlatformsInfo() {
    const params = {
        "@flag": "GET_Platform_INFO"
    };
    try {
        var response = await apiClient.callSp('CIMitar_Master..USP_MA_getTesterInfo', params);
    }
    catch (error) {
        gFunc.ShowMessage('Error fetching platforms.', 'error', '', 5000);
        loading.value = false;
    }
    if (response) {
        listPlatforms.value = response[0]['data'];
    }
    else {
        listPlatforms.value = [];
        gFunc.ShowMessage('Error fetching platforms.', 'error', '', 5000);
        loading.value = false;
    }
};
onMounted(async () => {
    await fetchlistPlatformsInfo();
    selectedPlatformName.value = listPlatforms.value[9];
    await fetchHistory();
});
</script>

<template>

    <div class="card">
        <h1 class="text-3xl font-bold mb-4">Socket Close Rate</h1>
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
                    <Select v-model="selectedViewMode" inputId="view_mode" :options="viewModes" optionLabel="name"
                        class="w-full" />
                    <label for="view_mode">View Mode</label>
                </FloatLabel>
            </div>
            <div class="self-end">
                <Button label="Search" icon="pi pi-search" :loading="loading" @click="fetchHistory" />
            </div>
        </div>
        <BaseChart title="Socket Close Rate" type="bar" :data="chartData" :options="chartOptions" class="h-full"
            v-if="tableData.length" />
        <BaseTable :columns="testerTableColumns" :row-data="tableData" v-if="tableData.length" />
    </div>

</template>
<style scoped></style>
