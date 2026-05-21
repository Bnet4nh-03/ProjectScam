<script setup>
import { useLayout } from "@/layout/composables/layout";
import { useAuthStore } from "@/stores/useAuthStore";
import { inject, onMounted, ref, watch, nextTick } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import _, { cloneDeep } from "lodash";
import moment from "moment";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const chartLineRef = ref(null);

// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    // sortable: true,
    // filter: true,
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

const chartOptionsLine = ref({
    chart: {
        type: "line", // Kiểu biểu đồ (cột)
        //backgroundColor:  "transparent",          // Đặt nền trong suốt
        backgroundColor: 'var(--surface-card)',     // màu cho nền phía sau
        plotBackgroundColor: null,                  // màu nền cho chart
        plotBackgroundImage: null,                  // đặt hình nền cho background
        zoomType: "x",                               // Cho phép zoom ngang
    },

    title: {
        text: props.data.chartTitle, // Tiêu đề của chart
        margin: 7,
        style: {
            color: 'var(--primary-color)',
        }
    },
    legend: {
        layout: 'vetical',
        align: 'right',
        verticalAlign: 'middle',
        y: 20,
        // layout: 'vertical',
        // align: 'right',
        // verticalAlign: 'middle',
        itemStyle: {
            color: 'var(--text-color)', // Màu chữ của series name
            fontWeight: 'bold',
            fontSize: '14px'
        },
    },
    tooltip: {
        shared: true,
        formatter: function () {
            let tooltipContent = '';
            // Lặp qua tất cả các điểm có cùng giá trị trên trục X
            const chartTitle = this.series.chart.options.title.text;
            this.points.forEach(point => {
                if (chartTitle.includes(" UE")) {
                    // tooltipContent += `<span style="color:${point.series.color}">${point.series.name}</span>: <b>${point.y.toFixed(0)}%</b><br/>`;
                    tooltipContent += `<span style="color:${point.series.options.borderColor}">${point.series.name}</span>: <b>${Intl.NumberFormat('en-US').format(point.y)}%</b><br/>`;
                } else {
                    // tooltipContent += `<span style="color:${point.series.color}">${point.series.name}</span>: <b>${point.y}</b> (${point.percentage.toFixed(0)}%)<br/>`;
                    tooltipContent += `<span style="color:${point.series.options.borderColor}">${point.series.name}</span>: <b>${Intl.NumberFormat('en-US').format(point.y)}</b><br/>`;
                }
            });
            return tooltipContent;
        },
    },
    credits: {
        enabled: false // Ẩn logo Highcharts
    },
    xAxis: {
        categories: [], // Nhãn trục X
        labels: {
            style: {
                color: 'var(--text-color)',
            },
        },
    },
    yAxis: [
        {   // Primary yAxis
            title: {
                text: "", // Tiêu đề trục Y
            },
            labels: {
                style: {
                    color: 'var(--text-color)',
                },
                format: '{value}'
            },
        }, { // Secondary yAxis
            title: {
                text: "", // Tiêu đề trục Y
            },
            labels: {
                style: {
                    color: 'var(--text-color)',
                },
            },
        }
    ],
    series: [],
    exporting: {
        enabled: true
    },

    plotOptions: {
        line: {
            dataLabels: {
                enabled: true,
                align: 'center', // Căn giữa
                verticalAlign: 'top', // Đặt giá trị phía dưới điểm
                y: -25, // Điều chỉnh vị trí theo trục Y
                formatter: function () {
                    const chartTitle = this.series.chart.options.title.text;
                    if (chartTitle.includes("UE")) {
                        return this.y.toFixed(2) + "%";
                    } else {
                        return Intl.NumberFormat('en-US').format(this.y.toFixed(2));
                    }
                },
                style: {
                    color: 'var(--text-color)',  // Đổi màu chữ thành đỏ cam
                    fontSize: '12px',  // Kích thước chữ
                    fontWeight: '500', // Đậm chữ
                    textOutline: 'none', // Loại bỏ viền chữ mặc định của Highcharts
                    backgroundColor: 'rgba(255,255,255,0.7)' // Tạo nền mờ
                }
            },
            enableMouseTracking: true
        },
        column: {
            borderRadius: 1,
            dataLabels: {
                enabled: false,
                align: 'center', // Căn giữa
                verticalAlign: 'top', // Đặt giá trị phía dưới điểm
                y: -20, // Điều chỉnh vị trí theo trục Y
                style: {
                    color: 'var(--text-color)',  // Đổi màu chữ thành đỏ cam
                    fontSize: '10px',  // Kích thước chữ
                    fontWeight: '500', // Đậm chữ
                    textOutline: 'none', // Loại bỏ viền chữ mặc định của Highcharts
                    backgroundColor: 'rgba(255,255,255,0.7)' // Tạo nền mờ
                }
            },
        },
        series: {
            point: {
                events: {
                    click() {
                    },
                    dblclick(event) {
                        console.log("Chi tiết sự kiện:", event);
                    },
                },
            },
        },
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

watch(props.data, async (newValue, oldValue) => {
    if (newValue && newValue.chartData.length > 0) {
        chartOptionsLine.value = {
            ...chartOptionsLine.value,
            series: newValue.chartData,
            xAxis: {
                categories: newValue.chartLable, // Nhãn trục X
                labels: {
                    style: {
                        color: 'var(--text-color)',
                    },
                },
            },
            yAxis: [
                {   // Primary yAxis
                    title: {
                        text: "", // Tiêu đề trục Y
                    },
                    labels: {
                        style: {
                            color: 'var(--text-color)',
                        },
                        format: newValue.chartData[0].name.includes("UE") ? '{value} %' : '{value}'
                    },
                }, { // Secondary yAxis
                    title: {
                        text: "", // Tiêu đề trục Y
                    },
                    labels: {
                        style: {
                            color: 'var(--text-color)',
                        },
                    },
                }
            ],

        };
    }
}, { immediate: true });

onMounted(() => {

});


</script>
<template>
    <div class="col-span-12 lg:col-span-6 xl:col-span-6">
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <div class="card flex flex-col gap-2" style="padding: 0.5rem !important;">
                <div class="font-semibold text-2xl">{{ data.title }}</div>
                <highcharts :options="chartOptionsLine" ref="chartLineRef" :style="'height:' + data.chartHeight">
                </highcharts>
            </div>
        </div>
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <Accordion value="0" style="background-color: #fff;">
                <AccordionPanel value="1">
                    <AccordionHeader style="padding: 3px 10px;">
                       <div class="p-1 px-3 flex items-center justify-between" style="width:100%">
                            <p class="text-xl">Details Data</p>
                            <Button class="mr-1" label="" severity="info"  size="small" icon="pi pi-download"
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
