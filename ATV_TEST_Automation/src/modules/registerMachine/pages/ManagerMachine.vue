<script setup>
import { inject, onMounted, onUnmounted, ref, watch, onBeforeMount } from 'vue';
import BaseTable from '@/modules/registerMachine/component/BaseTable.vue';
import _ from "lodash";
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import ManagerMachineService from '../services/ManagerMachineService.js';
import { mode } from 'crypto-js';
const authStore = useAuthStore();
const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');


const tableTesterColumns = [
    { label: 'Tester ID', field: 'testerid' },
    { label: 'Factory', field: 'factory'},
    { label: 'Platform Name', field: 'platformnm' },
    { label: 'Hostname', field: 'hostname', mode: 'input' },
    { label: 'Tester Name', field: 'testername', mode: 'input' },
    { label: 'Emes Host', field: 'emeshost', mode: 'input' },
    { label: 'Flag Manual', field: 'flag_manual', mode: 'input' },
    { label: 'Use TPA', field: 'use_tpa' },
    { label: 'Menu Code', field: 'menucode', mode: 'input' },
    { label: 'Handler ID', field: 'handlerid', mode: 'input' },
    { label: 'Handler Hostname', field: 'rfidnm' },
    { label: 'Language', field: 'language', mode: 'input' },
    { label: 'Lastmoduser', field: 'lastmoduser' }
]

const listTesterNotRun = ref([])

const service = new ManagerMachineService(apiClient);

async function getTesterNotRun() {
    try {
        const response = await service.getTesterNotRun()

        listTesterNotRun.value = response || []

    } catch (error) {
        gFunc.ShowMessage("Failed to get tester not running.", "error", "", 3000)
    }
}

onMounted(() => {
    getTesterNotRun()
})
</script>

<template>
    <div class="card" v-if="listTesterNotRun.length === 0">
        <h1 class="text-3xl font-bold">No tester not running</h1>
    </div>

    <div class="card" v-else>
        <h1 class="text-3xl font-bold">Tester Not Running</h1>

        <BaseTable
            title=""
            :enablePaginator=true
            :searching=true
            :columns="tableTesterColumns"
            :rowData="listTesterNotRun"
        />
    </div>
</template>

<style lang="css">
.table-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2d3748;
}
</style>