<!-- TableSection.vue -->
<script setup>
  const props = defineProps({
  title: {
    type: String,
    default: "",
  },
  columns: {
    type: Array,
    required: true,
    // Example: [{ label: "Date", field: "date" }, { label: "Lot", field: "lot" }]
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
  }

});

</script>


<template>
  <div>
    <div >
      <div class="table-title">{{ props.title }}</div>
      <div class="table-container">
        <table>
          <thead>
            <tr>
              <th v-for="(col) in props.columns" :key="index">
                {{ col }}
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(row, index) in props.rowData" :key="index">
              <td v-for="(col) in props.columns" :key="indexColumn">
                  {{ row[col] }}
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<style scoped>
.table-container {
  max-height: 400px;
  overflow-y: auto;
  border: 1px solid #ccc;
  width: 100%;
  box-sizing: border-box;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 0.1rem;
}

th, td {
  border: 1px solid #ccc;
  padding: 8px;
  text-align: center;
}

thead th {
  position: sticky;
  top: 0;
  background-color: #0d437f;
  color: white;
  z-index: 1;
}

h2 {
  color: black;
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 1rem;
  text-align: center;
}

.table-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2d3748;
  margin-bottom: 1rem;
  text-align: center;
}

/* Responsive adjustments */
@media (max-width: 768px) {
  .table-container {
    max-height: 300px;
  }
  h2 {
    font-size: 20px;
  }
}
</style>