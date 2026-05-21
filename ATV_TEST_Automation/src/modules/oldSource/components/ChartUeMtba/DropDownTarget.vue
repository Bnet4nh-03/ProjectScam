<script setup>
import { useLayout } from "@/layout/composables/layout";
import { useConfirm } from "primevue/useconfirm";
import { apiService } from "@/service/BaseService";
import { useAuthStore } from "@/stores/useAuthStore";
import { inject, onMounted, ref, watch, nextTick } from "vue";
// Import AG Grid Vue Component
import { AgGridVue } from "ag-grid-vue3";
import _ from "lodash";
import moment from "moment";

const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const authStore = useAuthStore();

const isLoading = ref(false);

const lstTarget = ref([]);
const filteredTarget = ref();
const selectedTarget = ref({});
const currentInputTarget = ref("");
const showAddNewTarget = ref(false);
const confirm = useConfirm();

const emit = defineEmits(["onTargetChange"]);

// Khai báo props nhận từ component cha
const props = defineProps({
    data: {
        type: Object,
        required: true,
        default: () => ({
            systemType: '',
            targetType: '',
        }),
    },
});

const OnInputTarget = (value) => {
    currentInputTarget.value = value.target.value;
}

const AddNewTarget = (event) => {
    const currentTarget = currentInputTarget.value.trim();
    if (!currentTarget) return;

    const exists = lstTarget.value.some(
        (target) => target.code.toString().toLowerCase() === currentTarget.toLowerCase()
    );

    if (!exists) {
        const newTarget = {
            name: Number(currentTarget),
            code: Number(currentTarget),
            status: 'C',
        };
        lstTarget.value.push(newTarget);
        filteredTarget.value = [...lstTarget.value];
        selectedTarget.value = newTarget;
    } else {
        gFunc.ShowMessage(`${currentTarget} already exists in the target list.`, gVariable.messageType.error);
    }
};

const SearchTarget = (event) => {
    setTimeout(() => {
        if (!event.query.trim().length) {
            filteredTarget.value = [...lstTarget.value];
        } else {
            filteredTarget.value = lstTarget.value.filter((target) => {
                // return target.name.toString().toLowerCase().startsWith(event.query.toLowerCase());
                return target.code.toString().toLowerCase().includes(event.query.toLowerCase());
            });
        }
    }, 200);
};

const ConfirmSaveTarget = ()=> {
    if(!selectedTarget.value.code){
        gFunc.ShowMessage("Target field must not be empty", gVariable.messageType.error);
        return;
    }
     if (selectedTarget.value["status"] != "C") {
        gFunc.ShowMessage(`${selectedTarget.value.code} already exists in the target list.`, gVariable.messageType.error);
        isLoading.value = false;
        return;
    }
    confirm.require({
        group: `confirmDialog${props.data.targetType}`,
        header: 'Are you sure?',
        message: 'Please confirm to proceed.',
        accept: () => {
            // call api for submit request
           SaveTarget();
        },
        reject: () => {
        }
    });
}

const SaveTarget = async () => {
    isLoading.value = true;
    var paramReq = {
        targetCode: selectedTarget.value.code,
        badgeNo: authStore.userInfo.badge_no,
        systemType: props.data.systemType,
        targetType: props.data.targetType,
    }
    const response = await apiService.post('/api/UeMtba/SaveTarget', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        lstTarget.value = res.data;
        if (res.data.length > 0) {
            selectedTarget.value = res.data[0];
        }
        gFunc.ShowMessage(`Target saved successfully.`);
    }
    isLoading.value = false;
}

const GetListTarget = async () => {
    isLoading.value = true;
    var paramReq = {
        systemType:  props.data.systemType,
        targetType: props.data.targetType,
    }
    const response = await apiService.post('/api/UeMtba/GetListTarget', gFunc.CreateReqData(paramReq));
    var res = gFunc.CheckResData(response);
    if (res.isCheck) {
        lstTarget.value = res.data;
        if (res.data.length > 0) {
            selectedTarget.value = res.data[0];
        }
    }
    isLoading.value = false;
}


watch(currentInputTarget, async (newValue, oldValue) => {
    showAddNewTarget.value = newValue.trim().length > 0 && !lstTarget.value.some(
        (target) => target.code.toString().toLowerCase() === newValue.trim().toLowerCase()
    );
}, { immediate: true });

watch(selectedTarget, async (newValue, oldValue) => {
    if (_.toString(newValue) !="") {
        // emit data for parent
         emit("onTargetChange", {
           systemType: props.data.systemType,
           targetType: props.data.targetType,
           targetVal: newValue.code
        });
    }
});


onMounted(() => {
    GetListTarget();
});

</script>
<template>
    <InputGroup style="width: 180px;" class="inputGroup">
        <FloatLabel variant="on">
            <AutoComplete :disabled="authStore.HasPermission([gVariable.permission.assy2.Create])?false:true" :class="authStore.HasPermission([gVariable.permission.assy2.Create])? 'dropDownTarget': ''" dropdown v-model="selectedTarget" optionLabel="name" :suggestions="filteredTarget"
                size="small" @input="OnInputTarget" @complete="SearchTarget">
                <template #option="slotProps">
                    <div class="flex items-center">
                        <!-- <img :alt="slotProps.option.name"
                    src="https://primefaces.org/cdn/primevue/images/flag/flag_placeholder.png"
                    :class="`flag flag-${slotProps.option.code.toLowerCase()} mr-2`" style="width: 18px" /> -->
                        <div>{{ slotProps.option.code }}</div>
                    </div>
                </template>
                <template #header>
                    <div class="font-medium px-3 py-2">Available Target</div>
                </template>
                <template #footer>
                    <div class="px-3 py-3" v-if="showAddNewTarget">
                        <Button label="Add New Target" fluid severity="secondary" text size="small"
                            v-on:click="AddNewTarget" icon="pi pi-plus" />
                    </div>
                </template>
            </AutoComplete>
            <label for="target">{{props.data.targetType}} target</label>
        </FloatLabel>
        <InputGroupAddon v-if="authStore.HasPermission([gVariable.permission.assy2.Create])">
            <Button severity="secondary"
                :loading="isLoading" v-on:click="ConfirmSaveTarget()" icon="pi pi-save px-1" size="small"></Button>
        </InputGroupAddon>
    </InputGroup>


     <ConfirmDialog :group="`confirmDialog${props.data.targetType}`" >
        <template #container="{ message, acceptCallback, rejectCallback }">
            <div class="flex flex-col items-center p-8 bg-surface-0 dark:bg-surface-900 rounded">
                <div
                    class="rounded-full bg-primary text-primary-contrast inline-flex justify-center items-center h-24 w-24 -mt-20">
                    <i class="pi pi-question" style="font-size: 2.5rem"></i>
                </div>
                <span class="font-bold text-2xl block mb-2 mt-6">{{ message.header }}</span>
                <p class="mb-0">{{ message.message }}</p>
                <div class="flex items-center gap-2 mt-6">
                    <Button label="Save" @click="acceptCallback" class="w-32"></Button>
                    <Button label="Cancel" outlined @click="rejectCallback" class="w-32"></Button>
                </div>
            </div>
        </template>
    </ConfirmDialog>
</template>

<style>
.dropDownTarget .p-autocomplete-dropdown{
    border-start-end-radius: 0px !important;
    border-end-end-radius: 0px !important;
}

.inputGroup .p-inputtext{
    border-start-end-radius: 0px !important;
    border-end-end-radius: 0px !important;
}
</style>
