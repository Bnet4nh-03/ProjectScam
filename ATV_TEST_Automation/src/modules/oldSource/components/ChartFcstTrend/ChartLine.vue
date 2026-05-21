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
const lstGroupSelected = ref([]);
const rowDataSelected = ref([]);

// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: true,
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
            chartHeight: '30vh',
            tableData: [],
            tableHeight: '230px',
            columnDefs: [],
            isShowFilter: false,
            defaultSelected: []
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
        // zoomType: "x"                               // Cho phép zoom ngang
    },
    legend: {
        layout: 'vertical',
        align: 'left',
        verticalAlign: 'middle',
        itemStyle: {
            color: 'var(--text-color)', // Màu chữ của series name
            fontWeight: 'bold',
            fontSize: '14px'
        }
    },
    title: {
        text: props.data.chartTitle, // Tiêu đề của chart
        style: {
            color: 'var(--primary-color)',
        }
    },
    tooltip: {
        formatter: function (item) {
            let date = new Date(this.x);
            const formattedDate = `${date.getMonth() + 1}-${date.getFullYear()}`;
            return `<b>${formattedDate}</b>: ${Intl.NumberFormat('en-US').format(this.y)}`;
        }
    },
    xAxis: {
        // categories: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4"], // Nhãn trục X
        type: "datetime",
        minPadding: 0.02, // Nới rộng 1% ở đầu
        maxPadding: 0.02, // Nới rộng 1% ở cuối
        ordinal: false,
        labels: {
            style: {
                color: 'var(--text-color)',
            },
        },
        dateTimeLabelFormats: {
            month: "%m - %Y",  // Định dạng tháng - năm
            year: "%Y"        // Chỉ hiển thị năm nếu cần
        },
    },
    yAxis: {
        title: {
            text: "Millions", // Tiêu đề trục Y
        },
        labels: {
            style: {
                color: 'var(--text-color)',
            },
        },
    },
    series: props.data.chartData,
    navigator: {
        enabled: false // Bật navigator
    },
    scrollbar: {
        enabled: true // Thêm scrollbar để kéo dữ liệu
    },
    rangeSelector: {
        enabled: true, // Cho phép chọn phạm vi dữ liệu
        allButtonsEnabled: true,
        selected: 0,
        buttons: [
            { type: "month", count: 6, text: "6M" },
            { type: "year", count: 1, text: "1Y" },
            { type: "all", text: "All" }
        ],
        inputDateFormat: "%Y-%m", // Định dạng input tháng + năm
        inputEditDateFormat: "%Y-%m", // Khi chỉnh sửa cũng chỉ hiển thị tháng + năm
        inputBoxWidth: 80,

        buttonTheme: {
            style: {
                color: 'var(--text-color)', // Màu chữ
            },
            states: {
                hover: {
                    style: {
                        color: 'var(--primary-color)',
                        fontWeight: "bold",
                    }
                },
                select: {
                    style: {
                        color: 'var(--primary-color)',
                        fontWeight: "bold",
                    }
                }
            }
        },
        labelStyle: {
            color: 'var(--text-color)' // Màu chữ của label "Zoom"
        },
        inputStyle: {
            color: 'var(--primary-color)', // Màu chữ trong input field
            backgroundColor: 'var(--surface-card)', // Màu nền input (Xám đậm)
        },
    },

    plotOptions: {
        line: {
            marker: {
                enabled: true, // Hiển thị điểm trên đường line
                radius: 3 // Kích thước nhỏ hơn (mặc định là 4)
            },
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
                    backgroundColor: 'var(--surface-card)' // Tạo nền mờ
                }
            },
        },

        series: {
            point: {
                events: {
                    click() {
                        // if (this.timer) {
                        //     clearTimeout(this.timer);
                        //     this.timer = null;
                        //     alert(`Double-click vào cột "${this.category}" với giá trị: ${this.y}`);
                        //     handleChartColumnDoubleClick(this);
                        //     console.log("Double-click", this);
                        // } else {
                        //     this.timer = setTimeout(() => {
                        //         this.timer = null;
                        //         alert(`Single-click vào cột "${this.category}" với giá trị: ${this.y}`);
                        //         handleChartColumnClick(this);
                        //         console.log("Single-click", this);
                        //     }, 300);
                        // }
                    },
                    dblclick(event) {
                        // Hàm xử lý double-click vào cột
                        // alert(
                        //     `Bạn đã double-click vào cột "${this.category}" với giá trị: ${this.y}`
                        // );
                        console.log("Chi tiết sự kiện:", event);
                        // handleChartColumnDoubleClick(this);
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
    if (newValue.chartData.length > 0) {
        chartOptionsLine.value = {
            ...chartOptionsLine.value,
            series: newValue.chartData,
        };
    }
}, { immediate: true });

watch(lstGroupSelected, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        chartOptionsLine.value.series = newValue;
        rowDataSelected.value = [];
        for (let index = 0; index < newValue.length; index++) {
            const itemsToAdd = props.data.tableData.filter(
                (item) => item.key === newValue[index]['code']
            );
            if (itemsToAdd.length > 0) {
                rowDataSelected.value.push(itemsToAdd[0]);
            }
        }
    } else {
        chartOptionsLine.value.series = [];
        rowDataSelected.value = [];
    }
});


onMounted(() => {
    if (_.toString(props.data.defaultSelected) && props.data.defaultSelected.length > 0) {
        var tmpArr = [];
        for (let index = 0; index < props.data.defaultSelected.length; index++) {
            var pos = props.data.defaultSelected[index];
            tmpArr.push(props.data.chartData[pos]);
            rowDataSelected.value.push(props.data.tableData[pos]);
        }
        lstGroupSelected.value = tmpArr;
    } else {
        lstGroupSelected.value = props.data.chartData;
        rowDataSelected.value = props.data.tableData;
    }

});

function handleChartColumnClick(event) {
    event.category, event.series.name;
    alert(event.category + " " + event.series.name);
}
function handleChartColumnDoubleClick(event) {
    event.category, event.series.name;
    alert(event.category);
}

</script>
<template>
    <div class="col-span-12 lg:col-span-6 xl:col-span-6">
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <div class="card flex flex-col gap-2" style="padding: 0.5rem !important;">
                <div class="font-semibold text-2xl">{{ data.title }}</div>
                <div class="flex flex-row w-full gap-2 mt-4" v-if="data.isShowFilter">
                    <!-- <FloatLabel class="flex-[4]">
                            <MultiSelect id="on_label" v-model="lstCustSelected" :options="lstCust"
                                :maxSelectedLabels="2" display="chip" optionLabel="name" :filter="true" showClear
                                class="w-full" />
                            <label for="on_label">Select Customers Code</label>
                        </FloatLabel> -->
                    <FloatLabel class="flex-[6]">
                        <MultiSelect id="on_label" v-model="lstGroupSelected" :options="data.chartData"
                            :maxSelectedLabels="3" display="chip" optionLabel="name" :filter="true" showClear
                            class="w-full" />
                        <label for="on_label">Select Groups</label>
                    </FloatLabel>
                </div>
                <highcharts :options="chartOptionsLine" ref="chartLineRef" :style="'height:' + data.chartHeight">
                </highcharts>
            </div>
        </div>
        <div class="col-span-12 lg:col-span-12 xl:col-span-12">
            <Accordion value="1" style="background-color: #fff;">
                <AccordionPanel value="0">
                    <AccordionHeader style="padding: 5px 10px;">
                        <div class="p-1 px-3 flex items-center justify-between" style="width:100%">
                            <p class="text-xl">Details Data</p>
                            <Button class="mr-1" label="" severity="info"  size="small" icon="pi pi-download"
                                v-on:click="DownloadData" />
                        </div>
                    </AccordionHeader>
                    <AccordionContent>
                        <div style="width: 100%; height: 100%">
                            <!-- Đăng ký và sử dụng ag-grid -->
                            <ag-grid-vue class="ag-theme-alpine" :style="'width: 100%; height: ' + data.tableHeight"
                                :rowData="rowDataSelected" :columnDefs="data.columnDefs"
                                :defaultColDef="defaultColDef"  :gridOptions="gridOptions" />
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
</style>
