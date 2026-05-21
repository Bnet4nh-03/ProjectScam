<script setup>
import { useLayout } from "@/layout/composables/layout";
import { useAuthStore } from "@/stores/useAuthStore";
import { inject, onMounted, ref, watch, nextTick } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import _ from "lodash";
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
    headerHeight: 30,
    rowHeight: 25,
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
        type: "column", // Kiểu biểu đồ (cột)
        // backgroundColor:  "transparent",          // Đặt nền trong suốt
        backgroundColor: 'var(--surface-card)',     // màu cho nền phía sau
        plotBackgroundColor: 'var(--surface-card)',                  // màu nền cho chart
        plotBackgroundImage: null,                  // đặt hình nền cho background
        zoomType: "x",                               // Cho phép zoom ngang
    },
    // scrollbar: {
    //     enabled: true // Bật thanh cuộn ngang
    // },
    title: {
        text: props.data.chartTitle, // Tiêu đề của chart
        margin: 7,
        style: {
            color: 'var(--primary-color)',
        }
    },
    legend: {
        enabled: true,
        layout: 'vetical',
        align: 'right',
        verticalAlign: 'middle',
        y: 20,
        // layout: 'vertical',
        // align: 'right',
        // verticalAlign: 'middle',
        itemStyle: {
            color: 'var(--text-color)', // Màu chữ của series name
            color: '#000',
            fontWeight: 'bold',
            fontSize: '14px'
        },
        useHTML: true,
        // hide default icon of hight chart
        symbolWidth: 0,
        symbolHeight: 0,
        labelFormatter: function () {
            if (this.options.type == 'column') {
                // Trả lại chuỗi HTML có màu borderColor làm màu cho biểu tượng
                // return `<span style="display:inline-block;width:16px;height:12px;border:1px solid ${this.options.borderColor};background-color:${this.options.color};margin-right:5px;"></span> <span style="color: var(--text-color)">${this.name}</span>`;
                return `<span style="display:inline-block;width:16px;height:12px;
                    border:1px solid ${this.options.borderColor};
                    background-color:${this.options.color};
                    margin-right:5px;"></span>
                    <span style="color: var(--text-color)">${this.name}</span>`;

            } else if (this.options.type == 'spline' || this.options.type == 'line') {
                // Kiểm tra nếu series có marker.symbol
                let symbol = this.options.marker?.symbol || "circle"; // Mặc định là hình tròn nếu không có
                let svgContent = "";
                switch (symbol) {
                    case "circle":
                        svgContent = `<circle cx="10" cy="6" r="3.5" fill="${this.options.color}"></circle>`;
                        break;
                    case "triangle":
                        svgContent = `<svg width="10" height="10" viewBox="0 0 20 20" style="transform: translate(5px, 1px);">
                                        <path d="M10,0 L0,20 L20,20 Z" fill="${this.options.color}" />
                                    </svg>`;
                        break;
                    case "square":
                        svgContent = `<rect x="4" y="4" width="8" height="8" style="transform: translate(2px, -2px);" fill="${this.options.color}"></rect>`;
                        break;
                    case "diamond":
                        svgContent = `<svg width="10" height="10" viewBox="0 0 10 10" style="transform: translate(5px, 1px);">
                                        <path d="M5,0 L10,5 L5,10 L0,5 Z" fill="${this.options.color}" />
                                    </svg>`;
                        break;
                    default:
                        svgContent = `<circle cx="8" cy="6" r="3.5" fill="${this.options.color}"></circle>`;
                }
                var ret = `<div style="display: flex; align-items: center;">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="12">
                        <rect x="0" y="5" width="20" height="2" fill="${this.options.borderColor}"></rect>
                         ${svgContent}
                    </svg>
                        <span style="color: var(--text-color); margin-left: 5px;">${this.name}</span>
                    </div>`
                return ret
            }

        }
    },

    tooltip: {
        shared: true,
        formatter: function () {
            let tooltipContent = '';
            // Lặp qua tất cả các điểm có cùng giá trị trên trục X
            this.points.forEach(point => {
                if (point.series.name == "Ue" || point.series.name == "Target") {
                    // tooltipContent += `<span style="color:${point.series.color}">${point.series.name}</span>: <b>${point.y.toFixed(0)}%</b><br/>`;
                    tooltipContent += `<span style="color:${point.series.options.borderColor}">${point.series.name}</span>: <b>${point.y.toFixed(1)}%</b><br/>`;
                } else {
                    // tooltipContent += `<span style="color:${point.series.color}">${point.series.name}</span>: <b>${point.y}</b> (${point.percentage.toFixed(0)}%)<br/>`;
                    tooltipContent += `<span style="color:${point.series.options.borderColor}">${point.series.name}</span>: <b>${Intl.NumberFormat('en-US').format(point.y)}</b> (${point.percentage.toFixed(0)}%)<br/>`;
                }
            });
            return tooltipContent;
        }

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
            min: 0,
            max: 100,
            tickInterval: 10, // Khoảng cách giữa các giá trị
            title: {
                text: "UTILIZATION", // Tiêu đề trục Y
            },
            labels: {
                style: {
                    color: 'var(--text-color)',
                },
                format: '{value} %'
            },
        }, { // Secondary yAxis
            min: 0,
            max: 100,
            tickInterval: 10, // Khoảng cách giữa các giá trị
            title: {
                text: "", // Tiêu đề trục Y
            },
            labels: {
                enabled: false, // Ẩn labels
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
                enabled: false,
                align: 'center', // Căn giữa
                verticalAlign: 'top', // Đặt giá trị phía dưới điểm
                y: -25, // Điều chỉnh vị trí theo trục Y
                formatter: function () {
                    if (this.series.name.includes("UE")) {
                        return this.y.toFixed(2) + "%";
                    } else {
                        return this.y.toFixed(2);
                    }
                },
                style: {
                    color: 'var(--text-color)',  // Đổi màu chữ thành đỏ cam
                    fontSize: '12px',  // Kích thước chữ
                    fontWeight: '500', // Đậm chữ
                    textOutline: 'none', // Loại bỏ viền chữ mặc định của Highcharts
                    backgroundColor: 'var(--surface-card)' // Tạo nền mờ
                }
            },
            enableMouseTracking: true
        },
        column: {
            borderRadius: 1,
            stacking: 'percent',
            dataLabels: {
                enabled: true,
                align: 'center', // Căn giữa
                verticalAlign: 'middle', // Đặt giá trị phía dưới điểm
                inside: true, // Hiển thị nhãn bên trong cột
                // y: -20, // Điều chỉnh vị trí theo trục Y
                formatter: function () {
                    if (_.toString(this.point.percentage) != "") {
                        return this.point.percentage.toFixed(0) + "%";
                    } else {
                        return "";
                    }
                },
                style: {
                    color: 'var(--text-color)',  // Đổi màu chữ thành đỏ cam
                    fontSize: '10px',  // Kích thước chữ
                    fontWeight: '500', // Đậm chữ
                    textOutline: 'none', // Loại bỏ viền chữ mặc định của Highcharts
                    backgroundColor: 'var(--surface-card)' // Tạo nền mờ
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
                    min: 0,
                    max: 100,
                    tickInterval: 10, // Khoảng cách giữa các giá trị
                    title: {
                        text: "UTILIZATION", // Tiêu đề trục Y
                    },
                    labels: {
                        style: {
                            color: 'var(--text-color)',
                        },
                        format: '{value} %'
                    },
                }, { // Secondary yAxis
                    min: 0,
                    max: 100,
                    tickInterval: 10, // Khoảng cách giữa các giá trị
                    title: {
                        text: "", // Tiêu đề trục Y
                    },
                    labels: {
                        enabled: false, // Ẩn labels
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
