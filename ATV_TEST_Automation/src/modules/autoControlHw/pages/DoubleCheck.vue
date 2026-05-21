<script setup>
import { ref, computed, onMounted, inject, watch } from 'vue';
import { useConfirm } from "primevue/useconfirm";
import BaseTable from '../component/BaseTable.vue';
import DoubleCheckService from '../services/DoubleCheckService';
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import { getStatusStyle } from '../utils/variable';
import _ from "lodash";
// Providers & Store
const gFunc = inject('gFunc');
const gVariable = inject('gVariable');
const apiClient = inject('apiClient');
const authStore = useAuthStore();
const doubleCheckService = new DoubleCheckService(apiClient);
const confirm = useConfirm();

// State
const allRequests = ref([]);
const selectedRequest = ref(null);
const hardwareComponents = ref([]);
const attachments = ref([]);
const comment = ref('');
const isLoading = ref(false);
const isProcessing = ref(false);
const showSuccessDialog = ref(false);
const successDialogMsg = ref('');

// Logic Phân trang
const first = ref(0);
const rows = ref(8);
const paginatedRequests = computed(() => {
    return allRequests.value.slice(first.value, first.value + rows.value);
});

const onPage = (event) => {
    first.value = event.first;
};

const tableColumns = ref([
    { label: 'Component Type', field: 'type' },
    { label: 'Reference Code', field: 'code' }
]);

// Fetch initial data
onMounted(async () => {
    await loadPendingRequests();
});

const loadPendingRequests = async () => {
    isLoading.value = true;
    try {
        const res = await doubleCheckService.getListPending(authStore.userInfo.badge_no);
        allRequests.value = res || [];
        
        // Auto select first item if exists and nothing selected
        if (allRequests.value.length > 0 && !selectedRequest.value) {
            await selectRequest(allRequests.value[0]);
        } else if (allRequests.value.length === 0) {
            selectedRequest.value = null;
        }
    } catch (error) {
        gFunc.ShowMessage('Error loading requests: ' + error.message, 'error');
    } finally {
        isLoading.value = false;
    }
};

const selectRequest = async (req) => {
    // Reset state
    allRequests.value.forEach(r => r.active = false);
    req.active = true;
    selectedRequest.value = req;
    hardwareComponents.value = [];
    attachments.value = [];
    comment.value = '';

    // Fetch details
    try {
        const [hwRes, attachRes] = await Promise.all([
            doubleCheckService.getHardwareMapping(req.id),
            doubleCheckService.getAttachments(req.id)
        ]);
        
        hardwareComponents.value = hwRes || [];
        attachments.value = attachRes || [];
    } catch (error) {
        gFunc.ShowMessage('Error loading details: ' + error.message, 'error');
    }
};

const handleDecision = async (status) => {
    if (!selectedRequest.value) return;
     
    isProcessing.value = true;
    try {
        await sendEmail(status);
        const res = await doubleCheckService.submitDecision(
            selectedRequest.value.id,
            status,
            comment.value,
            authStore.userInfo.badge_no
        );

        if (res && res.length > 0 && res[0]['data'][0]['Result'] === 0) {
            successDialogMsg.value = `Request #${selectedRequest.value.id} has been ${status.toLowerCase()} successfully!`;
            showSuccessDialog.value = true;
            selectedRequest.value = null; // Clear selection
          
            await loadPendingRequests(); // Refresh list
        } else {
            const errorMsg = (res && res.length > 0) ? res[0]['data'][0]['Message'] : 'Process failed';
            throw new Error(errorMsg);
        }
    } catch (error) {
         
        gFunc.ShowMessage('Action failed: ' + error.message, 'error');
    } finally {
        isProcessing.value = false;
    }
};

const onApprove = () => {
    confirm.require({
        message: 'Are you sure you want to APPROVE this hardware configuration request?',
        header: 'Confirm Approval',
        icon: 'pi pi-check-circle !text-green-500 !text-3xl',
        rejectProps: {
            label: 'Cancel',
            severity: 'secondary',
            outlined: true
        },
        acceptProps: {
            label: 'Approve',
            severity: 'primary'
        },
        accept: () => {
            handleDecision('WAIT REGISTER');
        }
    });
};

const onReject = () => {
    if (!comment.value.trim()) {
        gFunc.ShowMessage('Please provide a reason for rejection in Review Notes', 'warn');
        return;
    }

    confirm.require({
        message: 'Are you sure you want to REJECT this hardware configuration request?',
        header: 'Confirm Rejection',
        icon: 'pi pi-exclamation-triangle !text-red-500 !text-3xl',
        rejectProps: {
            label: 'Cancel',
            severity: 'secondary',
            outlined: true
        },
        acceptProps: {
            label: 'Reject',
            severity: 'danger'
        },
        accept: () => {
            handleDecision('REJECTED');
        }
    });
};

/**
 * Tải file đính kèm
 */
const openAttachment = async (file) => {
    if (file.FilePath) {
        const param = {
            filePath: file.FilePath,
            fileName: file.FileName
        };
        
        try {
            const { filename, blob } = await apiClient.downloadFile(param);

            const url = window.URL.createObjectURL(blob);
            const a = document.createElement("a");
            a.href = url;
            a.download = filename || file.FileName;
            document.body.appendChild(a);
            a.click();

            a.remove();
            window.URL.revokeObjectURL(url);
        } catch (error) {
            gFunc.ShowMessage('Download file failed: ' + error.message, 'error');
        }
    }
};
function renderRequest(masterData, hwData) {

    // Render hardware list: TYPE : CODE
    const hardwareHtml = hwData?.map(hw => {
        return `<div>• ${hw.type} : ${hw.code}</div>`;
    }).join('') || '';

    return `
        <h3 style="color:#667eea; margin-bottom:15px;">📋 Master Information</h3>

        <table style="width:100%; border-collapse:collapse; font-size:14px;">
            <tbody>

                <tr style="background-color:#f8f9ff;">
                    <td style="width:25%; padding:10px; font-weight:bold;">Customer</td>
                    <td style="padding:10px;">${masterData.customer || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Device</td>
                    <td style="padding:10px;">${masterData.device || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Package</td>
                    <td style="padding:10px;">${masterData.package || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Tester</td>
                    <td style="padding:10px;">${masterData.tester || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Pitch</td>
                    <td style="padding:10px;">${masterData.pitch ?? ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Handler Recipe</td>
                    <td style="padding:10px;">${masterData.recipe || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Platform</td>
                    <td style="padding:10px;">${masterData.platform || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Requester</td>
                    <td style="padding:10px;">${masterData.requester || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Request Date</td>
                    <td style="padding:10px;">${masterData.date || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Status</td>
                    <td style="padding:10px;">${masterData.status || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Hardware List</td>
                    <td style="padding:10px;">
                        ${hardwareHtml}
                    </td>
                </tr>

            </tbody>
        </table>
    `;
}
async function acceptRequest(masterId,flowOder) {

    var params = {
        "@master_id": masterId, // UNIQUEIDENTIFIER = NULL
        "@request_title": "[" + gFunc.ConvertDate(new Date(), 'YYMMDDHHmmss') + "]" + "Request ACH",
        "@badgeno": authStore.userInfo.badge_no, // VARCHAR(50)
        "@flow_id": 27, // BIGINT
        "@comment": comment.value, // NVARCHAR(MAX)
        "@flow_order": flowOder, // INT
    };

    var res = gFunc.CheckResData(await apiClient.callSp("[TestDB]..[USP_ACH_SetRequest]", params));
    if (res.isCheck) {
        gFunc.ShowMessage("Your request has been submit successfully.", "", "", 3000);
        // Get request ID
       
            //await sendEmail();
       

    }
};
async function getApproverList() {
    try {
        var param = {
                "@flow_id": 27,
                "@system_type": "ACH"
            };
        var response = await apiClient.callSp("[TestDB]..[USP_ACH_GetApproverList]", param);
        return response[0];
    }
    catch (error) {
        console.error('Get approver list failed', error);
    }
};
async function sendEmail(status) {
    
    var flowOrder = 2;
    if (status==="REJECTED")
       { flowOrder=1001}
    else 
        {
            flowOrder=2
        }
    var listApprover = await getApproverList();
    const targetFlowOrder = (flowOrder === 1001) ? 1 : 2;
    var toMailList = listApprover.data.find( item => item.flow_id === 27 && item.flow_order === targetFlowOrder).list_email;
    
    const mailArray = toMailList
    .split(';')      // tách theo dấu ;
    .map(m => m.trim()) // loại bỏ khoảng trắng
    .filter(Boolean);

   
    var requestTable = renderRequest(selectedRequest.value,hardwareComponents.value);
    var tbodyNotify = ``;
    if (flowOrder <= 3) {
        tbodyNotify = `    
        <div style="padding:30px;">
            <strong>Dear Team TPE,</strong>
        </div>
        <p>You have received a new request. Please review the request below.</p>`
    }
    else if(flowOrder===1001) {
        tbodyNotify = `
        <div style="padding:30px;">
            <strong>Dear Team,</strong>
        </div>
        <p>This Maxtrix has been TPE1 REJECT registration. Please check the request below.</p>`
    }
    else  {
        tbodyNotify = `
        <div style="padding:30px;">
            <strong>Dear Team,</strong>
        </div>
        <p>This Maxtrix has been registration. Please check the request below.</p>`
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
                        <a href="http://10.201.12.31:8030/auto-control-hw/matrix-registration"
                        style="display:inline-block; background-color:#4CAF50; color:white; text-decoration:none; padding:15px 30px; border-radius:8px; font-weight:600; font-size:16px; margin:10px 0;">
                        ✅ Review Detail Request
                        </a>
                    </div>
                <!-- Status Table -->
                ${requestTable}
                
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
                    <p style="margin: 5px 0 0 0; color: #3498db; font-weight: 600; font-size: 15px;">AutoHW System</p>
                </div>
            </div>
        </body>
    `
    
    let mailSubject = 'TPE1 Double Check Master Registration';

    if (flowOrder === 2) {
        mailSubject = 'TPE2 Double Check Master Registration';
    }
    else if (flowOrder === 1000) {
        mailSubject = 'Completed HW Registration';
    }
    else if (flowOrder === 1001) {
        mailSubject = 'Reject HW Registration';
    }

    var param = {
        "mailPriority": "HIGH",
        "sender": gVariable.sender.autoHW,
        "subject": mailSubject,
        "body": _.toString(body),
        "toMailList":mailArray,
        "ccMailList": gVariable.groupMail.ccAutoHWMailList,
        "bccMailList": gVariable.groupMail.bccAutoHWMailList,
        "attachmentList": []
    };

    try {
        var response = await apiClient.sendEmail(param);
        if (response) {
            await acceptRequest(selectedRequest.value.id,flowOrder);
            gFunc.ShowMessage("Email has been sent successfully.", "", "", 3000);
        }
    } catch (error) {
        console.error('Send email failed', error);
    }
};
</script>

<template>
    <div class="card flex h-[calc(100vh-12.5rem)] w-full overflow-hidden bg-surface text-on-surface p-0 border-none shadow-none rounded-none font-body text-[12px]">
        
        <!-- Left Side: Pending Requests List -->
        <aside class="w-[28%] min-w-0 flex flex-col bg-surface-container-low border-r border-outline-variant/30">
            <div class="p-4 pb-2 shrink-0 bg-surface-container-low/50 backdrop-blur-md z-10">
                <div class="flex justify-between items-end mb-1">
                    <h1 class="text-lg font-black tracking-tighter text-primary uppercase leading-none">Approvals</h1>
                    <span class="text-[10px] font-black text-on-surface-variant bg-surface-container-highest px-2 py-0.5 rounded-full">{{ allRequests.length }} Total</span>
                </div>
                <div class="mt-3">
                    <InputGroup class="h-9">
                        <InputText placeholder="SEARCH..." class="!text-[11px] font-bold uppercase" />
                        <InputGroupAddon class="!bg-surface-container">
                            <Button icon="pi pi-search" severity="secondary" variant="text" size="small" class="!text-on-surface-variant" />
                        </InputGroupAddon>
                    </InputGroup>
                </div>
            </div>

            <!-- Scrollable List -->
            <div class="flex-1 overflow-y-auto custom-scrollbar bg-surface-container-low/30 p-3">
                <div v-if="isLoading && allRequests.length === 0" class="flex flex-col items-center justify-center h-full opacity-50">
                    <ProgressSpinner style="width: 30px; height: 30px" />
                </div>
                
                <div v-else-if="allRequests.length === 0" class="flex flex-col items-center justify-center h-full opacity-40 grayscale italic text-center p-4">
                    <i class="pi pi-inbox text-4xl mb-2"></i>
                    <p>No pending requests found for you.</p>
                </div>

                <div v-else class="flex flex-col gap-3">
                    <div v-for="req in paginatedRequests" :key="req.id" 
                         @click="selectRequest(req)"
                         :class="['group relative p-3.5 rounded-sm cursor-pointer transition-all duration-200 border-l-4 shadow-sm', 
                                  req.active ? 'bg-surface-container-highest border-primary shadow-md translate-x-1' : 'bg-surface border-transparent hover:border-primary/30 hover:shadow-md']">
                        
                        <div class="flex justify-between items-start mb-1.5">
                            <span :class="['text-[12px] font-black uppercase tracking-tight truncate pr-2', req.active ? 'text-primary' : 'text-on-surface']">{{ req.device }}</span>
                            <span class="text-[10px] font-bold text-on-surface-variant shrink-0">{{ req.date }}</span>
                        </div>
                        <div class="flex items-center gap-2 mb-2">
                            <i class="pi pi-database text-[10px] text-on-surface-variant"></i>
                            <span class="text-[10px] text-on-surface font-bold uppercase tracking-wider opacity-60 truncate">{{ req.platform }}</span>
                        </div>
                        <div class="flex justify-between items-center border-t border-outline-variant/5 pt-2">
                            <Tag :severity="getStatusStyle(req.status).severity" :value="req.status" :icon="getStatusStyle(req.status).icon" 
                                 class="!text-[9px] !font-black !uppercase !tracking-widest !px-1.5 !py-0.5 rounded-sm" />
                            <span class="text-[10px] text-on-surface-variant font-black opacity-80">{{ req.requester }}</span>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Compact Paginator -->
            <div class="p-2 border-t border-outline-variant/20 bg-surface-container-low shrink-0 shadow-[0_-4px_10px_rgba(0,0,0,0.02)]">
                <Paginator :first="first" :rows="rows" :totalRecords="allRequests.length" @page="onPage"
                    template="PrevPageLink CurrentPageReport NextPageLink" class="custom-compact-paginator" />
            </div>
        </aside>

        <!-- Right Side: Review & Action Panel -->
        <section class="flex-1 min-w-0 flex flex-col bg-surface overflow-hidden h-full relative">
            <div v-if="!selectedRequest" class="flex-1 flex flex-col items-center justify-center bg-surface-container-lowest opacity-30">
                <i class="pi pi-file-edit text-6xl mb-4"></i>
                <p class="text-lg font-black uppercase tracking-widest">Select a request to review</p>
            </div>

            <template v-else>
                <!-- Header -->
                <div class="px-5 py-3 bg-surface-container-low border-b border-outline-variant/10 flex justify-between items-center shrink-0 z-10">
                    <div class="min-w-0">
                        <h2 class="text-xl font-black text-on-surface tracking-tighter uppercase leading-none truncate">Review & Action</h2>
                        <p class="text-[11px] text-on-surface-variant mt-1 font-bold uppercase">REQ ID: <span class="font-mono text-primary tracking-normal">#{{ selectedRequest.id }}</span></p>
                    </div>
                    <div class="flex items-center gap-2 shrink-0">
                        <div class="flex items-center gap-1.5 px-2 py-1 bg-tertiary/10 rounded-sm border-l-2 border-tertiary">
                            <i class="pi pi-clock text-tertiary text-[11px]"></i>
                            <span class="text-[10px] font-black text-tertiary uppercase tracking-widest">Awaiting Approval</span>
                        </div>
                    </div>
                </div>

                <!-- Scrollable Content -->
                <div class="flex-1 overflow-y-auto py-4 px-5 space-y-5 bg-surface custom-scrollbar overflow-x-hidden">
                    <!-- Technical Parameters -->
                    <section class="bg-surface-container-lowest rounded-sm border border-outline-variant/15 p-4 space-y-4 shadow-sm">
                        <div class="flex items-center gap-2 border-b border-surface-container-high pb-2">
                            <i class="pi pi-cog text-primary text-md"></i>
                            <h2 class="text-[12px] font-black uppercase tracking-widest text-on-surface">Technical Parameters</h2>
                        </div>
                        <div class="grid grid-cols-2 lg:grid-cols-3 gap-x-8 gap-y-6">
                            <div class="flex flex-col gap-0.5">
                                <label class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest">Customer</label>
                                <p class="text-[12px] font-black text-on-surface uppercase">{{ selectedRequest.customer }}</p>
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest">Device</label>
                                <p class="text-[12px] font-black text-on-surface uppercase font-mono">{{ selectedRequest.device }}</p>
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest">Package</label>
                                <p class="text-[12px] font-black text-on-surface uppercase">{{ selectedRequest.package }}</p>
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest">Tester</label>
                                <p class="text-[12px] font-black text-on-surface uppercase">{{ selectedRequest.tester }}</p>
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest">Pitch (mm)</label>
                                <p class="text-[12px] font-black text-on-surface">{{ selectedRequest.pitch }} MM</p>
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest">Handler Recipe</label>
                                <p class="text-[12px] font-black text-on-surface uppercase font-mono truncate">{{ selectedRequest.recipe }}</p>
                            </div>
                        </div>
                    </section>

                    <div class="grid grid-cols-12 gap-6 items-start overflow-hidden">
                        <!-- Hardware Configuration -->
                        <section class="col-span-12 lg:col-span-8 bg-surface-container-lowest rounded-sm border border-outline-variant/15 p-4 space-y-2 shadow-sm min-w-0 overflow-hidden">
                            <div class="flex items-center gap-2 border-b border-surface-container-high pb-2">
                                <i class="pi pi-server text-primary text-md"></i>
                                <h2 class="text-[12px] font-black uppercase tracking-widest text-on-surface">Hardware Configuration</h2>
                            </div>
                            <BaseTable :columns="tableColumns" :rowData="hardwareComponents" :paginator="false" tableHeight="220px" class="w-full">
                                <template #type="{ data }">
                                    <span class="font-bold text-on-surface uppercase text-[12px]">{{ data.type }}</span>
                                </template>
                                <template #code="{ data }">
                                    <span class="font-bold text-on-surface uppercase text-[12px] font-mono">{{ data.code }}</span>
                                </template>
                            </BaseTable>
                        </section>

                        <!-- Attachments -->
                        <section class="col-span-12 lg:col-span-4 bg-surface-container-lowest rounded-sm border border-outline-variant/15 p-4 space-y-4 shadow-sm min-w-0 overflow-hidden">
                            <div class="flex items-center gap-2 border-b border-surface-container-high pb-2">
                                <i class="pi pi-paperclip text-primary text-md"></i>
                                <h2 class="text-[12px] font-black uppercase tracking-widest text-on-surface">Attachments</h2>
                            </div>
                            <div class="space-y-3">
                                <div v-for="(file, index) in attachments" :key="index" @click="openAttachment(file)"
                                    class="flex items-center gap-3 p-2.5 bg-surface border border-outline-variant/10 rounded-sm hover:border-primary/30 transition-all cursor-pointer group overflow-hidden">
                                    <i :class="['text-xl transition-colors shrink-0', file.FileType === 'pdf' ? 'pi pi-file-pdf text-error' : 'pi pi-file-excel text-success']"></i>
                                    <div class="flex-1 min-w-0">
                                        <p class="text-[11px] font-black text-on-surface truncate group-hover:text-primary uppercase tracking-tight">{{ file.FileName }}</p>
                                        <p class="text-[9px] text-on-surface-variant font-bold uppercase tracking-tighter">{{ file.FileSize }}</p>
                                    </div>
                                    <i class="pi pi-download text-[11px] text-on-surface-variant group-hover:text-primary shrink-0"></i>
                                </div>
                                <div v-if="attachments.length === 0" class="text-center p-4 opacity-40 italic">
                                    No attachments
                                </div>
                            </div>
                        </section>
                    </div>
                </div>

                <!-- Action Panel -->
                <div class="p-3 bg-surface-container-low border-t border-outline-variant/30 shrink-0 shadow-[0_-4px_12px_rgba(0,0,0,0.05)] z-20">
                    <div class="flex items-center gap-5">
                        <div class="flex-1 min-w-0">
                            <div class="flex items-center gap-1.5 mb-1 px-1">
                                <i class="pi pi-pencil text-[11px] text-primary"></i>
                                <label class="text-[10px] font-black uppercase tracking-widest text-on-surface-variant">Review Notes</label>
                            </div>
                            <Textarea v-model="comment" class="custom-textarea w-full !text-[12px] !py-2 !px-3 font-bold" placeholder="Decision notes..." rows="1" autoResize />
                        </div>
                        <div class="flex items-center gap-3 shrink-0 pt-4">
                            <Button label="Reject" icon="pi pi-times" severity="danger" variant="outlined" :loading="isProcessing"
                                class="py-3 px-6 text-[11px] font-black uppercase tracking-[0.15em] rounded-sm" @click="onReject" />
                            <Button label="Approve" icon="pi pi-check" :loading="isProcessing"
                                class="py-3 px-6 text-[11px] font-black uppercase tracking-[0.15em] bg-primary border-none rounded-sm shadow-md shadow-primary/20" @click="onApprove" />
                        </div>
                    </div>
                </div>
            </template>
        </section>

        <!-- Loading Overlay -->
        <div v-if="isProcessing" class="fixed inset-0 z-[100] flex flex-col items-center justify-center bg-black/20 backdrop-blur-[1px]">
            <ProgressSpinner style="width: 40px; height: 40px" />
        </div>

        <!-- Success Dialog -->
        <Dialog v-model:visible="showSuccessDialog" modal header="Success" :style="{ width: '25rem' }" :closable="false">
            <div class="flex flex-col items-center gap-4 py-4">
                <i class="pi pi-check-circle text-success text-6xl"></i>
                <p class="text-center font-black text-[14px] uppercase tracking-tighter">{{ successDialogMsg }}</p>
            </div>
            <template #footer>
                <div class="flex justify-center w-full">
                    <Button label="Close" severity="success" class="px-8 py-2 font-black uppercase text-[11px] tracking-widest" @click="showSuccessDialog = false" />
                </div>
            </template>
        </Dialog>

        <!-- Confirmation Dialog -->
        <ConfirmDialog />

        <!-- Decorative Footer -->
        <footer class="h-1 bg-surface-container flex fixed bottom-0 w-full z-50">
            <div class="w-1/3 h-full bg-error/40"></div>
            <div class="w-1/3 h-full bg-tertiary"></div>
            <div class="w-1/3 h-full bg-primary/40"></div>
        </footer>
    </div>
</template>

<style scoped>
/* Xử lý triệt để scroll ngang của Table */
:deep(.p-datatable-table) {
    width: 100% !important;
    table-layout: fixed !important;
}

:deep(.custom-datatable-simple .p-datatable-thead > tr > th) {
    background-color: var(--p-surface-container-high);
    color: var(--p-on-surface-variant);
    padding: 0.5rem 0.75rem;
    border-bottom: 1px solid var(--p-surface-container);
}

:deep(.custom-datatable-simple .p-datatable-tbody > tr > td) {
    padding: 0.5rem 0.75rem;
    border-bottom: 1px solid var(--p-surface-container);
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}

/* Custom Paginator Styling */
:deep(.custom-compact-paginator) {
    background: transparent !important;
    border: none !important;
    padding: 0 !important;
}

:deep(.custom-compact-paginator .p-paginator-content) {
    gap: 0.5rem;
}

:deep(.custom-compact-paginator .p-paginator-page, 
      .custom-compact-paginator .p-paginator-next, 
      .custom-compact-paginator .p-paginator-prev) {
    min-width: 2rem !important;
    height: 2rem !important;
    font-size: 11px !important;
    font-weight: bold !important;
}

:deep(.p-paginator-current) {
    font-size: 10px !important;
    font-weight: 800 !important;
    color: var(--p-on-surface-variant) !important;
    text-transform: uppercase;
}

/* Override Textarea */
:deep(.custom-textarea) {
    background-color: var(--p-surface-container-lowest);
    border: 1px solid rgba(119, 117, 135, 0.2);
    border-radius: 0.125rem;
    transition: all 0.2s;
}

:deep(.custom-textarea:focus) {
    border-color: var(--p-primary);
    box-shadow: 0 0 0 1px var(--p-primary);
}

/* Custom Scrollbar (Làm nổi bật hơn) */
.custom-scrollbar::-webkit-scrollbar {
    width: 6px;
}
.custom-scrollbar::-webkit-scrollbar-track {
    background: rgba(0, 0, 0, 0.03);
    border-radius: 10px;
}
.custom-scrollbar::-webkit-scrollbar-thumb {
    background: var(--p-primary-300);
    border-radius: 10px;
    border: 1px solid transparent;
}
.custom-scrollbar::-webkit-scrollbar-thumb:hover {
    background: var(--p-primary-400);
}
</style>
