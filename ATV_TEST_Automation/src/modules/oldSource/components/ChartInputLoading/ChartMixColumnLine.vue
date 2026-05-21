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
const chartColRef = ref(null);
const lstGroupSelected = ref([]);
const lstChartData = ref([]);
const rowDataSelected = ref([]);
const colSelected = ref([]);

const previewImage = ref(null);


// Get the current date
const currentDate = moment();
const currentWeek = ref("WW" + currentDate.format('ww'));
const startWeek = ref();
const endWeek = ref();
const indexOfStartWeek = ref();
const indexOfEndWeek = ref();



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
            chartLable: [],
            chartHeight: '30vh',
            tableData: [],
            tableHeight: '230px',
            columnDefs: [],
            isShowFilter: false,
            defaultSelected: []
        }),
    },
});


// Tùy chọn cấu hình biểu đồ cột
const chartOptionsCol = ref({
    chart: {
        //backgroundColor:  "transparent",          // Đặt nền trong suốt
        backgroundColor: 'var(--surface-card)',     // màu cho nền phía sau
        // plotBackgroundColor: null,                  // màu nền cho chart
        // plotBackgroundImage: null,                  // đặt hình nền cho background
        zoomType: "x"                               // Cho phép zoom ngang
    },
    title: {
        text: props.data.chartTitle, // Tiêu đề của chart
        style: {
            color: 'var(--primary-color)',
        }
    },
    legend: {
        layout: 'horizontal',
        align: 'center',
        verticalAlign: 'bottom',
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
        formatter: function (item) {
            return `<b>${this.series.name}</b>: ${Intl.NumberFormat('en-US').format(this.y)}`;
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
            title: {
                text: "", // Tiêu đề trục Y
            },
            labels: {
                style: {
                    color: 'var(--text-color)',
                },
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

onMounted(() => {
    lstChartData.value = props.data.chartData;
    // set default item from week, to week
    if (_.toString(props.data.chartLable) != '') {
        const indexCurrentWeek = _.findIndex(props.data.chartLable, (item) => item === currentWeek.value);
        if (indexCurrentWeek - 4 < 0) {
            startWeek.value = props.data.chartLable[0];
            // indexOfStartWeek.value = 0;
        } else {
            startWeek.value = props.data.chartLable[indexCurrentWeek - 4];
            // indexOfStartWeek.value = indexCurrentWeek - 4;
        }
        if ((indexCurrentWeek + 6) >= props.data.chartLable.length) {
            endWeek.value = props.data.chartLable[props.data.chartLable.length - 1];
            //   indexOfEndWeek.value = 0;
        } else {
            endWeek.value = props.data.chartLable[indexCurrentWeek + 6];
            //  indexOfEndWeek.value = indexCurrentWeek + 6;
        }
    }

    if (props.data["legendStyle"] && props.data["legendStyle"] == 'horizontal') {
        chartOptionsCol.value.legend.layout = 'horizontal';
        chartOptionsCol.value.legend.align = 'center';
        chartOptionsCol.value.legend.verticalAlign = 'bottom';
    } else {
        chartOptionsCol.value.legend.layout = 'vertical';
        chartOptionsCol.value.legend.align = 'right';
        chartOptionsCol.value.legend.verticalAlign = 'middle';
    }

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


watch(startWeek, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        indexOfStartWeek.value = _.findIndex(props.data.chartLable, (item) => item === newValue);
        indexOfEndWeek.value = _.findIndex(props.data.chartLable, (item) => item === endWeek.value);
        if (indexOfStartWeek.value > indexOfEndWeek.value) {
            gFunc.ShowMessage("From Week must not be greater than To Week", gVariable.messageType.error);
            return
        }
        OnChangeData(indexOfStartWeek.value,indexOfEndWeek.value);
    } else {
        chartOptionsCol.value.series = [];
    }
});

watch(endWeek, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        indexOfStartWeek.value = _.findIndex(props.data.chartLable, (item) => item === startWeek.value);
        indexOfEndWeek.value = _.findIndex(props.data.chartLable, (item) => item === newValue);
        if (indexOfStartWeek.value > indexOfEndWeek.value) {
            gFunc.ShowMessage("From Week must not be greater than To Week", gVariable.messageType.error);
            return
        }
        OnChangeData(indexOfStartWeek.value,indexOfEndWeek.value);
    } else {
        chartOptionsCol.value.series = [];
    }
});


watch(props.data, async (newValue, oldValue) => {
    if (newValue.chartData.length > 0) {
        chartOptionsCol.value = {
            ...chartOptionsCol.value,
            series: newValue.chartData,
        };
    }
}, { immediate: true });

watch(lstGroupSelected, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        chartOptionsCol.value.series = newValue;
        rowDataSelected.value = [];
        for (let index = 0; index < newValue.length; index++) {
            const itemsToAdd = props.data.tableData.filter(
                (item) => item.key == newValue[index]['code']
            );
            if (itemsToAdd.length > 0) {
                rowDataSelected.value.push(itemsToAdd[0]);
            }
        }
    } else {
        chartOptionsCol.value.series = [];
        rowDataSelected.value = [];
    }
});

const OnChangeData = async (indexOfStartWeek, indexOfEndWeek) => {
    // xử lý header của table
    const columnsToExtract = [0, 1, 2, ..._.range(indexOfStartWeek + 3, indexOfEndWeek + 4)];
    colSelected.value = _.map(columnsToExtract, (index) => props.data.columnDefs[index]);

    // xử lý dữ liệu cho chart
    const chartDataToExtract = [..._.range(indexOfStartWeek, indexOfEndWeek + 1)];

    // gán lại label cho chart
    chartOptionsCol.value.xAxis.categories = _.map(chartDataToExtract, (index) => props.data.chartLable[index]);

    // clone những item được chọn
    var tmpLstGroupSelected = _.cloneDeep(lstGroupSelected.value);

    // lặp những item đang được chọn để cắt mảng data cho chart hiển thị theo week đã filter
    for (let index = 0; index < tmpLstGroupSelected.length; index++) {
        var itemsToAdd = props.data.chartData.filter(
            (item) => item.code == tmpLstGroupSelected[index]['code']
        );
        if (itemsToAdd.length > 0) {
            tmpLstGroupSelected[index].data = _.map(chartDataToExtract, (i) => itemsToAdd[0].data[i]);
        }
    }

    // clone list item cũ
    var tmpLstChartData = _.cloneDeep(lstChartData.value);

    // cắt dữ liệu trong model của combobox
    for (let index = 0; index < tmpLstChartData.length; index++) {
        tmpLstChartData[index].data = _.map(chartDataToExtract, (i) => props.data.chartData[index].data[i]);
    }
    // gán lại dữ liệu cho combobox
    lstChartData.value = tmpLstChartData;

    // gán lại sau khi đã cắt mảng theo week
    lstGroupSelected.value = tmpLstGroupSelected;
    chartColRef.value.chart.xAxis[0].setExtremes(null, null);
}


// Khai báo emit để gửi sự kiện và dữ liệu về cha
const emit = defineEmits(["update"]);

// Hàm gửi dữ liệu về cha
const emitToParent = (isClear) => {
    var msg = "Hello from Child!";
    if (isClear) {
        msg = "";
    }
    emit("update", msg);
};


const sendChartToAPI = async () => {
    const chart = chartColRef.value.chart;

    // Lưu lại màu nền hiện tại
    const originalBackgroundColor = chart.options.chart.backgroundColor;

    // Thay đổi màu nền thành trắng
    chart.update({
        chart: {
            backgroundColor: '#ffffff' // Màu nền trắng
        }
    });
    var imageData = chart.getSVGForExport({
        type: 'image/png',
    });

    // Khôi phục màu nền ban đầu
    chart.update({
        chart: {
            backgroundColor: originalBackgroundColor
        }
    });
    // Tạo Blob từ dữ liệu SVG
    const blob = new Blob([imageData], { type: 'image/svg+xml' });
    // Tạo URL từ Blob
    previewImage.value = URL.createObjectURL(blob);

    // try {
    //     const response = await axios.post('https://your-api-endpoint.com/upload', {
    //         image: imageData
    //     });
    //     console.log('Image uploaded successfully:', response.data);
    // } catch (error) {
    //     console.error('Error uploading image:', error);
    // }
};





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

    <div class="col-span-12 lg:col-span-12 xl:col-span-12">
        <div class="card flex flex-col gap-2" style="padding: 0.5rem !important;">
            <div v-if="_.toString(data.title) != ''" class="font-semibold text-2xl">{{ data.title }}</div>
            <!-- <img :src="previewImage" alt="Chart Preview" /> -->
            <div class="flex flex-row w-full gap-2 mt-4" v-if="data.isShowFilter">
                <FloatLabel class="flex-[2] mt-1">
                    <Select id="on_label" v-model="startWeek" :options="props.data.chartLable" :filter="true"
                        class="w-full" />
                    <label for="on_label">From Week</label>
                </FloatLabel>
                <FloatLabel class="flex-[2] mt-1">
                    <Select id="on_label" v-model="endWeek" :options="props.data.chartLable" :filter="true"
                        class="w-full" />
                    <label for="on_label">To Week</label>
                </FloatLabel>
                <FloatLabel class="flex-[10] mt-1">
                    <MultiSelect id="on_label" v-model="lstGroupSelected" :options="lstChartData" :maxSelectedLabels="3"
                        display="chip" optionLabel="name" :filter="true" showClear class="w-full" />
                    <label for="on_label">Select Item</label>
                </FloatLabel>
                <!-- <button v-on:click="sendChartToAPI">aaaaaa</button> -->
            </div>
            <highcharts :options="chartOptionsCol" ref="chartColRef" :style="'height:' + data.chartHeight">
            </highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12">
        <Accordion value="1" style="background-color: #fff;">
            <AccordionPanel value="0">
                <AccordionHeader style="padding: 10px;">
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
                            :rowData="rowDataSelected" :columnDefs="colSelected" :defaultColDef="defaultColDef"
                            :gridOptions="gridOptions" />
                    </div>
                </AccordionContent>
            </AccordionPanel>
        </Accordion>
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
