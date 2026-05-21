<script setup>
import { inject, onMounted, computed, ref, watch } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import { apiService } from "@/modules/core/services/BaseService";
import { useAuthStore } from "@/modules/core/stores/useAuthStore";
import _ from "lodash";
import moment from "moment";
import * as XLSX from "xlsx";
import CpnChartColumn from '@/modules/oldSource/components/ChartBase/ChartColumn.vue';
import CpnChartPie from '@/modules/oldSource/components/ChartBase/ChartPie.vue';
import varialbe from "@/utils/variable";
import { pull } from "lodash";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();

const isLoading = ref(false);
const currentTime = ref('');
const activeStep = ref(0);
const selectedFactory = ref('');
const selectedArea = ref('');
const selectedCheckpoint = ref(null);
const selectedCheckpointInfo = ref('');
const employeeCode = ref('');
const issueDescription = ref('');
const isDrawing = ref(false);



const stepItems = ref([
    { label: 'Chọn khu vực kiểm tra' },
    { label: 'Thực hiện checklist' },
    { label: 'Xác nhận &amp; gửi' }
]);

const factories = ref([
    { id: 'factory-a', name: 'Nhà máy A - Cơ khí' },
    { id: 'factory-b', name: 'Nhà máy B - Điện tử' },
    { id: 'factory-c', name: 'Nhà máy C - Hóa chất' }
]);

const areas = ref([]);
const checkpoints = ref([]);

const receivingItems = ref([
    { id: 1, stt: 1, content: 'Bao bì vật tư còn nguyên vẹn, không bị rách hoặc hư hỏng', status: null, note: '' },
    { id: 2, stt: 2, content: 'Tem nhãn đầy đủ, rõ ràng (tên sản phẩm, mã, ngày sản xuất, hạn sử dụng)', status: null, note: '' },
    { id: 3, stt: 3, content: 'Số lượng thực tế khớp với phiếu giao hàng', status: null, note: '' },
    { id: 4, stt: 4, content: 'Vật tư được đặt đúng khu vực tiếp nhận', status: null, note: '' },
    { id: 5, stt: 5, content: 'Không có dấu hiệu ẩm mốc, hư hỏng do vận chuyển', status: null, note: '' }
]);

const inventoryItems = ref([
    { id: 6, stt: 6, content: 'Vật tư được lưu đúng sơ đồ kho, đúng vị trí quy định', status: null, note: '' },
    { id: 7, stt: 7, content: 'FIFO/LIFO đang được tuân thủ đúng quy trình', status: null, note: '' },
    { id: 8, stt: 8, content: 'Kệ/pallet không quá tải, đảm bảo an toàn', status: null, note: '' },
    { id: 9, stt: 9, content: 'Không có vật tư lẫn lộn giữa các loại khác nhau', status: null, note: '' },
    { id: 10, stt: 10, content: 'Khu vực lưu trữ sạch sẽ, không có rác thải', status: null, note: '' }
]);

const transportationItems = ref([
    { id: 11, stt: 11, content: 'Kệ/xe đẩy không cản trở lối đi, lối thoát hiểm', status: null, note: '' },
    { id: 12, stt: 12, content: 'Thiết bị vận chuyển (xe nâng, xe đẩy) hoạt động bình thường', status: null, note: '' },
    { id: 13, stt: 13, content: 'Bãi tập kết không lẫn vật tư khác loại', status: null, note: '' },
    { id: 14, stt: 14, content: 'Nhân viên đeo đầy đủ thiết bị bảo hộ khi xử lý vật liệu', status: null, note: '' },
    { id: 15, stt: 15, content: 'Khu vực vận chuyển có đủ ánh sáng và thông thoáng', status: null, note: '' }
]);

// Computed properties
const allItems = computed(() => {
    return [...receivingItems.value, ...inventoryItems.value, ...transportationItems.value];
});

const totalItems = computed(() => allItems.value.length);

const completedItems = computed(() => {
    return allItems.value.filter(item => item.status).length;
});

const completionPercentage = computed(() => {
    return totalItems.value > 0 ? Math.round((completedItems.value / totalItems.value) * 100) : 0;
});

const okCount = computed(() => {
    return allItems.value.filter(item => item.status === 'OK').length;
});

const nokCount = computed(() => {
    return allItems.value.filter(item => item.status === 'NOK').length;
});

const naCount = computed(() => {
    return allItems.value.filter(item => item.status === 'NA').length;
});

const isChecklistComplete = computed(() => {
    return completedItems.value === totalItems.value;
});

// Methods
const updateClock = () => {
    const now = new Date();
    currentTime.value = now.toLocaleString('vi-VN', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
    });
};



const loadAreas = () => {
    const areaData = {
        'factory-a': [
            { id: 'warehouse-a1', name: 'Kho A1 - Nguyên liệu' },
            { id: 'line-a1', name: 'Line A1 - Gia công' }
        ],
        'factory-b': [
            { id: 'warehouse-b1', name: 'Kho B1 - Linh kiện' }
        ],
        'factory-c': [
            { id: 'warehouse-c1', name: 'Kho C1 - Hóa chất' }
        ]
    };

    areas.value = areaData[selectedFactory.value] || [];
    selectedArea.value = '';
    checkpoints.value = [];
};

const loadCheckpoints = () => {
    const checkpointData = {
        'warehouse-a1': [
            { id: 'WH-A1-01', name: 'Khu nhận hàng A1', type: 'Receiving Area', priority: 'high', lastCheck: '2024-02-28' },
            { id: 'WH-A1-02', name: 'Kệ lưu trữ A1-01', type: 'Storage Rack', priority: 'medium', lastCheck: '2024-03-01' },
            { id: 'WH-A1-03', name: 'Kệ lưu trữ A1-02', type: 'Storage Rack', priority: 'medium', lastCheck: '2024-03-01' },
            { id: 'WH-A1-04', name: 'Bãi tập kết A1', type: 'Staging Area', priority: 'high', lastCheck: '2024-02-29' }
        ],
        'line-a1': [
            { id: 'LN-A1-01', name: 'Khu cấp liệu Line A1', type: 'Material Feed', priority: 'high', lastCheck: '2024-03-01' },
            { id: 'LN-A1-02', name: 'Kệ WIP Line A1', type: 'WIP Storage', priority: 'medium', lastCheck: '2024-03-01' },
            { id: 'LN-A1-03', name: 'Khu thành phẩm Line A1', type: 'Finished Goods', priority: 'low', lastCheck: '2024-03-02' }
        ],
        'warehouse-b1': [
            { id: 'WH-B1-01', name: 'Khu nhận linh kiện B1', type: 'Component Area', priority: 'high', lastCheck: '2024-03-01' }
        ],
        'warehouse-c1': [
            { id: 'WH-C1-01', name: 'Khu hóa chất nguy hiểm', type: 'Hazardous Storage', priority: 'high', lastCheck: '2024-02-27' }
        ]
    };

    checkpoints.value = checkpointData[selectedArea.value] || [];
};

const getPriorityText = (priority) => {
    const texts = {
        'high': 'Cao',
        'medium': 'Trung bình',
        'low': 'Thấp'
    };
    return texts[priority] || 'Chưa xác định';
};

const getPrioritySeverity = (priority) => {
    const severities = {
        'high': 'danger',
        'medium': 'warning',
        'low': 'success'
    };
    return severities[priority] || 'info';
};

const selectCheckpoint = (checkpoint) => {
    selectedCheckpoint.value = checkpoint;
    selectedCheckpointInfo.value = `${checkpoint.id} - ${checkpoint.name}`;
    nextStep();
};

const setStatus = (itemId, status) => {
    const item = allItems.value.find(item => item.id === itemId);
    if (item) {
        item.status = status;
        if (status !== 'NOK') {
            item.note = '';
        }
    }
};

const captureImage = (itemId) => {
    alert('Ảnh đã được chụp và lưu cho mục #' + itemId);
};

const nextStep = () => {
    if (activeStep.value < stepItems.value.length - 1) {
        activeStep.value++;
    }
};

const previousStep = () => {
    if (activeStep.value > 0) {
        activeStep.value--;
    }
};

const saveDraft = () => {
    alert('Kết quả checklist đã được lưu tạm!');
};

const submitChecklist = () => {
    if (!employeeCode.value.trim()) {
        alert('Vui lòng nhập mã nhân viên!');
        return;
    }

    if (nokCount.value > 0 && !issueDescription.value.trim()) {
        alert('Vui lòng mô tả chi tiết các vấn đề phát hiện!');
        return;
    }

    activeStep.value = 3;
};

const startNewInspection = () => {
    // Reset all data
    activeStep.value = 0;
    selectedFactory.value = '';
    selectedArea.value = '';
    selectedCheckpoint.value = null;
    selectedCheckpointInfo.value = '';
    employeeCode.value = '';
    issueDescription.value = '';
    areas.value = [];
    checkpoints.value = [];

    // Reset all checklist items
    allItems.value.forEach(item => {
        item.status = null;
        item.note = '';
    });

    clearSignature();
};

// Signature pad methods
const startDrawing = (e) => {
    isDrawing.value = true;
    // Drawing logic here
};

const draw = (e) => {
    if (!isDrawing.value) return;
    // Drawing logic here
};

const stopDrawing = () => {
    isDrawing.value = false;
};

const clearSignature = () => {
    // Clear signature logic here
};

// Lifecycle
onMounted(() => {
    updateClock();
    setInterval(updateClock, 1000);
});

</script>
<template>
    <div class="col-span-12 lg:col-span-12 xl:col-span-12 my-2">

        <!-- Steps Progress -->
        <div class="steps-container">
            <steps :model="stepItems" :readonly="false" :activestep="activeStep">
            </steps>
        </div>

        <!-- Step 1: Area Selection -->
        <card v-if="activeStep === 0">
            <template #title="">
                <i class="pi pi-map-marker mr-2"></i>
                Bước 1: Chọn khu vực kiểm tra vật liệu
            </template>
            <template #content="">
                <div class="grid grid-cols-12">
                    <div class="col-span-12 md:col-span-6">
                        <div class="field">
                            <label for="factory">Nhà máy</label>
                            <Select id="factory" v-model="selectedFactory" :options="factories" optionLabel="name"
                                optionValue="id" placeholder="Chọn nhà máy..." class="w-full" @change="loadAreas" />
                        </div>
                    </div>

                    <div class="col-span-12 md:col-span-6">
                        <div class="field">
                            <label for="area">Khu vực / Line sản xuất</label>
                            <Select id="area" v-model="selectedArea" :options="areas" optionLabel="name"
                                optionValue="id" placeholder="Chọn khu vực..." :disabled="!selectedFactory"
                                class="w-full" @change="loadCheckpoints">
                            </Select>
                        </div>
                    </div>
                </div>

                <div v-if="checkpoints.length > 0">
                    <h4 class="mb-3 text-900 font-semibold">
                        <i class="pi pi-map-marker mr-2"></i>
                        Điểm kiểm tra vật liệu
                    </h4>

                    <div class="checkpoint-grid">
                        <div v-for="checkpoint in checkpoints" :key="checkpoint.id" class="checkpoint-card"
                            :class="`priority-${checkpoint.priority}`" @click="selectCheckpoint(checkpoint)">
                            <div class="checkpoint-header">
                                <div class="checkpoint-id">{{ checkpoint.id }}</div>
                                <tag :value="getPriorityText(checkpoint.priority)"
                                    :severity="getPrioritySeverity(checkpoint.priority)">
                                </tag>
                            </div>
                            <div class="mb-3 font-medium">{{ checkpoint.name }}</div>
                            <div class="text-sm text-600 mb-3">
                                <div>Loại: {{ checkpoint.type }}</div>
                                <div>Kiểm tra cuối: {{ checkpoint.lastCheck }}</div>
                            </div>
                            <button label="Bắt đầu kiểm tra" icon="pi pi-play" class="w-full">
                            </button>
                        </div>
                    </div>
                </div>
            </template>
        </card>

        <!-- Step 2: Checklist Execution -->
        <div v-if="activeStep === 1">
            <div class="progress-section">
                <div class="progress-header">
                    <div>
                        <h3 class="text-xl font-semibold text-900 mb-2">Bước 2: Thực hiện checklist xử lý vật
                            liệu</h3>
                        <div class="text-sm text-600">
                            <span>Điểm kiểm tra: {{ selectedCheckpointInfo }}</span> |
                            <span>Người thực hiện: Trần Văn K</span> |
                            <span>Thời gian: {{ currentTime }}</span>
                        </div>
                    </div>
                    <div class="progress-stats">{{ completedItems }}/{{ totalItems }} ({{ completionPercentage
                    }}%)</div>
                </div>
                <progressbar :value="completionPercentage">
                </progressbar>
            </div>

            <!-- Receiving & Storage Group -->
            <panel header="🚚 Nhận hàng &amp; Lưu kho" class="mb-4">
                <DataTable :value="receivingItems" responsivelayout="scroll">
                    <column field="stt" header="STT" style="width: 60px"></column>
                    <column field="content" header="Nội dung kiểm tra"></column>
                    <column header="Trạng thái" style="width: 250px">
                        <template #body="slotProps">
                            <div class="status-buttons">
                                <Button label="OK" size="small"
                                    :class="{ 'p-button-success': slotProps.data.status === 'OK' }"
                                    :outlined="slotProps.data.status !== 'OK'"
                                    @click="setStatus(slotProps.data.id, 'OK')" />
                                <Button label="NOK" size="small"
                                    :class="{ 'p-button-danger': slotProps.data.status === 'NOK' }"
                                    :outlined="slotProps.data.status !== 'NOK'"
                                    @click="setStatus(slotProps.data.id, 'NOK')" />
                                <Button label="N/A" size="small"
                                    :class="{ 'p-button-secondary': slotProps.data.status === 'NA' }"
                                    :outlined="slotProps.data.status !== 'NA'"
                                    @click="setStatus(slotProps.data.id, 'NA')" />
                            </div>
                        </template>
                    </column>
                    <column header="Ghi chú" style="width: 200px">
                        <template #body="slotProps">
                            <textarea v-if="slotProps.data.status === 'NOK'" v-model="slotProps.data.note" rows="2"
                                placeholder="Ghi chú..." class="w-full"></textarea>
                        </template>
                    </column>
                    <Column header="Ảnh" style="width: 80px">
                        <template #body="slotProps">
                            <Button icon="pi pi-camera" size="small" outlined
                                @click="captureImage(slotProps.data.id)" />
                        </template>
                    </Column>
                </DataTable>
            </Panel>

            <!-- Inventory Management Group -->
            <Panel header="📦 Quản lý tồn kho" class="mb-4">
                <DataTable :value="inventoryItems" responsiveLayout="scroll">
                    <Column field="stt" header="STT" style="width: 60px"></Column>
                    <Column field="content" header="Nội dung kiểm tra"></Column>
                    <Column header="Trạng thái" style="width: 250px">
                        <template #body="slotProps">
                            <div class="status-buttons">
                                <Button label="OK" size="small"
                                    :class="{ 'p-button-success': slotProps.data.status === 'OK' }"
                                    :outlined="slotProps.data.status !== 'OK'"
                                    @click="setStatus(slotProps.data.id, 'OK')" />
                                <Button label="NOK" size="small"
                                    :class="{ 'p-button-danger': slotProps.data.status === 'NOK' }"
                                    :outlined="slotProps.data.status !== 'NOK'"
                                    @click="setStatus(slotProps.data.id, 'NOK')" />
                                <Button label="N/A" size="small"
                                    :class="{ 'p-button-secondary': slotProps.data.status === 'NA' }"
                                    :outlined="slotProps.data.status !== 'NA'"
                                    @click="setStatus(slotProps.data.id, 'NA')" />
                            </div>
                        </template>
                    </Column>
                    <Column header="Ghi chú" style="width: 200px">
                        <template #body="slotProps">
                            <Textarea v-if="slotProps.data.status === 'NOK'" v-model="slotProps.data.note" rows="2"
                                placeholder="Ghi chú..." class="w-full" />
                        </template>
                    </Column>
                    <Column header="Ảnh" style="width: 80px">
                        <template #body="slotProps">
                            <Button icon="pi pi-camera" size="small" outlined
                                @click="captureImage(slotProps.data.id)" />
                        </template>
                    </Column>
                </DataTable>
            </Panel>

            <!-- Transportation &amp; Safety Group -->
            <Panel header="🚛 Vận chuyển &amp; An toàn" class="mb-4">
                <DataTable :value="transportationItems" responsiveLayout="scroll">
                    <Column field="stt" header="STT" style="width: 60px"></Column>
                    <Column field="content" header="Nội dung kiểm tra"></Column>
                    <Column header="Trạng thái" style="width: 250px">
                        <template #body="slotProps">
                            <div class="status-buttons">
                                <Button label="OK" size="small"
                                    :class="{ 'p-button-success': slotProps.data.status === 'OK' }"
                                    :outlined="slotProps.data.status !== 'OK'"
                                    @click="setStatus(slotProps.data.id, 'OK')" />
                                <Button label="NOK" size="small"
                                    :class="{ 'p-button-danger': slotProps.data.status === 'NOK' }"
                                    :outlined="slotProps.data.status !== 'NOK'"
                                    @click="setStatus(slotProps.data.id, 'NOK')" />
                                <Button label="N/A" size="small"
                                    :class="{ 'p-button-secondary': slotProps.data.status === 'NA' }"
                                    :outlined="slotProps.data.status !== 'NA'"
                                    @click="setStatus(slotProps.data.id, 'NA')" />
                            </div>
                        </template>
                    </Column>
                    <Column header="Ghi chú" style="width: 200px">
                        <template #body="slotProps">
                            <Textarea v-if="slotProps.data.status === 'NOK'" v-model="slotProps.data.note" rows="2"
                                placeholder="Ghi chú..." class="w-full" />
                        </template>
                    </Column>
                    <Column header="Ảnh" style="width: 80px">
                        <template #body="slotProps">
                            <Button icon="pi pi-camera" size="small" outlined
                                @click="captureImage(slotProps.data.id)" />
                        </template>
                    </Column>
                </DataTable>
            </Panel>

            <div class="action-buttons">
                <Button label="Quay lại" icon="pi pi-arrow-left" outlined @click="previousStep" />
                <div class="btn-group">
                    <Button label="Lưu tạm" icon="pi pi-save" severity="warning" @click="saveDraft" />
                    <Button label="Hoàn tất checklist" icon="pi pi-check" :disabled="!isChecklistComplete"
                        @click="nextStep" />
                </div>
            </div>
        </div>

        <!-- Step 3: Confirmation &amp; Submit -->
        <Card v-if="activeStep === 2">
            <template #title>
                <i class="pi pi-check-circle mr-2"></i>
                Bước 3: Xác nhận &amp; gửi kết quả
            </template>
            <template #content>
                <!-- Summary Cards -->
                <div class="summary-cards">
                    <div class="summary-card total">
                        <div class="summary-number" style="color: var(--primary-color);">{{ totalItems }}</div>
                        <div class="summary-label">Tổng số mục</div>
                    </div>
                    <div class="summary-card ok">
                        <div class="summary-number" style="color: #22c55e;">{{ okCount }}</div>
                        <div class="summary-label">OK ✅</div>
                    </div>
                    <div class="summary-card nok">
                        <div class="summary-number" style="color: #ef4444;">{{ nokCount }}</div>
                        <div class="summary-label">NOK ❌</div>
                    </div>
                    <div class="summary-card na">
                        <div class="summary-number" style="color: #64748b;">{{ naCount }}</div>
                        <div class="summary-label">N/A ➖</div>
                    </div>
                </div>

                <!-- Issues Alert -->
                <Message v-if="nokCount > 0" severity="error" class="mb-4">
                    <div class="issues-alert-header">
                        <div>
                            <div class="issues-alert-title">Phát hiện vấn đề cần xử lý</div>
                            <div class="issues-alert-desc">Có {{ nokCount }} mục NOK cần mô tả chi tiết và thông
                                báo quản lý.</div>
                        </div>
                    </div>
                    <div class="field mt-3">
                        <label for="issueDesc">Mô tả chi tiết các vấn đề:</label>
                        <Textarea id="issueDesc" v-model="issueDescription" rows="4"
                            placeholder="Mô tả chi tiết vấn đề về vật liệu, vị trí, mức độ nghiêm trọng và đề xuất xử lý..."
                            class="w-full" />
                    </div>
                </Message>

                <!-- Confirmation Section -->
                <Panel header="🔐 Xác nhận hoàn thành kiểm tra" class="mb-4">
                    <div class="grid">
                        <div class="col-12 md:col-6">
                            <div class="field">
                                <label for="empCode">Mã nhân viên</label>
                                <InputText id="empCode" v-model="employeeCode" placeholder="Nhập mã nhân viên"
                                    class="w-full" />
                            </div>
                        </div>
                        <div class="col-12 md:col-6">
                            <div class="field">
                                <label>Chữ ký điện tử</label>
                                <div
                                    style="border: 2px dashed var(--primary-color); border-radius: 8px; padding: 1rem; background: var(--surface-50);">
                                    <canvas ref="signaturePad" class="signature-pad" width="400" height="100"
                                        @mousedown="startDrawing" @mousemove="draw" @mouseup="stopDrawing"
                                        @touchstart="startDrawing" @touchmove="draw" @touchend="stopDrawing"></canvas>
                                    <div class="flex justify-content-between align-items-center mt-2">
                                        <Button label="Xóa chữ ký" icon="pi pi-trash" size="small" outlined
                                            @click="clearSignature"></Button>
                                        <small class="text-500">Vẽ chữ ký ở trên</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </Panel>

                <div class="action-buttons">
                    <Button label="Quay lại" icon="pi pi-arrow-left" outlined @click="previousStep" />
                    <Button label="Gửi kết quả checklist" icon="pi pi-send" severity="success"
                        @click="submitChecklist" />
                </div>
            </template>
        </Card>

        <!-- Success Message -->
        <Card v-if="activeStep === 3" class="text-center">
            <template #content>
                <div
                    style="width: 80px; height: 80px; background: #dcfce7; border-radius: 50%; display: flex; align-items: center; justify-content: center; margin: 0 auto 2rem;">
                    <i class="pi pi-check" style="font-size: 2rem; color: #22c55e;"></i>
                </div>
                <h3 class="text-900 mb-3">Kết quả checklist đã được gửi!</h3>
                <p class="text-600 mb-4">Kết quả kiểm tra xử lý vật liệu đã được ghi nhận và gửi đến quản lý
                    kho.</p>
                <Button label="Kiểm tra khu vực khác" icon="pi pi-plus" @click="startNewInspection"></Button>
            </template>
        </Card>
    </div>

</template>


<style scoped>
:root {
    --primary-color: #1976D2;
    --primary-color-text: #ffffff;
    --surface-0: #ffffff;
    --surface-50: #f8fafc;
    --surface-100: #f1f5f9;
    --surface-200: #e2e8f0;
    --surface-300: #cbd5e1;
    --surface-400: #94a3b8;
    --surface-500: #64748b;
    --surface-600: #475569;
    --surface-700: #334155;
    --surface-800: #1e293b;
    --surface-900: #0f172a;
}

* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: var(--surface-50);
    color: var(--surface-700);
}

.layout-wrapper {
    min-height: 100vh;
    display: flex;
    flex-direction: column;
}

.layout-topbar {
    background: var(--surface-0);
    border-bottom: 1px solid var(--surface-200);
    padding: 1rem 2rem;
    display: flex;
    align-items: center;
    justify-content: space-between;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    z-index: 1000;
    height: 70px;
}

.layout-topbar-logo {
    display: flex;
    align-items: center;
    gap: 1rem;
}

.layout-topbar-logo i {
    font-size: 2rem;
    color: var(--primary-color);
}

.layout-topbar-logo h1 {
    font-size: 1.5rem;
    font-weight: 700;
    color: var(--surface-800);
}

.layout-topbar-right {
    display: flex;
    align-items: center;
    gap: 2rem;
}

.clock {
    font-family: 'Courier New', monospace;
    font-size: 0.9rem;
    color: var(--surface-600);
}

.user-info {
    display: flex;
    align-items: center;
    gap: 0.75rem;
}

.user-avatar {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    background: var(--primary-color);
    display: flex;
    align-items: center;
    justify-content: center;
    color: white;
    font-weight: 600;
}

.layout-main {
    display: flex;
    flex: 1;
    margin-top: 70px;
}

.layout-sidebar {
    width: 280px;
    background: var(--surface-0);
    border-right: 1px solid var(--surface-200);
    box-shadow: 2px 0 4px rgba(0, 0, 0, 0.1);
    position: fixed;
    top: 70px;
    bottom: 0;
    overflow-y: auto;
    z-index: 999;
}

.sidebar-menu {
    padding: 1rem 0;
}

.menu-item {
    display: flex;
    align-items: center;
    padding: 1rem 1.5rem;
    color: var(--surface-700);
    text-decoration: none;
    transition: all 0.3s ease;
    cursor: pointer;
    border-left: 4px solid transparent;
}

.menu-item:hover {
    background: var(--surface-100);
    color: var(--primary-color);
}

.menu-item.active {
    background: rgba(25, 118, 210, 0.1);
    color: var(--primary-color);
    border-left-color: var(--primary-color);
    font-weight: 600;
}

.menu-item i {
    margin-right: 0.75rem;
    font-size: 1.1rem;
    width: 20px;
}

.layout-content {
    flex: 1;
    margin-left: 280px;
    padding: 2rem;
    min-height: calc(100vh - 70px);
}

.content-header {
    margin-bottom: 2rem;
}

.content-title {
    font-size: 1.75rem;
    font-weight: 700;
    color: var(--surface-800);
    margin-bottom: 0.5rem;
}

.content-subtitle {
    color: var(--surface-600);
    font-size: 1rem;
}

.steps-container {
    margin-bottom: 2rem;
}

.checkpoint-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
    gap: 1rem;
    margin-top: 1.5rem;
}

.checkpoint-card {
    background: var(--surface-0);
    border: 2px solid var(--surface-200);
    border-radius: 8px;
    padding: 1.5rem;
    cursor: pointer;
    transition: all 0.3s ease;
}

.checkpoint-card:hover {
    border-color: var(--primary-color);
    box-shadow: 0 4px 12px rgba(25, 118, 210, 0.15);
    transform: translateY(-2px);
}

.checkpoint-card.priority-high {
    border-left: 4px solid #ef4444;
}

.checkpoint-card.priority-medium {
    border-left: 4px solid #f59e0b;
}

.checkpoint-card.priority-low {
    border-left: 4px solid #22c55e;
}

.checkpoint-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 1rem;
}

.checkpoint-id {
    font-weight: 700;
    color: var(--surface-800);
    font-size: 1.1rem;
}

.priority-badge {
    padding: 0.25rem 0.5rem;
    border-radius: 4px;
    font-size: 0.75rem;
    font-weight: 600;
}

.priority-high .priority-badge {
    background: #fee2e2;
    color: #dc2626;
}

.priority-medium .priority-badge {
    background: #fef3c7;
    color: #d97706;
}

.priority-low .priority-badge {
    background: #dcfce7;
    color: #16a34a;
}

.checklist-group {
    margin-bottom: 2rem;
    border-left: 4px solid var(--primary-color);
    background: linear-gradient(90deg, rgba(25, 118, 210, 0.05) 0%, transparent 100%);
    border-radius: 8px;
    padding: 1.5rem;
}

.group-title {
    font-size: 1.2rem;
    font-weight: 600;
    color: var(--surface-800);
    margin-bottom: 1rem;
    display: flex;
    align-items: center;
    gap: 0.75rem;
}

.status-buttons {
    display: flex;
    gap: 0.5rem;
}

.status-btn {
    min-width: 70px;
    min-height: 44px;
    border: 2px solid transparent;
    border-radius: 6px;
    font-weight: 600;
    cursor: pointer;
    transition: all 0.3s ease;
    background: transparent;
}

.status-btn.ok {
    background: #f0f9ff;
    color: #0369a1;
    border-color: #0369a1;
}

.status-btn.ok.active {
    background: #22c55e;
    color: white;
}

.status-btn.nok {
    background: #fef2f2;
    color: #dc2626;
    border-color: #dc2626;
}

.status-btn.nok.active {
    background: #ef4444;
    color: white;
}

.status-btn.na {
    background: #f8fafc;
    color: #64748b;
    border-color: #64748b;
}

.status-btn.na.active {
    background: #64748b;
    color: white;
}

.progress-section {
    background: var(--surface-0);
    border-radius: 8px;
    padding: 1.5rem;
    margin-bottom: 2rem;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

.progress-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 1rem;
}

.progress-stats {
    font-size: 1.5rem;
    font-weight: 700;
    color: var(--primary-color);
}

.summary-cards {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
    gap: 1rem;
    margin-bottom: 2rem;
}

.summary-card {
    background: var(--surface-0);
    border-radius: 8px;
    padding: 1.5rem;
    text-align: center;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

.summary-card.total {
    border-top: 4px solid var(--primary-color);
}

.summary-card.ok {
    border-top: 4px solid #22c55e;
}

.summary-card.nok {
    border-top: 4px solid #ef4444;
}

.summary-card.na {
    border-top: 4px solid #64748b;
}

.summary-number {
    font-size: 2rem;
    font-weight: 700;
    margin-bottom: 0.5rem;
}

.summary-label {
    font-size: 0.9rem;
    color: var(--surface-600);
}

.signature-pad {
    border: 2px dashed var(--primary-color);
    border-radius: 8px;
    background: var(--surface-50);
    cursor: crosshair;
}

.action-buttons {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-top: 2rem;
    gap: 1rem;
}

.btn-group {
    display: flex;
    gap: 1rem;
}

.issues-alert {
    background: #fef2f2;
    border: 1px solid #fecaca;
    border-radius: 8px;
    padding: 1.5rem;
    margin-bottom: 2rem;
}

.issues-alert-header {
    display: flex;
    align-items: start;
    gap: 1rem;
    margin-bottom: 1rem;
}

.issues-alert i {
    color: #dc2626;
    font-size: 1.2rem;
    margin-top: 0.2rem;
}

.issues-alert-title {
    font-weight: 600;
    color: #dc2626;
}

.issues-alert-desc {
    color: #7f1d1d;
    font-size: 0.9rem;
}

@media (max-width: 1024px) {
    .layout-sidebar {
        width: 80px;
    }

    .layout-content {
        margin-left: 80px;
    }

    .menu-item span {
        display: none;
    }

    .checkpoint-grid {
        grid-template-columns: 1fr;
    }
}

@media (max-width: 768px) {
    .layout-sidebar {
        transform: translateX(-100%);
        transition: transform 0.3s ease;
    }

    .layout-sidebar.mobile-visible {
        transform: translateX(0);
    }

    .layout-content {
        margin-left: 0;
        padding: 1rem;
    }

    .layout-topbar {
        padding: 1rem;
    }

    .summary-cards {
        grid-template-columns: repeat(2, 1fr);
    }
}

/* PrimeVue customizations */
.p-steps .p-steps-item.p-highlight .p-steps-number {
    background: var(--primary-color);
    color: white;
}

.p-button.p-button-success {
    background: #22c55e;
    border-color: #22c55e;
}

.p-button.p-button-warning {
    background: #f59e0b;
    border-color: #f59e0b;
}

.p-button.p-button-danger {
    background: #ef4444;
    border-color: #ef4444;
}

.p-datatable .p-datatable-tbody>tr>td {
    padding: 1rem;
}

.p-datatable .p-datatable-thead>tr>th {
    padding: 1rem;
    background: var(--surface-100);
}
</style>
