<script setup>
import { useLayout } from "@/layout/composables/layout";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import { ref } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";

const { isDarkTheme } = useLayout();

// Khai báo props nhận từ component cha
const props = defineProps({
    message: "", // Prop truyền từ cha
});

const localval = ref("Hello");
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

const authStore = useAuthStore();
const username = ref("");
const password = ref("");

const login = () => {
    // Giả lập login thành công
    authStore.login({ name: username.value }, "fake-jwt-token");
};
const logout = () => {
    // Giả lập login thành công
    authStore.Logout();
};

// Dữ liệu cho bảng
const columnDefs = [
    { field: "make", sortable: true, filter: true },
    { field: "model", sortable: true, filter: true },
    { field: "price", sortable: true, filter: true },
];

const rowData = [
    { make: "Toyota", model: "Celica", price: 35000 },
    { make: "Ford", model: "Mondeo", price: 32000 },
    { make: "Porsche", model: "Boxster", price: 72000 },
];

// Cấu hình mặc định cho các cột
const defaultColDef = {
    resizable: true,
    sortable: true,
    filter: true,
};

// Tùy chọn cấu hình biểu đồ
const chartOptions = ref({
    chart: {
        type: "column", // Kiểu biểu đồ (cột)
    },
    title: {
        text: "Biểu đồ cột", // Tiêu đề
    },
    xAxis: {
        categories: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4"], // Nhãn trục X
    },
    yAxis: {
        title: {
            text: "Giá trị", // Tiêu đề trục Y
        },
    },
    plotOptions: {
        series: {
            point: {
                events: {
                    click() {
                        if (this.timer) {
                            clearTimeout(this.timer);
                            this.timer = null;
                            alert(`Double-click vào cột "${this.category}" với giá trị: ${this.y}`);
                            handleChartColumnDoubleClick(this);
                            console.log("Double-click", this);
                        } else {
                            this.timer = setTimeout(() => {
                                this.timer = null;
                                alert(`Single-click vào cột "${this.category}" với giá trị: ${this.y}`);
                                handleChartColumnClick(this);
                                console.log("Single-click", this);
                            }, 300);
                        }
                    },
                    dblclick(event) {
                        // Hàm xử lý double-click vào cột
                        alert(
                            `Bạn đã double-click vào cột "${this.category}" với giá trị: ${this.y}`
                        );
                        console.log("Chi tiết sự kiện:", event);
                        // handleChartColumnDoubleClick(this);
                    },
                },
            },
        },
    },
    series: [
        {
            name: "Doanh thu",
            data: [100, 200, 150, 300, 500], // Dữ liệu biểu đồ
        },
    ],
});

const chartOptionsStock = {
    series: [
        {
            data: [1, 2, 3],
        },
    ],
};

const chart3D = ref({
    chart: {
        type: 'pie',
        options3d: {
            enabled: true,
            alpha: 50,
            beta: 0
        },


    },
    title: {
        text: 'Beijing 2022 gold medals by country',
    },
    subtitle: {
        text: '3D donut in Highcharts'
    },
    plotOptions: {
        pie: {
            innerSize: 50,
            depth: 45
        }
    },
    series: [{
        name: 'Medals',
        data: [
            ['Norway', 16],
            ['Germany', 12],
            ['USA', 8],
            ['Sweden', 8],
            ['Netherlands', 8],
            ['ROC', 6],
            ['Austria', 7],
            ['Canada', 4],
            ['Japan', 3]

        ]
    }]
}
);

const treegraph = ref({
    chart: {
        inverted: true,
        marginBottom: 170
    },
    title: {
        text: 'Inverted treegraph',
        align: 'left'
    },
    series: [
        {
            type: 'treegraph',
            data: [
                {
                    id: '0.0',
                    parent: '',
                    name: 'The World'
                },
                {
                    id: '1.3',
                    parent: '0.0',
                    name: 'Asia'
                },
                {
                    id: '1.1',
                    parent: '0.0',
                    name: 'Africa'
                },
                {
                    id: '1.2',
                    parent: '0.0',
                    name: 'America'
                },
                {
                    id: '1.4',
                    parent: '0.0',
                    name: 'Europe'
                },
                {
                    id: '1.5',
                    parent: '0.0',
                    name: 'Oceanic'
                },

                /* Africa */
                {
                    id: '2.1',
                    parent: '1.1',
                    name: 'Eastern Africa'
                },

                {
                    id: '2.5',
                    parent: '1.1',
                    name: 'Western Africa'
                },

                {
                    id: '2.3',
                    parent: '1.1',
                    name: 'North Africa'
                },

                {
                    id: '2.2',
                    parent: '1.1',
                    name: 'Central Africa'
                },

                {
                    id: '2.4',
                    parent: '1.1',
                    name: 'South America'
                },

                /* America */
                {
                    id: '2.9',
                    parent: '1.2',
                    name: 'South America'
                },

                {
                    id: '2.8',
                    parent: '1.2',
                    name: 'Northern America'
                },

                {
                    id: '2.7',
                    parent: '1.2',
                    name: 'Central America'
                },

                {
                    id: '2.6',
                    parent: '1.2',
                    name: 'Caribbean'
                },

                /* Asia */
                {
                    id: '2.13',
                    parent: '1.3',
                    name: 'Southern Asia'
                },

                {
                    id: '2.11',
                    parent: '1.3',
                    name: 'Eastern Asia'
                },

                {
                    id: '2.12',
                    parent: '1.3',
                    name: 'South-Eastern Asia'
                },

                {
                    id: '2.14',
                    parent: '1.3',
                    name: 'Western Asia'
                },

                {
                    id: '2.10',
                    parent: '1.3',
                    name: 'Central Asia'
                },

                /* Europe */
                {
                    id: '2.15',
                    parent: '1.4',
                    name: 'Eastern Europe'
                },

                {
                    id: '2.16',
                    parent: '1.4',
                    name: 'Northern Europe'
                },

                {
                    id: '2.17',
                    parent: '1.4',
                    name: 'Southern Europe'
                },

                {
                    id: '2.18',
                    parent: '1.4',
                    name: 'Western Europe'
                },
                /* Oceania */
                {
                    id: '2.19',
                    parent: '1.5',
                    name: 'Australia and New Zealand'
                },

                {
                    id: '2.20',
                    parent: '1.5',
                    name: 'Melanesia'
                },

                {
                    id: '2.21',
                    parent: '1.5',
                    name: 'Micronesia'
                },

                {
                    id: '2.22',
                    parent: '1.5',
                    name: 'Polynesia'
                }
            ],
            tooltip: {
                pointFormat: '{point.name}'
            },
            dataLabels: {
                pointFormat: '{point.name}',
                style: {
                    whiteSpace: 'nowrap',
                    color: '#000000',
                    textOutline: '3px contrast'
                },
                crop: false
            },
            marker: {
                radius: 6
            },
            levels: [
                {
                    level: 1,
                    dataLabels: {
                        align: 'left',
                        x: 20
                    }
                },
                {
                    level: 2,
                    colorByPoint: true,
                    dataLabels: {
                        verticalAlign: 'bottom',
                        y: -20
                    }
                },
                {
                    level: 3,
                    colorVariation: {
                        key: 'brightness',
                        to: -0.5
                    },
                    dataLabels: {
                        verticalAlign: 'top',
                        rotation: 90,
                        y: 20
                    }
                }
            ]
        }
    ]
});

const networkGrap = ref({
    chart: {
        type: 'networkgraph',
        plotBorderWidth: 1
    },
    title: {
        text: 'Network Graph Example'
    },
    plotOptions: {
        networkgraph: {
            keys: ['from', 'to']
        }
    },
    series: [{
        data: [
            ['A', 'B'],
            ['A', 'C'],
            ['B', 'D'],
            ['C', 'D'],
            ['C', 'E'],
            ['D', 'E']
        ],
        dataLabels: {
            enabled: true,
            format: '{point.name}'
        }
    }]
});

// Cấu hình biểu đồ gauge
const gaugeOptions = {
    chart: {
        type: "gauge",
        //backgroundColor:  "transparent", // Đặt nền trong suốt
        backgroundColor: 'var(--surface-card)',     // màu cho nền phía sau
        plotBackgroundColor: null,                  // màu nền cho chart
        plotBackgroundImage: null,                  // đặt hình nền cho background
        plotBorderWidth: 0,
        plotShadow: false,
        height: "100%",
    },

    title: {
        text: "Speedometer",
        style: {
            color: 'var(--primary-color)',
        }
    },

    pane: {
        startAngle: -90,
        endAngle: 89.9,
        background: null,
        center: ["50%", "75%"],
        size: "90%",
    },

    // the value axis
    yAxis: {
        min: 0,
        max: 200,
        tickPixelInterval: 72,
        tickPosition: "inside",
        tickColor: "#FFFFFF",
        tickLength: 20,
        tickWidth: 2,
        minorTickInterval: null,
        labels: {
            distance: 20,
            style: {
                fontSize: "14px",
                color: 'var(--text-color)',
            },
        },
        lineWidth: 0,
        plotBands: [
            {
                from: 0,
                to: 130,
                color: "#55BF3B", // green
                thickness: 20,
                borderRadius: "50%",
            },
            {
                from: 150,
                to: 200,
                color: "#DF5353", // red
                thickness: 20,
                borderRadius: "50%",
            },
            {
                from: 120,
                to: 160,
                color: "#DDDF0D", // yellow
                thickness: 20,
            },
        ],
    },

    series: [
        {
            name: "Speed",
            data: [80],
            tooltip: {
                valueSuffix: " km/h",
            },
            dataLabels: {
                format: "{y} km/h",
                borderWidth: 0,
                style: {
                    fontSize: "16px",
                    color: 'var(--primary-color)',
                    textOutline: 'none'
                },
            },
            dial: {
                radius: "80%",
                backgroundColor: "gray",
                baseWidth: 12,
                baseLength: "0%",
                rearLength: "0%",
            },
            pivot: {
                backgroundColor: "gray",
                radius: 6,
            },
        },
    ],
};

const ganttChart = {
    title: {
        text: "Gantt Chart with Progress Indicators",
    },
    xAxis: {
        min: Date.UTC(2014, 10, 17),
        max: Date.UTC(2014, 10, 30),
    },

    series: [
        {
            name: "Project 1",
            data: [
                {
                    name: "Start prototype",
                    start: Date.UTC(2014, 10, 18),
                    end: Date.UTC(2014, 10, 25),
                    completed: 0.25,
                },
                {
                    name: "Test prototype",
                    start: Date.UTC(2014, 10, 27),
                    end: Date.UTC(2014, 10, 29),
                },
                {
                    name: "Develop",
                    start: Date.UTC(2014, 10, 20),
                    end: Date.UTC(2014, 10, 25),
                    completed: {
                        amount: 0.12,
                        fill: "#fa0",
                    },
                },
                {
                    name: "Run acceptance tests",
                    start: Date.UTC(2014, 10, 23),
                    end: Date.UTC(2014, 10, 26),
                },
            ],
        },
    ],
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

    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <h2>Login</h2>
            <InputText v-model="username" placeholder="Username" />
            <InputText v-model="password" type="password" placeholder="Password" />
            <Button @click="login">Login</button>
            <Button @click="logout">Logout</button>
            <p v-if="authStore.isAuthenticated">User: {{ authStore.user?.name }}</p>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <h3>Child Component</h3>
            <p>Message từ cha: {{ message }}</p>
            <Button type="button" @click="emitToParent(false)" :icon="isDarkTheme ? 'pi pi-moon' : 'pi pi-sun'"
                severity="primary" />
            <Button type="button" @click="emitToParent(true)" :icon="isDarkTheme ? 'pi pi-moon' : 'pi pi-sun'"
                label="clear" class="ml-2 mb-2" severity="primary" />
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <h3>Sử dụng chuỗi dịch</h3>
            <h1>{{ $t("greeting") }}</h1>
            <FloatLabel variant="in">
                <InputText id="username" v-model="localval" />
                <label for="username">Username</label>
            </FloatLabel>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <h3>Sử dụng font-awesome</h3>
            <font-awesome-icon icon="home" />
            <font-awesome-icon icon="user" />
            <font-awesome-icon :icon="['fab', 'facebook']" />
            <font-awesome-icon :icon="['fab', 'twitter']" />
            <font-awesome-icon :icon="['fab', 'tiktok']" />
            <font-awesome-icon icon="fa-solid fa-magnifying-glass" size="lg"
                :style="{ color: 'var(--primary-color)' }" />
        </div>
    </div>

    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <div class="flex justify-between mb-4">
                <div>
                    <span class="block text-muted-color font-medium mb-4">Orders</span>
                    <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">152</div>
                </div>
                <div class="flex items-center justify-center bg-blue-100 dark:bg-blue-400/10 rounded-border"
                    style="width: 2.5rem; height: 2.5rem">
                    <i class="pi pi-shopping-cart text-blue-500 !text-xl"></i>
                </div>
            </div>
            <span class="text-primary font-medium">24 new </span>
            <span class="text-muted-color">since last visit</span>
        </div>
    </div>

    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <div class="flex justify-between mb-4">
                <div>
                    <span class="block text-muted-color font-medium mb-4">Revenue</span>
                    <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">$2.100</div>
                </div>
                <div class="flex items-center justify-center bg-orange-100 dark:bg-orange-400/10 rounded-border"
                    style="width: 2.5rem; height: 2.5rem">
                    <i class="pi pi-dollar text-orange-500 !text-xl"></i>
                </div>
            </div>
            <span class="text-primary font-medium">%52+ </span>
            <span class="text-muted-color">since last week</span>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <div class="flex justify-between mb-4">
                <div>
                    <span class="block text-muted-color font-medium mb-4">Customers</span>
                    <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">28441</div>
                </div>
                <div class="flex items-center justify-center bg-cyan-100 dark:bg-cyan-400/10 rounded-border"
                    style="width: 2.5rem; height: 2.5rem">
                    <i class="pi pi-users text-cyan-500 !text-xl"></i>
                </div>
            </div>
            <span class="text-primary font-medium">520 </span>
            <span class="text-muted-color">newly registered</span>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <div class="flex justify-between mb-4">
                <div>
                    <span class="block text-muted-color font-medium mb-4">Comments</span>
                    <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">152 Unread</div>
                </div>
                <div class="flex items-center justify-center bg-purple-100 dark:bg-purple-400/10 rounded-border"
                    style="width: 2.5rem; height: 2.5rem">
                    <i class="pi pi-comment text-purple-500 !text-xl"></i>
                </div>
            </div>
            <span class="text-primary font-medium">85 </span>
            <span class="text-muted-color">responded</span>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <highcharts :options="chartOptions" ref="chartCol"></highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <highcharts :constructor-type="'stockChart'" :options="chartOptionsStock"></highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-6">
        <div class="card mb-0">
            <highcharts :constructorType="'ganttChart'" :options="ganttChart" ref="chart"></highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <highcharts :options="gaugeOptions"></highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-3">
        <div class="card mb-0">
            <highcharts :options="chart3D" style="height: 300px;"></highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-6">
        <div class="card mb-0">
            <highcharts :options="treegraph" style="height: 300px;"></highcharts>
        </div>
    </div>
    <div class="col-span-12 lg:col-span-6 xl:col-span-6">
        <div class="card mb-0">
            <highcharts :options="networkGrap" style="height: 300px;"></highcharts>
        </div>
    </div>


    <div class="col-span-12 lg:col-span-6 xl:col-span-6">
        <div style="width: 100%; height: 100%" class="mt-2">
            <!-- Đăng ký và sử dụng ag-grid -->
            <ag-grid-vue class="ag-theme-alpine" style="width: 100%; height: 250px" :rowData="rowData"
                :columnDefs="columnDefs" :defaultColDef="defaultColDef" />
        </div>
    </div>

</template>

<style>
.highcharts-button-box {
    fill: var(--surface-card) !important;
    /* Màu chữ */
}
</style>
