<script setup>
/**
 * ---------------------------------------------------------------------------------------------------------
 * IMPORTS
 * ---------------------------------------------------------------------------------------------------------
 */
import { inject, computed, onMounted, ref, onBeforeMount } from 'vue';
import BaseTable from '@/modules/registerMachine/component/BaseTable.vue';
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import * as XLSX from 'xlsx';
import axios from "axios";
import { add } from 'lodash';

/**
 * ---------------------------------------------------------------------------------------------------------
 * INJECTED DEPENDENCIES
 * ---------------------------------------------------------------------------------------------------------
 */
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');
const authStore = useAuthStore();


/**
 * ---------------------------------------------------------------------------------------------------------
 * STATE - TABLE OPTIONS & FLAGS
 * ---------------------------------------------------------------------------------------------------------
 */

// Data for select options

const platformNameDataTable = ref([]);
const testerDataTable = ref([]);
const testerEnvDataTable = ref([]);
const handlerDataTable = ref([]);

const testerListData = ref([]);
const handlerListData = ref([]);
const handlerCompanyListData = ref([]);
const handlerTypeListData = ref([]);
const platformTypeListData = ref([]);
const platformNameListData = ref([]);




// const platformTypes = ref([]);
// const platformName = ref([]);

// UI flags
const allowAddRow = true;
const allowUploadData = true;
const allowSubmit = true;
const allowRefresh = true;
const allowSearching = true;
const enablePaginator = true;
const enableAction = true;


/**
 * ---------------------------------------------------------------------------------------------------------
 * LIFECYCLE
 * ---------------------------------------------------------------------------------------------------------
 */

// Initialize data before component mounts
onBeforeMount(async () => {
  await refresh();
});

// Reserved for future use
onMounted(() => {});

/**
 * ---------------------------------------------------------------------------------------------------------
 * DATA LOADING
 * ---------------------------------------------------------------------------------------------------------
 */

/**
 * Reset state and reload data
 */
async function refresh() {
  platformNameDataTable.value = [];
  testerDataTable.value = [];
  // testerEnvDataTable.value = [];
  handlerDataTable.value = [];

  testerEnvDataTable.value = {
    handlersByCompany: {},
    testersByPlatformType: {}
  };


  platformTypeListData.value = [];
  handlerCompanyListData.value = [];
  handlerTypeListData.value = [];
  platformNameListData.value = [];
  await loadData();
}

/**
 * Load initial data from API
 */
const testerTableColumns = [
  { label: "Factory", field: "factory" },
  { label: "Tester ID", field: "testerid" },
  { label: "Tester No", field: "testerno" },
  { label: "Platform Type Name", field: "platformtypename" },
  { label: "Platform Name", field: "platformname" },
  { label: "Host Name", field: "hostname" },
  { label: "Tester Name", field: "testername" },
  { label: "EMES Host", field: "emeshost" },

];

const handlerTableColumns = [
  { label: "Factory", field: "factory" },
  { label: "Handler Id", field: "handlerid" },
  { label: "Handler Company", field: "mfg" },
  { label: "Handler Host Name", field: "hanhostnm" },
  { label: "rfidnm", field: "rfidnm" },
  { label: "Asset No", field: "assetno" },
  { label: "Serial No", field: "serialno" },
];

async function loadPlatformTypes() {
  const res = await apiClient.callSp(
    "DBMGMT..USP_MANAGER_GetPlatformTypes",
    {}
  );
  platformTypeListData.value = res[0].data;
}

async function loadPlatformName() {
  const res = await apiClient.callSp(
    "DBMGMT..USP_MANAGER_GetPlatforms",
    { '@platformtypeno': -1 }
  );
  platformNameListData.value = res[0].data;
}

async function loadHandlerCompanies() {
  const res = await apiClient.callSp(
    "TestDB..USP_RegisterMachine_GetHandlerCompanies",
    {}
  );
  handlerCompanyListData.value = res[0].data;
}

async function loadHandlerTypes() {
  const res = await apiClient.callSp(
    "TestDB..USP_RegisterMachine_GetHandlerTypes",
    {}
  );
  handlerTypeListData.value = res[0].data;
}

async function loadTesters() {
  const res = await apiClient.callSp(
    "TestDB..USP_RegisterMachine_GetTesterList",
    {}
  );
  testerDataTable.value = res[0];
  testerListData.value = res[0].data;
}

async function loadHandlers() {
  const res = await apiClient.callSp(
    "TestDB..USP_RegisterMachine_GetHandlerList",
    {}
  );
  handlerDataTable.value = res[0];
  handlerListData.value = res[0].data;
}

async function refreshHandlers() {
  try {
    await loadData();
    await loadHandlers();
    gFunc.ShowMessage("Handlers refreshed successfully", "success", "", 3000);
  } catch (error) {
    gFunc.ShowMessage("Refresh handlers failed", "error", "", 3000);
  }
}


async function refreshTesters() {
  try {
    await loadData();
    await loadTesters();
    gFunc.ShowMessage("Testers refreshed successfully", "success", "", 3000);
  } catch (error) {
    gFunc.ShowMessage("Refresh testers failed", "error", "", 3000);
  }
}

async function loadData() {
  await loadPlatformTypes();
  await loadHandlerCompanies();
  await loadHandlerTypes();
  await loadTesters();
  await loadHandlers();
  await loadPlatformName();
}

/**
 * ---------------------------------------------------------------------------------------------------------
 * TABLE SCHEMA (DYNAMIC CONFIGURATION)
 * ---------------------------------------------------------------------------------------------------------
 */

const TABLE_SCHEMA = computed(() => ({

  
  platformTypeName: [
    { label: "No", field: "no", mode: "view" },
    {
      label: "Platform Type Name",
      field: "platformTypeName",
      mode: "input",
      required: true
    },
    { label: "Status", field: "status", type: "status",mode: "status"}
  ],

  platformName: [
    { label: "No", field: "no", mode: "view" },

    {
      label: "Platform Type Name",
      field: "platformTypeNameNo",
      mode: "select",
      options: platformTypeListData.value,
      optionLabel: "platformtypename",
      optionValue: "platformtypeno",
      required: true,
    },

    {
      label: "Platform Name",
      field: "platformName",
      mode: "input",
      required: true
    },
    { label: "Status", field: "status", type: "status",mode: "status"}
  ],
  
  tester: [
    { label: "No", field: "no", mode: "view" },

    // { label: "Locate", field: "locate", mode: "input", required: true },

    {
      label: "Platform Type Name",
      field: "platformtypeno",
      mode: "select",
      options: platformTypeListData.value,
      optionLabel: "platformtypename",
      optionValue: "platformtypeno",
      required: true,
    },
    
    
    {
      label: "Platform Name",
      field: "platformName",
      mode: "select",
      /**
       * Dynamic options based on selected platform type
       */
      getOptions: (row) => {
        if (!row.platformtypeno) return [];
        return testerDataTable.value[row.platformtypeno] ?? [];
      },
      optionLabel: "platformname",
      optionValue: "platformno",
      required: true,
    },

    { label: "Hostname", field: "hostname", mode: "input", required: true },
    { label: "Tester name", field: "testerName", mode: "input", required: true },
    { label: "EmesHost", field: "emesHost", mode: "input", required: true },
    { label: "Status", field: "status", type: "status",mode: "status"}
    // { label: "Asset No", field: "assetNo", mode: "input", required: true },
    // { label: "Serial No", field: "serialNo", mode: "input", required: true },
  ],

  handler: [
    { label: "No", field: "no", mode: "view" },
    {
      label: "MFG",
      field: "hancompno",
      mode: "select",
      options: handlerCompanyListData.value,
      optionLabel: "hancompnm",
      optionValue: "hancompno",
      required: true,
    },
    {
      label: "Handler Type Name",
      field: "hantypeno",
      mode: "select",
      getOptions: (row) => {
        if (!row.hancompno) return [];
        return handlerDataTable.value[row.hancompno] ?? [];
      },
      optionLabel: "hantypenm",
      optionValue: "hantypeno",
      required: true,
    },
    { label: "Handler Host Name", field: "hanhostnm", mode: "input", required: true },
    { label: "rfiddrm", field: "rfiddrm", mode: "input", required: true },
    { label: "Serial no", field: "SerialNo", mode: "input", required: true },
    { label: "Owner", field: "owner", mode: "input", required: true },
    { label: "Asset no", field: "assetNo", mode: "input", required: true },
    { label: "Status", field: "status", type: "status",mode: "status"}
  ],

    handlerType: [
    { label: "No", field: "no", mode: "view" },
    {
      label: "Handler Company Name",
      field: "HandlerCompNo",
      mode: "select",
      options: handlerCompanyListData.value,
      optionLabel: "hancompnm",
      optionValue: "hancompno",
      required: true,
    },
    { label: "Handler Type Name", field: "handlertype", mode: "input", required: true  },
    { label: "Maxsitecount", field: "maxsitecount", mode: "input", required: true },
    // { label: "Handlercateid", field: "handlercateid", mode: "input", required: false },
    { label: "Status", field: "status", type: "status",mode: "status"}
  ],

  handlerCompany: [
    { label: "No", field: "no", mode: "view" },
    { label: "Handler Company Name", field: "hancompnm", mode: "input", required: true  },
    { label: "Status", field: "status", type: "status",mode: "status"}
  ],
  
  testerEnv: [
    { label: "No", field: "no", mode: "view" },
    // {
    //   label: "Handler Company Name",
    //   field: "handlersbycompany",
    //   mode: "select",
    //   options: handlerCompanyListData.value,
    //   optionLabel: "hancompnm",
    //   optionValue: "hancompno",
    //   required: true,
    // },

    // {
    //   label: "Handler Name",
    //   field: "handlername",
    //   mode: "select",
    //   getOptions: (row) => {
    //     if (!row.handlersbycompany) return [];
    //     return testerEnvDataTable.value.handlersByCompany[row.handlersbycompany] ?? [];
    //   },
    //   optionLabel: "handlername",
    //   optionValue: "handlerno",
    //   required: true,
    // },

    {
      label: "Platform Type Name",
      field: "testersbyplatformtype",
      mode: "select",
      options: platformTypeListData.value,
      optionLabel: "platformtypename",
      optionValue: "platformtypeno",
      required: true,
    },

    {
      label: "Tester Hostname",
      field: "testername",
      mode: "select",
      /**
       * Dynamic options based on selected platform type
       */
      getOptions: (row) => {
        if (!row.testersbyplatformtype) return [];
        return testerEnvDataTable.value.testersByPlatformType[row.testersbyplatformtype] ?? [];
      },
      optionLabel: "testername",
      optionValue: "testerid",
      required: true,
    },
    

    {label: "Flag Manual", 
    field: "flag_manual", 
    mode: "select",
      options: [
        { label: "Yes", value: 1 },
        { label: "No", value: 0 }
      ],
      optionLabel: "label",
      optionValue: "value",
      required: true
    },

    {
      label: "Use TPA",
      field: "use_tpa",
      mode: "select",
      options: [
        { label: "Yes", value: 1 },
        { label: "No", value: 0 }
      ],
      optionLabel: "label",
      optionValue: "value",
      required: true
    },

    {
      label: "Menu Code",
      field: "menucode",
      mode: "input",
      required: true
    },

    {
      label: "Language",
      field: "language",
      mode: "select",
      options: [
        { label: "Yes", value: 1 },
        { label: "No", value: 0 }
      ],
      optionLabel: "label",
      optionValue: "value",
      required: true
    },

    {
      label: "Handler ID",
      field: "handlerid",
      mode: "input",
    },

    { label: "Status", field: "status", type: "status", mode: "status" }
  ]


}));



const getTableColumns = (type) =>
  computed(() => TABLE_SCHEMA.value[type] || []);

const tableListPlatformType = getTableColumns("platformTypeName");
const tableListPlatformName = getTableColumns("platformName");
const tableListTesterColumns = getTableColumns("tester");
const tableListTesterEnvColumns = getTableColumns("testerEnv");
const tableListHandlerColumns = getTableColumns("handler");
const tableListHandlerTypeColumns = getTableColumns("handlerType");
const tableListHandlerCompanyColumns = getTableColumns("handlerCompany");

/**
 * ---------------------------------------------------------------------------------------------------------
 * ROW FACTORY
 * ---------------------------------------------------------------------------------------------------------
 */

const createRow = (type) => {
  const schema = TABLE_SCHEMA.value?.[type];
  if (!schema) return {};

  const row = {};
  schema.forEach(col => {
    if (col.field !== "no") row[col.field] = "";
  });

  return row;
};

const defineRowDataTester = () => createRow("tester");
const defineRowDataTesterEnv = () => createRow("testerEnv");
const defineRowDataHandler = () => createRow("handler");
const defineRowDataHandlerType = () => createRow("handlerType");
const defineRowDataHandlerCompany = () => createRow("handlerCompany");
const defineRowPlatformTypeName = () => createRow("platformTypeName");
const defineRowPlatformName = () => createRow("platformName");

const REQUIRED_FIELDS = computed(() =>
  Object.fromEntries(
    Object.keys(TABLE_SCHEMA.value).map(type => [
      type,
      TABLE_SCHEMA.value[type]
        .filter(col => col.required)
        .map(col => col.field)
    ])
  )
);

/**
 * ---------------------------------------------------------------------------------------------------------
 * TABLE OPERATIONS
 * ---------------------------------------------------------------------------------------------------------
 */

function addRow(targetRef, defineFn) {
  targetRef.value.push(defineFn());
}

function updateRows(targetRef, newData) {
  targetRef.value = newData;
}

// check enty row or miss data row
function validateAndFilterRows(rows, type) {
  const requiredFields = REQUIRED_FIELDS.value[type];

  const isEmptyValue = (v) =>
    v === "" || v === null || v === undefined;

  const isRowEmpty = (row) =>
    Object.values(row).every(isEmptyValue);

  const validRows = [];

  for (const row of rows) {
    if (isRowEmpty(row)) continue;

    const hasMissingField = requiredFields.some(
      field => isEmptyValue(row[field])
    );

    if (hasMissingField) {
      return { error: "Thiếu dữ liệu", rows: [] };
    }

    validRows.push(row);
  }

  return { error: null, rows: validRows };
}

/**
 * ---------------------------------------------------------------------------------------------------------
 * SUBMIT HANDLER
 * ---------------------------------------------------------------------------------------------------------
 */
async function handleSubmit(rawTableData, type) {
  const { error, rows } = validateAndFilterRows(rawTableData, type);
  if (error) return alert(error);
  if (!rows.length) return alert("Không có dữ liệu hợp lệ để gửi");

  const errors = [];

  const callSpWithCheck = async (spName, param, rowLabel) => {
    const res = await apiClient.callSp(spName, param);
    const result = res?.[0]?.data?.[0];

    if (!result || result.Success == 0) {
      errors.push(`${result?.Message || 'Unknown error'}`);
    }
    return result;
  };

  if (type === 'platformTypeName') {
    for (const row of rows) {
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertPlatformType",
        { "@platformtype": String(row.platformTypeName || '').trim() },
        row.platformTypeName
      );
      if (result?.Status) row.status = result.Status;
    }
  }

  else if (type === 'platformName') {
    for (const row of rows) {
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertPlatform",
        {
          "@jsonParam": JSON.stringify({
            platformname: row.platformName,
            platformtypeno: row.platformTypeNameNo
          })
        },
        row.platformName
      );
      if (result?.Status) row.status = result.Status;
    }
  }

  else if (type === 'tester') {
    for (const row of rows) {
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertTester",
        {
          "@jsonParam": JSON.stringify({
            factory: "ATV",
            hostname: row.hostname,
            testername: row.testerName,
            emeshost: row.emesHost,
            otherhostname: "",
            ipaddress: "",
            rootpassword: "",
            os: "windows",
            osrev: "",
            updatedate: null,
            lastmoddate: null,
            lastmoduser: authStore.userInfo.displayName,
            platformno: row.platformName,
            platformtypeno: row.platformtypeno,
            adtcname: "",
            adtcIP: ""
          })
        },
        row.testerName
      );


      if (result?.Status) row.status = result.Status;
    }
  }


  else if (type === 'testerEnv') {
    for (const row of rows) {
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertTesterEnv",
        {
          "@jsonParam": JSON.stringify({
            testerid: row.testername,
            use_tpa: row.use_tpa,
            flag_manual: row.flag_manual,
            language: row.language,
            menucode: row.menucode,
            handlerid: row.handlerid
          })
        },
        row.handlertype
      );
      if (result?.Status) row.status = result.Status;
    }
  }


  else if (type === 'handlerType') {
    for (const row of rows) {
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertHandlerType",
        {
          "@jsonParam": JSON.stringify({
            HandlerType: row.handlertype,
            Maxsitecount: row.maxsitecount,
            // Handlercateid: row.handlercateid,
            Handlercomp: row.HandlerCompNo
          })
        },
        row.handlertype
      );
      if (result?.Status) row.status = result.Status;
    }
  }

  else if (type === 'handlerCompany') {
    for (const row of rows) {
      console.log(row)
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertHandlerCompany",
        { "@hancompnm": String(row.hancompnm || '').trim() },
        row.hancompnm
      );
      if (result?.Status) row.status = result.Status;
    }
  }

  else if (type === 'handler') {
    for (const row of rows) {
      const result = await callSpWithCheck(
        "TestDB..USP_RegisterMachine_InsertHandler",
        {
          "@jsonParam": JSON.stringify({
            hanhostnm: row.hanhostnm,
            hantypeno: row.hantypeno,
            rfidnm: row.rfiddrm,
            serialno: row.SerialNo,
            owner: row.owner,
            assetno: row.assetNo,
            mfg: "",
            indate: null,
            lastmoddate: null,
            lastmoduser: authStore.userInfo.displayName,
            factory: "ATV"
          })
        },
        row.hanhostnm
      );
      if (result?.Status) row.status = result.Status;
    }
  }


  if (errors.length) {
    gFunc.ShowMessage(`Có (${errors.length}) lỗi:\n${errors.join('\n')}`, "error", "", 3000);
  } else {
    gFunc.ShowMessage("Đăng ký thành công", "success", "", 3000);
  }

}

/**
 * ---------------------------------------------------------------------------------------------------------
 * SELECT CHANGE HANDLER
 * ---------------------------------------------------------------------------------------------------------
 */

async function handleSelectChange({ field, value, row }) {
  /* ============================
   * PLATFORM TYPE → PLATFORM NAME
   * (tester, testerEnv)
   * ============================ */
  if (field === 'platformtypeno') {
    testerDataTable.value[value] =
      platformNameListData.value.filter(
        p => p.platformtypeno == value
      );
    return;
  }

  if (field === 'hancompno') {
    handlerDataTable.value[value] =
      handlerTypeListData.value.filter(
        p =>{
          return p.hancompno == value
        }
      );
    return;
  }

  if (field === 'testersbyplatformtype') {

    testerEnvDataTable.value.testersByPlatformType[value]  = testerListData.value.filter(
      t => {
        return t.platformtypeno == value
      }
    );

    return;
  }

  if (
    field === 'flag_manual' ||
    field === 'use_tpa' ||
    field === 'menucode' ||
    field === 'language'
  ) {
    row[field] = value;
    return;
  }
}

/**
 * ---------------------------------------------------------------------------------------------------------
 * INITIAL ROWS
 * ---------------------------------------------------------------------------------------------------------
 */

function createRows(defineFn, count = 5) {
  return Array.from({ length: count }, () => defineFn());
}

// Initial data
const rowDataTester = ref(createRows(defineRowDataTester, 3));
const rowDataTesterEnv = ref(createRows(defineRowDataTesterEnv, 3));
const rowPlatformTypeName = ref(createRows(defineRowPlatformTypeName, 3));
const rowPlatformName = ref(createRows(defineRowPlatformName, 3));
const rowDataHandler = ref(createRows(defineRowDataHandler, 3));
const rowDataHandlerType = ref(createRows(defineRowDataHandlerType, 3));
const rowDataHandlerCompany = ref(createRows(defineRowDataHandlerCompany, 3));

// Add row handlers
const addPlatformTypeRow = () => addRow(rowPlatformTypeName, defineRowPlatformTypeName);
const addPlatformNameRow = () => addRow(rowPlatformName, defineRowPlatformName);
const addTesterRow = () => addRow(rowDataTester, defineRowDataTester);
const addTesterRowEnv = () => addRow(rowDataTesterEnv, defineRowDataTesterEnv);
const addHandlerRow = () => addRow(rowDataHandler, defineRowDataHandler);
const addHandlerTypeRow = () => addRow(rowDataHandlerType, defineRowDataHandlerType);
const addHandlerCompanyRow = () => addRow(rowDataHandlerCompany, defineRowDataHandlerCompany);

// Function delete row data
const updateDataTester = (data) => updateRows(rowDataTester, data);
const updateDataTesterEnv = (data) => updateRows(rowDataTesterEnv, data);
const updateDataHandler = (data) => updateRows(rowDataHandler, data);
const updateDataHandlerType = (data) => updateRows(rowDataHandlerType, data);
const updateDataHandlerCompany = (data) => updateRows(rowDataHandlerCompany, data);
const updateDataplatformName = (data) => updateRows(rowPlatformName, data);



/**
 * ---------------------------------------------------------------------------------------------------------
 * REFRESH
 * ---------------------------------------------------------------------------------------------------------
 */
const refreshConfig = {
  tester: {
    target: rowDataTester,
    define: defineRowDataTester,
    message: "Testers table refreshed"
  },  
  testerEnv: {
    target: rowDataTesterEnv,
    define: defineRowDataTesterEnv,
    message: "Testers table refreshed"
  },
  platformTypeName: {
    target: rowPlatformTypeName,
    define: defineRowPlatformTypeName,
    message: "Platform type names table refreshed"
  },
  platformName: {
    target: rowPlatformName,
    define: defineRowPlatformName,
    message: "Platform names table refreshed"
  },
  handler: {
    target: rowDataHandler,
    define: defineRowDataHandler,
    message: "Handlers table refreshed"
  },
  handlerType: {
    target: rowDataHandlerType,
    define: defineRowDataHandlerType,
    message: "Handler types table refreshed"
  },  
  handlerCompany: {
    target: rowDataHandlerCompany,
    define: defineRowDataHandlerCompany,
    message: "Handler Companys table refreshed"
  }
};

async function refreshTable(type) {
  await loadData();
  const config = refreshConfig[type];
  if (!config) {
    gFunc.ShowMessage("Invalid refresh type", "error", "", 3000);
    return;
  }

  config.target.value = createRows(config.define, 3);
  gFunc.ShowMessage(config.message, "success", "", 3000);
}
</script>

<template>

  <div class="card flex flex-col bg-surface text-on-surface p-0 font-body border-none shadow-sm p-5">
    <Tabs value="0">
      <TabList class="bg-surface-container-low/50 mb-5">
        <Tab value="0" class="!text-[11px] font-black uppercase tracking-widest py-4">
          <i class="pi pi-plus-circle text-blue-500 mr-2"></i>
          Registration Tester
        </Tab>

        <Tab value="1" class="!text-[11px] font-black uppercase tracking-widest py-4">
          <i class="pi pi-plus-circle text-green-500 mr-2"></i>
          Registration Handler
        </Tab>

        <Tab value="2" class="!text-[11px] font-black uppercase tracking-widest py-4">
          <i class="pi pi-database text-purple-500 mr-2"></i>
          Data machine
        </Tab>
      </TabList>

      <TabPanels class="!p-0 flex-1 ">
          <!-- Tab 1: Registration Form -->
          <TabPanel value="0" class="flex flex-col">
            <div class="flex gap-8 mb-8">
              <div class="flex-1 min-w-0 mr-4">
                <BaseTable title="Platform Type Name Register" 
                :columns=tableListPlatformType  
                :rowData=rowPlatformTypeName 
                :allowSubmit="allowSubmit"
                @submit-data="(rows) => handleSubmit(rows, 'platformTypeName')"
                @add-row="addPlatformTypeRow"
                :refresh=allowRefresh
                @refresh-data="refreshTable('platformTypeName')"
                >
                </BaseTable>
              </div>
          
          
              <div class="flex-1 min-w-0">
                <BaseTable title="Platform Name Register" 
                :columns=tableListPlatformName  
                :rowData=rowPlatformName
                :allowAddRow=allowAddRow
                :allowSubmit="allowSubmit"
                :isAction=true
                @submit-data="(rows) => handleSubmit(rows, 'platformName')"
                @update:rowData="updateDataplatformName "
                @add-row="addPlatformNameRow"
                :refresh=allowRefresh
                @refresh-data="refreshTable('platformName')"
                >
                </BaseTable>
              </div>
            </div>

            <div class="mb-8">
              <BaseTable title="Asset Register Tester" 
              :columns=tableListTesterColumns  
              :rowData=rowDataTester
              :enablePaginator=enablePaginator
              :allowAddRow=allowAddRow
              :allowSubmit=allowSubmit
              :isAction=enableAction
              @add-row="addTesterRow"
              @submit-data="(rows) => handleSubmit(rows, 'tester')"
              @update:rowData="updateDataTester"
              @cell-select-change="handleSelectChange"
              :refresh=allowRefresh
              @refresh-data="refreshTable('tester')"
              >
              </BaseTable>
            </div>

            <div class="mb-8">
              <BaseTable title="Asset Register Tester Enviroment" 
              :columns=tableListTesterEnvColumns  
              :rowData=rowDataTesterEnv
              :enablePaginator=enablePaginator
              :allowAddRow=allowAddRow
              :allowSubmit=allowSubmit
              :isAction=enableAction
              @add-row="addTesterRowEnv"
              @submit-data="(rows) => handleSubmit(rows, 'testerEnv')"
              @update:rowData="updateDataTesterEnv"
              @cell-select-change="handleSelectChange"
              :refresh=allowRefresh
              @refresh-data="refreshTable('testerEnv')"
              >
              </BaseTable>
            </div>

          </TabPanel>

          <TabPanel value="1" class="!p-0">

            <div class="mb-8">
              <BaseTable title="Asset Register Handler Company" 
              :columns=tableListHandlerCompanyColumns  
              :rowData=rowDataHandlerCompany
              :enablePaginator=enablePaginator
              :allowAddRow=allowAddRow
              :allowSubmit=allowSubmit
              :isAction=enableAction
              @add-row="addHandlerCompanyRow"
              @submit-data="(rows) => handleSubmit(rows, 'handlerCompany')"
              @update:rowData="updateDataHandlerCompany"
              :refresh=allowRefresh
              @refresh-data="refreshTable('handlerCompany')"
              >
              </BaseTable>
            </div>

            <div class="mb-8">
              <BaseTable title="Asset Register Handler Type" 
              :columns=tableListHandlerTypeColumns  
              :rowData=rowDataHandlerType
              :enablePaginator=enablePaginator
              :allowAddRow=allowAddRow
              :allowSubmit=allowSubmit
              :isAction=enableAction
              @add-row="addHandlerTypeRow"
              @submit-data="(rows) => handleSubmit(rows, 'handlerType')"
              @update:rowData="updateDataHandlerType"
              :refresh=allowRefresh
              @refresh-data="refreshTable('handlerType')"
              >
              </BaseTable>
            </div>

            <div class="mb-8">
              <BaseTable title="Asset Register Handler" 
              :columns=tableListHandlerColumns  
              :rowData=rowDataHandler
              :enablePaginator=enablePaginator
              :allowAddRow=allowAddRow
              :allowSubmit=allowSubmit
              :isAction=enableAction
              @add-row="addHandlerRow"
              @submit-data="(rows) => handleSubmit(rows, 'handler')"
              @cell-select-change="handleSelectChange"
              @update:rowData="updateDataHandler"
              :refresh=allowRefresh
              @refresh-data="refreshTable('handler')"
              >
              </BaseTable>
            </div>
          </TabPanel>


          <TabPanel value="2" class="!p-0">
            <div class="mb-8">
              
              <BaseTable title="Tester Information" 
              :columns=testerTableColumns 
              :rowData=testerListData 
              :enablePaginator=enablePaginator
              :refresh=allowRefresh
              :searching=allowSearching
              @refresh-data=refreshTesters
              />
            </div>

            <div class="mb-8">
              <BaseTable title="Handler Information" 
              :columns=handlerTableColumns 
              :rowData=handlerListData 
              :enablePaginator=enablePaginator
              :refresh=allowRefresh
              :searching=allowSearching
              @refresh-data=refreshHandlers
              />
            </div>
          </TabPanel>
      </TabPanels>
    </Tabs>
  </div>


</template>
<!-- 
    <div class="charts-section">
        <BaseChart title="Monaco hold lot status" type="bar" :data="statusChartData" :options="chartOptions" />
        <BaseChart title="Monaco hold lot trend" type="bar" :data="trendChartData" :options="chartOptions" />
    </div> -->


<style scoped>
.asset-wrapper {
  padding: 16px;
}


.asset-table {
  width: 100%;
  border-collapse: collapse;
}

.asset-table thead {
  background: var(--p-primary-500);
}

.asset-table th {
  color: white;
  padding: 8px;
  font-size: 13px;
  position: sticky;
  top: 0;
}

.asset-table td {
  padding: 6px;
  border-bottom: 1px solid #e5e7eb;
}

input,
select {
  width: 100%;
  font-size: 13px;
  padding: 4px;
}

.actions {
  margin-top: 12px;
  text-align: right;
}

button {
  padding: 6px 12px;
  margin-left: 6px;
}

.submit {
  background: var(--p-primary-500);
  color: white;
  border: none;
}
</style>