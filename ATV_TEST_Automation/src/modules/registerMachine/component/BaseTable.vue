<script setup>
import { ref, computed, watch } from 'vue';


const currentPage = ref(0)     
const rowsPerPage = ref(10)

const props = defineProps({ 
  title: {
    type: String,
    default: "",
  },
  columns: {
    type: Array,
    required: true,
  },
  rowData: {
    type: Array,
    required: true,
  },
  tableHeight: {
    type: String,
    default: '450px'
  },
  selection: {
    type: Boolean,
    default: false
  },
  searching: {
    type: Boolean,
    default: false
  },
  refresh: {
    type: Boolean,
    default: false
  },
  selectionMode: {
    type: String,
    default: 'multiple'
  },
  // for enable button add row
  allowAddRow: {
    type: Boolean,
    default: false
  },
  // for enable button upload data
  allowUploadData: {
    type: Boolean,
    default: false
  },
  // for enable button submit
  allowSubmit: {
    type: Boolean,
    default: false
  },
  // for enable button Paginator
  enablePaginator: {
    type: Boolean,
    default: false
  },
  // for enable col action
  isAction: {
    type: Boolean,
    default: false
  },

});
const emit = defineEmits([
  'row-dblclick',
  'selection-change',
  'update:rowData',
  'request-clicked',
  'add-row',
  'upload-data',
  'submit-data',
  'cell-select-change',
  'refresh-data'
]);

const searchTerm = ref('');
const selectedRows = ref([]);
const fileInput = ref(null);


function onSelectChange(row, col, rowIndex) {
  const value = row[col.field];

  emit('cell-select-change', {
    row,
    field: col.field,
    value,
    rowIndex
  });
}


const processedData = computed(() => {
  let data = [...props.rowData];

  // Searching
  if (searchTerm.value) {
    const lowerCaseSearchTerm = searchTerm.value.toLowerCase();
    data = data.filter(row => {
      return props.columns.some(col => {
        const cellValue = row[col.field];
        if (cellValue) {
          return String(cellValue).toLowerCase().includes(lowerCaseSearchTerm);
        }
        return false;
      });
    });
  }
  return data;
});


// Take value of page for updata "NO" when change Page
function onPageChange(event) {
  currentPage.value = event.page      
  rowsPerPage.value = event.rows      
}


// Send raw data to RegisterTester.vue
function submitData() {
  emit('submit-data', props.rowData);
}

function onDelete(row) {
  const updatedData = props.rowData.filter(item => item !== row);
  emit('update:rowData', updatedData);
}

function onFileChange(event) {
  const file = event.target.files[0];
  if (!file) return;
  emit('upload-data', file);
  event.target.value = '';
}

function triggerFileUpload() {
  fileInput.value?.click();
}

function getStatusClass(value) {
  if (!value) return 'status-na';

  return ('status-' + value.toString().trim().toLowerCase().replace(/\s+/g, '-'));
}

function handleInputPaste(event, startRowIndex, startColIndex) {
  const clipboardText = event.clipboardData?.getData('text');
  if (!clipboardText) return;

  event.preventDefault();

  const rows = clipboardText
    .trim()
    .split(/\r?\n/)
    .map(row => row.split('\t'));

  const updatedData = [...props.rowData];

  rows.forEach((rowValues, rIdx) => {
    const targetRow = updatedData[startRowIndex + rIdx];
    if (!targetRow) return;

    rowValues.forEach((cellValue, cIdx) => {
      const col = props.columns[startColIndex + cIdx];
      if (!col) return;


      if (col.mode !== 'input') return;
      if (col.field === 'no') return;

      targetRow[col.field] = cellValue;
    });
  });

  emit('update:rowData', updatedData);
}


</script>

<template>
  <!-- handler button -->
  <div class="table-header">
    <div class="table-title">{{ props.title }}</div>
    <div class="flex gap-2 ">

    <input v-if="props.searching" type="text" v-model="searchTerm" placeholder="Search..." class="search-box" />
    <slot name="actions"></slot>

    <div class="table-footer-actions" v-if="props.allowUploadData">
      <input ref="fileInput" type="file" accept=".xlsx,.xls" hidden @change="onFileChange" />
      <Button label="Import Excel" icon="pi pi-file-excel" severity="success" @click="triggerFileUpload"></Button>
    </div>

    <div class="table-footer-actions" v-if="props.allowAddRow">
      <Button label="Add Row" icon="pi pi-plus" severity="info" @click="emit('add-row')" ></Button>
    </div>

    <div class="table-footer-actions" v-if="props.allowSubmit">
      <Button label="Submit" icon="pi pi-send" severity="primary" @click="submitData" ></Button>
    </div>

    <div class="table-footer-actions" v-if="props.selection">
      <Button label="Request" icon="pi pi-envelope" severity="warning" @click="emit('request-clicked')" ></Button>
    </div>

    <div class="table-footer-actions" v-if="props.refresh">
      <Button label="Refresh" icon="pi pi-refresh" severity="secondary" outlined @click="emit('refresh-data')" ></Button>
    </div>


    </div>
  </div>

  <!-- main table -->
  <div class="table-wrapper">
    <DataTable :value="processedData" :rows="rowsPerPage" v-model:selection="selectedRows" :paginator=props.enablePaginator :rowsPerPageOptions="props.enablePaginator ? [5, 10, 20, 50, 100] : []" @page="onPageChange" scrollable :scrollHeight="props.tableHeight" tableStyle="width: 100%; table-layout: auto;">

      <Column v-for="(col, index) in props.columns"  :field="col.field" :header="col.label.toUpperCase()" headerClass="text-center whitespace-nowrap" bodyClass="whitespace-nowrap overflow-hidden p-0">
        <template #body="slotProps" >
          <!-- no -->
          <span v-if="col.field === 'no'" headerClass="text-center" >
            {{ slotProps.index + 1 + currentPage * rowsPerPage}}
          </span>

          <input
            v-else-if="col.mode === 'input'"
            maxlength="30"
            class="cell-input"
            v-model="slotProps.data[col.field]"
            @paste="handleInputPaste($event, slotProps.index, index)"
          />

          <!--select-->
          <select 
            v-else-if="col.mode === 'select'" 
            v-model="slotProps.data[col.field]" 
            class="cell-select" 
            @change="onSelectChange(slotProps.data, col, slotProps.index)"
          >
            <option value="" disabled>---- Select ----</option>
            <option  
              v-for="opt in (col.getOptions ? col.getOptions(slotProps.data) : col.options)" 
              :key="String(opt[col.optionLabel])" 
              :value="String(opt[col.optionValue])"
            >
              {{ opt[col.optionLabel] }}
            </option>
          </select>

          <!-- status -->
          <span v-else-if="col.mode === 'status'" class="status-badge" :class="getStatusClass(slotProps.data[col.field])"> {{ slotProps.data[col.field] }} </span>
          
          <!-- data static -->
          <span v-else> {{ slotProps.data[col.field] }}</span>
          
        </template>

      </Column>
      
      <Column v-if="isAction" header="Action" headerClass="text-center whitespace-nowrap" bodyClass="text-center whitespace-nowrap p-0">
        <template #body="slotProps">
          <div class="flex justify-center">
            <Button
              icon="pi pi-trash"
              class="p-button-sm p-button-text p-button-danger action-btn"
              @click="onDelete(slotProps.data)"
            ></Button>
          </div>
        </template>
      </Column>


    </DataTable>

  </div>
  <!-- </div> -->
</template>

<style lang="scss" scoped>
@media screen and (max-width: 960px) {
  ::v-deep(.customized-timeline) {
    .p-timeline-event:nth-child(even) {
      flex-direction: row;

      .p-timeline-event-content {
        text-align: left;
      }
    }

    .p-timeline-event-opposite {
      flex: 0;
    }
  }
}

body {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
  background: #ffffff;
  min-height: 100vh;
}

.dashboard-container {
  margin: auto;
}

.table-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1.5rem;
}

.table-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2d3748;
}

.table-wrapper {
  border: 1px solid #ddd;
  border-radius: 12px;
  overflow: hidden;
  align-items: stretch;
}


.cell-input {
  width: 100%;
  height: 100%;
  min-width: 0;      
  border: 0;
  outline: none;
  background: transparent;
  box-shadow: none;
  font-size: 13px;
}


.cell-select {
  width: 100%;
  height: 100%;
  border: 0;
  background: transparent;
  outline: none;
  box-shadow: none;
  appearance: none;       
  line-height: normal;
  min-width: 0;
  font-size: 13px;
}


.search-box {
  padding: 0.75rem 1rem;
  border: 2px solid #e2e8f0;
  border-radius: 8px;
  font-size: 0.9rem;
  width: 250px;
  transition: border-color 0.3s ease;
}

.search-box:focus {
  outline: none;
  border-color: #0F4B8F;
}


.action-btn {
  width: 100%;
  height: 100%;
  padding: 0 !important;
  margin: 0;
  display: flex;
  align-items: center;
  justify-content: center;
}

:deep(.action-btn .pi) {
  font-size: 12px;
}


.status-badge {
  display: inline-flex;
  // align-items: center;
  // justify-content: center;
  padding: 0.25rem 0.75rem;
  border-radius: 20px;
  font-size: 0.8rem;
  // font-weight: 600;
  text-transform: uppercase;
}

/* Release → green */
.status-release {
  background-color: var(--p-green-300);
  color: var(--p-green-900);
}

/* Pending → amber */
.status-pending {
  background-color: var(--p-yellow-300);
  color: var(--p-yellow-800);
}

/* Hold → red */
.status-hold {
  background-color: var(--p-red-300);
  color: var(--p-red-800);
}

/* Done → teal */
.status-done {
  background-color: var(--p-green-300);
  color: var(--p-green-900);
}

/* NA → gray */
.status-na {
  background-color: var(--p-gray-300);
  color: var(--p-gray-700);
}

.status-request {
  background-color: #99cfff;
  color: var(--p-gray-700);
}

.status-preparing {
  background-color: #ffe680;
  color: var(--p-gray-700);
}

.status-duplicate {
  background-color: #ffb949;
  color: var(--p-gray-700);
}

.status-ready-to-delivery {
  background-color: #99e699;
  color: var(--p-gray-700);
}

.status-in {
  background-color: #80dfff;
  color: var(--p-gray-700);
}

.status-out {
  background-color: #b3b3b3;
  color: var(--p-gray-700);
}

.status-received {
  background-color: #b3ff99;
  color: var(--p-gray-700);
}

.status-reject {
  background-color: #ff9999;
  color: var(--p-gray-700);
}

.status-cancel {
  background-color: #d9d9d9;
  color: var(--p-gray-700);
}

// /* Pending → amber */
// .status-received {
//   background-color: var(--p-yellow-300);
//   color: var(--p-yellow-800);
// }

// /* Hold → red */
// .status-reject {
//   background-color: var(--p-red-300);
//   color: var(--p-red-800);
// }

@media (max-width: 768px) {
  .dashboard-container {
    padding: 1rem;
  }

  .search-box {
    width: 100%;
    margin-top: 1rem;
  }

  .table-header {
    flex-direction: column;
    align-items: stretch;
  }
}

.table-header .flex {
  display: flex;
  align-items: center;
}

.table-footer-actions {
  text-align: end;
}

:deep(.p-datatable-thead > tr > th) {
  background-color: var(--p-primary-500);
  color: #ffffff;
  text-align: center !important;
}

:deep(.p-datatable-tbody > tr) {
  background-color: #ffffff;
  color: #4a5568;
}

:deep(.p-datatable-tbody > tr:hover) {
  background-color: #e8f0f8;
}
</style>