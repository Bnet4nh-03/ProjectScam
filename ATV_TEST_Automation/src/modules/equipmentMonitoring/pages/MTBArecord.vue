<script setup>
/**
 * Imports and State Management
 * - Uses PrimeVue components for selectors
 * - Vue Reactivity (ref, computed, watch) for state
 * - Chart.js for data visualization
 */
import { ref, onMounted, onUnmounted , inject, watch, computed } from 'vue'
import TableSection from '@/modules/equipmentMonitoring/component/TableSection.vue'
import ChartSection from '@/modules/equipmentMonitoring/component/ChartSection.vue'
import TopJamTable from '@/modules/equipmentMonitoring/component/TopJamTable.vue'
import { Chart, registerables } from 'chart.js';
import Select from 'primevue/select';
import ChartDataLabels from 'chartjs-plugin-datalabels';

Chart.register(...registerables, ChartDataLabels);

const apiClient = inject('apiClient')

const reportType = ref('Daily');
const reportTypeOption = ref(["Daily","Weekly","Monthly"]);
const isDaily = computed(() => reportType.value === 'Daily' && dataType.value === 'MTBA');
const isWeekly = computed(() => reportType.value === 'Weekly' && dataType.value === 'MTBA');
const isMonthly = computed(() => reportType.value === 'Monthly' && dataType.value === 'MTBA');
const isMTBF = computed(() => dataType.value === 'MTBF');

const dataType = ref("MTBA")
const dataTypeOption = ref(["MTBA", "MTBF"])

const linesCode = ref([])
const platformModels = ref([])

const currentLineCode = ref(localStorage.getItem('currentLineCode') || '');
const currentPlatform = ref(localStorage.getItem('currentPlatform') || '');

const chartDataMap = ref({});
const chartOptionsMap = ref({});

const chartCommonDataMap = ref([])
const chartCommonOptionsMap = ref([]);

const chartMonthDataMap = ref({});
const chartMonthOptionsMap = ref({});

const chartWeekDataMap = ref({});
const chartWeekOptionsMap = ref({});

const mtbaDataTableMap = ref({});
const mtbaColumnTableMap = ref({});

const mtbaCommonDataTable = ref([])
const mtbaCommonColumnTable = ref([]);

const mtbaDataWeeklyTableMap = ref({});
const mtbaWeeklyColumnTableMap = ref({});

const mtbaDataMonthlyTableMap = ref({});
const mtbaMonthlyColumnTableMap = ref({});

const mtbaSummaryTopJamDataMap = ref({})
const mtbaSummaryTopJamColumnMap = ref({})

const mtbfDataTableMap = ref({})
const mtbfColumnTableMap = ref({})

const chartMtbfDataMap = ref({});
const chartMtbfOptionsMap = ref({});


// ---- Helper Functions ----

/**
 * Pads numbers with leading zeros (e.g., 3 -> '03')
 */
const pad2 = (num) => String(num).padStart(2, '0');
const pad4 = (num) => String(num).padStart(4, '0');


/**
 * Shifts a specific month by a delta.
 * Handles year rollover (e.g., Dec 2024 + 1 month -> Jan 2025).
 */
function shiftYearMonth(year, monthIndex, deltaMonths) {
  /*
  * Shift a (year, monthIndex) by deltaMonths.
  * monthIndex is 0–11 in JS Date.
  */
  const total = year * 12 + monthIndex + deltaMonths;
  const newYear = Math.floor(total / 12);
  // Safe modulo for negatives
  const newMonthIndex = ((total % 12) + 12) % 12;
  return { year: newYear, monthIndex: newMonthIndex };
}

/**
 * Generates a list of dates from the most recent Monday up to today.
 * Useful for "Week to Date" daily views.
 */
function getDayFromMondayToToday(){
  const today = new Date();
  const weekday = today.getDay(); // Sunday = 0, Monday = 1

  // Adjust because Python's weekday starts Monday=0, JS starts Sunday=0
  const adjustedWeekday = weekday === 0 ? 6 : weekday - 1;

  if (adjustedWeekday === 0) {
    return [today.toISOString().split('T')[0]]; // If today is Monday
  }

  // Calculate Monday
  const monday = new Date(today);
  monday.setDate(today.getDate() - adjustedWeekday);

  // Generate list of dates from Monday to today
  const daysList = [];
  for (let i = 0; i <= adjustedWeekday; i++) {
    const currentDay = new Date(monday);
    currentDay.setDate(monday.getDate() + i);
    daysList.push(currentDay.toISOString().split('T')[0]);
  }

  return daysList;

}

/**
 * Calculates the last 4 ISO weeks (WW-YYYY) relative to a reference date.
 * Returns a dictionary mapping Week-Year keys to [StartDate, EndDate] (start date from Sunday to Saturday)
 */
// function getLast4Weeks(refDate = null) {
//   const weeksDict = {};

//   const isoToDate = (year, week, weekday) => {
//     // ISO week starts Monday (weekday: 1=Mon..7=Sun)
//     const simple = new Date(year, 0, 1 + (week - 1) * 7);
//     const dayOfWeek = simple.getDay();
//     const ISOweekStart = simple;
//     if (dayOfWeek <= 4) {
//       ISOweekStart.setDate(simple.getDate() - simple.getDay() + 1);
//     } else {
//       ISOweekStart.setDate(simple.getDate() + 8 - simple.getDay());
//     }
//     ISOweekStart.setDate(ISOweekStart.getDate() + (weekday - 1));
//     return ISOweekStart;
//   };

//   const getISOWeek = (date) => {
//     const tempDate = new Date(date.getTime());
//     tempDate.setHours(0, 0, 0, 0);
//     tempDate.setDate(tempDate.getDate() + 4 - (tempDate.getDay() || 7));
//     const yearStart = new Date(tempDate.getFullYear(), 0, 1);
//     const weekNo = Math.ceil(((tempDate - yearStart) / 86400000 + 1) / 7);
//     return { year: tempDate.getFullYear(), week: weekNo };
//   };

//   const calculateWeeks = () => {
//     const today = refDate ? new Date(refDate) : new Date();
//     const { year, week } = getISOWeek(today);

//     const result = {};

//     for (let i = 3; i >= 0; i--) {
//       let targetWeek = week - i;
//       let targetYear = year;

//       // Handle wrap-around if week < 1
//       while (targetWeek < 1) {
//         targetYear -= 1;
//         const lastWeekPrevYear = getISOWeek(new Date(targetYear, 11, 28)).week;
//         targetWeek += lastWeekPrevYear;
//       }

//       const monday = isoToDate(targetYear, targetWeek, 1);
//       const sunday = isoToDate(targetYear, targetWeek, 7);

//       const key = `WW${String(targetWeek).padStart(2, '0')}-${targetYear}`;
//       result[key] = [
//         monday.toISOString().split('T')[0],
//         sunday.toISOString().split('T')[0],
//       ];
//     }
//     weeksDict.value = result;
//   };

//   calculateWeeks();

//   return weeksDict.value;
// }

/**
 * Calculates the last 4 ISO weeks (WW-YYYY) relative to a reference date.
 * Returns a dictionary mapping {Week-Year keys with [StartDate, EndDate]} (start date from Monday to Sunday)
 */
function getLast4Weeks(refDate = null) {
  // Format a Date as YYYY-MM-DD in local time (no UTC shift)
  const formatDate = (d) => {
    const y = d.getFullYear();
    const m = String(d.getMonth() + 1).padStart(2, '0');
    const day = String(d.getDate()).padStart(2, '0');
    return `${y}-${m}-${day}`;
  };

  // Get ISO week-numbering year and week (ISO 8601: Monday=1 ... Sunday=7)
  const getISOWeekInfo = (date) => {
    const d = new Date(date.getTime());
    d.setHours(0, 0, 0, 0);

    // Move to Thursday of the current ISO week
    const day = d.getDay() || 7; // Sunday->7
    d.setDate(d.getDate() + 4 - day);

    const isoYear = d.getFullYear();

    // Jan 1st of ISO year and compute week number
    const yearStart = new Date(isoYear, 0, 1);
    const week = Math.ceil((((d - yearStart) / 86400000) + 1) / 7);

    return { isoYear, week };
  };

  // Convert ISO year/week to the Monday of that ISO week
  const isoWeekToMonday = (isoYear, isoWeek) => {
    // ISO week 1 is the week with Jan 4th; get its Monday
    const jan4 = new Date(isoYear, 0, 4);
    const jan4Day = jan4.getDay() || 7; // Sunday->7
    const mondayOfWeek1 = new Date(jan4);
    mondayOfWeek1.setDate(jan4.getDate() - (jan4Day - 1));

    // Monday of target week = Monday of week1 + (isoWeek - 1) * 7
    const monday = new Date(mondayOfWeek1);
    monday.setDate(mondayOfWeek1.getDate() + (isoWeek - 1) * 7);
    return monday;
  };

  // Get number of ISO weeks in a year (52 or 53)
  const weeksInISOYear = (isoYear) => {
    // ISO week of Dec 28 always belongs to the last ISO week of the year
    const { week } = getISOWeekInfo(new Date(isoYear, 11, 28));
    return week; // 52 or 53
  };

  // Determine reference date (today or provided)
  const today = refDate ? new Date(refDate) : new Date();
  const { isoYear, week: currentWeek } = getISOWeekInfo(today);

  // Build last 4 weeks, including current week
  const result = {};
  for (let i = 3; i >= 0; i--) {
    let targetWeek = currentWeek - i;
    let targetYear = isoYear;

    // Handle wrap-around for weeks before week 1
    while (targetWeek < 1) {
      targetYear -= 1;
      targetWeek += weeksInISOYear(targetYear);
    }

    // Handle wrap-around for weeks beyond last week of the ISO year
    const weeksInYear = weeksInISOYear(targetYear);
    while (targetWeek > weeksInYear) {
      targetWeek -= weeksInYear;
      targetYear += 1;
    }

    const monday = isoWeekToMonday(targetYear, targetWeek);
    const sunday = new Date(monday);
    sunday.setDate(monday.getDate() + 6);

    const key = `WW${String(targetWeek).padStart(2, '0')}-${targetYear}`;
    result[key] = [formatDate(monday), formatDate(sunday)];
  }
  
  return result;
}

/**
 * Generates a map of the last N months.
 * Keys are 'YYYY-MM', values are [StartDate, EndDate] of that month.
 */
function lastNMonths(n, refDate = new Date(), includeCurrent = true) {
  /**
   * Returns an object:
   * {
   *   'YYYY-MM': ['YYYY-MM-01', 'YYYY-MM-DD'],
   *   ...
   * }
   * Inserted from oldest → newest (matches your Python loop).
  */
  if (n <= 0) {
    throw new Error('n must be a positive integer');
  }

  let startYear = refDate.getFullYear();
  let startMonthIndex = refDate.getMonth(); // 0-11

  if (!includeCurrent) {
    // shift one month back
    startMonthIndex -= 1;
    if (startMonthIndex < 0) {
      startMonthIndex = 11;
      startYear -= 1;
    }
  }

  const results = {};
  // Build oldest → newest (same as Python range(n-1, -1, -1))

  for (let i = n - 1; i >= 0; i--) {
    const { year: y, monthIndex: mi } = shiftYearMonth(startYear, startMonthIndex, -i);
    const ym = `${pad4(y)}-${pad2(mi + 1)}`;

    const firstDay = `${ym}-01`;
    const lastDayNum = new Date(y, mi + 1, 0).getDate(); // last day of month
    const lastDay = `${ym}-${pad2(lastDayNum)}`;

    results[ym] = [firstDay, lastDay];
  }

  return results;

}

/**
 * Fetches daily MTBA data for all days from the start of the current week (Monday) to today.
 */
async function getDayData(platform){
  const dataDay = []
  const dayList = getDayFromMondayToToday()
  for (const day of dayList){
    const resultData = {Date : day }
    const fromDate = day + ' 00:00:00'
    const toDate = day + ' 23:59:59'
    const result = await get_MTBA_data(fromDate, toDate, platform, 'Get date data')
    const dataReturn = {...resultData, ...result[0]}
    dataDay.push(dataReturn);
  }
  return dataDay
}

/**
 * Fetches MTBA data for a given dictionary of time ranges (Weeks or Months) in parallel.
 * Filters out specific exclusion periods (skip lists).
 */
async function getMonthWeekData(dateDict, platform) {
  const skip = new Set(["2025-01","2025-02","2025-03","2025-04", "2025-05","2025-06","2025-07","2025-08", "2025-09", "2025-10"]);
  const skip_2 = new Set(["2025-10", "2025-11", "2025-12"])

  const keys = Object.keys(dateDict).filter(key => {
    if (skip.has(key)) return false;
    if (skip_2.has(key) && platform == 'M850A') return false;
    return true;
  });

  const promises = keys.map(async key => {
    const range = dateDict[key]; // ['YYYY-MM-01', 'YYYY-MM-DD']
    return await getDataDictMTBA(range, key, platform);
  });

  const results = await Promise.all(promises);
  return results;
}

/**
 * Wrapper to fetch MTBA data for a specific date range key.
 */
async function getDataDictMTBA(dataList, keyData, platform){
  const resultData = {Date : keyData }
  const fromDate = dataList[0] + ' 00:00:00'
  const toDate = dataList[1] + ' 23:59:59'
  const result = await get_MTBA_data(fromDate, toDate, platform, '')
  const dataReturn = {...resultData, ...result[0]}
  return dataReturn
}

// ---- Date Formatters ----

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


/**
 * Extracts column headers from the first row of data.
 */
function getColumnDataTable(dataTable){
  if (!Array.isArray(dataTable)){
    dataTable = dataTable.value
  }

  if (!Array.isArray(dataTable) || dataTable.length === 0) {
    return [];
  }

  return Object.keys(dataTable[0]);
}

// ---- API Calls ----

/**
 * Calls stored procedure to get MTBA data.
 */
async function get_MTBA_data(fromTime, toTime, platformnm, condition) {
  let param;
  param = {
    "@from_time" : fromTime,
    "@to_time" : toTime,
    "@platformnm": platformnm,
    "@Condition": condition
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

/**
 * Generic API wrapper for retrieving common data (Lines, Platforms, Machines).
 */
async function getCommonData(condition, platformtyp, lineCode = "") {
  if (platformtyp == '' && condition == 'Get machine list'){
    platformtyp = 'TW350HT'
  }
  let param;
  param = {
    "@Condition" : condition,
    "@Platformnm": platformtyp,
    "@Current_line": lineCode
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Common_Data]", param)
  
  return resp[0]['data']
}

/**
 * Fetches details for the top jams for a specific handler.
 */
async function getTopJamListMtba(handler) {
  let param;
  let json_para = `{"handler" : "${handler}"} `
  param = {
    "@json_para" : json_para,
    }
  const resp = await apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Top_JAM_Error]", param)
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

// ---- Data Transformation ----

/**
 * Pivots raw API data into a format suitable for the generic table component.
 * Metrics (Run Time, JAM Count, MTBA) become columns, Handlers become fields.
 */
function pivotData(data, customMetrics = null) {
  //check if data is an array or not
  if (!Array.isArray(data) || data.length === 0) {
    return [];
  }
  
  // List of metrics to extract from the data
  const metrics = customMetrics || ['Run Time', 'JAM Count', 'MTBA'];
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

/**
 * Similar to pivotData but for Time-Series data (Week/Month).
 * Dates become fields.
 */
function pivotWeekMonthData(data) {
  //check if data is an array or not
  if (!Array.isArray(data) || data.length === 0) {
    return [];
  }
  
  // List of metrics to extract from the data
  const metrics = ['Run Time', 'JAM Count', 'MTBA'];
  // Create a new array, each element is a row of data according to each index
  const pivoted = metrics.map(metricName => {
    const row = { Date: metricName }; //Initial a new object with index name is Machine
    // loop through each element of the data
    data.forEach(item => {
      row[item.Date] = item[metricName]; //Assign the value of the corresponding index to the Handler name
    });
 
    return row;
  });

  return pivoted;
}


// ---- Chart Configuration ----

/**
 * Generates Chart.js configuration options.
 * Customized for MTBA with dual axis support if needed (or fixed max scale).
 */
function getChartOptions(platform, chartData, extra = 200) {
  // Gather all numeric values across all datasets
  const allValues = (chartData?.datasets ?? [])
    .flatMap(ds => ds?.data ?? [])
    .filter(v => typeof v === 'number' && !Number.isNaN(v));

  const maxData = allValues.length ? Math.max(...allValues) : 0;

  return {
    responsive: true,
    maintainAspectRatio: false,

    scales: {
      y: {
        beginAtZero: true,
        // max: maxData + extra,  // <-- vertical axis = max(data) + 200
        // Optional prettiness:
        // ticks: { stepSize: 50 }
      }
    },

    plugins: {
      legend: {
        position: 'bottom',
        labels: { usePointStyle: true, font: { size: 14 } }
      },
      title: {
        display: true,
        text: `${platform} MTBA Chart`
      },
      datalabels: {
        display: (context) => context.dataset.type === 'bar',
        anchor: 'end',
        align: 'top',
        formatter: (value) => value,
        font: { weight: 'bold', size: 12 },
        color: '#000'
      }
    }
  };
}

/**
 * Constructs the dataset for the main MTBA chart (Bar + Target Line).
 */
function generateChartDataForPlatform(rawData, columns, platform) {

  if (!rawData || rawData.length === 0 ) return []

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
  const labels = Object.keys(rawData[0]).filter(key => key !== "Machine");
  const dataChart = Object.values(rawData[2]).filter(k => k !== 'MTBA');
  const targetData = new Array(columns.length - 1).fill(target);
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

function generateChartMonthDataForPlatform(rawData, platform) {

  if (!rawData || rawData.length === 0) return null;

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
  const labels = rawData.map(item => item.Date);
  const dataChart = rawData.map(item => item.MTBA);
  const targetData = new Array(rawData.length).fill(target);
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

  chartDataMap.value = {};
  chartOptionsMap.value = {};

  mtbaDataTableMap.value = {};
  mtbaColumnTableMap.value = {};

  chartCommonDataMap.value = {};
  chartCommonOptionsMap.value = {};

  chartMonthDataMap.value = {};
  chartMonthOptionsMap.value = {};

  chartWeekDataMap.value = {};
  chartWeekOptionsMap.value = {};

  mtbaCommonDataTable.value = {};
  mtbaCommonColumnTable.value = {};

  mtbaDataWeeklyTableMap.value = {};
  mtbaWeeklyColumnTableMap.value = {};

  mtbaDataMonthlyTableMap.value = {};
  mtbaMonthlyColumnTableMap.value = {};

  mtbaSummaryTopJamColumnMap.value = {};

  mtbaSummaryTopJamDataMap.value = {};
}

/**
 * Computes which platforms to show based on the current selection.
 */
const visiblePlatforms = computed(() => {
  return currentPlatform.value ? [currentPlatform.value] : [];
});

/**
 * Initializes dropdown options on mount or when Line Code changes.
 * Ensures a valid default selection is made.
 */
async function initOptionsOnce() {
  // Tải danh sách Line Code
  linesCode.value = await getLinesCode();
  // Nếu lựa chọn cũ không hợp lệ -> chọn phần tử đầu
  if (!currentLineCode.value || !linesCode.value.includes(currentLineCode.value)) {
    currentLineCode.value = linesCode.value[0] || '';
    localStorage.setItem('currentLineCode', currentLineCode.value);
  }
  
  //Get existed platform has data MTBA
  const existedPlatform = new Set(await getPlatformType())
  const resultPlatforms = await getPlatformLineCode(currentLineCode.value)

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

// ---- Watchers ----
// Trigger data refresh when filters change.

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

watch(reportType, async (newReportType) => {
  reportType.value = newReportType
  // when changing Platform -> remove old data and fetch data for new platform
  clearMaps();
  await displayAllData();
});

watch(dataType, async (newDataType) => {
  clearMaps();
  await displayAllData();
});

/**
 * Main Data Orchestrator.
 * Determines which data to fetch based on `reportType` (Daily/Weekly/Monthly) or `dataType` (MTBA/MTBF).
 * Populates reactive state maps for Tables and Charts.
 */
async function displayAllData() {
  const platform = currentPlatform.value;
  if (!platform) return;

  if (dataType.value === 'MTBF') {
    await displayMTBFData();
    return;
  }

  // 1. Daily Data
  if (isDaily.value) {
    const result = await get_MTBA_data(getTodayDateTime(), getCurrentDateTime(), platform, '');
  
    const pivotedData = pivotData(result);
    const columns = getColumnDataTable({ value: pivotedData });

    mtbaDataTableMap.value[platform] = pivotedData;
    mtbaColumnTableMap.value[platform] = columns;
  
    const chartData = generateChartDataForPlatform(pivotedData, columns, platform);
  
    if (chartData) {
      chartDataMap.value[platform] = chartData;
      chartOptionsMap.value[platform] = getChartOptions(platform, chartData);
    }

    // Common data for Daily charts
    const dataLast3Month = await getMonthWeekData(lastNMonths(3), platform)
    const dataLast4Week = await getMonthWeekData(getLast4Weeks(), platform)
    const dataRecentdays = await getDayData(platform)
    const dataCommon = [...dataLast3Month, ...dataLast4Week, ...dataRecentdays]

    mtbaCommonDataTable.value[platform] = pivotWeekMonthData(dataCommon)

    const dataCommonColumn = [...["Date"], ...dataCommon.map(item => item.Date)]
    mtbaCommonColumnTable.value[platform] = dataCommonColumn
  
    const charCommonData = generateChartMonthDataForPlatform(dataCommon, platform)

    if (charCommonData){
      chartCommonDataMap.value[platform] = charCommonData;
      chartCommonOptionsMap.value[platform] = getChartOptions(platform + "  Common", charCommonData);
    }
    
    // Top Jam Data (Dependent on Daily Data)
    for (const [p, dataArray] of Object.entries(mtbaDataTableMap.value)) {
      if (p !== platform) continue; // Should effectively only be one, but safe check
      const topJamRows = [];
      for (const data of dataArray) {
        if (data["Machine"] === "JAM Count") {
          const entries = Object.entries(data)
            .filter(([key, value]) => key !== "Machine" && value > 0)
            .sort((a, b) => b[1] - a[1])
            .slice(0, 3);
          for (let i = 0; i < entries.length; i++) {
            const [handler, qty] = entries[i];
          
            const jamDetail = await getTopJamListMtba(handler);
          
            const jams = []
            for (const jamRow of jamDetail){
              jams.push([{No: jamRow["No"], "Jam ID": jamRow["Jam ID"], "Jam Description": jamRow["Jam Description"], Quantity: jamRow["Quantity"]}]);
            }
            topJamRows.push({
              machine: handler,
              jams: jams  
            });
          
          }
        }
      }
    
      mtbaSummaryTopJamDataMap.value[platform] = topJamRows;
      mtbaSummaryTopJamColumnMap.value[platform] = ["Top 3 Worst M/C", "No", "Jam ID", "Jam Description", "Qty", "Comment"];
    }
    
  }

  // 2. Weekly Data
  if (isWeekly.value) {
    const dataMonthly = await getMonthWeekData(lastNMonths(6), platform)
    const dataWeely = await getMonthWeekData(getLast4Weeks(), platform)
    const weeklyData = [...dataMonthly, ...dataWeely]
    mtbaDataWeeklyTableMap.value[platform] = pivotWeekMonthData(weeklyData)

    const weeklyColumn = [...["Date"], ...weeklyData.map(item => item.Date)]
    mtbaWeeklyColumnTableMap.value[platform] = weeklyColumn

    const chartWeekData = generateChartMonthDataForPlatform(weeklyData, platform)

    if (chartWeekData){
      chartWeekDataMap.value[platform] = chartWeekData;
      chartWeekOptionsMap.value[platform] = getChartOptions(platform + " Weekly", chartWeekData);
    }
  }

  // 3. Monthly Data
  if (isMonthly.value) {
    const mtbaMonthDataTable = await getMonthWeekData(lastNMonths(12), platform)
    mtbaDataMonthlyTableMap.value[platform] = pivotWeekMonthData(mtbaMonthDataTable)
  
    const monthlyColumn = [...["Date"], ...mtbaMonthDataTable.map(item => item.Date)]
  
    mtbaMonthlyColumnTableMap.value[platform] = monthlyColumn
  
    const chartMonthData = generateChartMonthDataForPlatform(mtbaMonthDataTable, platform)
  
    if (chartMonthData){
      chartMonthDataMap.value[platform] = chartMonthData;
      chartMonthOptionsMap.value[platform] = getChartOptions(platform + " Monthly", chartMonthData);
    }
  }

}

/**
 * Fetches and displays MTBF specific data.
 * Called when dataType is set to 'MTBF'.
 */
async function displayMTBFData() {
  const platform = currentPlatform.value;
  if (!platform) return;
  const mtbfResult = await get_MTBF_data(platform);
  const mtbfMetrics = ['Run Time', 'Total Assist', 'MTBF'];
  const pivotDataMtbf = pivotData(mtbfResult, mtbfMetrics);
  const mtbfColumns = getColumnDataTable({ value: pivotDataMtbf });

  mtbfDataTableMap.value[platform] = pivotDataMtbf;
  mtbfColumnTableMap.value[platform] = mtbfColumns;

  const mtbfLabels = mtbfResult.map(item => item.Handler);
  const mtbfDataChart = mtbfResult.map(item => item.MTBF);
  const chartDataMtbf = generateChartDataMtbf(mtbfLabels, mtbfDataChart);
  if (chartDataMtbf) {
    chartMtbfDataMap.value[platform] = chartDataMtbf;
    chartMtbfOptionsMap.value[platform] = getChartOptions(platform + ' MTBF');
  }
}

onMounted(async () => {
  // Tải options ban đầu và đồng bộ lựa chọn từ localStorage
  await initOptionsOnce();

  // Hiển thị dữ liệu theo lựa chọn hiện tại
  await displayAllData();

});

</script>


<template>
  <!-- Period selector -->
  <div class="card flex flex-wrap items-end gap-5">
    <FloatLabel class="w-full md:w-56" variant="on">
      <Select v-model="currentLineCode" inputId="over_label" :options="linesCode" class="w-full" />
      <label for="on_label">Line Code</label>
    </FloatLabel>

    <FloatLabel class="w-full md:w-56" variant="on">
      <Select v-model="currentPlatform" :options="platformModels" inputId="platform_select" class="w-full" />
      <label for="on_label">Platform Type</label>
    </FloatLabel>

    <FloatLabel class="w-full md:w-56" variant="on">
      <Select v-model="reportType" :options="reportTypeOption" inputId="reportType_select" class="w-full" />
      <label for="on_label">Report Type</label>
    </FloatLabel>

    <FloatLabel class="w-full md:w-56" variant="on">
      <Select v-model="dataType" :options="dataTypeOption" inputId="mtbamtbf_select" class="w-full" />
      <label for="on_label">Data Type</label>
    </FloatLabel>
  </div>

  <!-- Daily -->
  <section v-show="isDaily">
    <div v-for="platform in visiblePlatforms" :key="platform">
      <div v-if="true">
        <h2>{{ platform }} Daily Report</h2>

        <div class="card charts-row">
          <ChartSection
            v-if="chartDataMap[platform] && chartOptionsMap[platform]"
            :chartData="chartDataMap[platform]"
            :chartOptions="chartOptionsMap[platform]"
            class="chart-item"
          />
          <ChartSection
            v-if="chartCommonDataMap[platform] && chartCommonOptionsMap[platform]"
            :chartData="chartCommonDataMap[platform]"
            :chartOptions="chartCommonOptionsMap[platform]"
            class="chart-item"
          />
        </div>

        <div class="tables-row">
          <div class="card table-item">
            <TableSection
              :title="`${platform} MTBA Data Daily`"
              :columns="mtbaColumnTableMap[platform]"
              :rowData="mtbaDataTableMap[platform]"
            />
          </div>
          <div class="card table-item">
            <TableSection
              :title="`${platform} MTBA Common Data`"
              :columns="mtbaCommonColumnTable[platform]"
              :rowData="mtbaCommonDataTable[platform]"
            />
          </div>
        </div>

        <div class="card tables-row">
          <TopJamTable
            v-if="mtbaSummaryTopJamDataMap[platform]"
            :title="`${platform} Top 3 Worst M/C Daily`"
            :topJamSummary="mtbaSummaryTopJamDataMap[platform]"
          />
        </div>
      </div>
    </div>
  </section>

  <!-- Weekly -->
  <section v-show="isWeekly">
    <div v-for="platform in Object.keys(mtbaDataWeeklyTableMap)" :key="platform">
      <h2>{{ platform }} Weekly Report</h2>

      <div class="card charts-row">
        <ChartSection
          v-if="chartWeekDataMap[platform] && chartWeekOptionsMap[platform]"
          :chartData="chartWeekDataMap[platform]"
          :chartOptions="chartWeekOptionsMap[platform]"
          class="chart-item"
        />
      </div>

      <div class="tables-row">
        <div class="card table-item">
          <TableSection
            :title="`${platform} MTBA Data Weekly`"
            :columns="mtbaWeeklyColumnTableMap[platform]"
            :rowData="mtbaDataWeeklyTableMap[platform]"
          />
        </div>
      </div>
    </div>
  </section>

  <!-- Monthly -->
  <section v-show="isMonthly">
    <div v-for="platform in Object.keys(mtbaDataMonthlyTableMap)" :key="platform">
      <h2>{{ platform }} Monthly Report</h2>

      <div class="card charts-row">
        <ChartSection
          v-if="chartMonthDataMap[platform] && chartMonthOptionsMap[platform]"
          :chartData="chartMonthDataMap[platform]"
          :chartOptions="chartMonthOptionsMap[platform]"
          class="chart-item"
        />
      </div>

      <div class="tables-row">
        <div class="card table-item">
          <TableSection
            :title="`${platform} MTBA Data Monthly`"
            :columns="mtbaMonthlyColumnTableMap[platform]"
            :rowData="mtbaDataMonthlyTableMap[platform]"
          />
        </div>
      </div>
    </div>
  </section>

  <!-- MTBF Section -->
  <section v-show="isMTBF">
    <div v-for="platform in visiblePlatforms" :key="platform">
      <div v-if="mtbfDataTableMap[platform]?.length > 0">
        <h2>{{ platform }} MTBF Report</h2>

        <div class="card charts-row">
          <ChartSection
            v-if="chartMtbfDataMap[platform] && chartMtbfOptionsMap[platform]"
            :chartData="chartMtbfDataMap[platform]"
            :chartOptions="chartMtbfOptionsMap[platform]"
            class="chart-item"
          />
        </div>

        <div class="tables-row">
          <div class="card table-item">
            <TableSection
              :title="`${platform} MTBF Data`"
              :columns="mtbfColumnTableMap[platform]"
              :rowData="mtbfDataTableMap[platform]"
            />
          </div>
        </div>
      </div>
    </div>
  </section>
  
</template>


<style scoped>
h2 {
  color: black;
  font-size: 23px;
  font-weight: bold;
  margin-bottom: 1rem;
  text-align: center;
}

.platform-section {
  margin-bottom: 2rem;
}

/* Put children side-by-side */
.charts-row {
  display: flex;
  gap: 1rem;
  align-items: stretch;
  flex-wrap: wrap;           /* stack on small screens */
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
}


.table-item {
  flex: 1 1 480px;        /* each table tries to be ~480px wide */
  min-width: 320px;       /* prevent too narrow tables */
  box-sizing: border-box;
}

.reportType-selector {
  margin-top: 2rem; /* or padding-top */
}

.card {
  margin-bottom: 1rem;
}
</style>
