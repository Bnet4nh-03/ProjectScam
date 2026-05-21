<script setup>
import { ref, onMounted, inject, watch } from 'vue';
import TesterSummaryService from '../services/TesterSummaryService';
import MultiSelect from 'primevue/multiselect';
import FloatLabel from 'primevue/floatlabel';
import Button from 'primevue/button';
import _ from 'lodash';

// Providers
const apiClient = inject('apiClient');
const gFunc = inject('gFunc');
const summaryService = new TesterSummaryService(apiClient);

// State
const testers = ref([]);
const activeConfigsByPackage = ref([]);
const models = ref([]);
const isLoading = ref(false);
const lastRefresh = ref('');

// Filter Data
const customers = ref([]);
const devices = ref([]);
const packages = ref([]);
const allTesters = ref([]);

const filters = ref({
    customer: [],
    device: [],
    package: [],
    tester: []
});

// Fetch Filter Options (Cascading)
const fetchFilterOptions = async () => {
    try {
        const res = await summaryService.getAvailableFilters({
            customerCodes: filters.value.customer.map(i => i.code),
            deviceIds: filters.value.device.map(i => i.code),
            packageIds: filters.value.package.map(i => i.code),
            testerIds: filters.value.tester.map(i => i.code)
        });

        customers.value = res.customers || [];
        devices.value = res.devices || [];
        packages.value = res.packages || [];
        allTesters.value = res.testers || [];
    } catch (error) {
        console.error('Fetch filter options failed', error);
    }
};

// Watch filters to update options
watch(
    filters,
    async () => {
        await fetchFilterOptions();
    },
    { deep: true }
);

// Reset handlers for cascading effect
const onCustomerChange = () => {
    filters.value.device = [];
    filters.value.package = [];
    filters.value.tester = [];
};

const onDeviceChange = () => {
    filters.value.package = [];
    filters.value.tester = [];
};

const onPackageChange = () => {
    filters.value.tester = [];
};

// Fetch Initial Data
onMounted(async () => {
    try {
        isLoading.value = true;
        
        // 1. Tải options ban đầu (Cascading)
        await fetchFilterOptions();

        // 2. Load toàn bộ dữ liệu lần đầu tiên
        await loadData();

    } catch (error) {
        console.error('Initial load failed', error);
    } finally {
        isLoading.value = false;
    }
});

const loadData = async () => {
    isLoading.value = true;
    try {
        const queryParams = {
            customerCodes: filters.value.customer.map(i => i.code),
            deviceIds: filters.value.device.map(i => i.code),
            packageIds: filters.value.package.map(i => i.code),
            testerIds: filters.value.tester.map(i => i.code),
            testerNames: filters.value.tester.map(i => i.name)
        };

        // 1. Lấy dữ liệu ma trận (Backend filtered) và cấu hình active song song (Realtime)
        let [matrixData, activeData] = await Promise.all([
            summaryService.getCompatibilityMatrix(queryParams),
            summaryService.getActiveConfigurations(queryParams)
        ]);

        // 2. Đồng bộ filter frontend cho ActiveData
        if (filters.value.package.length > 0) {
            const selectedPackageNames = filters.value.package.map(i => i.name);
            activeData = activeData.filter(i => selectedPackageNames.includes(i.PackageName));
        }

        if (filters.value.tester.length > 0) {
            const selectedTesterNames = filters.value.tester.map(i => i.name);
            activeData = activeData.filter(i => selectedTesterNames.includes(i.testername));
        }

        // 3. Xây dựng danh sách Tester (Columns)
        const uniqueTesters = _.uniq([
            ...matrixData.map(item => item.testername),
            ...activeData.map(item => item.testername)
        ]).sort();
        testers.value = uniqueTesters;

        // 4. Transform Matrix Data
        transformMatrixData(matrixData, activeData);

        // 5. Transform Active Data
        transformActiveData(activeData, matrixData);

        lastRefresh.value = new Date().toLocaleString();
    } catch (error) {
        console.error('Load data failed', error);
    } finally {
        isLoading.value = false;
    }
};

const getParameterIcon = (label) => {
    switch (label) {
        case 'TB': return 'pi pi-server';
        case 'CK': return 'pi pi-box';
        case 'MP': return 'pi pi-minus-circle';
        case 'Pitch (mm)': return 'pi pi-arrows-h';
        case 'Handler Recipe': return 'pi pi-file-edit';
        default: return 'pi pi-tag';
    }
};

const getPackageTextColor = (name) => {
    const n = name.toUpperCase();
    if (n.includes('QFP')) return 'text-blue-700';
    if (n.includes('BGA')) return 'text-purple-800';
    if (n.includes('SOP') || n.includes('TSOP')) return 'text-orange-700';
    if (n.includes('QFN')) return 'text-emerald-800';
    return 'text-slate-800';
};

const transformMatrixData = (matrixData, activeData) => {
    const groupedByDevice = _.groupBy(matrixData, 'DeviceCode');
    const deviceModelsList = [];

    _.forEach(groupedByDevice, (deviceItems, deviceCode) => {
        const groupedByPackage = _.groupBy(deviceItems, 'PackageName');
        const packageList = [];

        _.forEach(groupedByPackage, (items, packageName) => {
            const rows = [
                { label: 'TB', type: '64', values: [] },
                { label: 'CK', type: '13', values: [] },
                { label: 'MP', type: '74', values: [] },
                { label: 'Pitch (mm)', type: 'Pitch', values: [] },
                { label: 'Handler Recipe', type: 'Recipe', values: [] }
            ];
            testers.value.forEach(tester => {
                const configMappings = items.filter(i => i.testername === tester);
                if (configMappings.length > 0) {
                    rows[0].values.push(configMappings.find(m => m.HardwareType === '64')?.HardwareName || '');
                    rows[1].values.push(configMappings.find(m => m.HardwareType === '13')?.HardwareName || '');
                    rows[2].values.push(configMappings.find(m => m.HardwareType === '74')?.HardwareName || '');
                    rows[3].values.push(configMappings[0].Pitch?.toFixed(3) || '');
                    rows[4].values.push(configMappings[0].HandlerRecipe || '');
                } else {
                    rows.forEach(r => r.values.push('Unsupported'));
                }
            });

            packageList.push({
                name: packageName,
                rows: rows
            });
        });

        deviceModelsList.push({
            name: deviceCode,
            expanded: true,
            packages: packageList
        });
    });

    models.value = deviceModelsList;
};

const transformActiveData = (activeData, matrixData) => {
    const filteredPackageNames = filters.value.package.map(p => p.name);
    const compatibleTesters = _.uniq(matrixData.map(m => m.testername));

    const displayData = activeData.length > 0 ? activeData : [{ testername: '', PackageName: '', HardwareType: '', HardwareCode: '' }];

    const groupedByPackage = _.groupBy(displayData, 'PackageName');
    const packageList = [];

    _.forEach(groupedByPackage, (items, packageName) => {
        const rows = [
            { label: 'TB', type: 'TB', values: [], alerts: [] },
            { label: 'CK', type: 'CK', values: [], alerts: [] },
            { label: 'MP', type: 'MP', values: [], alerts: [] }
        ];

        testers.value.forEach(testerName => {
            const mappings = items.filter(i => i.testername === testerName);
            
            ['TB', 'CK', 'MP'].forEach((type, idx) => {
                const activeHw = mappings.find(m => m.HardwareType === type)?.HardwareCode || '';
                rows[idx].values.push(activeHw);

                const matrixHw = matrixData.find(m => 
                    m.testername === testerName && 
                    m.PackageName === packageName && 
                    ((type === 'TB' && m.HardwareType === '64') || 
                     (type === 'CK' && m.HardwareType === '13') || 
                     (type === 'MP' && m.HardwareType === '74'))
                )?.HardwareName || '';

                let status = 'normal';

                // Xử lý logic trạng thái (Ready / Matching / Busy / Illegal / Unsupported)
                const isHwEmpty = !activeHw || activeHw === '' || activeHw === 'N/A';

                // Kiểm tra xem Tester này có cấu hình cho Package này trong Matrix không
                const isCompatibleWithPackage = matrixData.some(m => m.testername === testerName && m.PackageName === packageName);

                if (isHwEmpty) {
                    // TRƯỜNG HỢP: MÁY TRỐNG (Không có RFID)
                    if (isCompatibleWithPackage) {
                        status = 'ready';
                    } else {
                        status = 'unsupported';
                    }
                } else {
                    // TRƯỜNG HỢP: CÓ PHẦN CỨNG (Có mã RFID)
                    if (packageName === 'N/A' || packageName === 'UNKNOWN/ILLEGAL' || (matrixHw && activeHw.trim().toUpperCase() !== matrixHw.trim().toUpperCase())) {
                        status = 'illegal';
                    } else if (filteredPackageNames.includes(packageName) || filteredPackageNames.length === 0) {
                        status = 'matching';
                    } else {
                        status = 'busy';
                    }
                }
                
                rows[idx].alerts.push(status);
            });
        });

        packageList.push({
            name: packageName,
            rows: rows
        });
    });

    activeConfigsByPackage.value = packageList;
};

const clearFilters = () => {
    filters.value = {
        customer: [],
        device: [],
        package: [],
        tester: []
    };
};
</script>

<template>
    <main class="card h-full overflow-hidden flex flex-col bg-surface font-body text-on-surface p-0 border-none shadow-none rounded-none">
        <!-- Filter Bar -->
        <div class="bg-surface-container-lowest px- py-3 border-b border-outline-variant/30 flex items-center gap-3 flex-wrap shrink-0">
            <div class="w-60">
                <FloatLabel variant="on">
                    <MultiSelect v-model="filters.customer" id="customer" filter :options="customers" optionLabel="name"
                        class="w-full !h-8 !text-[11px] font-bold shadow-sm" :maxSelectedLabels="2" display="chip"
                        @change="onCustomerChange" />
                    <label for="customer" class="uppercase tracking-widest !text-[9px] font-black">Customers</label>
                </FloatLabel>
            </div>
            <div class="w-60">
                <FloatLabel variant="on">
                    <MultiSelect v-model="filters.device" id="device" filter :options="devices" optionLabel="name"
                        class="w-full !h-8 !text-[11px] font-bold shadow-sm" :maxSelectedLabels="1" display="chip"
                        @change="onDeviceChange" />
                    <label for="device" class="uppercase tracking-widest !text-[9px] font-black">Devices</label>
                </FloatLabel>
            </div>
            <div class="w-60">
                <FloatLabel variant="on">
                    <MultiSelect v-model="filters.package" id="package" filter :options="packages" optionLabel="name"
                        class="w-full !h-8 !text-[11px] font-bold shadow-sm" :maxSelectedLabels="1" display="chip"
                        @change="onPackageChange" />
                    <label for="package" class="uppercase tracking-widest !text-[9px] font-black">Packages</label>
                </FloatLabel>
            </div>
            <div class="w-60">
                <FloatLabel variant="on">
                    <MultiSelect v-model="filters.tester" id="tester" filter :options="allTesters" optionLabel="name"
                        class="w-full !h-8 !text-[11px] font-bold shadow-sm" :maxSelectedLabels="1" display="chip" />
                    <label for="tester" class="uppercase tracking-widest !text-[9px] font-black">Tester IDs</label>
                </FloatLabel>
            </div>

            <div class="ml-auto flex items-center gap-2">
                <Button label="SEARCH" icon="pi pi-search" severity="primary" variant="outlined"
                    class="h-8 !text-[10px] font-black px-4 bg-primary border-none shadow-md shadow-primary/20 rounded-sm tracking-[0.1em]"
                    :loading="isLoading" @click="loadData" />
                <Button label="CLEAR" icon="pi pi-filter-slash" severity="primary" variant="outlined"
                    class="h-8 !text-[10px] font-black px-4 bg-primary border-none shadow-md shadow-primary/20 rounded-sm tracking-[0.1em]"
                    :loading="isLoading" @click="clearFilters" />
            </div>
        </div>

        <!-- Legend -->
        <div class="bg-surface-container-low px-4 py-1.5 border-b border-outline-variant flex items-center gap-4 shrink-0 overflow-x-auto custom-scrollbar whitespace-nowrap">
            <div class="flex items-center gap-2 border-r border-outline-variant/50 pr-4 shrink-0">
                <i class="pi pi-info-circle text-primary text-[10px]"></i>
                <span class="text-[9px] font-black text-on-surface-variant uppercase tracking-[0.1em]">Status Guide:</span>
            </div>
            <div class="flex items-center gap-5">
                <div v-for="item in [
                    { label: 'Ready', class: 'status-ready', desc: 'Compatible/Empty' },
                    { label: 'Matching', class: 'status-matching', desc: 'Active & Valid' },
                    { label: 'Busy', class: 'status-busy', desc: 'Active (Other Pkg)' },
                    { label: 'Illegal', class: 'status-illegal', desc: 'Hardware Mismatch' },
                    { label: 'Unsupported', class: 'bg-white border border-outline-variant/30', desc: 'Not Registered' }
                ]" :key="item.label" class="flex items-center gap-2 shrink-0">
                    <div :class="['w-3 h-3 rounded-sm shadow-sm ring-1 ring-inset ring-black/5', item.class]"></div>
                    <span class="text-[9px] font-black uppercase tracking-tight text-on-surface">
                        {{ item.label }}
                        <span class="text-on-surface-variant/60 font-bold ml-1 text-[8.5px]">({{ item.desc }})</span>
                    </span>
                </div>
            </div>
        </div>

        <!-- Matrix Grid -->
        <div class="flex-1 overflow-auto bg-surface relative custom-scrollbar">
            <table class="w-full border-collapse min-w-max">
                <thead class="sticky top-0 z-30 bg-surface-container-high shadow-sm">
                    <tr>
                        <th class="w-10 sticky left-0 z-40 bg-surface-container-high border-b border-outline-variant px-1 py-2 text-primary font-black uppercase tracking-widest text-[9px]">
                            PACKAGE
                        </th>
                        <th class="w-40 sticky left-10 z-40 bg-surface-container-high border-b border-outline-variant px-3 py-2 text-primary font-black uppercase tracking-widest text-[9px] text-center border-l border-outline-variant/30">
                            PARAMETER
                        </th>
                        <th v-for="tester in testers" :key="tester"
                            class="px-3 py-2 border-b border-outline-variant text-on-surface font-black !text-center uppercase tracking-widest text-[10px] min-w-[130px] border-l border-outline-variant/30">
                            {{ tester }}
                        </th>
                    </tr>
                </thead>
                <tbody class="text-[10.5px]">
                    <!-- SECTION: REAL-TIME ACTIVE -->
                    <tr class="bg-primary/10 border-y border-primary/30">
                        <td :colspan="testers.length + 2" class="px-4 py-1.5">
                            <div class="flex items-center gap-2 text-primary font-black text-[9px] tracking-[0.15em] uppercase">
                                <i class="pi pi-bolt text-[10px]"></i> Current Active Configuration (RFID Real-time)
                            </div>
                        </td>
                    </tr>
                    <template v-for="pkg in activeConfigsByPackage" :key="pkg.name">
                        <tr v-for="(row, rowIndex) in pkg.rows" :key="rowIndex" class="hover:bg-primary/5 transition-colors">
                            <td v-if="rowIndex === 0" :rowspan="pkg.rows.length"
                                class="sticky left-0 z-20 bg-surface-container-highest border-b border-outline-variant text-center !p-0 vertical-text">
                                <span :class="[getPackageTextColor(pkg.name), 'text-[9.5px] font-black uppercase tracking-tighter py-2 block']">
                                    {{ pkg.name }}
                                </span>
                            </td>
                            <td class="sticky left-10 z-20 bg-surface-container-low border-b border-outline-variant px-3 py-1.5 border-l border-outline-variant/20">
                                <div class="flex items-center gap-2 font-bold text-on-surface-variant uppercase tracking-tighter">
                                    <i :class="[getParameterIcon(row.label), 'text-primary/80 text-[10px]']"></i>
                                    {{ row.label }}
                                </div>
                            </td>
                            <td v-for="(val, colIndex) in row.values" :key="colIndex"
                                :class="['border-b border-outline-variant text-center font-mono py-1.5 px-1 border-l border-outline-variant/10', 'status-' + row.alerts[colIndex]]">
                                <span class="text-[9px] font-black truncate max-w-[120px] inline-block align-middle" :title="val">
                                    {{ (row.alerts[colIndex] === 'ready' && (val === 'N/A' || !val)) ? 'READY' : 
                                       (row.alerts[colIndex] === 'unsupported') ? '---' : (val || '---') }}
                                </span>
                            </td>
                        </tr>
                    </template>

                    <!-- SECTION: COMPATIBILITY MATRIX -->
                    <tr class="bg-slate-100 border-y border-slate-300">
                        <td :colspan="testers.length + 2" class="px-4 py-1.5">
                            <div class="flex items-center gap-2 text-slate-500 font-bold text-[9px] tracking-[0.15em] uppercase">
                                <i class="pi pi-database text-[10px]"></i> Registered Compatibility Matrix (Reference)
                            </div>
                        </td>
                    </tr>

                    <template v-for="model in models" :key="model.name">
                        <!-- Model Header -->
                        <tr class="bg-slate-50/50 border-b border-slate-200 cursor-pointer" @click="model.expanded = !model.expanded">
                            <td :colspan="testers.length + 2" class="sticky left-0 z-20 px-4 py-1.5">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <i :class="['pi text-[9px] text-slate-400 transition-transform duration-200', model.expanded ? 'pi-chevron-down' : 'pi-chevron-right']"></i>
                                        <span class="text-[10.5px] font-bold text-slate-700 tracking-tight uppercase">DEVICE MODEL: {{ model.name }}</span>
                                    </div>
                                    <span class="text-[8px] font-bold bg-slate-400/20 text-slate-600 px-2 py-0.5 rounded-sm border border-slate-300/50">
                                        {{ model.packages.length }} PACKAGES
                                    </span>
                                </div>
                            </td>
                        </tr>

                        <!-- Matrix Rows -->
                        <template v-if="model.expanded" v-for="pkg in model.packages" :key="pkg.name">
                            <tr v-for="(row, rIdx) in pkg.rows" :key="row.label" class="hover:bg-slate-50/80 transition-colors border-b border-slate-100">
                                <td v-if="rIdx === 0" :rowspan="pkg.rows.length"
                                    class="sticky left-0 z-20 bg-slate-50/50 border-b border-slate-100 text-center !p-0 vertical-text border-r border-slate-200">
                                    <span :class="[getPackageTextColor(pkg.name), 'text-[9px] font-bold uppercase tracking-tighter py-2 block opacity-80']">
                                        {{ pkg.name }}
                                    </span>
                                </td>
                                <td class="sticky left-10 z-20 bg-white/50 px-3 py-1.5 border-r border-slate-200">
                                    <div class="flex items-center gap-2 font-semibold text-slate-500 uppercase tracking-tighter">
                                        <i :class="[getParameterIcon(row.label), 'text-slate-400 text-[10px]']"></i>
                                        {{ row.label }}
                                    </div>
                                </td>
                                <td v-for="(val, vIdx) in row.values" :key="vIdx"
                                    :class="['text-center font-mono py-1.5 px-1 border-r border-slate-100', 
                                             val === 'Unsupported' ? 'incompatible-cell text-slate-300' : 'text-slate-600 font-semibold bg-white/30']">
                                    {{ val === 'Unsupported' ? '---' : val }}
                                </td>
                            </tr>
                        </template>
                    </template>
                </tbody>
            </table>
        </div>

        <footer class="h-6 bg-surface-container-highest flex items-center justify-between px-4 border-t border-outline-variant shrink-0">
            <span class="text-[8px] font-black text-on-surface-variant uppercase tracking-widest flex items-center gap-1">
                <i class="pi pi-clock"></i> {{ lastRefresh }}
            </span>
        </footer>
    </main>
</template>

<style scoped>
.vertical-text {
    writing-mode: vertical-rl;
    transform: rotate(180deg);
    white-space: nowrap;
}

.custom-scrollbar::-webkit-scrollbar {
    width: 4px;
    height: 4px;
}

.custom-scrollbar::-webkit-scrollbar-track { background: transparent; }
.custom-scrollbar::-webkit-scrollbar-thumb { 
    background: rgba(0, 0, 0, 0.2); 
    border-radius: 4px; 
}

/* Status Styles - High Contrast */
.status-ready { background-color: rgba(34, 197, 94, 0.15) !important; color: #15803d !important; border: 1px solid rgba(34, 197, 94, 0.3) !important; }
.status-matching { background-color: rgba(59, 130, 246, 0.12) !important; color: #1d4ed8 !important; }
.status-busy { background-color: rgba(234, 179, 8, 0.15) !important; color: #a16207 !important; }
.status-illegal { 
    background-color: rgba(239, 68, 68, 0.2) !important; 
    color: #b91c1c !important; 
    font-weight: 900 !important; 
    border: 1px solid rgba(239, 68, 68, 0.4) !important;
}
.status-unsupported {
    background-color: white !important;
    color: #cbd5e1 !important;
}

.incompatible-cell {
    background: repeating-linear-gradient(45deg, #f1f5f9, #f1f5f9 4px, #e2e8f0 4px, #e2e8f0 8px);
}
</style>
