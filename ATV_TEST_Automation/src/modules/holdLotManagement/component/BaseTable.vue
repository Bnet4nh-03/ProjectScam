<script setup>
import { ref, computed, watch } from 'vue';
const props = defineProps({
  title: {
    type: String,
    default: "",
  },
  columns: {
    type: Array,
    required: true,
    // Example: [{ label: "Date", field: "date", sortable: true }, { label: "Lot", field: "lot" }]
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
  selectionMode: {
    type: String,
    default: 'multiple'
  }

});
const emit = defineEmits([
  'row-dblclick',
  'selection-change',
  'update:rowData',
  'request-clicked'
]);

const searchTerm = ref('');
const selectedRows = ref([]);

// Sync selectedRows with props.rowData
watch(() => props.rowData, (newVal) => {
  if (props.selection) {
    selectedRows.value = newVal.filter(r => r.selected);
  }
}, { immediate: true });

// Handle selection changes
watch(selectedRows, (newVal) => {
  emit('selection-change', newVal);
  if (props.selectionMode === 'multiple') {
    // Update original data selected state if needed
    let hasChanges = false;
    const updatedData = props.rowData.map(row => {
      const isSelected = newVal.includes(row);
      if (row.selected !== isSelected) {
        hasChanges = true;
        return { ...row, selected: isSelected };
      }
      return row;
    });

    if (hasChanges) {
      emit('update:rowData', updatedData);
    }
  }

});

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

function onRowDoubleClicked(event) {
  emit("row-dblclick", event.data);
}

function getStatusClass(value) {
  if (!value) return 'status-na';
  // Remove space and convert to '-'
  value = value.toString().replace(/\s+/g, '-');
  return 'status-' + value.toString().toLowerCase();
};
</script>

<template>
  <!-- <div class="card"> -->
  <div class="table-header">
    <div class="table-title">{{ props.title }}</div>
    <div class="flex gap-2 ">
      <input v-if="props.searching" type="text" v-model="searchTerm" placeholder="Search..." class="search-box" />
      <slot name="actions"></slot>
      <div class="table-footer-actions" v-if="props.selection">
        <Button label="Request" @click="emit('request-clicked')"></Button>
      </div>
    </div>
  </div>

  <div class="table-wrapper">
    <DataTable :value="processedData" :paginator="true" :rows="10" :rowsPerPageOptions="[5, 10, 20, 50, 100]"
      v-model:selection="selectedRows" @row-dblclick="onRowDoubleClicked" scrollable :scrollHeight="props.tableHeight"
      tableStyle="min-width: 50rem"
      paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
      currentPageReportTemplate="{first} to {last} of {totalRecords}">

      <Column v-if="props.selection" :selectionMode="props.selectionMode" headerStyle="width: 3rem"></Column>

      <Column v-for="(col, index) in props.columns" :key="index" :field="col.field"
        :header="col.label.toString().toUpperCase()" headerClass="text-center">
        <template #body="slotProps">
          <span v-if="col.type === 'status'" class="status-badge" :class="getStatusClass(slotProps.data[col.field])">
            {{ slotProps.data[col.field] }}
          </span>
          <span v-else>
            <span v-html="slotProps.data[col.field]"></span>
          </span>
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