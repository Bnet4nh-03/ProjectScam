<script setup>
import { ref, onMounted, onUnmounted , inject, watch, computed } from 'vue'
import DatePicker from 'primevue/datepicker';
import TableSection from '@/modules/equipmentMonitoring/component/TableSection.vue'
import ChartSection from '@/modules/equipmentMonitoring/component/ChartSection.vue'
import TopJamTable from '@/modules/equipmentMonitoring/component/TopJamTable.vue'
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';

Chart.register(...registerables, ChartDataLabels);

const apiClient = inject('apiClient')

const mtbaDataTableMap = ref({});
const mtbaColumnTableMap = ref({});

const chartMtbaDataMap = ref({});
const chartMtbaOptionsMap = ref({});

const mtbfDataTableMap = ref({})
const mtbfColumnTableMap = ref({})

const chartMtbfDataMap = ref({});
const chartMtbfOptionsMap = ref({});

const mtbaSummaryTopJamDataMap = ref({})
const totalJamDataMap = ref({});
const totalJamColumnsMap = ref({});

// Date range picker refs (for Total Jam / Date Range view)
const dateRange = ref(null);
const fromDate = ref(null);
const toDate = ref(null);

// Date range / helper maps moved from MTBArecord.vue
const dateRangeSectionMap = ref({});

// Request id for concurrency control when loading date-range sections
let displayAllDataRequestId = 0;

function isLatestRequest(requestId) {
  return requestId === displayAllDataRequestId;
}

function uniqueDateColumns(data = []) {
  return ['Date', ...new Set(data.map(item => item.Date).filter(Boolean))];
}

function safeArray(data) {
  return Array.isArray(data) ? data : [];
}

async function getDayData(platform){
  const dataDay = []
  const dayList = (function getDayFromMondayToToday(){
    const today = new Date();
    const weekday = today.getDay();
    const adjustedWeekday = weekday === 0 ? 6 : weekday - 1;
    if (adjustedWeekday === 0) {
      return [today.toISOString().split('T')[0]];
    }
    const monday = new Date(today);
    monday.setDate(today.getDate() - adjustedWeekday);
    const daysList = [];
    for (let i = 0; i <= adjustedWeekday; i++) {
      const currentDay = new Date(monday);
      currentDay.setDate(monday.getDate() + i);
      daysList.push(currentDay.toISOString().split('T')[0]);
    }
    return daysList;
  })();

  for (const day of dayList){
    const resultData = {Date : day }
    const fromDate = day + ' 00:00:00'
    const toDate = day + ' 23:59:59'
    const result = await get_MTBA_data(fromDate, toDate, platform)
    const dataReturn = {...resultData, ...(result[0] || {})}
    dataDay.push(dataReturn);
  }
  return dataDay
}

async function getDataDictMTBA(dataList, keyData, platform){
  const resultData = {Date : keyData }
  const fromDate = dataList[0] + ' 00:00:00'
  const toDate = dataList[1] + ' 23:59:59'
  const result = await get_MTBA_data(fromDate, toDate, platform)
  const dataReturn = {...resultData, ...(result[0] || {})}
  return dataReturn
}

async function getMonthWeekData(dateDict, platform) {
  const skip = new Set(["2025-01","2025-02","2025-03","2025-04", "2025-05","2025-06","2025-07","2025-08", "2025-09", "2025-10"]);
  const skip_2 = new Set(["2025-10", "2025-11", "2025-12"])

  const keys = Object.keys(dateDict).filter(key => {
    if (skip.has(key)) return false;
    if (skip_2.has(key) && platform == 'M850A') return false;
    return true;
  });

  const promises = keys.map(async key => {
    const range = dateDict[key];
    return await getDataDictMTBA(range, key, platform);
  });

  const results = await Promise.all(promises);
  return results;
}

async function loadDateRangeSection(platform, from, to, requestId) {
  try {
    const dateRangeResult = await get_MTBA_data(from, to, platform);

    if (!isLatestRequest(requestId)) return;

    const pivotedData = pivotData(safeArray(dateRangeResult));
    const columns = getColumnDataTable({ value: pivotedData });

    const chartData = generateChartDataForPlatform(
      pivotedData.map(r => r.Machine ? Object.keys(r).filter(k => k !== 'Machine') : [] ).flat(),
      pivotedData.length ? pivotedData[2] : [],
      platform
    );
    const chartOptions = chartData ? getChartOptions(`${platform} Date Range`) : null;

    dateRangeSectionMap.value[platform] = {
      tableData: pivotedData,
      columns,
      chartData,
      chartOptions
    };
  } catch (error) {
    console.error(`loadDateRangeSection error [${platform}]:`, error);

    if (!isLatestRequest(requestId)) return;

    dateRangeSectionMap.value[platform] = {
      tableData: [],
      columns: [],
      chartData: null,
      chartOptions: null
    };
  }
}

function formatDateTime(dateString) {
  if (!dateString) return '';

  const date = new Date(dateString);
  if (isNaN(date.getTime())) return dateString;

  const hh = String(date.getHours()).padStart(2, '0');
  const mm = String(date.getMinutes()).padStart(2, '0');
  const ss = String(date.getSeconds()).padStart(2, '0');
  const dd = String(date.getDate()).padStart(2, '0');
  const MM = String(date.getMonth() + 1).padStart(2, '0');
  const yyyy = date.getFullYear();

  return `${hh}:${mm}:${ss} ${dd}/${MM}/${yyyy}`;
}

async function loadTotalJamSection(platform, from, to, requestId) {
  try {
    const result = await getTotalJamList(from, to, platform);
    if (!isLatestRequest(requestId)) return;
    if (result?.length) {
      totalJamDataMap.value[platform] = result;
      totalJamColumnsMap.value[platform] = Object.keys(result[0]);
    } else {
      totalJamDataMap.value[platform] = [];
      totalJamColumnsMap.value[platform] = [];
    }
  } catch (error) {
    console.error(`loadTotalJamSection error [${platform}]:`, error);
    if (!isLatestRequest(requestId)) return;
    totalJamDataMap.value[platform] = [];
    totalJamColumnsMap.value[platform] = [];
  }
}

const lineCode = ref([])
const platformModels = ref([])
const currentLineCode = ref(localStorage.getItem('currentLineCode') || '');
const currentPlatform = ref(localStorage.getItem('currentPlatform') || '');

function getTodayDate() {
  const today = new Date();
  const year = today.getFullYear();
  const month = String(today.getMonth() + 1).padStart(2, '0');
  const day = String(today.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

function getTodayDateTime(){
  const today = getTodayDate();
  return `${today} 00:00:00`;   //return '2025-11-04 00:00:00'
}

function getCurrentDateTime() {
    const now = new Date();

    const year = now.getFullYear();
    const month = String(now.getMonth() + 1).padStart(2, '0');
    const day = String(now.getDate()).padStart(2, '0');
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
    const seconds = String(now.getSeconds()).padStart(2, '0');

    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
  }

function getColumnDataTable(dataTable){
  if (!Array.isArray(dataTable.value) || dataTable.value.length === 0) {
    return [];
  }
  return Object.keys(dataTable.value[0]);
}

async function get_MTBA_data(fromTime, toTime, platformnm) {
  let param;
  param = {
    "@from_time" : fromTime,
    "@to_time" : toTime,
    "@platformnm": platformnm
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_MTBA_Data]", param)
  return resp[0]['data']
  
}

async function get_MTBF_data(platformnm) {
  let param;
  param = {
    "@platformnm": platformnm
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_MTBF_Data]", param)

  return resp[0]['data']
}

async function getCommonData(condition, platformtyp, line_code = "") {
  if (platformtyp == '' && condition == 'Get machine list'){
    platformtyp = 'TW350HT'
  }
  let param;
  param = {
    "@Condition" : condition,
    "@Platformnm": platformtyp,
    "@Current_line": line_code
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Common_Data]", param)
  
  return resp[0]['data']
}

async function getTopJamListMtba(handler) {
  let param;
  let json_para = `{"handler" : "${handler}"} `
  param = {
    "@json_para" : json_para,
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Top_JAM_Error]", param)
  return resp[0]['data']
}

async function getTotalJamList(from_date, to_date, platform_type) {
  let param;
  param = {
    "@From_date" : from_date,
    "@To_date": to_date,
    "@Platform_type": platform_type
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Total_JAM_List]", param)
  
  return resp[0]['data']
}

async function getPlatformType() {
  const platFormTyps = await getCommonData('Get rsc type', '')
  const platFormItems = platFormTyps.map(item => item.rcs_type)
  return platFormItems
}

async function getLinesCode() {
  const result = await getCommonData('Get current line', '', '')
  const allLineCode = result.map(item => item.current_line)
  return allLineCode
}

async function getPlatformLineCode(lineCode) {
  const result = await getCommonData('Get platform', '', lineCode)
  const allPlatform = result.map(item => item.model_no)
  return allPlatform
}

function pivotData(data, metrics) {
  //check if data is an array or not
  if (!Array.isArray(data) || data.length === 0) {
    return [];
  }
  
  // Create a new array, each element is a row of data according to each index
  const pivoted = metrics.map(metricName => {
    const row = { Machine: metricName }; //Initial a new object with index name is Machine
    // loop through each element of the data
    data.forEach(item => {
      row[item.Handler] = item[metricName]; //Assign the value of the corresponding index to the Handler name
    });
 
    return row;
  });

  return pivoted;
}

function getChartOptions(text) {
  return {
    responsive: true, // Biểu đồ tự động điều chỉnh kích thước theo màn hình
    maintainAspectRatio: false, // Không giữ tỷ lệ khung hình gốc (cho phép biểu đồ co giãn tự do)

    plugins: {
      legend: {
        position: 'bottom', // Vị trí của chú thích (legend) nằm dưới biểu đồ
        labels: {
          usePointStyle: true, // Dùng biểu tượng điểm thay vì hình chữ nhật
          font: { size: 14 } // Kích thước chữ trong legend
        }
      },

      title: {
        display: true, // Hiển thị tiêu đề biểu đồ
        text: text + ' Chart Data' // Nội dung tiêu đề
      },

      datalabels: {
        display: function(context) {
          return context.dataset.type === 'bar';
        },
        anchor: 'end', // Vị trí neo của nhãn (ở cuối cột)
        align: 'top', // Căn nhãn ở phía trên
        formatter: value => value, // Hàm định dạng giá trị hiển thị
        font: {
          weight: 'bold', // Chữ đậm
          size: 12 // Kích thước chữ
        },
        color: '#000' // Màu chữ là đen
      }
    }
  };
}

function generateChartDataForPlatform(labels, dataChart, platform) {

  if (!labels || !dataChart === 0 ) return null;

  let target;
  switch (platform) {
    case 'TW350HT':
      target = 350;
      break;
    case 'M6243':
    case 'M850A':
      target = 300;
      break;
    case 'TWSL301N':
      target = 300;
      break;
    case 'HT-7045':
    case 'HT-9045F':
      target = 250;
      break;
    default:
      //target = 200;
  }
  const targetData = new Array(labels.length).fill(target);
  const barColors = dataChart.map(value => value < target ? '#df7132' : '#92d050');
  const bar2Color = barColors[0] === '#92d050' ? '#df7132' : '#92d050';

  const datasets = [
    {
      type: 'line',
      label: 'Target',
      data: targetData,
      borderColor: '#156082',
      backgroundColor: '#156082',
      fill: false,
      tension: 0.8,
      pointStyle: 'line'
    },
    {
      type: 'bar',
      label: 'MTBA',
      data: dataChart,
      backgroundColor: barColors,
      pointStyle: 'rect',
      barThickness: 30
    },
    {
      type: 'bar',
      label: 'MTBA',
      backgroundColor: bar2Color,
      pointStyle: 'rect',
    }
  ];

  return {
    labels,
    datasets
  };
}

function generateChartDataMtbf(labels, dataChart) {

  if (!labels || !dataChart === 0 ) return null;

  const datasets = [
    {
      type: 'bar',
      label: 'MTBF',
      data: dataChart,
      backgroundColor: '#0d437f',
      pointStyle: 'rect',
      barThickness: 30
    },

  ];

  return {
    labels,
    datasets
  };
}

// ==== Helpers ====
function clearMaps() {
  mtbaDataTableMap.value = {};
  mtbaColumnTableMap.value = {};
  chartMtbaDataMap.value = {};
  chartMtbaOptionsMap.value = {};

  // mtbfDataTableMap.value = {};
  // mtbfColumnTableMap.value = {};
  // chartMtbfDataMap.value = {};
  // chartMtbfOptionsMap.value = {};

  mtbaSummaryTopJamDataMap.value = {};
  totalJamDataMap.value = {};
  totalJamColumnsMap.value = {};
}

// Chỉ render platform hiện đang chọn
const visiblePlatforms = computed(() => {
  return currentPlatform.value ? [currentPlatform.value] : [];
});

// ==== Init options (tải options một lần khi mount hoặc khi Line Code đổi) ====
async function initOptionsOnce() {
  // Tải danh sách Line Code
  
  lineCode.value = await getLinesCode();
  // Nếu lựa chọn cũ không hợp lệ -> chọn phần tử đầu
  if (!currentLineCode.value || !lineCode.value.includes(currentLineCode.value)) {
    currentLineCode.value = lineCode.value[0] || '';
    localStorage.setItem('currentLineCode', currentLineCode.value);
  }

  //Get existed platform has data MTBA
  const existedPlatform = new Set(await getPlatformType())
  const resultPlatforms = await getPlatformLineCode(currentLineCode.value);

  //Remove platform does not has data
  for (const item of resultPlatforms){
    if (existedPlatform.has(item)){
      platformModels.value.push(item)
    }
  }

  if (!currentPlatform.value || !platformModels.value.includes(currentPlatform.value)) {
    currentPlatform.value = platformModels.value[0] || '';
    localStorage.setItem('currentPlatform', currentPlatform.value);
  }
}

// ==== Watchers cho filter ====
watch(currentLineCode, async (newLine) => {
  platformModels.value = []
  localStorage.setItem('currentLineCode', newLine || '');

  //Get existed platform has data MTBA
  const existedPlatform = new Set(await getPlatformType())
  const resultPlatforms = await getPlatformLineCode(newLine);
  //Remove platform does not has data
  for (const item of resultPlatforms){
    if (existedPlatform.has(item)){
      platformModels.value.push(item)
    }
  }

  // platformModels.value = await getPlatformLineCode(newLine);

  // Synchronize currentPlatform with the new list.
  if (!platformModels.value.includes(currentPlatform.value)) {
    currentPlatform.value = platformModels.value[0] || '';
    localStorage.setItem('currentPlatform', currentPlatform.value);
  }

  // when changing Line -> remove old data và fetch data for current platform 
  clearMaps();
  await displayAllData();
});

watch(currentPlatform, async (newPlatform) => {
  localStorage.setItem('currentPlatform', newPlatform || '');

  // when changing Platform -> remove old data and fetch data for new platform
  clearMaps();
  await displayAllData();
});

// Watcher for date range selection: load date-range chart/table and total jam list
function formatYMD(d) {
  const dt = d instanceof Date ? d : new Date(d);
  const y = dt.getFullYear();
  const m = String(dt.getMonth() + 1).padStart(2, '0');
  const day = String(dt.getDate()).padStart(2, '0');
  return `${y}-${m}-${day}`;
}

watch(dateRange, async (newRange) => {
  const isValid = Array.isArray(newRange) && newRange.length === 2 && newRange[0] && newRange[1];
  if (!isValid) return;

  const startStr = formatYMD(newRange[0]);
  const endStr = formatYMD(newRange[1]);

  const from = `${startStr} 00:00:00`;
  const to = `${endStr} 23:59:59`;

  fromDate.value = new Date(startStr);
  toDate.value = new Date(endStr);

  const platform = currentPlatform.value;
  if (!platform) return;

  const requestId = ++displayAllDataRequestId;
  await Promise.all([
    loadDateRangeSection(platform, from, to, requestId),
    loadTotalJamSection(platform, from, to, requestId)
  ]);
});

// ==== CHỈ fetch data cho platform đã chọn ====
async function displayAllData() {
  const platform = currentPlatform.value;
  if (!platform) return;

  try {
    // ===== CALL APIs song song =====
    const [mtbaResult, mtbfResult, totalJamResult] = await Promise.all([
      get_MTBA_data(getTodayDateTime(), getCurrentDateTime(), platform),
      get_MTBF_data(platform),
      getTotalJamList(getTodayDate(), getTodayDate(), platform)
    ]);

    // ===== MTBA =====
    const mtbaMetrics = ['Run Time', 'JAM Count', 'MTBA'];
    const pivotMtba = pivotData(mtbaResult, mtbaMetrics);
    mtbaDataTableMap.value[platform] = pivotMtba;
    mtbaColumnTableMap.value[platform] = getColumnDataTable({ value: pivotMtba });

    // Chart MTBA
    const chartDataMtba = generateChartDataForPlatform(
      mtbaResult.map(i => i.Handler),
      mtbaResult.map(i => i.MTBA),
      platform
    );

    if (chartDataMtba) {
      chartMtbaDataMap.value[platform] = chartDataMtba;
      chartMtbaOptionsMap.value[platform] = getChartOptions(`${platform} MTBA`);
    }

    // ===== MTBF =====
    const mtbfMetrics = ['Run Time', 'Total Assist', 'MTBF'];
    const pivotMtbf = pivotData(mtbfResult, mtbfMetrics);
    mtbfDataTableMap.value[platform] = pivotMtbf;
    mtbfColumnTableMap.value[platform] = getColumnDataTable({ value: pivotMtbf });

    // Chart MTBF
    const chartDataMtbf = generateChartDataMtbf(
      mtbfResult.map(i => i.Handler),
      mtbfResult.map(i => i.MTBF)
    );

    if (chartDataMtbf) {
      chartMtbfDataMap.value[platform] = chartDataMtbf;
      chartMtbfOptionsMap.value[platform] = getChartOptions(`${platform} MTBF`);
    }

    // ===== TOP JAM (OPTIMIZED) =====
    const jamRow = pivotMtba.find(d => d.Machine === 'JAM Count');

    let topJamRows = [];
    if (jamRow) {
      const topHandlers = Object.entries(jamRow)
        .filter(([key, val]) => key !== 'Machine' && val > 0)
        .sort((a, b) => b[1] - a[1])
        .slice(0, 3)
        .map(([handler]) => handler);

      const jamDetails = await Promise.all(
        topHandlers.map(handler => getTopJamListMtba(handler))
      );

      topJamRows = topHandlers.map((handler, index) => ({
        machine: handler,
        jams: jamDetails[index].map(j => ({
          No: j['No'],
          'Jam ID': j['Jam ID'],
          'Jam Description': j['Jam Description'],
          Quantity: j['Quantity']
        }))
      }));
    }

    mtbaSummaryTopJamDataMap.value[platform] = topJamRows;

    // ===== TOTAL JAM =====
    if (totalJamResult?.length) {
      totalJamDataMap.value[platform] = totalJamResult;
      totalJamColumnsMap.value[platform] = Object.keys(totalJamResult[0]);
    }

  } catch (error) {
    console.error('displayAllData error:', error);
  }
}

onMounted(async () => {
  // Tải options ban đầu và đồng bộ lựa chọn từ localStorage
  await initOptionsOnce();

  // Hiển thị dữ liệu theo lựa chọn hiện tại
  await displayAllData();

  // Refresh mỗi 3 phút: chỉ refresh data theo lựa chọn hiện tại, KHÔNG reset options
  const intervalId = setInterval(async () => {
    await displayAllData();
  }, 180000);

  // Dọn interval khi unmount
  onUnmounted(() => {
    clearInterval(intervalId);
  });
});

</script>


<template>
  <div class="card flex flex-wrap items-end gap-5">
    <FloatLabel class="w-full md:w-56">
      <Select v-model="currentLineCode" inputId="over_label" :options="lineCode" class="w-full" />
      <label for="over_label">Line Code</label>
    </FloatLabel>

    <FloatLabel class="w-full md:w-56">
      <Select v-model="currentPlatform" inputId="over_label" :options="platformModels" class="w-full" />
      <label for="over_label">Platform Type</label>
    </FloatLabel>
      <FloatLabel class="w-full md:w-72">
        <DatePicker
          v-model="dateRange"
          inputId="date_range"
          selectionMode="range"
          dateFormat="mm/dd/yy"
          showIcon
          :manualInput="false"
          class="w-full"
        />
        <label for="date_range">Date Range</label>
      </FloatLabel>
  </div>

  <div v-for="platform in visiblePlatforms" :key="platform">
    <div>
      <h2>{{ platform }} MTBA Data Visualization</h2>

      <div class="card charts-row">
        <ChartSection
          v-if="chartMtbaDataMap[platform] && chartMtbaOptionsMap[platform]"
          :chartData="chartMtbaDataMap[platform]"
          :chartOptions="chartMtbaOptionsMap[platform]"
          class="chart-item"
        />
        <!--
        <ChartSection
          v-if="chartMtbfDataMap[platform] && chartMtbfOptionsMap[platform]"
          :chartData="chartMtbfDataMap[platform]"
          :chartOptions="chartMtbfOptionsMap[platform]"
          class="chart-item"
        />
        -->
      </div>

      <div class="card tables-row">
        <div class="table-item">
          <TableSection
            :title="`${platform} MTBA Data`"
            :columns="mtbaColumnTableMap[platform]"
            :rowData="mtbaDataTableMap[platform]"
          />
        </div>
        <!--
        <div class="table-item">
          <TableSection
            :title="`${platform} MTBF Data`"
            :columns="mtbfColumnTableMap[platform]"
            :rowData="mtbfDataTableMap[platform]"
          />
        </div>
        -->
      </div>

      <div class="card tables-row">
        <TopJamTable
          v-if="mtbaSummaryTopJamDataMap[platform]"
          :title="`${platform} Top 3 Worst M/C`"
          :topJamSummary="mtbaSummaryTopJamDataMap[platform]"
        />
      </div>
      
      <div class="card tables-row" v-if="totalJamDataMap[platform]">
        <div class="table-item">
          <TableSection
            :title="`${platform} Total Jam List`"
            :columns="totalJamColumnsMap[platform]"
            :rowData="totalJamDataMap[platform]"
          />
        </div>
      </div>
    </div>
  </div>

</template>


<style scoped>

h2 {
  margin-top: 2rem;
  color: black;
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 1rem;
  text-align: center;
}

/* Put children side-by-side */
.charts-row {
  display: flex;
  gap: 1rem;
  align-items: stretch;
  flex-wrap: wrap;           /* stack on small screens */
  margin-bottom: 2rem;       /* thêm khoảng cách dưới chart */
}

/* Each chart takes half width */
.chart-item {
  flex: 1 1 480px;           /* grow, shrink, base width ~480px */
  min-width: 320px;          /* allow two charts on medium screens */
}

.tables-row {
  display: flex;
  gap: 1rem;                 /* space between tables */
  flex-wrap: wrap;           /* stack on small screens */
  margin-bottom: 2rem;       /* thêm khoảng cách dưới table */
}

.table-item {
  flex: 1 1 480px;        /* each table tries to be ~480px wide */
  min-width: 320px;       /* prevent too narrow tables */
  box-sizing: border-box;
}

.line-selector {
  margin-top: 2rem; /* or padding-top */
}

.card {
  margin-bottom: 1rem;
}

</style>
