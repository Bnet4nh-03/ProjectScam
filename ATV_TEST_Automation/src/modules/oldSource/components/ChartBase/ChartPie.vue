<script setup>
import { useLayout } from "@/layout/composables/layout";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import { inject, onMounted, ref, watch, nextTick } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import _ from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');


// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: false,
};
const gridOptions = {
    headerHeight: 35,
    rowHeight: 30,
}
// Khai báo props nhận từ component cha
const props = defineProps({
    data: {
        type: Object,
        required: true,
        default: () => ({
            title: '',
            chartTitle: '',
            chartData: [],
            chartLable: [],
            chartHeight: '30vh',
            tableData: [],
            tableHeight: '230px',
            columnDefs: [],
        }),
    },
});


// Tùy chọn cấu hình biểu đồ cột
const chartOptionsPie = ref({
    chart: {
        backgroundColor: 'var(--surface-card)',
        type: 'pie',
        zooming: {
            type: 'xy'
        },
        panning: {
            enabled: true,
            type: 'xy'
        },
        panKey: 'shift'
    },
    title: {
        text: props.data.chartTitle,
        margin: 7,
        style: {
            color: 'var(--primary-color)',
        }
    },
    tooltip: {
        useHTML: true, // Cho phép hiển thị HTML
        formatter: function () {
            return `<span style="color:${this.point.color}; font-weight:bold">${this.point.name}</span>:
                <b>${this.point.y}</b> (${this.point.percentage.toFixed(0)}%)`;
        },
        style: {
            fontSize: '14px'
        }

    },

    legend: {
        enabled: true,
        layout: 'horizontal',  // Sắp xếp legend theo hàng ngang
        align: 'center',       // Căn giữa
        verticalAlign: 'bottom', // Đặt ở dưới cùng
        itemStyle: {
            color: 'var(--text-color)', // Màu chữ của series name
            fontSize: '14px',
            fontWeight: 'bold'
        }
    },


    plotOptions: {
        pie: {
            dataLabels: {
                enabled: true,
                distance: -40,
                formatter: function () {
                    return `<span style="color:#fff; font-size:1.2rem; text-outline:none;">${this.point.percentage.toFixed(0)}%</span>`;
                },

                style: {
                    fontSize: '1.2rem',
                    textOutline: 'none',
                    opacity: 1,
                    textOutline: 'none'
                },
                filter: {
                    operator: '>',
                    property: 'percentage',
                    value: 10
                }
            },
            showInLegend: true

        }
    },
    series: [{
        name: '',
        data: [],
    }],

    exporting: {
        enabled: true
    },

});

const DownloadData = () => {
    event.stopPropagation();
    if (props.data.tableData.length > 0) {
        gFunc.DownloadExcel(_.cloneDeep(props.data.columnDefs), _.cloneDeep(props.data.tableData));
    } else {
        gFunc.ShowMessage(`Data does not exists`, gVariable.messageType.error);
    }
}

onMounted(() => {
});

watch(props.data, async (newValue, oldValue) => {
    if (newValue && newValue['chartData'] && newValue.chartData.length > 0) {
        chartOptionsPie.value = {
            ...chartOptionsPie.value
        };
        chartOptionsPie.value.series[0].data = newValue.chartData
    }
}, { immediate: true });


</script>
<template>

    <div class="col-span-12 lg:col-span-12 xl:col-span-12">
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <div class="card flex flex-col gap-2" style="padding: 0.5rem !important;">
                <div class="font-semibold text-2xl">{{ data.title }}</div>
                <highcharts :options="chartOptionsPie" ref="chartLineRef" :style="'height:' + data.chartHeight">
                </highcharts>
            </div>
        </div>
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <Accordion value="0" style="background-color: #fff;">
                <AccordionPanel value="1">
                    <AccordionHeader style="padding: 3px 10px;">
                        <div class="p-1 px-3 flex items-center justify-between" style="width:100%">
                            <p class="text-xl underline cursor-pointer" style="color: var(--primary-color);">Details Data</p>
                            <Button class="mr-1" label="" severity="info" size="small" icon="pi pi-download"
                                v-on:click="DownloadData" />
                        </div>
                    </AccordionHeader>
                    <AccordionContent>
                        <div style="width: 100%; height: 100%">
                            <!-- Đăng ký và sử dụng ag-grid -->
                            <ag-grid-vue class="ag-theme-alpine" :style="'width: 100%; height:' + data.tableHeight"
                                :rowData="data.tableData" :columnDefs="data.columnDefs" :defaultColDef="defaultColDef"
                                :gridOptions="gridOptions" />
                        </div>
                    </AccordionContent>
                </AccordionPanel>
            </Accordion>
        </div>
    </div>
</template>

<style>
.highcharts-button-box {
    fill: var(--surface-card) !important;
    /* Màu chữ */
}

.highcharts-button text {
    fill: var(--p-primary-500) !important;
}

.ag-header,
.ag-row,
.ag-paging-panel,
.ag-center-cols-viewport,
.ag-cell-label-container {
    /* Màu nền */
    background-color: var(--surface-card) !important;
    color: var(--text-color) !important;
}

.ag-cell-label-container,
.ag-icon-filter {
    color: var(--primary-color) !important;
}
</style>
