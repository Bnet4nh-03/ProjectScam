<!-- src/components/BaseChart.vue -->
<template>
  <div class="chart-card">
    <div class="chart-title" >{{ title }}</div>
    <Chart :type="type" :data="data" :options="options" class="h-80" :plugins="[ChartDataLabels]"/>
  </div>
</template>

<script setup>
import Chart from 'primevue/chart';
import ChartDataLabels from 'chartjs-plugin-datalabels';

defineProps({
  title: String,
  type: { type: String, default: 'bar' },
  data: Object,
  options: Object
});
</script>

<style scoped>
.chart-card {
  background: #fff;
  border-radius: 16px;
  padding: 1.5rem;
  box-shadow: 0 4px 16px rgba(15, 75, 143, 0.1);
  border: 1px solid #c5d8ec;
}
.chart-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2d3748;
  margin-bottom: 1rem;
  text-align: center;
}
</style>