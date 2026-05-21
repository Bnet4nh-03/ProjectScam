<script setup>

import Checkbox from 'primevue/checkbox';
import { useLayout } from '@/layout/composables/layout';
import { useConfirm } from "primevue/useconfirm";
import { inject, onMounted, onUnmounted, ref, watch, onBeforeMount } from 'vue';
import BaseChart from '@/modules/holdLotManagement/component/BaseChart.vue';
import BaseTable from '../component/BaseTable.vue';
import _ from "lodash";
const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import { releaseLotService } from '@/modules/holdLotManagement/services/ReleaseLotService';
const { getPrimary, getSurface, isDarkTheme } = useLayout();
const authStore = useAuthStore();
const trendChartData = ref(null);
const chartOptions = ref(null);
const holdLotSummaryData = ref(null);
const statusChartData = ref(null);
const listLotSelected = ref([]);
const isShowLotRequestedDialog = ref(false);
const confirm = useConfirm();
const isSendFA = ref(false);
const isAttachment = ref(true);
const requestComment = ref(null);
const fileUpload = ref(null);
const listRequest = ref([]);
const operationNumber = {
    'SLT0': '7763',
    'SLT1': '984',
    'SLT2': '985'
};

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
const lotDataTable = ref([]);
const lotTableColumns = [
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

const requestTableColumns = [
    { label: "Date", field: "request_date" },
    { label: "Tile", field: "request_title" },
    { label: "Lot", field: "lot", type: "chip" },
    { label: "Status", field: "request_status", type: "status" },
    { label: "Comment", field: "comment" },
    { label: "Requester", field: "requester_name" },
];

const requestTableEmailColumns = [
    { label: "Date" },
    { label: "By" },
    { label: "Comment" },
    { label: "Staus" },
];

const requestSelected = ref(null);

function getCssVar(name) {
    return getComputedStyle(document.documentElement).getPropertyValue(name).trim();
}

function initDataset() {
    var dataset = [
        { type: 'bar', label: 'SLT0', backgroundColor: getCssVar('--p-green-500'), data: [], barThickness: 32 },
        { type: 'bar', label: 'SLT1', backgroundColor: getCssVar('--p-yellow-500'), data: [], barThickness: 32 },
        { type: 'bar', label: 'SLT2', backgroundColor: getCssVar('--p-red-500'), data: [], barThickness: 32 }];
    return dataset;
};

function setTrendChartData() {
    if (!Array.isArray(holdLotSummaryData.value.data)) {
        return {
            labels: gFunc.GetWWPrevious(),
            datasets: initDataset()
        };
    }
    var datasets = initDataset();
    const weekNumbers = gFunc.GetWWPrevious();
    const labels = weekNumbers.map(week => `WW${week}`);
    const totalData = [];

    weekNumbers.forEach(week => {
        const slt0Count = holdLotSummaryData.value.data
            .filter(item => item['HROPR'] == operationNumber.SLT0 &&
                gFunc.GetWeekNumber(new Date(gFunc.ConvertDate(item.HRHDTM))) == week).length;

        const slt1Count = holdLotSummaryData.value.data
            .filter(item => item['HROPR'] == operationNumber.SLT1 &&
                gFunc.GetWeekNumber(new Date(gFunc.ConvertDate(item.HRHDTM))) == week).length;

        const slt2Count = holdLotSummaryData.value.data
            .filter(item => item['HROPR'] == operationNumber.SLT2 &&
                gFunc.GetWeekNumber(new Date(gFunc.ConvertDate(item.HRHDTM))) == week).length;

        // Push null instead of 0 to hide the bar
        datasets[0].data.push(slt0Count === 0 ? null : slt0Count);
        datasets[1].data.push(slt1Count === 0 ? null : slt1Count);
        datasets[2].data.push(slt2Count === 0 ? null : slt2Count);
        totalData.push(slt0Count + slt1Count + slt2Count);
    });

    datasets.push({
        type: 'line',
        label: 'Total',
        borderColor: gVariable.backgroundColorAmkor[2],
        borderWidth: 2,
        fill: false,
        data: totalData,
        tension: 0.4
    });

    return {
        labels: labels,
        datasets: datasets
    };
};

function setStatusChartData() {
    const labels = ['TE', 'FA', 'QA'];
    if (!Array.isArray(holdLotSummaryData.value.data)) {
        return {
            labels: labels,
            datasets: initDataset(),
        };
    }
    var datasets = initDataset();
    const totalData = [];

    labels.forEach(label => {
        var teCount =
            holdLotSummaryData.value.data
                .filter(item => item['HROPR'] === operationNumber.SLT0 &&
                    item[label] === 'Pending').length;
        var faCount =
            holdLotSummaryData.value.data
                .filter(item => item['HROPR'] === operationNumber.SLT1 &&
                    item[label] === 'Pending').length;
        var qaCount =
            holdLotSummaryData.value.data
                .filter(item => item['HROPR'] === operationNumber.SLT2 &&
                    item[label] === 'Pending').length;
        // Push null instead of 0 to hide the bar
        datasets[0].data.push(teCount === 0 ? null : teCount);
        datasets[1].data.push(faCount === 0 ? null : faCount);
        datasets[2].data.push(qaCount === 0 ? null : qaCount);
        totalData.push(teCount + faCount + qaCount);
    });

    datasets.push({
        type: 'line',
        label: 'Total',
        borderColor: gVariable.backgroundColorAmkor[2],
        borderWidth: 2,
        fill: false,
        data: totalData,
        tension: 0.4
    });

    return {
        labels: labels,
        datasets: datasets
    };
};

function setChartOptions() {
    const documentStyle = getComputedStyle(document.documentElement);
    const borderColor = documentStyle.getPropertyValue('--surface-border');
    const textMutedColor = documentStyle.getPropertyValue('--text-color-secondary');

    return {
        maintainAspectRatio: false,
        aspectRatio: 0.8,
        layout: {
            padding: {
                top: 30  // Add padding at the top for the labels
            }
        },
        plugins: {
            legend: {
                position: 'bottom',  // This moves the legend below the chart
                labels: {
                    color: textMutedColor,
                    boxWidth: 12,
                    padding: 20
                }
            },
            // Add this datalabels configuration
            datalabels: {
                display: true,
                color: '#000000', // White text color
                anchor: 'end',
                align: 'top',
                formatter: function (value) {
                    return value; // Display the exact value
                }
            }
        },
        scales: {
            x: {
                ticks: {
                    color: textMutedColor,
                    align: 'center'
                },
                grid: {
                    color: 'transparent',
                    borderColor: 'transparent'
                }
            },
            y: {
                ticks: {
                    color: textMutedColor
                },
                grid: {
                    color: borderColor,
                    borderColor: 'transparent',
                    drawTicks: false
                }
            }
        }
    };
};

watch([getPrimary, getSurface, isDarkTheme], () => {
    trendChartData.value = setTrendChartData();
    chartOptions.value = setChartOptions();
    statusChartData.value = setStatusChartData();
});

onMounted(async () => {
});

onBeforeMount(async () => {
    await refresh();
});

async function loadData() {
    holdLotSummaryData.value = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetHoldLotSummary]", {});
    holdLotSummaryData.value = holdLotSummaryData.value[0];
    // Map the data to row structure 
    lotDataTable.value = holdLotSummaryData.value.data
        .filter(item => item.HRSTS === 'HOLD')   // only keep HOLD status
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
            request_id: item.request_id,
            dcc: item.SMDCC,
            operation: item.HROPR,
            holdCode: item.HRHRSN
        }));
    // Request data
    await getRequestList();
    // Filter request data to show only pending request
    listRequest.value = listRequest.value.filter(item => item.request_status === "Pending");
    // Set chart data
    trendChartData.value = setTrendChartData();
    chartOptions.value = setChartOptions();
    statusChartData.value = setStatusChartData();
}

async function handleRequestClicked() {

    if (listLotSelected.value.length) {
        // Validate that all selected lots have request_id as null
        const hasExistingRequest = listLotSelected.value.some(lot => !gFunc.CheckItemIsObject(lot.request_id));

        if (hasExistingRequest) {
            gFunc.ShowMessage("Selected lot(s) already have an associated request.\nPlease select lots without existing requests.", "error", "", 5000);
            return;
        }

        await bindingTimeLineData();
    } else {
        gFunc.ShowMessage("Please select a lot to request.", "error", "", 3000);
    }
};

function validateRequest(row) {
    const { te, fa, qa } = row;

    // Permission checks
    if (te === "Pending" && !authStore.HasPermission(gVariable.permission.hlmApproved.TE)) {
        gFunc.ShowMessage("You don't have permission make request!!!", "error", "", 3000);
        return false;
    }
    if (fa === "Pending" && !authStore.HasPermission(gVariable.permission.hlmApproved.FA)) {
        gFunc.ShowMessage("You don't have permission submit report!!!", "error", "", 3000);
        return false;
    }
    if (qa === "Pending" && !authStore.HasPermission(gVariable.permission.hlmApproved.QA)) {
        gFunc.ShowMessage("You don't have permission release hold lot!!!", "error", "", 3000);
        return false;
    }

    // File upload required if TE or FA is pending
    if ((te === "Pending" || fa === "Pending") && !fileUpload.value) {
        gFunc.ShowMessage("Please select a file to upload.", "error", "", 3000);
        return false;
    }

    return true;
};

async function requireConfirm() {
    confirm.require({
        group: 'headless',
        header: 'Are you sure to submit these information?',
        accept: async () => {
            if (validateRequest(listLotSelected.value[0])) {
                await acceptRequest();
                isShowLotRequestedDialog.value = false;
            }
        },
        reject: () => {

        }
    });
};

async function releaseLot(row) {
    var param = {
        "lotName": row.lot,
        "lotDcc": row.dcc,
        "holdCode": row.holdCode,
        "releaseReason": row.station + "_" + row.type + "_Approved to release_" + row.date,
        "userBadge": requestSelected.value.request_by,
        "holdOpr": _.toInteger(row.operation),
        "shipBackDate": 20251020
    };
    const response = await releaseLotService.post('/atv/data400/releaseLot', param);
    return response.result;
}

async function setLot(row, requestID, flowOrder) {
    var param = {
        "@request_id": requestID, // UNIQUEIDENTIFIER
        "@flow_order": flowOrder,
        "@lot": row.lot, // VARCHAR(50)
        "@operation": row.operation
    }
    // var resp = gFunc.CheckResData(await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_SetLot]", param));
    await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_SetLot]", param);
}

async function acceptRequest() {

    var flowOrder = 0;
    var requestID;
    if (requestSelected.value) {
        if (listLotSelected.value[0].fa == "NA") {
            if (listLotSelected.value[0].qa == "Pending")
                flowOrder = _.toInteger(requestSelected.value.flow_order) + 2;
        }
        else {
            flowOrder = _.toInteger(requestSelected.value.flow_order) + 1;
        }
        requestID = requestSelected.value.request_id;
    }
    else {
        flowOrder = isSendFA.value == true ? 12 : 13;
        requestID = null;
    }
    var params = {
        "@request_id": requestID, // UNIQUEIDENTIFIER = NULL
        "@request_title": "[" + gFunc.ConvertDate(new Date(), 'YYMMDDHHmmss') + "]" + " [Monaco] Request for release hold lot",
        "@badgeno": authStore.userInfo.badge_no, // VARCHAR(50)
        "@flow_id": "26", // BIGINT
        "@comment": requestComment.value, // NVARCHAR(MAX)
        "@flow_order": flowOrder, // INT
    };

    var res = gFunc.CheckResData(await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_SetRequest]", params));
    if (res.isCheck) {
        gFunc.ShowMessage("Your request has been submit successfully.", "", "", 3000);
        // Get request ID
        requestID = res.data.request_id;
        // Call API to release lot        
        // Link request with list lot selected
        if (flowOrder == "3") {
            listLotSelected.value.forEach(async row => {
                var result = await releaseLot(row);
                if (result === "") {
                    await setLot(row, requestID, flowOrder);
                }
                else {
                    gFunc.ShowMessage("Release lot " + row.lot + " failed: " + result, "error", "");
                }
            });
        }
        else {
            listLotSelected.value.forEach(async row => {
                await setLot(row, requestID, flowOrder);
            });
        }
        if (isAttachment.value == true) {
            // Upload file
            await uploadFile(flowOrder, requestID);
        }
        else {
            await sendEmail(requestID);
        }

    }
};

async function refresh() {
    holdLotSummaryData.value = null;
    listLotSelected.value = [];
    isSendFA.value = false;
    isAttachment.value = true;
    requestComment.value = "";
    fileUpload.value = null;
    listRequest.value = [];
    events.value = getInitialEvents();
    lotDataTable.value = [];
    requestSelected.value = null;
    await loadData();
};

function onFileSelect(event) {
    fileUpload.value = event.files[0];
    if (!fileUpload.value) {
        gFunc.ShowMessage("Please select a file to upload.", "error", "", 3000);
        return;
    }

};

async function uploadFile(flowOrder, requestID) {
    try {
        const metadata = {
            uploadedBy: authStore.userInfo.badge_no,
            uploadTimestamp: new Date().toISOString(),
            "AppName": "EsiMonacoHoldLotManagement",
            "SaveMode": "Rename",
        };
        const result = await apiClient.uploadFile(fileUpload.value, metadata);
        await setRequestAttachment(result.fullFilePath, requestID, flowOrder)
        // await refresh();
        isShowLotRequestedDialog.value = false; // Close dialog on success
    } catch (error) {
        console.error('Upload failed', error);
    }
};

async function setRequestAttachment(fullFilePath, requestID, flowOrder) {
    if (flowOrder == "12" || flowOrder == "13") {
        flowOrder = "1";
    }
    var param = {
        "@request_id": requestID, // UNIQUEIDENTIFIER
        "@file_name": fileUpload.value.name,// NVARCHAR(MAX),
        "@file_path": fullFilePath,// NVARCHAR(MAX),
        "@file_mime_type": fileUpload.value.type,// NVARCHAR(255),
        "@flow_order": flowOrder
    };
    var res = gFunc.CheckResData(await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_SetRequestAttachment]", param));
    if (res.isCheck) {
        await sendEmail(requestID);
        gFunc.ShowMessage("Your attachment has been upload successfully.", "", "", 3000);
    }
    else {
        gFunc.ShowMessage("Your attachment has been upload failed.", "", "", 3000);
    }
};

async function getRequestList() {
    try {
        listRequest.value = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetRequestList]", {});
        listRequest.value = listRequest.value[0];
        listRequest.value = await Promise.all(listRequest.value.data.map(async (request) => {
            var param = {
                "@request_id": request.request_id
            };
            var response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetRequest]", param);
            response = response[0];
            const lots = response.data.map(item => item.SMLOT).join(', ');
            return { ...request, lot: lots };
        }));
    }
    catch (error) {
        console.error('Get request list failed', error);
    }
};

async function getRequestAttachment() {
    try {
        var param = {
            "@request_id": requestSelected.value.request_id // VARCHAR(50)
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
            "@request_id": requestSelected.value.request_id, // VARCHAR(50)
        };
        var response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetRequestHistoryList]", param);
        return response[0];
    }
    catch (error) {
        console.error('Get request history list failed', error);
    }
};

async function getApproverList() {
    try {
        var response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetApproverList]", {});
        return response[0];
    }
    catch (error) {
        console.error('Get approver list failed', error);
    }
};

async function bindingTimeLineData() {
    const newEvents = getInitialEvents();
    const eventMap = new Map(newEvents.map(e => [e.title, e]));

    if (requestSelected.value) {
        const [requestHistory, requestAttachment] = await Promise.all([
            getRequestHistoryList(),
            getRequestAttachment()
        ]);

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
    }

    // Set pending status from listLotSelected
    if (listLotSelected.value.length > 0) {
        const selected = listLotSelected.value[0];
        const pendingEventTitle = ['te', 'fa', 'qa'].find(key => selected[key] === 'Pending');
        if (pendingEventTitle) {
            const event = eventMap.get(pendingEventTitle.toUpperCase());
            if (event && event.status !== 'Done') {
                event.status = 'Pending';
                event.color = 'var(--p-yellow-500)';
            }
        }
    }

    events.value = newEvents;
    isShowLotRequestedDialog.value = true;
};

async function getFileAttachment(item) {
    var param = {
        "filePath": item.filePath,
        "fileName": item.fileName,
    };
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
};

function renderLotList() {
    const headers = lotTableColumns
        .filter(col => !['te', 'fa', 'qa', 'status'].includes(col.field))
        .map(col => `<th style="background-color:#0F4B8F; color:white; ">${col.label}</th>`).join('');

    const rows = listLotSelected.value.map((lot, index) => {
        const rowBg = index % 2 === 0 ? 'background-color:#f8f9ff;' : '';
        const cells = lotTableColumns
            .filter(col => !['te', 'fa', 'qa', 'status'].includes(col.field))
            .map(col => {
                const cellValue = lot[col.field] || 'NA';
                let cellContent = cellValue;
                return `<td style="border-bottom:1px solid #e0e6ed;text-align:center;">${cellContent}</td>`;
            }).join('');
        return `<tr style="${rowBg}">${cells}</tr>`;
    }).join('');

    return `
        <h3 style="color:#667eea; margin-bottom:15px;">📦 Lot Details</h3>
        <table style="width:100%; border-collapse:collapse; margin:25px 0; font-size:14px;">
            <thead>
                <tr>${headers}</tr>
            </thead>
            <tbody>
                ${rows}
            </tbody>
        </table>
    `;
}

function renderRequest(requestHisory) {
    const headers = requestTableEmailColumns.map(col => `<th style="background-color:#0F4B8F; color:white;">${col.label}</th>`).join('');
    const rows = requestHisory.data.map((req, index) => {
        const rowBg = index % 2 === 0 ? 'background-color:#f8f9ff;' : '';

        // Status badge style using CSS variables
        let badgeStyle = '';
        if (req.approved_status === "Requested") {
            badgeStyle = "background-color:#fff3cd;";
        } else {
            badgeStyle = "background-color:#d4edda;";
        }

        return `
            <tr style="${rowBg}">
                <td style=" border-bottom:1px solid #e0e6ed;text-align:center; padding:10px;">${gFunc.ConvertDate(req.update_at)}</td>         
                <td style=" border-bottom:1px solid #e0e6ed;text-align:center; padding:10px;">${req.updated_name} - ${req.update_by} - ${req.updated_division} / ${req.updated_department}</td>
                <td style=" border-bottom:1px solid #e0e6ed;text-align:center; padding:10px;">${req.comment || ''}</td>
                <td style=" border-bottom:1px solid #e0e6ed;text-align:center; padding:10px;">
                    <span style="${badgeStyle} border-radius:12px;">
                        ${req.approved_status}
                    </span>
                </td>
            </tr>
        `;
    }).join('');
    return `
        <h3 style="color:#667eea; margin-bottom:15px;">📊 Request Status & Information</h3>
        <table style="width:100%; border-collapse:collapse; margin:25px 0; font-size:14px;">
            <thead>
                <tr>${headers}</tr>
            </thead>
            <tbody>
                ${rows}
            </tbody>
        </table>
    `;
};

async function sendEmail(requestID) {
    await getRequestList();
    requestSelected.value = listRequest.value.find(
        item => item.request_id === requestID
    );
    var flowOrder = requestSelected.value.flow_order;
    if (flowOrder == 1) {
        flowOrder = isSendFA.value ? flowOrder + 1 : flowOrder + 2;
    }
    else {
        flowOrder += 1;
    }

    var requestHisory = await getRequestHistoryList();
    var listApprover = await getApproverList();
    var toMailList = listApprover.data
        .map(item => item.email);
    for (var i = 0; i < requestHisory.data.length; i++) {
        var flowOrderHistory = requestHisory.data[i].flow_order;
        toMailList[flowOrderHistory - 1] = requestHisory.data[i].updated_email;
    }
    var toList = listApprover.data
        .filter(item => item.flow_order === flowOrder)
        .map(item => item.username);

    var requestTable = renderRequest(requestHisory);
    var lotListTable = renderLotList();
    var tbodyNotify = ``;
    if (flowOrder <= 3) {
        tbodyNotify = `    
        <div style="padding:30px;">
            <strong>Dear Mr ${toList},</strong>
        </div>
        
        <p>You have received a new request. Please review the request below.</p>`
    }
    else {
        tbodyNotify = `
        <div style="padding:30px;">
            <strong>Dear Team,</strong>
        </div>
        <p>This lot has been released. Please check the request below.</p>`
    }
    var body = `
        <body style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                    line-height:1.6;
                    margin:0;
                    padding:20px;
                    background-color:transparent;">
            <div style="max-width:600px; margin:0 auto; background-color:white; border-radius:12px; box-shadow:0 4px 6px rgba(0,0,0,0.1); overflow:hidden;">
                <!-- Body -->
                ${tbodyNotify}
                    <!-- Action Section -->
                    <div style="text-align:center; margin:30px 0; padding:25px; background-color:transparent; border-radius:10px;">
                        <p>Please access this link to review request:</p>
                        <a href="http://10.201.12.31:8030/"
                        style="display:inline-block; background-color:#4CAF50; color:white; text-decoration:none; padding:15px 30px; border-radius:8px; font-weight:600; font-size:16px; margin:10px 0;">
                        ✅ Review Detail Request
                        </a>
                    </div>
                <!-- Status Table -->
                ${requestTable}
                <!-- Lot List Table -->
                ${lotListTable}
                </div>
                <!-- Contact Information -->
                <div style="padding: 20px; border-radius: 6px; margin: 30px 0;">
                    <p style="margin: 0; font-size: 15px;">
                        If you have any questions, please contact the requester directly or reach out to our support team.
                    </p>
                </div>

                <!-- Closing -->
                <div style="margin-top: 30px;">
                    <p style="margin: 0; font-size: 15px;">Best regards,</p>
                    <p style="margin: 5px 0 0 0; color: #3498db; font-weight: 600; font-size: 15px;">Monaco Hold Lot System</p>
                </div>
            </div>
        </body>
    `
    var param = {
        "mailPriority": "HIGH",
        "sender": "atvtfa_notice@amkor.com",
        "subject": requestHisory.data[0].request_title,
        "body": _.toString(body),
        "toMailList": toMailList,
        "ccMailList": gVariable.groupMail.ccMailList,
        "bccMailList": gVariable.groupMail.bccMailList,
        "attachmentList": []
    };

    try {
        var response = await apiClient.sendEmail(param);
        if (response) {
            gFunc.ShowMessage("Email has been sent successfully.", "", "", 3000);
        }
    } catch (error) {
        console.error('Send email failed', error);
    }
};

function handleSelectionChange(selectedItems) {

    listLotSelected.value = selectedItems;
};

async function getRequest() {
    try {
        var param = {
            "@request_id": requestSelected.value.request_id // UNIQUEIDENTIFIER
        };
        var response = await apiClient.callSp("[TestDB]..[USP_HoldLotManagement_GetRequest]", param);
        response = response[0];
        listLotSelected.value = response.data
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
                // request_id: item.request_id,
                dcc: item.SMDCC,
                operation: item.HROPR,
                holdCode: item.HRHRSN
            }));

    }
    catch (error) {
        console.error('Get request failed', error);
    }
}

async function onRequestDoubleClicked(item) {
    requestSelected.value = item;
    await getRequest();
    await bindingTimeLineData();
};
</script>

<template>
    <div class="card" v-if="listRequest.length">
        <!-- Data Table Section -->
        <BaseTable title="Request Information" :columns=requestTableColumns :rowData=listRequest
            @row-dblclick="onRequestDoubleClicked" />
    </div>
    <div class="card">
        <!-- Data Table Section -->
        <BaseTable title="Hold Lot Information" :columns=lotTableColumns v-model:rowData=lotDataTable
            :selection=authStore.HasPermission(gVariable.permission.hlmApproved.TE)
            @selection-change="handleSelectionChange" @request-clicked="handleRequestClicked" />
        <!-- Charts Section -->
        <div class="charts-section">
            <BaseChart title="Monaco hold lot status" type="bar" :data="statusChartData" :options="chartOptions" />
            <BaseChart title="Monaco hold lot trend" type="bar" :data="trendChartData" :options="chartOptions" />
        </div>
    </div>
    <!-- Dialog -->
    <Dialog v-model:visible="isShowLotRequestedDialog" modal header="Detail Hold Lot" :style="{ width: '95vw' }"
        @hide="refresh">
        <BaseTable title="" :columns=lotTableColumns :rowData=listLotSelected />
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
                                v-if="slotProps.item.filePath"></Button>
                            <div v-if="slotProps.item.status === 'Pending'">
                                <label for="name" class="w-[100px] text-left">Comment</label>
                                <Editor v-model="requestComment" class="w-full" editorStyle="height: 100px" />
                                <div class="flex mt-2">
                                    <Checkbox v-model="isAttachment" value="isAttachment" binary
                                        v-if="listLotSelected[0]?.qa === 'Pending'" />
                                    <label for="name" class="w-[100px] text-left">Attachment</label>
                                </div>
                                <div class="flex" v-if="isAttachment">
                                    <FileUpload mode="basic" name="demo[]" accept=".pptx,.pdf" @select="onFileSelect"
                                        customUpload />
                                </div>
                            </div>
                        </template>
                    </Card>
                </template>
            </Timeline>
        </div>
        <div class="table-footer" v-if="listLotSelected[0]?.te === 'Pending'">
            <Checkbox v-model="isSendFA" value="isSendFA" binary />
            <label class="font-semibold"> Send FA </label>
        </div>
        <div class="table-footer" v-if="listLotSelected[0]?.qa !== 'Done'">
            <Button @click="requireConfirm">Submit</Button>
        </div>
    </Dialog>
    <ConfirmDialog group="headless">
        <template #container="{ message, acceptCallback, rejectCallback }">
            <div class="p-4 bg-white dark:bg-gray-800 rounded-lg shadow-lg">
                <div class="font-semibold text-lg mb-2">{{ message.header }}</div>
                <p class="mb-4">{{ message.message }}</p>
                <div class="flex justify-end gap-2">
                    <Button label="Cancel" severity="secondary" @click="rejectCallback" />
                    <Button label="Confirm" @click="acceptCallback" />
                </div>
            </div>
        </template>
    </ConfirmDialog>
</template>

<style lang="scss" scoped>
::v-deep(.p-timeline-vertical.p-timeline-alternate .p-timeline-event:nth-child(even) .p-timeline-event-content) {
    margin-left: auto;
    text-align: left !important;

}

.charts-section {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: 2rem;
}

.table-footer {
    text-align: end;
    margin-top: 1rem;
}
</style>
