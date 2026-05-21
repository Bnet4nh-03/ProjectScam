<script setup>
import { ref, computed, watchEffect } from 'vue';

const props = defineProps({
    item: Object,
    inoutActions: Array,
    userInfo: Object,
    selectedRequest: Object
});

const emit = defineEmits(['update-state']);

const hwTypeDesc = props.item['hw_type_desc'] || 0;
const barCode = props.item['barcode'] || '';
const scode_id = props.selectedRequest['scode_id'];

const location_id = props.selectedRequest['Location'];
const ioActions = ref([...props.inoutActions]);
const ioComment = ref('');
const ioMemo = ref(props.item['memo'] || '');
const ioNotice = ref(props.item['notice'] || '');
const licHcc = props.userInfo['displayName'];
const licReq = props.selectedRequest['Requester'];
const formattedActions = computed(() =>
    ioActions.value.length ? ioActions.value.join(';') : 'N/A'
);

watchEffect(() => {
    const stateInfo = {
        hw_type_no: hwTypeDesc,
        barcode: barCode,
        scode_id: scode_id,
        location_id: location_id,
        io_actions: formattedActions.value,
        io_comment: ioComment.value,
        memo: ioMemo.value,
        notice: ioNotice.value,
        lic_hcc: licHcc,
        lic_req: licReq,
        extra: '',
        tester_id: 0,
    };
    emit('update-state', { hwTypeDesc, stateInfo });
});
</script>

<template>
    <div class="border rounded-lg p-4 mb-4">
        <FloatLabel class="mt-4">
            <label>Part In/Out Actions</label>
            <MultiSelect v-model="ioActions" display="chip" :options="inoutActions" filter
                placeholder="Part In/Out Actions" class="w-full" />
        </FloatLabel>

        <FloatLabel variant="on" class="mt-4">
            <label>Part In/Out Comment</label>
            <Textarea v-model="ioComment" class="w-full"></Textarea>
        </FloatLabel>
        <div class="grid grid-cols-2 gap-4">
            <FloatLabel variant="on" class="mt-4">
                <label>Memo</label>
                <Textarea v-model="ioMemo" class="w-full"></Textarea>
            </FloatLabel>
            <FloatLabel variant="on" class="mt-4">
                <label>Notice</label>
                <Textarea v-model="ioNotice" class="w-full"></Textarea>
            </FloatLabel>
        </div>
    </div>
</template>
