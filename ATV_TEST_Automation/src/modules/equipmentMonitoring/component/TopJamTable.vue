<script setup>
const props = defineProps({
  title: {
    type: String,
    default: "Top 3 Worst M/C Table"
  },
  topJamSummary: {
    type: Array,
    required: true
  }
});
</script>

<template>
  <div class="top-jam-table">
    <h2 v-if="props.topJamSummary && props.topJamSummary.length > 0"> {{ props.title }}</h2>
    <table v-if="props.topJamSummary && props.topJamSummary.length > 0">
      <thead>
        <tr>
          <th>Top 3 Worst M/C</th>
          <th>No</th>
          <th>Jam ID</th>
          <th>Jam Description</th>
          <th>Quantity</th>
        </tr>
      </thead>
      <tbody>
        <template v-for="(machine, mIndex) in props.topJamSummary" :key="mIndex">
          <!-- Lấy danh sách jams và flatten -->
          <template v-for="(jam, jIndex) in machine.jams.flat()" :key="jIndex">
            <tr>
              <!-- Nếu là dòng đầu tiên của machine thì hiển thị tên máy với rowspan -->
              <td v-if="jIndex === 0" :rowspan="machine.jams.flat().length">{{ machine.machine }}</td>
              <td>{{ jam.No }}</td>
              <td>{{ jam['Jam ID'] }}</td>
              <td>{{ jam['Jam Description'] }}</td>
              <td>{{ jam.Quantity }}</td>
            </tr>
          </template>
        </template>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
.top-jam-table {
  margin-top: 1rem;
  width: 100%;
  box-sizing: border-box;
}

table {
  width: 100%;
  border-collapse: collapse;
  text-align: center;
}

th, td {
  border: 1px solid #ccc;
  padding: 8px;
}

thead th {
  background-color: #0d437f;
  color: white;
}

h2 {
  font-size: 1.5rem;
  font-weight: bold;
  margin-bottom: 1rem;
  text-align: center;
}

/* Responsive adjustments */
@media (max-width: 768px) {
  h2 {
    font-size: 1.2rem;
  }
}
</style>