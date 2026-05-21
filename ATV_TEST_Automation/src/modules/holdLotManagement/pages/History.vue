<script setup>
import { inject, onMounted, ref } from 'vue';
import BaseTable from '../component/BaseTable.vue';
import _ from "lodash";
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');
const holdLotSummaryData = ref(null);
const selectedRow = ref([]);
const showDialog = ref(false);

const getInitialEvents = () => ([
    {
        title: 'TE',
        status: 'NA',
        user: '',
        comment: '',
        date: '',
        fileName: '',
        filePath: '',
        color: 'var(--p-gray-400)'
    },
    {
        title: 'FA',
        status: 'NA',
        user: '',
        comment: '',
        date: '',
        fileName: '',
        filePath: '',
        color: 'var(--p-gray-400)'
    },
    {
        title: 'QA',
        status: 'NA',
        user: '',
        comment: '',
        date: '',
        fileName: '',
        filePath: '',
        color: 'var(--p-gray-400)'
    }
]);
const events = ref(getInitialEvents());
const rowData = ref([]);
const columns = [
    { label: "Date", field: "date" },
    { label: "Lot", field: "lot" },
    { label: "Station", field: "station" },
    { label: "Type", field: "type" },
    { label: "Failing", field: "failling" },
    { label: "TE", field: "te", type: "status" },
    { label: "FA", field: "fa", type: "status" },
    { label: "QA", field: "qa", type: "status" },
    { label: "Status", field: "status", type: "status" }
];

async function loadData() {
    holdLotSummaryData.value = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetHoldLotSummary]", {});
    holdLotSummaryData.value = holdLotSummaryData.value[0];
    // Map the data to row structure 
    rowData.value = holdLotSummaryData.value.data
        .map(item => ({
            date: gFunc.ConvertDate(item.HRHDTM),
            lot: item.SMLOT,
            type: gFunc.CheckItemIsObject(item.HOLD_TYPE) ? "NA" : item.HOLD_TYPE,
            station: item.SMOPRN,
            failling: gFunc.CheckItemIsObject(item.FAILING_TESTS) ? "NA" : item.FAILING_TESTS,
            te: gFunc.CheckItemIsObject(item.TE) ? "NA" : item.TE,
            fa: gFunc.CheckItemIsObject(item.FA) ? "NA" : item.FA,
            qa: gFunc.CheckItemIsObject(item.QA) ? "NA" : item.QA,
            status: item.HRSTS,
            request_id: item.request_id
        }));
};

async function onRowDoubleClicked(row) {
    selectedRow.value = [row];
    // Check if request_id is not null
    if (!gFunc.CheckItemIsObject(selectedRow.value[0].request_id)) {
        await bindingTimeLineData();
        showDialog.value = true;
    }
    else {
        gFunc.ShowMessage('This lot has not been requested yet.', 'error');
    }
};

async function getRequestAttachment() {
    try {
        var param = {
            "@request_id": selectedRow.value[0].request_id // VARCHAR(50)
        };
        var response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetRequestAttachement]", param);
        return response[0];
    }
    catch (error) {
        console.error('Get request attachment failed', error);
    }
};

async function getRequestHistoryList() {
    try {
        var param = {
            "@request_id": selectedRow.value[0].request_id, // VARCHAR(50)
        };
        var response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetRequestHistoryList]", param);
        return response[0];
    }
    catch (error) {
        console.error('Get request history list failed', error);
    }
};

async function bindingTimeLineData() {
    const newEvents = getInitialEvents();

    const [requestHistory, requestAttachment] = await Promise.all([
        getRequestHistoryList(),
        getRequestAttachment()
    ]);

    // Create a map for easy access
    const eventMap = new Map(newEvents.map(e => [e.title, e]));

    // Process history
    if (requestHistory && requestHistory.data) {
        for (const history of requestHistory.data) {
            const event = newEvents[history.flow_order - 1];
            if (event) {
                event.status = 'Done';
                event.user = history.updated_name;
                event.date = gFunc.ConvertDate(history.update_at);
                event.comment = history.comment;
                event.color = 'var(--p-green-500)';
            }
        }
    }

    // Process attachments
    if (requestAttachment && requestAttachment.data) {
        for (const attachment of requestAttachment.data) {
            const event = newEvents[attachment.flow_order - 1];
            if (event) {
                event.fileName = attachment.file_name;
                event.filePath = attachment.file_path;
            }
        }
    }

    // Set pending status
    const selected = selectedRow.value[0];
    const pendingEventTitle = ['te', 'fa', 'qa'].find(key => selected[key] === 'Pending');
    if (pendingEventTitle) {
        const event = eventMap.get(pendingEventTitle.toUpperCase());
        if (event && event.status !== 'Done') {
            event.status = 'Pending';
            event.color = 'var(--p-yellow-500)';
        }
    }

    events.value = newEvents;
};

async function getFileAttachment(item) {
    var param = {
        "filePath": item.filePath,
        "fileName": item.fileName,
    };
    try {
        // Destructure the return value
        const { filename, blob } = await apiClient.downloadFile(param);

        // Create a temporary link
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement("a");
        a.href = url;
        a.download = filename || param.fileName; // fallback if filename missing
        document.body.appendChild(a);
        a.click();

        // Cleanup
        a.remove();
        window.URL.revokeObjectURL(url);
    }
    catch (error) {
        console.error('Download file failed', error);
    }
};

function exportExcel() {
    const columnDefs = columns.map(col => ({ headerName: col.label, field: col.field }));
    gFunc.DownloadExcel(columnDefs, rowData.value, 'Hold Lot History', 'Hold Lot History.xlsx');
}

onMounted(async () => {
    await loadData();
});
</script>

<template>
    <!-- Data Table Section -->
    <div class="card">
        <BaseTable title="Hold Lot History" :columns=columns :rowData=rowData table-height="650px"
            @row-dblclick="onRowDoubleClicked" :searching="true">
            <template #actions>
                <Button label="Export to Excel" @click="exportExcel" />
            </template>
        </BaseTable>
    </div>

    <!-- Dialog -->
    <Dialog v-model:visible="showDialog" modal header="Detail Hold Lot" :style="{ width: '95vw' }">
        <BaseTable title="" :columns=columns :rowData=selectedRow table-height='100px' />
        <div class="card">
            <Timeline :value="events" align="alternate" class="customized-timeline">
                <template #marker="slotProps">
                    <span class="flex w-8 h-8 items-center justify-center text-white rounded-full z-10 shadow-sm"
                        :style="{ backgroundColor: slotProps.item.color }">
                        {{ slotProps.item.title }}
                    </span>
                </template>
                <template #content="slotProps">
                    <Card class="mt-4" v-if="['Pending', 'Done'].includes(slotProps.item.status)">
                        <template #title>
                            {{ slotProps.item.status }}
                        </template>
                        <template #subtitle v-if="slotProps.item.status === 'Done'">
                            {{ slotProps.item.date }} {{ slotProps.item.user }}
                            <span v-html="slotProps.item.comment"></span>
                        </template>
                        <template #content>
                            <Button label="Attachment" variant="text" @click="getFileAttachment(slotProps.item)"
                                v-if="slotProps.item.status !== 'Pending'"></Button>
                        </template>
                    </Card>
                </template>
            </Timeline>
        </div>
    </Dialog>
</template>

<style lang="scss" scoped>
@media screen and (max-width: 960px) {
    ::v-deep(.customized-timeline) {
        .p-timeline-event:nth-child(even) {
            flex-direction: row;

            .p-timeline-event-content {
                text-align: left;
            }
        }

        .p-timeline-event-opposite {
            flex: 0;
        }
    }
}

.dashboard-container {
    margin: auto;
    height: 100%;
    /* Fill parent height */
    display: flex;
    /* Optional: helps with layout */
    flex-direction: column;
}

.p-timeline-vertical.p-timeline-alternate .p-timeline-event:nth-child(even) .p-timeline-event-content {
    text-align: right;
}
</style>