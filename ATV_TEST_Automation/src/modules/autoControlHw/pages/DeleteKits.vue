<script setup>
import { ref, onMounted, inject, watch, computed } from 'vue';
import DeleteKitsService from '../services/DeleteKitsService';
import MultiSelect from 'primevue/multiselect';
import FloatLabel from 'primevue/floatlabel';
import Button from 'primevue/button';
import Checkbox from 'primevue/checkbox';

// Providers
const apiClient = inject('apiClient');
const gFunc = inject('gFunc');
const service = new DeleteKitsService(apiClient);

// State
const rows = ref([]);
const selected = ref([]);
const isLoading = ref(false);
const openConfirm = ref(false);

// Filter Data
const customers = ref([]);
const devices = ref([]);
const packages = ref([]);
const testers = ref([]);


const filters = ref({
    customer: [],
    device: [],
    package: [],
    tester: []
});

const page = ref(1);
const pageSize = ref(10);
const pageSizes = [5, 10, 20];


// Fetch Filter Options (Cascading)
const fetchFilterOptions = async () => {
    try {
        const res = await service.getAvailableFilters({
            customerCodes: filters.value.customer.map(i => i.code),
            deviceIds: filters.value.device.map(i => i.code),
            packageIds: filters.value.package.map(i => i.code),
            testerIds: filters.value.tester.map(i => i.code)
        });

        customers.value = res.customers || [];
        devices.value = res.devices || [];
        packages.value = res.packages || [];
        testers.value = res.testers || [];

    } catch (err) {
        console.error('fetchFilterOptions error', err);
    }
};

// Watch cascading filters
watch(filters, async () => {
    await fetchFilterOptions();
}, { deep: true });

// Reset cascading
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

// Load data
const loadData = async () => {
    page.value = 1;
    isLoading.value = true;
    try {
        const raw = await service.getCompatibilityMatrix({
            customerCodes: filters.value.customer.map(i => i.code),
            deviceIds: filters.value.device.map(i => i.code),
            packageIds: filters.value.package.map(i => i.code),
            testerIds: filters.value.tester.map(i => i.code)
        });
        console.log(raw)
        rows.value = transformRows(raw);

        selected.value = [];

    } catch (err) {
        console.error('loadData error', err);
    } finally {
        isLoading.value = false;
    }
};

const transformRows = (data) => {
    const map = {};

    data.forEach(item => {
        const key = `${item.DeviceCode}_${item.PackageName}_${item.testername}`;

        if (!map[key]) {
            map[key] = {
                MasterID: item.MasterID,
                CreateBy: item.username,
                DeviceCode: item.DeviceCode,
                PackageName: item.PackageName,
                testername: item.testername,
                TB: '',
                CK: '',
                MP: '',
                Pitch: item.Pitch,
                HandlerRecipe: item.HandlerRecipe
            };
        }

        if (item.HardwareType === '64')
            map[key].TB = item.HardwareCode || item.HardwareName;

        if (item.HardwareType === '13')
            map[key].CK = item.HardwareCode || item.HardwareName;

        if (item.HardwareType === '74')
            map[key].MP = item.HardwareCode || item.HardwareName;
    });

    return Object.values(map);
};
watch(pageSize, () => {
    page.value = 1;
});

const paginatedRows = computed(() => {
    const start = (page.value - 1) * pageSize.value;
    return rows.value.slice(start, start + pageSize.value);
});

const totalPages = computed(() => {
    return Math.ceil(rows.value.length / pageSize.value) || 1;
});

const nextPage = () => {
    if (page.value < totalPages.value) page.value++;
};

const prevPage = () => {
    if (page.value > 1) page.value--;
};

watch(page, () => {
    document.querySelector('.flex-1')?.scrollTo({ top: 0 });
});


// Select All
const toggleAll = (val) => {
    if (val) selected.value = [...rows.value];
    else selected.value = [];
};

// Delete
const confirmDelete = async () => {
    try {
        isLoading.value = true;

        const ids = selected.value.map(i => i.MasterID);

        console.log("Delete IDs:", ids); // debug

        await service.deleteByMasterIDs(ids);

        await loadData();

    } catch (err) {
        console.error('Delete failed', err);
    } finally {
        selected.value = [];
        openConfirm.value = false;
        isLoading.value = false;
    }
};



// Clear filters
const clearFilters = () => {
    filters.value = {
        customer: [],
        device: [],
        package: [],
        tester: []
    };
};

// Init
onMounted(async () => {
    isLoading.value = true;
    await fetchFilterOptions();
    await loadData();
    isLoading.value = false;
});
</script>


<template>
<main class="card flex flex-col h-full">

    <!-- FILTER BAR -->
    <div class="flex gap-3 flex-wrap p-3 border-b">

        <FloatLabel class="w-60">
            <MultiSelect v-model="filters.customer" :options="customers"
                optionLabel="name" filter display="chip" class="w-full custom-ms"
                @change="onCustomerChange"/>
            <label>Customer</label>
        </FloatLabel>

        <FloatLabel class="w-60">
            <MultiSelect v-model="filters.device" :options="devices"
                optionLabel="name" filter display="chip" class="w-full custom-ms"
                @change="onDeviceChange"/>
            <label>Device</label>
        </FloatLabel>

        <FloatLabel class="w-60">
            <MultiSelect v-model="filters.package" :options="packages"
                optionLabel="name" filter display="chip" class="w-full custom-ms"
                @change="onPackageChange"/>
            <label>Package</label>
        </FloatLabel>

        <FloatLabel class="w-60">
            <MultiSelect v-model="filters.tester" :options="testers"
                optionLabel="name" filter display="chip" class="w-full custom-ms"/>
            <label>Tester</label>
        </FloatLabel>

        <div class="ml-auto flex gap-2">
            <Button label="Search" icon="pi pi-search"
                :loading="isLoading" @click="loadData"/>
            <Button label="Clear" icon="pi pi-times"
                severity="secondary" @click="clearFilters"/>
        </div>
    </div>

    <!-- INFO BAR -->
    <div class="flex justify-between px-4 py-2 text-sm">
        <div>Selected: <b>{{ selected.length }}</b></div>

        <Button
            label="Delete Selected"
            icon="pi pi-trash"
            severity="danger"
            :disabled="selected.length === 0"
            @click="openConfirm = true"
        />
    </div>

    <!-- TABLE -->
    <div class="flex-1 overflow-auto">
    <table class="w-full border-collapse text-[12px] table-fixed">

        <thead class="bg-gray-200 sticky top-0">
            <tr class="text-left">
                <th class="w-10 text-center">
                    <!-- <Checkbox
                        :binary="true"
                        :modelValue="selected.length === rows.length"
                        @update:modelValue="toggleAll"
                    /> -->
                </th>

                <th class="w-32">Device</th>
                <th class="w-32">Package</th>
                <th class="w-40">Tester</th>

                <th class="w-40 text-center">TB</th>
                <th class="w-40 text-center">CK</th>
                <th class="w-40 text-center">MP</th>

                <th class="w-24 text-center">Pitch</th>
                <th>Recipe</th>
                <th class="w-40">Created By</th>
                
            </tr>
        </thead>

        <tbody>
            <tr v-for="(row, i) in paginatedRows" :key="i"
                class="hover:bg-gray-50">

                <td class="text-center">
                    <Checkbox :value="row" v-model="selected"/>
                </td>

                <td>{{ row.DeviceCode }}</td>
                <td>{{ row.PackageName }}</td>
                <td class="font-semibold text-blue-800">
                    {{ row.testername }}
                </td>

                <!-- ✅ TB / CK / MP -->
                <td class="font-mono text-center">
                    <div class="cell">{{ row.TB || '-' }}</div>
                </td>

                <td class="font-mono text-center">
                    <div class="cell">{{ row.CK || '-' }}</div>
                </td>

                <td class="font-mono text-center">
                    <div class="cell">{{ row.MP || '-' }}</div>
                </td>

                <td class="text-center">{{ row.Pitch }}</td>

                <td class="font-mono text-blue-700">
                    {{ row.HandlerRecipe }}
                </td>
          
                <td class="text-gray-600 font-mono">
                    {{ row.CreateBy || '-' }}
                </td>

            </tr>
        </tbody>

    </table>

    <div class="flex justify-between items-center px-4 py-2 border-t text-sm bg-gray-50">
            
        <!-- LEFT -->
        <div class="flex items-center gap-2">
            <span>Show</span>
            <select v-model="pageSize" class="border rounded px-2 py-1">
                <option v-for="s in pageSizes" :key="s" :value="s">
                    {{ s }}
                </option>
            </select>
            <span>entries</span>
        </div>

        <!-- CENTER -->
        <div>
            Showing 
            {{ (page - 1) * pageSize + 1 }}
            -
            {{ Math.min(page * pageSize, rows.length) }}
            of {{ rows.length }}
        </div>

        <!-- RIGHT -->
        <div class="flex items-center gap-2">
            <Button icon="pi pi-chevron-left"
                severity="secondary"
                @click="prevPage"
                :disabled="page === 1"
            />

            <span class="px-2 font-semibold">
                {{ page }} / {{ totalPages }}
            </span>

            <Button icon="pi pi-chevron-right"
                severity="secondary"
                @click="nextPage"
                :disabled="page === totalPages"
            />
        </div>

    </div>

</div>
    <!-- CONFIRM MODAL -->
    <div v-if="openConfirm"
        class="fixed inset-0 flex items-center justify-center bg-black/50">

        <div class="bg-white p-6 rounded w-80 text-center">
            <h3 class="text-lg font-semibold mb-2">
                Confirm Delete
            </h3>

            <p class="mb-4">
                Delete <b>{{ selected.length }}</b> kits?
            </p>

            <div class="flex justify-between">
                <Button label="Cancel" severity="secondary"
                    @click="openConfirm = false"/>
                <Button label="Confirm" severity="danger"
                    @click="confirmDelete"/>
            </div>
        </div>
    </div>

</main>
</template>


<style scoped>
table th {
    padding: 8px 10px;
    font-weight: 600;
    border-bottom: 1px solid #d1d5db;
}

table td {
    padding: 6px 10px;
    border-bottom: 1px solid #e5e7eb;
    vertical-align: middle;
}

.cell {
    width: 100%;
    padding: 6px 8px;
    background: #f9fafb;
    border: 1px solid #e5e7eb;
    border-radius: 4px;
    font-size: 12px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.custom-ms {
    min-height: 42px;
    display: flex;
    align-items: center;
    padding: 4px 8px;
}

/* label spacing */
:deep(.p-float-label label) {
    top: -6px;
    font-size: 12px;
}

/* input area */
:deep(.p-multiselect) {
    height: 42px;
}

/* chip inside */
:deep(.p-multiselect-token) {
    font-size: 11px;
    padding: 2px 6px;
}

</style>