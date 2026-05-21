<script setup>
import { inject, onMounted, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/service/BaseService";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');


// Khai báo props nhận từ component cha
const props = defineProps({
    message: "", // Prop truyền từ cha
});

const isLoading = ref(false);
const lstCust = ref([]);
const lstCustSelected = ref([]);

const lstGroup = ref([]);
const lstGroupFilter = ref([]);
const lstGroupSelected = ref([]);

const lstVolCust = ref([]);
const lstVolCustSelected = ref([]);

const lstVolGroup = ref([]);
const lstVolGroupFilter = ref([]);
const lstVolGroupSelected = ref([]);


const background = ref([
    'rgba(251, 65, 4, 0,2)',
    "rgba(75, 192, 192, 0.2)",
    'rgba(255, 99, 132, 0.2)',
    'rgba(54, 162, 235, 0.2)',
    'rgba(255, 159, 64, 0.2)',
    'rgba(153, 102, 255, 0.2)',
    'rgba(255, 205, 86, 0.2)',
    'rgba(201, 203, 207, 0.2)',
    'rgba(0, 128, 128, 0.2)',
    'rgba(124, 252, 0, 0.2)',
    'rgba(255, 192, 203, 0.2)',
    'rgba(128, 128, 128, 0.2)',
    'rgba(128, 0, 0, 0.2)',
    'rgba(0, 0, 128, 0.2)',
    'rgba(128, 128, 0, 0.2)',
    'rgba(255, 0, 255, 0.2)',
    'rgba(228,176,146,0.2)',
    'rgba(16, 157, 88,0.2)',
    'rgba(158,190,165,0.2)',
    "rgba(251, 162, 208, 0.2)",
    'rgba(34, 126, 156,0.2)',
    'rgba(255,170,54,0.2)',
    'rgba(62, 241, 186,0.2)',
    'rgba(236, 31, 106, 0.2)',
    'rgba(255,180,174,0.2)',
    'rgb(255, 95, 1, 0.2)',
    'rgba(251,193,147,0.2)',
    'rgba(164,207,209,0.2)',
    'rgba(253, 138, 4,0.2)',
    'rgba(172,156,203,0.2)',
    "rgba(105, 102, 205, 0.2)",
    'rgba(249,163,254,0.2)',
    'rgba(249,214,122,0.2)',
    'rgba(163,198,198,0.2)',
    'rgba(197,151,165,0.2)',
    'rgba(222,177,169,0.2)',
    'rgba(254,154,154,0.2)',
    'rgba(192,212,225,0.2)',
    'rgba(219,210,105,0.2)',
    'rgba(208,202,177,0.2)',
    'rgba(205,124,124,0.2)',
    'rgba(124,164,182,0.2)',
    'rgba(255,184,208,0.2)',
    'rgba(228,206,202,0.2)',
    'rgba(255,191,179,0.2)',
    'rgba(196,154,104,0.2)',
    'rgba(255,214,109,0.2)',
    'rgba(203,163,164,0.2)',
    'rgba(228,223,212,0.2)',
    'rgba(144,181,178,0.2)',
    'rgba(167,177,193,0.2)',
    'rgba(228,127,195,0.2)',
    'rgba(249,193,62,0.2)',
    'rgba(248,191,172,0.2)',
    'rgba(255,182,88,0.2)',
    'rgba(215,171,114,0.2)',
    'rgba(224,206,183,0.2)',
    'rgba(241,142,144,0.2)',
    'rgba(229,190,164,0.2)',
    'rgba(253,252,160,0.2)',
    'rgba(174,195,66,0.2)',
    'rgba(144,155,181,0.2)',
    'rgba(216,158,196,0.2)',
    'rgba(252,196,183,0.2)',
    'rgba(228,219,218,0.2)',
    'rgba(3,169,244,0.2)',
    'rgba(254,230,132,0.2)',
]);

const border = ref([
    'rgb(251, 65, 4)',
    "rgb(75, 192, 192)",
    'rgb(255, 99, 132)',
    'rgb(54, 162, 235)',
    'rgb(255, 159, 64)',
    'rgb(153, 102, 255)',
    'rgb(255, 205, 86)',
    'rgb(201, 203, 207)',
    'rgb(0, 128, 128)',
    'rgb(124, 252, 0)',
    'rgb(255, 192, 203)',
    'rgb(128, 128, 128)',
    'rgb(128, 0, 0)',
    'rgb(0, 0, 128)',
    'rgb(128, 128, 0)',
    'rgb(255, 0, 255)',
    'rgb(228,176,146)',
    'rgb(16, 157, 88)',
    'rgb(158,190,165)',
    "rgb(251, 162, 208)",
    'rgb(34, 126, 156)',
    'rgb(255,170,54)',
    'rgb(62, 241, 186)',
    'rgb(236, 31, 106)',
    'rgb(255,180,174)',
    'rgb(255, 95, 1)',
    'rgb(251,193,147)',
    'rgb(164,207,209)',
    'rgb(253, 138, 4)',
    'rgb(172,156,203)',
    "rgb(105, 102, 205)",
    'rgb(249,163,254)',
    'rgb(249,214,122)',
    'rgb(163,198,198)',
    'rgb(197,151,165)',
    'rgb(222,177,169)',
    'rgb(254,154,154)',
    'rgb(192,212,225)',
    'rgb(219,210,105)',
    'rgb(208,202,177)',
    'rgb(205,124,124)',
    'rgb(124,164,182)',
    'rgb(255,184,208)',
    'rgb(228,206,202)',
    'rgb(255,191,179)',
    'rgb(196,154,104)',
    'rgb(255,214,109)',
    'rgb(203,163,164)',
    'rgb(228,223,212)',
    'rgb(144,181,178)',
    'rgb(167,177,193)',
    'rgb(228,127,195)',
    'rgb(249,193,62)',
    'rgb(248,191,172)',
    'rgb(255,182,88)',
    'rgb(215,171,114)',
    'rgb(224,206,183)',
    'rgb(241,142,144)',
    'rgb(229,190,164)',
    'rgb(253,252,160)',
    'rgb(174,195,66)',
    'rgb(144,155,181)',
    'rgb(216,158,196)',
    'rgb(252,196,183)',
    'rgb(228,219,218)',
    'rgb(3,169,244)',
    'rgb(254,230,132)',
]);

// Khai báo column cho bảng trend
const columnFcstTrendDefs = ref([]);
// Dữ liệu cho bảng trend
const rowDataFcstTrend = ref([]);
const rowDataFcstTrendFilter = ref([]);

// Khai báo column cho bảng vol
const columnFcstVolDefs = ref([]);
// Dữ liệu cho bảng vol
const rowDataFcstVol = ref([]);
const rowDataFcstVolFilter = ref([]);

// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: true,
};

// Tùy chọn cấu hình biểu đồ cột
const chartOptionsCol = ref({
    chart: {
        type: "column",                             // Kiểu biểu đồ (cột)
        //backgroundColor:  "transparent",          // Đặt nền trong suốt
        backgroundColor: 'var(--surface-card)',     // màu cho nền phía sau
        plotBackgroundColor: null,                  // màu nền cho chart
        plotBackgroundImage: null,                  // đặt hình nền cho background
        // zoomType: "x"                               // Cho phép zoom ngang
    },
    title: {
        text: "Monthly FCST Volume V2V by Device", // Tiêu đề
        style: {
            color: 'var(--primary-color)',
        }
    },
    legend: {
        itemStyle: {
            color: 'var(--text-color)', // Màu chữ của series name
            fontWeight: 'bold',
            fontSize: '14px'
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
        labels: {
            style: {
                color: 'var(--text-color)',
            },
        },
        dateTimeLabelFormats: {
            month: "%m - %Y",  // Định dạng tháng - năm
            year: "%Y"        // Chỉ hiển thị năm nếu cần
        }
    },
    yAxis: {
        title: {
            text: "Thousands", // Tiêu đề trục Y
        },
        labels: {
            style: {
                color: 'var(--text-color)',
            },
        },
    },
    series: [],
    navigator: {
        enabled: false // Bật navigator
    },
    scrollbar: {
        enabled: true // Thêm scrollbar để kéo dữ liệu
    },
    rangeSelector: {
        enabled: true, // Cho phép chọn phạm vi dữ liệu
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
        itemStyle: {
            color: 'var(--text-color)', // Màu chữ của series name
            fontWeight: 'bold',
            fontSize: '14px'
        }
    },
    title: {
        text: "Monthly Accumulate FCST V2V by Device", // Tiêu đề
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
    series: [],
    navigator: {
        enabled: false // Bật navigator
    },
    scrollbar: {
        enabled: true // Thêm scrollbar để kéo dữ liệu
    },
    rangeSelector: {
        enabled: true, // Cho phép chọn phạm vi dữ liệu
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
                    backgroundColor: 'rgba(255,255,255,0.7)' // Tạo nền mờ
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

watch(lstCustSelected, (newValue, oldValue) => {
    // Tìm phần tử bị thêm
    const addedItems = _.differenceWith(newValue, oldValue, _.isEqual);

    // Tìm phần tử bị xóa
    const removedItems = _.differenceWith(oldValue, newValue, _.isEqual);

    if (removedItems.length) {
        // xoá item ở list group filter
        for (let index = 0; index < removedItems.length; index++) {
            _.remove(lstGroupFilter.value, item => item.code.startsWith(removedItems[index]["code"]));
            _.remove(lstGroupSelected.value, item => item.code.startsWith(removedItems[index]["code"]));
            _.remove(rowDataFcstTrendFilter.value, item => item['Column2'] === removedItems[index]["code"]);

            console.log("Removed Items:", removedItems);
        }
    }

    if (addedItems.length) {
        // thêm item vào list group filter
        for (let index = 0; index < addedItems.length; index++) {

            // Lọc ra những item có `code` bắt đầu bằng addedItems.code và chưa tồn tại trong lstGroupFilter
            const itemsToAdd = lstGroup.value.filter(
                (item) => item.code.startsWith(addedItems[index].code) && !_.some(lstGroupFilter.value, { code: item.code })
            );

            // Thêm vào list
            lstGroupFilter.value.push(...itemsToAdd);
        }
        console.log("Added Items:", addedItems);
    }
});

watch(lstGroupSelected, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        chartOptionsLine.value.series = newValue;

        rowDataFcstTrendFilter.value = [];
        for (let index = 0; index < newValue.length; index++) {
            // Lọc ra những item có `code` bắt đầu bằng addedItems.code và chưa tồn tại trong lstGroupFilter
            const itemsToAdd = rowDataFcstTrend.value.filter(
                (item) => item.key === newValue[index]['code']
            );
            if (itemsToAdd.length > 0) {
                rowDataFcstTrendFilter.value.push(itemsToAdd[0]);
            }
        }
    } else {
        chartOptionsLine.value.series = [];
        rowDataFcstTrendFilter.value = [];
    }
});


watch(lstVolCustSelected, (newValue, oldValue) => {
    // Tìm phần tử bị thêm
    const addedItems = _.differenceWith(newValue, oldValue, _.isEqual);

    // Tìm phần tử bị xóa
    const removedItems = _.differenceWith(oldValue, newValue, _.isEqual);

    if (removedItems.length) {
        // xoá item ở list group filter
        for (let index = 0; index < removedItems.length; index++) {
            _.remove(lstVolGroupFilter.value, item => item.code.startsWith(removedItems[index]["code"]));
            _.remove(lstVolGroupSelected.value, item => item.code.startsWith(removedItems[index]["code"]));
            _.remove(rowDataFcstVolFilter.value, item => item['Column2'] === removedItems[index]["code"]);

        }
    }

    if (addedItems.length) {
        // thêm item vào list group filter
        for (let index = 0; index < addedItems.length; index++) {

            // Lọc ra những item có `code` bắt đầu bằng addedItems.code và chưa tồn tại trong lstGroupFilter
            const itemsToAdd = lstVolGroup.value.filter(
                (item) => item.code.startsWith(addedItems[index].code) && !_.some(lstVolGroupFilter.value, { code: item.code })
            );

            // Thêm vào list
            lstVolGroupFilter.value.push(...itemsToAdd);
        }
    }
});

watch(lstVolGroupSelected, (newValue, oldValue) => {
    if (_.toString(newValue) != '') {
        chartOptionsCol.value.series = newValue;

        rowDataFcstVolFilter.value = [];
        for (let index = 0; index < newValue.length; index++) {
            // Lọc ra những item có `code` bắt đầu bằng addedItems.code và chưa tồn tại trong lstGroupFilter
            const itemsToAdd = rowDataFcstVol.value.filter(
                (item) => item.key === newValue[index]['code']
            );
            if (itemsToAdd.length > 0) {
                rowDataFcstVolFilter.value.push(itemsToAdd[0]);
            }
        }
    } else {
        chartOptionsCol.value.series = [];
        rowDataFcstVolFilter.value = [];
    }
});

function handleChartColumnClick(event) {
    // event.category, event.series.name;
    // alert(event.category + " " + event.series.name);
}
function handleChartColumnDoubleClick(event) {
    // event.category, event.series.name;
    // alert(event.category);
}

const GetDataFcstTrend = async () => {
    isLoading.value = true;
    var param = {
        "header": {
            "userId": "string",
            "accessToken": "string",
            "role": "string"
        },
        "body": "string"
    }
    const response = await apiService.post('/api/PcsFcstTrend', param);
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        ConvertDataFcstTrend(res.data.fcstTrendData);
        ConvertDataFcstVolData(res.data.fcstVolData);
    }

    isLoading.value = false;
};

const ConvertDataFcstVolData = (dataFcstVol) => {
    if (dataFcstVol.length > 0) {
        // int data
        columnFcstVolDefs.value = [];
        rowDataFcstVol.value = [];

        for (let index = 0; index < dataFcstVol.length; index++) {
            var row = _.cloneDeep(dataFcstVol[index]);
            if (index == 1) {
                Object.keys(row).forEach((key, index) => {
                    columnFcstVolDefs.value.push({
                        field: key,
                        headerName: index < 6 ? row[key] : row[key] + "-" + dataFcstVol[0][key],
                        width: 120,
                        sortable: true,
                        filter: true,
                        valueFormatter: (params) => {
                            const value = Number(params.value);
                            if (!isNaN(value)) {
                                return new Intl.NumberFormat('en-US').format(value);
                            }
                            return params.value;
                        }
                    })
                    // console.log(`Index: ${index}, Name: ${key}, Value: ${obj[key]}`);
                });
                columnFcstVolDefs.value.unshift({
                    headerName: 'No',
                    valueGetter: (params) => params.node.rowIndex + 1,
                    width: 80
                })
            }
            if (index > 1) {
                // set data cho grid
                dataFcstVol[index]['key'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];
                rowDataFcstVol.value.push(dataFcstVol[index]);

                // gán value cho combobox customer
                const itemVolCust = {
                    name: row['Column2'],
                    code: row['Column2'],
                };

                // Kiểm tra nếu newItem chưa tồn tại trong lstVolCust thì thêm vào
                if (!_.some(lstVolCust.value, itemVolCust)) {
                    lstVolCust.value.push(itemVolCust);
                }

                var itemVolGroup = {};
                itemVolGroup['name'] = row['Column5'] + "_" + row['Column6'];
                itemVolGroup['code'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];

                delete row["Column2"];
                delete row["Column3"];
                delete row["Column4"];
                delete row["Column5"];
                delete row["Column6"];
                delete row["Column7"];


                itemVolGroup['lineWidth'] = 2;
                itemVolGroup['showInNavigator'] = true;
                itemVolGroup['data'] = Object.entries(row).map(item => [moment(`${dataFcstVol[1][item[0]]} ${dataFcstVol[0][item[0]]}`, "MMM YYYY").startOf("month").valueOf(), item[1] !== null ? Number(item[1]) : null]);
                itemVolGroup['color'] = background.value[index];
                itemVolGroup['borderColor'] = border.value[index];
                itemVolGroup['borderWidth'] = 1;

                // Lấy timestamp đầu tiên và cuối cùng
                const firstTimestamp = itemVolGroup['data'][0][0];
                const lastTimestamp = itemVolGroup['data'][itemVolGroup['data'].length - 1][0];

                itemVolGroup['data'].unshift([moment(firstTimestamp).subtract(15, "day").valueOf(), null]);
                itemVolGroup['data'].push([moment(lastTimestamp).add(15, "day").valueOf(), null]);

                lstVolGroup.value.push(itemVolGroup);
            }
        }

        lstVolCustSelected.value = [lstVolCust.value[0]];

        const itemsToAdd = lstVolGroup.value.filter(
            (item) => item.code.startsWith(lstVolCust.value[0].code)
        );
        lstVolGroupSelected.value = itemsToAdd;

        const itemsToAddGrid = rowDataFcstVol.value.filter(
            (item) => item['Column2'].startsWith(lstVolCust.value[0].code)
        );

        rowDataFcstVolFilter.value = itemsToAddGrid;
    }
};
const ConvertDataFcstTrend = (dataFcstTrend) => {
    if (dataFcstTrend.length > 0) {
        // int data
        columnFcstTrendDefs.value = [];
        rowDataFcstTrend.value = [];

        for (let index = 0; index < dataFcstTrend.length; index++) {
            var row = _.cloneDeep(dataFcstTrend[index]);
            if (index == 1) {
                Object.keys(row).forEach((key, index) => {
                    columnFcstTrendDefs.value.push({
                        field: key,
                        headerName: index < 6 ? row[key] : row[key] + "-" + dataFcstTrend[0][key],
                        width: 120,
                        sortable: true,
                        filter: true,
                        valueFormatter: (params) => {
                            const value = Number(params.value);
                            if (!isNaN(value)) {
                                return new Intl.NumberFormat('en-US').format(value);
                            }
                            return params.value;
                        }
                    })
                    // console.log(`Index: ${index}, Name: ${key}, Value: ${obj[key]}`);
                });
                columnFcstTrendDefs.value.unshift({
                    headerName: 'No',
                    valueGetter: (params) => params.node.rowIndex + 1,
                    width: 80
                })
            }
            if (index > 1) {
                // set data cho grid
                dataFcstTrend[index]['key'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];
                rowDataFcstTrend.value.push(dataFcstTrend[index]);

                // gán value cho combobox customer
                const itemCust = {
                    name: row['Column2'],
                    code: row['Column2'],
                };

                // Kiểm tra nếu newItem chưa tồn tại trong lstCust thì thêm vào
                if (!_.some(lstCust.value, itemCust)) {
                    lstCust.value.push(itemCust);
                }

                var itemGroup = {};
                itemGroup['name'] = row['Column5'] + "_" + row['Column6'];
                itemGroup['code'] = row['Column2'] + "_" + row['Column5'] + "_" + row['Column6'];

                delete row["Column2"];
                delete row["Column3"];
                delete row["Column4"];
                delete row["Column5"];
                delete row["Column6"];
                delete row["Column7"];


                itemGroup['lineWidth'] = 2;
                itemGroup['showInNavigator'] = true;
                itemGroup['data'] = Object.entries(row).map(item => [moment(`${dataFcstTrend[1][item[0]]} ${dataFcstTrend[0][item[0]]}`, "MMM YYYY").startOf("month").valueOf(), item[1] !== null ? Number(item[1]) : null]);
                itemGroup['color'] = border.value[index];
                // Lấy timestamp đầu tiên và cuối cùng
                const firstTimestamp = itemGroup['data'][0][0];
                const lastTimestamp = itemGroup['data'][itemGroup['data'].length - 1][0];

                itemGroup['data'].unshift([moment(firstTimestamp).subtract(15, "day").valueOf(), null]);
                itemGroup['data'].push([moment(lastTimestamp).add(15, "day").valueOf(), null]);

                lstGroup.value.push(itemGroup);
            }
        }

        lstCustSelected.value = [lstCust.value[0]];

        const itemsToAdd = lstGroup.value.filter(
            (item) => item.code.startsWith(lstCust.value[0].code)
        );
        lstGroupSelected.value = itemsToAdd;

        const itemsToAddGrid = rowDataFcstTrend.value.filter(
            (item) => item['Column2'].startsWith(lstCust.value[0].code)
        );

        rowDataFcstTrendFilter.value = itemsToAddGrid;
    }
}

onMounted(() => {
    // loadExcelDataNew();
    GetDataFcstTrend();
});
</script>
<template>
    <div v-if="isLoading" class="flex flex-wrap">
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="10vh" class="mb-2"></Skeleton>
        <Skeleton width="100vw" height="50vh" class="mb-2"></Skeleton>
    </div>
    <div v-else class="grid grid-cols-12 gap-4">
        <div class="col-span-12 lg:col-span-6 xl:col-span-6">
            <div class="col-span-12 lg:col-span-12 xl:col-span-12">
                <div class="card mb-0 flex flex-col gap-2">
                    <div class="font-semibold text-3xl mb-4">FCST Trend (220)</div>
                    <div class="flex flex-row w-full gap-2">
                        <FloatLabel class="flex-[4]">
                            <MultiSelect id="on_label" v-model="lstCustSelected" :options="lstCust"
                                :maxSelectedLabels="2" display="chip" optionLabel="name" :filter="true" showClear
                                class="w-full" />
                            <label for="on_label">Select Customers Code</label>
                        </FloatLabel>
                        <FloatLabel class="flex-[6]">
                            <MultiSelect id="on_label" v-model="lstGroupSelected" :options="lstGroupFilter"
                                :maxSelectedLabels="2" display="chip" optionLabel="name" :filter="true" showClear
                                class="w-full" />
                            <label for="on_label">Select Groups</label>
                        </FloatLabel>
                    </div>
                    <highcharts :options="chartOptionsLine" ref="chartLine" style="height: 62vh;"></highcharts>
                </div>
            </div>
            <div class="col-span-12 lg:col-span-12 xl:col-span-12">
                <Accordion value="1" style="background-color: #fff;">
                    <AccordionPanel value="0">
                        <AccordionHeader>
                            <p class="text-xl">Details Data</p>
                        </AccordionHeader>
                        <AccordionContent>
                            <div style="width: 100%; height: 100%" class="mt-2">
                                <!-- Đăng ký và sử dụng ag-grid -->
                                <ag-grid-vue class="ag-theme-alpine" style="width: 100%; height: 230px"
                                    :rowData="rowDataFcstTrendFilter" :columnDefs="columnFcstTrendDefs"
                                    :defaultColDef="defaultColDef" />
                            </div>
                        </AccordionContent>
                    </AccordionPanel>
                </Accordion>

            </div>
        </div>
        <div class="col-span-12 lg:col-span-6 xl:col-span-6">
            <div class="col-span-12 lg:col-span-12 xl:col-span-12">
                <div class="card mb-0 flex flex-col gap-2">
                    <div class="font-semibold text-3xl mb-4">Month Volume</div>
                    <div class="flex flex-row w-full gap-2">
                        <FloatLabel class="flex-[4]">
                            <MultiSelect id="on_label" v-model="lstVolCustSelected" :options="lstVolCust"
                                :maxSelectedLabels="2" display="chip" optionLabel="name" :filter="true" showClear
                                class="w-full" />
                            <label for="on_label">Select Customers Code (Volume):</label>
                        </FloatLabel>
                        <FloatLabel class="flex-[6]">
                            <MultiSelect id="on_label" v-model="lstVolGroupSelected" :options="lstVolGroupFilter"
                                :maxSelectedLabels="2" display="chip" optionLabel="name" :filter="true" showClear
                                class="w-full" />
                            <label for="on_label">Select Groups (Volume):</label>
                        </FloatLabel>
                    </div>
                    <highcharts :options="chartOptionsCol" ref="chartCol" style="height: 62vh;"></highcharts>
                </div>
            </div>
            <div class="col-span-12 lg:col-span-12 xl:col-span-12">
                <Accordion value="1" style="background-color: #fff;">
                    <AccordionPanel value="0">
                        <AccordionHeader>
                            <p class="text-xl">Details Data</p>
                        </AccordionHeader>
                        <AccordionContent>
                            <div style="width: 100%; height: 100%" class="mt-2">
                                <!-- Đăng ký và sử dụng ag-grid -->
                                <ag-grid-vue class="ag-theme-alpine" style="width: 100%; height: 230px"
                                    :rowData="rowDataFcstVolFilter" :columnDefs="columnFcstVolDefs"
                                    :defaultColDef="defaultColDef" />
                            </div>
                        </AccordionContent>
                    </AccordionPanel>
                </Accordion>

            </div>
        </div>

    </div>
</template>

<style>
.highcharts-button-box {
    fill: var(--surface-card) !important;
    /* Màu chữ */
}

.highcharts-credits {
    display: none;
}

.card {
    padding: 1.5rem;
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
