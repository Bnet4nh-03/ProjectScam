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
  },
  paginator: {
    type: Boolean,
    default: true
  },
  loading: {
    type: Boolean,
    default: false
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

watch(() => props.rowData, (newVal) => {
  if (props.selection) {
    selectedRows.value = newVal.filter(r => r.selected);
  }
}, { immediate: true });

watch(selectedRows, (newVal) => {
  emit('selection-change', newVal);
  if (props.selectionMode === 'multiple') {
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
  value = value.toString().replace(/\s+/g, '-');
  return 'status-' + value.toString().toLowerCase();
};
</script>

<template>
  <div class="base-table-container">
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
      <DataTable :value="processedData" :paginator="props.paginator" :rows="10" :rowsPerPageOptions="[5, 10, 20, 50, 100]"
        v-model:selection="selectedRows" @row-dblclick="onRowDoubleClicked" scrollable :scrollHeight="props.tableHeight"
        tableStyle="min-width: 30rem" :loading="props.loading"
        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
        currentPageReportTemplate="{first} to {last} of {totalRecords}">

      <template #empty>
        <div class="flex flex-col items-center justify-center p-8 text-surface-400 dark:text-surface-500">
          <i class="pi pi-database text-4xl mb-4"></i>
          <span class="text-lg font-medium">No data available</span>
        </div>
      </template>

      <Column v-if="props.selection" :selectionMode="props.selectionMode" headerStyle="width: 3rem"></Column>

      <Column v-for="(col, index) in props.columns" :key="index" :field="col.field"
        :header="col.label.toString().toUpperCase()" 
        :headerClass="col.headerClass"
        :bodyClass="col.bodyClass">
        <template #body="slotProps">
          <!-- Dynamic Slot Support -->
          <slot :name="col.field" :data="slotProps.data" :index="slotProps.index">
            <span v-if="col.type === 'status'" class="status-badge" :class="getStatusClass(slotProps.data[col.field])">
              {{ slotProps.data[col.field] }}
            </span>
            <span v-else>
              <span v-html="slotProps.data[col.field]"></span>
            </span>
          </slot>
        </template>
      </Column>
    </DataTable>
  </div>
</div>
</template>

<style lang="scss" scoped>
/* Copy 100% style from holdLotManagement BaseTable */
.table-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
}

.table-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2d3748;
}

.table-wrapper {
  border: 1px solid #ddd;
  border-radius: 10px 10px 0px 0px; /* Bo góc 12px như bản gốc */
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
  padding: 0.25rem 0.75rem;
  border-radius: 20px;
  font-size: 0.8rem;
  text-transform: uppercase;
}

/* Các class status copy từ bản gốc */
.status-release { background-color: var(--p-green-300); color: var(--p-green-900); }
.status-pending { background-color: var(--p-yellow-300); color: var(--p-yellow-800); }
.status-hold { background-color: var(--p-red-300); color: var(--p-red-800); }
.status-done { background-color: var(--p-green-300); color: var(--p-green-900); }
.status-na { background-color: var(--p-gray-300); color: var(--p-gray-700); }

:deep(.p-datatable-thead > tr > th) {
  background-color: var(--p-primary-500); /* Màu xanh header */
  color: #ffffff;
  padding: 0.5rem 1rem; /* Giảm padding header */
}

:deep(.p-datatable-tbody > tr > td) {
  padding: 0.3rem 1rem; /* Giảm padding body row */
  color: #4a5568;
}

:deep(.p-datatable-tbody > tr:hover) {
  background-color: #e8f0f8;
}

.table-footer-actions {
  text-align: end;
}
</style>
