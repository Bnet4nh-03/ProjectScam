<script setup>
// Imports for Vue features, UI components, and charting
import { ref, onMounted, inject, watch } from 'vue'
import DatePicker from 'primevue/datepicker';
import Select from 'primevue/select';
import TableSection from '@/modules/equipmentMonitoring/component/TableSection.vue'
import ChartSection from '@/modules/equipmentMonitoring/component/ChartSection.vue'
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';

// Register Chart.js components and plugins
Chart.register(...registerables, ChartDataLabels);

// Inject API client for making backend calls
const apiClient = inject('apiClient')

// Reactive state for filter inputs
const rscItems = ref([]);    // List of RSC types (e.g., TW350HT)
const rscType = ref('');     // Selected RSC type
const fromDate = ref('');    // Start date for filter
const toDate = ref('');      // End date for filter


// Reactive state for Data Table and Chart
const jamDataTable = ref([])      // Data for the table
const jamColumnTable = ref([]);   // Column definitions for the table

const jamDataChart = ref()        // Data for the chart
const chartOptions = ref();       // Configuration options for the chart

const machineList = ref([]);      // List of machines (Handlers)


// --- Date Helper Functions ---

// Get today's date in YYYY-MM-DD format
function getTodayDate() {
  const today = new Date();
  const year = today.getFullYear();
  const month = String(today.getMonth() + 1).padStart(2, '0');
  const day = String(today.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

// Get the date 7 days ago in YYYY-MM-DD format
function getLast7Days() {
  const today = new Date();
  today.setDate(today.getDate() - 7);
  const year = today.getFullYear();
  const month = String(today.getMonth() + 1).padStart(2, '0');
  const day = String(today.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

// Convert 'YYYY-MM-DD' string to Date object
function parseDateString(dateString) {
  // dateString format: 'YYYY-MM-DD'
  const [year, month, day] = dateString.split('-').map(Number);
  return new Date(year, month - 1, day); // month is zero-based
}

// Format Date object or string to 'YYYY-MM-DD'
function formatDate(dateInput) {
  // If input is a string like '10/18/2025'
  if (typeof dateInput === 'string') {
    const [month, day, year] = dateInput.split('/');
    return `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`;
  }

  // If input is a Date object
  if (dateInput instanceof Date) {
    const year = dateInput.getFullYear();
    const month = String(dateInput.getMonth() + 1).padStart(2, '0');
    const day = String(dateInput.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }
  return '';
}

// Return start and end timestamps for a date range
function getDate(fromDate, toDate) {
  return {
    from: formatDate(fromDate) + ' 00:00:00',
    to: formatDate(toDate) + ' 23:59:59'
  };
}

// --- Watchers ---

// Watch for changes in RSC Type or Dates. Re-fetch data when all filters are present.
watch([rscType,fromDate, toDate], async ([newRSC, newFrom, newTo]) => {
  if (newRSC &&  newFrom && newTo) {
    const { from, to } = getDate(newFrom, newTo);
    // Fetch table, chart, and machine list data
    await get_JAM_data('Get_data_table', newRSC, from, to);
    await get_JAM_data('Get_data_chart', newRSC, from, to);
    await getMachineList();
  }
});

// Helper to extract column headers from data
function getColumnDataTable(dataTable){
  if (!Array.isArray(dataTable.value) || dataTable.value.length === 0) {
    return [];
  }
  return Object.keys(dataTable.value[0]);

}

// --- API Calls ---

// Main function to fetch JAM data (Table or Chart) based on condition
async function get_JAM_data(condition, rsc_type, fromDate, toDate) {
  let param;
  // If dates are provided, use them; otherwise default to last 7 days
  if (fromDate != '' && toDate != ''){
    param = {
      "@CONDITION" : condition,
      "@RSC_TYPE" : rsc_type,
      "@FROM_DATE": fromDate,
      "@TO_DATE": toDate
      }
  }
  else{
    const today = getTodayDate();
    param = {
      "@CONDITION" : condition,
      "@RSC_TYPE" : 'TW350HT',
      "@FROM_DATE": getLast7Days(),
      "@TO_DATE": today
      }
  }
  
  // Call Stored Procedure
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_JAM_Error_Data]", param)
  
  // Handle response based on request type (Table vs Chart)
  if (condition == 'Get_data_table'){
    jamDataTable.value = resp[0]['data']
    jamColumnTable.value = getColumnDataTable(jamDataTable)
  }
  else{
    const result = resp[0]['data']
    jamDataChart.value = getChartData(result);
    chartOptions.value = getChartOptions();
  }
  
}

// Fetch common data like Resource Types or Machine Lists
async function getCommonData(condition, platformtyp) {
  ;
  if (platformtyp == '' && condition == 'Get machine list'){
    platformtyp = 'TW350HT'
  }
  let param;
  param = {
    "@Condition" : condition,
    "@Platformnm": platformtyp
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Common_Data]", param)
  ;
  return resp[0]['data']
}

// Fetch available Platform/RSC Types and populate dropdown
async function getPlatformType() {
  const platFormTyps = await getCommonData('Get rsc type', '')
  const platFormItems = platFormTyps.map(item => item.rcs_type)
  rscItems.value = platFormItems
}

// Fetch list of machines based on selected RSC type
async function getMachineList() {
  const machinData = await getCommonData('Get machine list', rscType.value)
  ;
  const allMachine = machinData.map(item => item.handler)
  machineList.value = allMachine
}

// --- Chart Configuration ---

// Process raw data into Chart.js format
function getChartData(chartData) {
  if (chartData.length === 0) return;
  
  const rawData = chartData;
  const labels = rawData.map(row => row.Datetime); // X-axis labels (Time)
  const totalData = rawData.map(row => row.Total); // Line chart data
  const keys = Object.keys(rawData[0]).filter(k => k !== 'Datetime' && k !== 'Total'); // Bar chart keys
  
  const colors = ['#ff6384', '#36a2eb', '#cc65fe', '#ffce56', '#4bc0c0', '#9966ff', '#9fc0df', '#4f8dc4', '#0d437f'];
  const getColor = index => colors[index % colors.length];

  // Combine Line (Total) and Bar (Specific Errors) datasets
  const datasets = [
    {
      type: 'line',
      label: 'Total',
      data: totalData,
      borderColor: '#007bff',
      backgroundColor: '#007bff',
      fill: false,
      tension: 0.3,
      pointStyle: 'dot'
    },
    ...keys.map((key, index) => ({
      type: 'bar',
      label: key,
      data: rawData.map(row => row[key]),
      backgroundColor: getColor(index),
      // barThickness: 20,
      pointStyle: 'rect'
    }))
  ];
  
  return {
    labels,
    datasets
  };
}

// Define Chart options (Responsive, Titles, Legend)
function getChartOptions() {
  return {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
      legend: { 
        position: 'bottom', 
        labels: {usePointStyle: true }
      },
      title: { 
        display: true, 
        text: 'Jam Worse Error Chart' },
    }
  };
}

// --- Lifecycle Hook ---

// Initialize default values and fetch initial data on component mount
onMounted(() => {
  rscType.value = 'TW350HT'
  fromDate.value = parseDateString(getLast7Days());
  toDate.value = parseDateString(getTodayDate());

  getPlatformType();

  // getMachineList();

  // Initial data fetch
  get_JAM_data('Get_data_table', rscType.value, getLast7Days(), getTodayDate())
  get_JAM_data('Get_data_chart', rscType.value, getLast7Days(), getTodayDate())


})

</script>


<template>
  <!-- Filter Section: Date Range and RSC Type Selector -->
  <div class="card flex flex-wrap gap-4">
    <div>
      <label for="fromDate" class="font-bold block mb-2">From Date</label>
      <DatePicker v-model="fromDate" showIcon fluid :showOnFocus="false" inputId="fromDate" />
    </div>
    <div>
      <label for="toDate" class="font-bold block mb-2">To Date</label>
      <DatePicker v-model="toDate" showIcon fluid :showOnFocus="false" inputId="toDate" />
    </div>
    <div>
      <label for="rcsType" class="font-bold block mb-2">RSC Type</label>
      <Select v-model="rscType" :options="rscItems" placeholder="Select RSC Type" class="w-full md:w-56" />
    </div>
  </div>

  <!-- Chart Display Section -->
  <div>
    <div class="chart-row">
      <ChartSection v-if="jamDataChart && chartOptions" :chartData="jamDataChart" :chartOptions="chartOptions"/>
      <!-- <ChartSection v-if="showChart" :chartData="jamChartData"/> -->
    </div>
  </div>
  
  <!-- Table Display Section -->
  <div>
    <TableSection title="JAM Worse Error List" :columns=jamColumnTable :rowData=jamDataTable />
  </div>
  <!-- <p>Machine list = {{ machineList }}</p> -->
</template>

<style scoped>

h2 {
  color: black;
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 1rem;
  text-align: center;
}

.chart-row {
  display: flex;
  gap: 20px; /* gap between charts */
  flex-wrap: wrap; /* wrap to new line if small screen */
  margin-bottom: 2rem;
}

</style>
