<script setup>
import Chart from 'primevue/chart';

const props = defineProps({
  chartData: {
    type: Object,
    required: true
  },
  chartOptions: {
    type: Object,
    required: true
  }
});

</script>

<template>
  <div class="chart-container">
    <Chart type="bar" :data="chartData" :options="chartOptions" class="chart"  />
  </div>
</template>


<style>
.chart-container {
  width: 100%;
  height: 50vh;
  display: flex;
  justify-content: center;
  align-items: center;
  box-sizing: border-box;
}

.chart {
  width: 100%;
  height: 100%;
  max-width: 2000px; /* Prevent chart from stretching too much */
  min-width: 600px;  /* Keep chart readable */
}
</style>
