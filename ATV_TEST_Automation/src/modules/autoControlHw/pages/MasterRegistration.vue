<script setup>
import { onMounted, inject, ref, watch } from 'vue';
import cpnAutoComplete from '../component/cpnAutoComplete.vue';
import BaseTable from '../component/BaseTable.vue';
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import MasterRegistrationService from '../services/MasterRegistrationService';
import { getStatusStyle } from '../utils/variable';
import _ from "lodash";
const gVariable = inject('gVariable');
const gFunc = inject('gFunc');
const apiClient = inject('apiClient');
const authStore = useAuthStore();
const masterRegistrationService = new MasterRegistrationService(apiClient);

const activeTab = ref('0');

// Model tập trung cho toàn bộ form
const masterData = ref({
    customer: null,
    device: null,
    tester: null,
    package: null,
    pitch: 0,
    handlerRecipe: '',
    hardwareList: [],
    attachments: [],
    approver: null
});

const tableColumns = ref([
    { label: 'Component Type', field: 'type' },
    { label: 'Reference Code', field: 'code' },
    { label: 'Ops', field: 'ops', headerClass: '!flex !justify-center', bodyClass: '!text-center' }
]);

// Các biến tạm cho việc thêm hardware
const hardware = ref(null);
const hardwares = ref([]);
const componentType = ref(null);
const isLoadingHardware = ref(false);
const isSubmitting = ref(false);
const showSuccessDialog = ref(false);
const showConfirmDialog = ref(false);

// Danh mục dữ liệu cho dropdowns
const customers = ref([]);
const devices = ref([]);
const testers = ref([]);
const packages = ref([]);
const componentTypes = ref([]);
const lstApprovers = ref([]);

// State cho Tab lịch sử
const historyData = ref([]);
const isHistoryLoading = ref(false);
const historyColumns = [
    { label: 'Date', field: 'date' },
    { label: 'Device', field: 'device' },
    { label: 'Customer', field: 'customer' },
    { label: 'Status', field: 'status' },
    { label: 'Reason', field: 'reason' }
];


onMounted(async () => {
    try {
        // Load initial categories data
        customers.value = await masterRegistrationService.getListCustomer();
        devices.value = await masterRegistrationService.getListDevice();
        testers.value = await masterRegistrationService.getListTester();
        packages.value = await masterRegistrationService.getListPackage();
        componentTypes.value = await masterRegistrationService.getListComponentTypes();
        lstApprovers.value = await masterRegistrationService.getListDoubleCheckApprove(
            authStore.userInfo.department,
            authStore.userInfo.badge_no
        );

        await loadHistory();
    } catch (error) {
        gFunc.ShowMessage('Error loading initial data: ' + error.message, 'error');
    }
});

const loadHistory = async () => {
    isHistoryLoading.value = true;
    try {
        const res = await masterRegistrationService.getMyHistory(authStore.userInfo.badge_no);
        historyData.value = res || [];
    } catch (error) {
        console.error('Load history failed', error);
    } finally {
        isHistoryLoading.value = false;
    }
};

const getStatusSeverity = (status) => {
    switch (status) {
        case 'REGISTERED': return 'success';
        case 'WAIT REGISTER': return 'warn';
        case 'REJECTED': return 'danger';
        case 'RETURNED': return 'danger';
        case 'PENDING': return 'secondary';
        default: return 'info';
    }
};

const getStatusIcon = (status) => {
    switch (status) {
        case 'REGISTERED': return 'pi pi-check-circle';
        case 'WAIT REGISTER': return 'pi pi-clock';
        case 'REJECTED': return 'pi pi-times-circle';
        case 'RETURNED': return 'pi pi-backward';
        case 'PENDING': return 'pi pi-spinner';
        default: return 'pi pi-info-circle';
    }
};

watch(componentType, async (newVal) => {
    hardware.value = null;
    hardwares.value = [];
    if (newVal && newVal.code) {
        isLoadingHardware.value = true;
        try {
            hardwares.value = await masterRegistrationService.getListHardware(newVal.code);
        } catch (error) {
            gFunc.ShowMessage('Error loading hardware list: ' + error.message, 'error');
        } finally {
            isLoadingHardware.value = false;
        }
    }
});

const onFileSelect = (event) => {
    const files = event.files;
    files.forEach((file) => {
        const sizeInMB = (file.size / (1024 * 1024)).toFixed(1) + ' MB';
        const extension = file.name.split('.').pop().toLowerCase();

        masterData.value.attachments.push({
            FileName: file.name,
            FileSize: sizeInMB,
            FileType: extension,
            objectURL: file.objectURL,
            rawFile: file // Quan trọng: lưu file vật lý để upload
        });
    });
};

const removeFile = (index) => {
    masterData.value.attachments.splice(index, 1);
    gFunc.ShowMessage('File removed', 'info', '', 2000);
};

const onAppend = () => {
    if (componentType.value && hardware.value) {
        // Check duplicate
        const isDuplicate = masterData.value.hardwareList.some(item =>
            item.type.code === componentType.value.code &&
            item.code.code === hardware.value.code
        );

        if (isDuplicate) {
            gFunc.ShowMessage('This hardware is already in the list', 'warn');
            return;
        }

        masterData.value.hardwareList.push({
            type: componentType.value,
            code: hardware.value
        });
        hardware.value = null;
    }
};

const removeHardware = (index) => {
    masterData.value.hardwareList.splice(index, 1);
    gFunc.ShowMessage('Hardware removed from list', 'info', '', 2000);
};

/**
 * Hàm upload file đơn lẻ lên server
 */
async function performUpload(fileUpload) {
    const metadata = {
        uploadedBy: authStore.userInfo.badge_no,
        uploadTimestamp: new Date().toISOString(),
        "AppName": "AutoControlHardware",
        "SaveMode": "Rename",
    };
    const result = await apiClient.uploadFile(fileUpload, metadata);
    if (result && result.fullFilePath) {
        return result.fullFilePath;
    }
    throw new Error('Upload failed: No path returned from server');
}

const onSubmit = () => {
    // 1. Validation
    if (!masterData.value.customer) { gFunc.ShowMessage('Please select a Customer', 'error'); return; }
    if (!masterData.value.device) { gFunc.ShowMessage('Please select a Device', 'error'); return; }
    if (!masterData.value.package) { gFunc.ShowMessage('Please select a Package', 'error'); return; }
    if (!masterData.value.tester) { gFunc.ShowMessage('Please select a Tester', 'error'); return; }
    if (!masterData.value.pitch) { gFunc.ShowMessage('Please input Pitch', 'error'); return; }
    if (!masterData.value.handlerRecipe) { gFunc.ShowMessage('Please input Handler recipe', 'error'); return; }
    if (masterData.value.hardwareList.length === 0) { gFunc.ShowMessage('Please add at least one hardware mapping', 'error'); return; }
    // if (!masterData.value.approver) { gFunc.ShowMessage('Please select an Approver', 'error'); return; }

    showConfirmDialog.value = true;
};

const executeSubmit = async () => {
     
    showConfirmDialog.value = false;
    isSubmitting.value = true;
    try {
        // 2. Upload files (đợi hoàn thành tất cả)
        if (masterData.value.attachments.length > 0) {
            for (let fileObj of masterData.value.attachments) {
                // Chỉ upload những file mới chọn (có rawFile và chưa có FilePath)
                if (!fileObj.FilePath && fileObj.rawFile) {
                    fileObj.FilePath = await performUpload(fileObj.rawFile);
                }
            }
        }
        // await sendEmail();
        // 3. Submit data to Database via Service (gọi SP)
        const res = await masterRegistrationService.submitMasterRegistration(
            masterData.value,
            authStore.userInfo.badge_no
        );
        const masterId = res[0].data[0].MasterID;
        // 4. Kiểm tra kết quả
        if (res && res.length > 0 && res[0]['data'][0]['Result'] === 0) {
            showSuccessDialog.value = true;
            await acceptRequest(masterId);
            resetForm();
        } else {
            const errorMsg = (res && res.length > 0) ? res[0]['data'][0]['Message'] : 'Unknown error';
            throw new Error(errorMsg);
        }
    } catch (error) {
        gFunc.ShowMessage('Process failed: ' + error.message, 'error');
    } finally {
        isSubmitting.value = false;
    }
};
async function acceptRequest(masterId) {

    // var flowOrder = 1;
    var flowOrder = 2;
    
    var params = {
        "@master_id": masterId, // UNIQUEIDENTIFIER = NULL
        "@request_title": "[" + gFunc.ConvertDate(new Date(), 'YYMMDDHHmmss') + "]" + "Request ACH",
        "@badgeno": authStore.userInfo.badge_no, // VARCHAR(50)
        "@flow_id": 27, // BIGINT
        "@comment": "", // NVARCHAR(MAX)
        "@flow_order": flowOrder, // INT
    };

    var res = gFunc.CheckResData(await apiClient.callSp("[TestDB]..[USP_ACH_SetRequest]", params));
    if (res.isCheck) {
        gFunc.ShowMessage("Your request has been submit successfully.", "", "", 3000);
        // Get request ID
       
            //await sendEmail();
       

    }
};

function renderRequest(masterData) {
    // Render hardware list: TYPE_NAME : HARDWARE_NAME
    const hardwareHtml = masterData.hardwareList?.map(hw => {
        const typeName = hw.type?.name || '';
        const hardwareName = hw.code?.name || '';
        return `<div>• ${typeName} : ${hardwareName}</div>`;
    }).join('') || '';

    return `
        <h3 style="color:#667eea; margin-bottom:15px;">📋 Master Information</h3>

        <table style="width:100%; border-collapse:collapse; font-size:14px;">
            <tbody>

                <tr style="background-color:#f8f9ff;">
                    <td style="width:25%; padding:10px; font-weight:bold;">Customer</td>
                    <td style="padding:10px;">${masterData.customer?.name || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Device</td>
                    <td style="padding:10px;">${masterData.device?.name || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Package</td>
                    <td style="padding:10px;">${masterData.package?.name || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Tester</td>
                    <td style="padding:10px;">${masterData.tester?.name || ''}</td>
                </tr>

                <tr style="background-color:#f8f9ff;">
                    <td style="padding:10px; font-weight:bold;">Pitch</td>
                    <td style="padding:10px;">${masterData.pitch || ''}</td>
                </tr>

                <tr>
                    <td style="padding:10px; font-weight:bold;">Handler Recipe</td>
                    <td style="padding:10px;">${masterData.handlerRecipe || ''}</td>
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
async function sendEmail() {
   
    var flowOrder = 1;
    
    var listApprover = await getApproverList();
    const targetFlowOrder = (flowOrder === 1001) ? 1 : 999;
    var toMailList = listApprover.data.find( item => item.flow_id === 27 && item.flow_order === targetFlowOrder).list_email;
    
    const mailArray = toMailList
    .split(';')      // tách theo dấu ;
    .map(m => m.trim()) // loại bỏ khoảng trắng
    .filter(Boolean);

   
    var requestTable = renderRequest(masterData.value);
    var tbodyNotify = ``;
    // if (flowOrder <= 3) {
    //     tbodyNotify = `    
    //     <div style="padding:30px;">
    //         <strong>Dear Team TPE,</strong>
    //     </div>
    //     <p>You have received a new request. Please review the request below.</p>`
    // }
    if (flowOrder <= 3) {
        tbodyNotify = `    
        <div style="padding:30px;">
            <strong>Dear Team,</strong>
        </div>
        <p>You have received a new request. Please review the request below.</p>`
    }
    else {
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
    var param = {
        "mailPriority": "HIGH",
        "sender": gVariable.sender.autoHW,
        "subject": "TPE Check Master Registration",
        "body": _.toString(body),
        "toMailList":mailArray,
        "ccMailList": [],
        "bccMailList": gVariable.groupMail.bccAutoHWMailList,
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

const resetForm = () => {
    masterData.value = {
        customer: null,
        device: null,
        tester: null,
        package: null,
        pitch: 0,
        handlerRecipe: '',
        hardwareList: [],
        attachments: [],
        approver: null
    };
    hardware.value = null;
    componentType.value = null;
};
</script>

<template>
    <div
        class="card flex flex-col h-[calc(100vh-12.5rem)] bg-surface text-on-surface p-0 overflow-hidden font-body border-none shadow-sm">
        <Tabs v-model:value="activeTab">
            <TabList class="px-6 bg-surface-container-low/50">
                <Tab value="0" class="!text-[11px] font-black uppercase tracking-widest py-4">
                    <i class="pi pi-plus-circle mr-2"></i>New Registration
                </Tab>
                <Tab value="1" class="!text-[11px] font-black uppercase tracking-widest py-4" @click="loadHistory">
                    <i class="pi pi-history mr-2"></i>My History
                </Tab>
            </TabList>

            <TabPanels class="!p-0 flex-1 overflow-hidden">
                <!-- Tab 1: Registration Form -->
                <TabPanel value="0" class="!p-0 h-[calc(100vh-15.5rem)] flex flex-col">
                    <div class="flex-1 overflow-y-auto py-4 px-4 md:px-4 custom-scrollbar">
                        <div class="space-y-4 pb-2">
                            <!-- Technical Parameters -->
                            <section
                                class="bg-surface-container-lowest rounded-sm border border-outline-variant/15 p-3 space-y-6 shadow-sm">
                                <div class="flex items-center gap-2 border-b border-surface-container-high pb-2">
                                    <i class="pi pi-cog text-primary text-lg"></i>
                                    <h2 class="text-sm font-bold uppercase tracking-wider text-on-surface">Technical
                                        Parameters</h2>
                                </div>
                                <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-x-6 gap-y-6">
                                    <div class="flex flex-col gap-1.5">
                                        <FloatLabel class="w-full" variant="on">
                                            <Select v-model="masterData.customer" inputId="customer_id"
                                                :options="customers" optionLabel="name" class="w-full" showClear filter>
                                                <!-- Selected value -->
                                                <template #value="slotProps">
                                                    <span v-if="slotProps.value">
                                                        {{ slotProps.value.name }} - {{ slotProps.value.code }}
                                                    </span>
                                                </template>
                                                <template #option="slotProps">
                                                    {{ slotProps.option.name }} - {{ slotProps.option.code }}
                                                </template>

                                            </Select>
                                            <label class="uppercase tracking-widest" for="customer_id">Customer</label>
                                        </FloatLabel>
                                    </div>
                                    <div class="flex flex-col gap-1.5">
                                        <cpnAutoComplete inputId="device_id" v-model="masterData.device" v-model:items="devices"
                                            optionLabel="name" label="Device" required />
                                    </div>
                                    <div class="flex flex-col gap-1.5 w-full">
                                        <cpnAutoComplete inputId="package_id" v-model="masterData.package" v-model:items="packages"
                                            optionLabel="name" label="Package" required />
                                    </div>
                                    <div class="flex flex-col gap-1.5">
                                        <FloatLabel class="w-full" variant="on">
                                            <Select v-model="masterData.tester" inputId="tester_id" :options="testers"
                                                optionLabel="name" class="w-full" showClear filter />
                                            <label class="uppercase tracking-widest" for="tester_id">Tester</label>
                                        </FloatLabel>
                                    </div>
                                    <div class="flex flex-col gap-1.5">
                                        <InputGroup>
                                            <FloatLabel variant="on">
                                                <InputNumber id="pitch_id" v-model="masterData.pitch" locale="de-DE"
                                                    :minFractionDigits="2" />
                                                <label class="uppercase tracking-widest" for="pitch_id">Pitch
                                                    (mm)</label>
                                            </FloatLabel>
                                            <InputGroupAddon>MM</InputGroupAddon>
                                        </InputGroup>
                                    </div>
                                    <div class="flex flex-col gap-1.5 w-full">
                                        <FloatLabel class="w-full" variant="on">
                                            <InputText class="w-full" id="recipe_id"
                                                v-model="masterData.handlerRecipe" />
                                            <label class="uppercase tracking-widest" for="recipe_id">Handler
                                                Recipe</label>
                                        </FloatLabel>
                                    </div>
                                </div>
                            </section>

                            <div class="grid grid-cols-12 gap-4 items-start">
                                <!-- Hardware Mapping -->
                                <section
                                    class="col-span-12 lg:col-span-9 bg-surface-container-lowest rounded-sm border border-outline-variant/15 p-4 space-y-2 shadow-sm">
                                    <div class="flex items-center justify-between">
                                        <div class="flex items-center gap-2">
                                            <i class="pi pi-server text-primary text-lg"></i>
                                            <h2 class="text-sm font-bold uppercase tracking-wider text-on-surface">
                                                Hardware Configuration & Mapping
                                            </h2>
                                        </div>
                                    </div>
                                    <div
                                        class="bg-surface-container-low p-3 rounded-sm border border-outline-variant/30 grid grid-cols-1 md:grid-cols-12 gap-4 items-end">
                                        <div class="md:col-span-4 flex flex-col gap-2">
                                            <FloatLabel class="w-full" variant="on">
                                                <Select v-model="componentType" inputId="comp_type_id"
                                                    :options="componentTypes" optionLabel="name" class="w-full"
                                                    showClear filter />
                                                <label class="uppercase tracking-widest" for="comp_type_id">Component
                                                    Type</label>
                                            </FloatLabel>
                                        </div>
                                        <div class="md:col-span-6 flex flex-col gap-2">
                                            <FloatLabel class="w-full" variant="on">
                                                <Select v-model="hardware" inputId="hw_id" :options="hardwares"
                                                    optionLabel="name" class="w-full" showClear filter
                                                    :loading="isLoadingHardware" />
                                                <label class="uppercase tracking-widest" for="hw_id">Select
                                                    hardware</label>
                                            </FloatLabel>
                                        </div>
                                        <div class="md:col-span-2">
                                            <Button label="Append" icon="pi pi-plus"
                                                class="w-full h-11 text-[11px] font-bold uppercase tracking-widest rounded-sm shadow-sm"
                                                :disabled="!componentType || !hardware" @click="onAppend" />
                                        </div>
                                    </div>
                                    <BaseTable :columns="tableColumns" :rowData="masterData.hardwareList"
                                        :paginator="false" tableHeight="300px">
                                        <template #type="{ data }">
                                            <span class="font-bold text-on-surface text-[12px] uppercase">{{
                                                data.type?.name || data.type }}</span>
                                        </template>
                                        <template #code="{ data }">
                                            <span class="font-bold text-on-surface text-[12px] font-mono">{{
                                                data.code?.name || data.code }}</span>
                                        </template>
                                        <template #ops="{ index }">
                                            <div class="w-full text-center">
                                                <Button icon="pi pi-trash" severity="danger" rounded class="p-button-md"
                                                    variant="outlined" @click="removeHardware(index)" />
                                            </div>
                                        </template>
                                    </BaseTable>
                                </section>

                                <!-- File Attachments -->
                                <section
                                    class="col-span-12 lg:col-span-3 bg-surface-container-lowest rounded-sm border border-outline-variant/15 p-4 shadow-sm space-y-4">
                                    <div
                                        class="flex items-center justify-between border-b border-surface-container-high pb-3">
                                        <div class="flex items-center gap-2">
                                            <i class="pi pi-paperclip text-primary text-lg"></i>
                                            <h2 class="text-sm font-bold uppercase tracking-wider text-on-surface">
                                                Attachments</h2>
                                        </div>
                                    </div>
                                    <div class="space-y-4">
                                        <FileUpload mode="basic" name="demo[]"
                                            accept="image/*,.pdf,.xls,.xlsx,.txt,.doc,.docx" :maxFileSize="10485760"
                                            @select="onFileSelect" :auto="true" chooseLabel="Upload"
                                            class="w-full p-button-sm text-[10px] font-bold uppercase tracking-widest"
                                            icon="pi pi-upload" />
                                        <div class="space-y-2 mt-4 overflow-y-auto max-h-[300px] custom-scrollbar">
                                            <p
                                                class="text-[10px] font-bold text-on-surface-variant uppercase tracking-widest border-b pb-1">
                                                Files ({{ masterData.attachments.length }}/5)</p>
                                            <div v-for="(file, index) in masterData.attachments" :key="index"
                                                class="flex items-center gap-2 p-2 bg-surface border border-outline-variant/10 rounded-sm hover:border-primary/30 transition-colors">
                                                <i :class="file.FileType === 'pdf' ? 'pi pi-file-pdf text-error' : 'pi pi-file text-primary'"
                                                    class="text-lg"></i>
                                                <div class="flex-1 min-w-0">
                                                    <p class="text-[10px] font-bold text-on-surface truncate uppercase">
                                                        {{ file.FileName }}</p>
                                                    <p class="text-[9px] text-on-surface-variant font-bold">{{
                                                        file.FileSize }}</p>
                                                </div>
                                                <Button icon="pi pi-times" severity="secondary" text rounded
                                                    size="small" @click="removeFile(index)" />
                                            </div>
                                            <div v-if="masterData.attachments.length === 0"
                                                class="p-4 border border-dashed border-outline-variant/20 rounded-sm text-center opacity-50">
                                                <i class="pi pi-inbox text-2xl text-outline-variant mb-2"></i>
                                                <p class="text-[10px] text-outline font-bold uppercase">No files</p>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>

                    <!-- Sticky Footer -->
                    <footer
                        class="p-4 bg-surface-container-low border-t border-outline-variant/30 shrink-0 shadow-[0_-4px_12px_rgba(0,0,0,0.05)] z-20">
                        <div class="flex flex-col lg:flex-row items-center gap-6 justify-end">
                            <!-- <FloatLabel class="w-auto" variant="on">
                                <Select v-model="masterData.approver" inputId="approver_id" :options="lstApprovers"
                                    optionLabel="name" optionValue="code" class="w-full min-w-[300px]" showClear
                                    filter />
                                <label class="uppercase tracking-widest" for="approver_id">Double Check Approver</label>
                            </FloatLabel> -->
                            <div class="flex items-center gap-3 w-full lg:w-auto ">
                                <Button label="Submit" icon="pi pi-send" iconPos="right"
                                    class="px-10 py-4 text-[11px] font-black uppercase tracking-[0.15em] shadow-lg shadow-primary/20 bg-primary border-none rounded-sm"
                                    @click="onSubmit" />
                            </div>
                        </div>
                    </footer>
                </TabPanel>

                <!-- Tab 2: My History -->
                <TabPanel value="1" class="!p-0 h-[calc(100vh-16rem)]">
                    <div class="p-6 h-full flex flex-col">
                        <BaseTable :columns="historyColumns" :rowData="historyData" :paginator="true"
                            :loading="isHistoryLoading" tableHeight="calc(100vh-25rem)">
                            <template #date="{ data }">
                                <span class="text-[11px] font-bold text-on-surface-variant">{{ data.date }}</span>
                            </template>
                            <template #device="{ data }">
                                <span class="text-[12px] font-black uppercase text-primary font-mono">{{ data.device
                                    }}</span>
                            </template>
                            <template #customer="{ data }">
                                <span
                                    class="text-[11px] font-bold uppercase text-on-surface truncate block max-w-[200px]">{{
                                    data.customer }}</span>
                            </template>
                            <template #status="{ data }">
                                <Tag :severity="getStatusSeverity(data.status)" :value="data.status"
                                    :icon="getStatusIcon(data.status)"
                                    class="!text-[9px] !font-black !uppercase !tracking-widest !px-2 !py-1 rounded-sm" />
                            </template>
                            <template #reason="{ data }">
                                <div v-if="data.status === 'REJECTED' || data.status === 'RETURNED'"
                                    class="text-[11px] font-bold italic text-error truncate max-w-[300px]"
                                    v-tooltip.top="data.rejectReason || data.returnReason">
                                    <i class="pi pi-comment mr-1"></i>{{ data.rejectReason || data.returnReason }}
                                </div>
                                <span v-else class="text-[10px] opacity-30 italic font-bold">No issues</span>
                            </template>
                        </BaseTable>
                    </div>
                </TabPanel>
            </TabPanels>
        </Tabs>

        <!-- Loading Overlay -->
        <div v-if="isSubmitting"
            class="fixed inset-0 z-[100] flex flex-col items-center justify-center bg-black/30 backdrop-blur-[2px]">
            <div class="bg-surface-0 p-8 rounded-lg shadow-xl flex flex-col items-center">
                <ProgressSpinner style="width: 50px; height: 50px" strokeWidth="4" />
                <span class="mt-4 font-bold text-primary uppercase tracking-[0.2em] text-xs">Processing...</span>
            </div>
        </div>

        <!-- Success Dialog -->
        <Dialog v-model:visible="showSuccessDialog" modal header="Submission Successful" :style="{ width: '30rem' }"
            :closable="false">
            <div class="flex flex-col items-center py-6">
                <div class="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mb-4">
                    <i class="pi pi-check text-3xl text-green-600"></i>
                </div>
                <p class="text-lg font-bold text-center">Master Registered successfully!</p>
                <p class="text-sm text-surface-500 text-center mt-2">
                    Your hardware configuration has been submitted and is waiting for the Double Check approval.
                </p>
            </div>
            <template #footer>
                <div class="flex justify-center w-full">
                    <Button label="Close" class="px-10 py-3 font-bold" @click="showSuccessDialog = false" />
                </div>
            </template>
        </Dialog>

        <!-- Confirm Submit Dialog -->
        <Dialog v-model:visible="showConfirmDialog" modal header="Confirmation" :style="{ width: '25rem' }">
            <div class="flex items-center gap-4 py-4">
                <i class="pi pi-exclamation-triangle text-warn text-4xl"></i>
                <div class="flex flex-col">
                    <span class="font-bold text-lg">Are you sure?</span>
                    <span class="text-sm text-surface-500">Do you want to submit this hardware configuration for double
                        check?</span>
                </div>
            </div>
            <template #footer>
                <div class="flex justify-end gap-2">
                    <Button label="No" icon="pi pi-times" severity="secondary" variant="text"
                        @click="showConfirmDialog = false" />
                    <Button label="Yes, Submit" icon="pi pi-check" severity="primary" @click="executeSubmit"
                        autofocus />
                </div>
            </template>
        </Dialog>
    </div>
</template>

<style scoped>
.tracking-widest {
    letter-spacing: 0.1em;
    font-weight: 700 !important;
}
</style>
