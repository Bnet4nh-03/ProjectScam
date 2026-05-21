<template>
    <div class="grid">
        <div class="col-12">
            <DataTable ref="dt" :value="roles" v-model:selection="selectedRoles" dataKey="id" :paginator="true"
                :rows="10" :filters="filters"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 25]"
                currentPageReportTemplate="Hiển thị từ {first} đến {last} của {totalRecords} nhóm quyền"
                responsiveLayout="scroll">
                <template #header>
                    <Toolbar class="border-none p-0">
                        <template v-slot:start>
                            <span class="p-input-icon-left">
                                <InputText v-model="filters['global'].value" placeholder="Tìm kiếm..." />
                            </span>
                        </template>
                        <template v-slot:end>
                            <div class="flex gap-2">
                                <Button label="Thêm mới" icon="pi pi-plus" class="p-button-success" @click="openNew" />
                                <Button label="Xóa" icon="pi pi-trash" class="p-button-danger"
                                    @click="confirmDeleteSelected"
                                    :disabled="!selectedRoles || !selectedRoles.length" />
                            </div>
                        </template>
                    </Toolbar>
                </template>

                <Column selectionMode="multiple" headerStyle="width: 3rem"></Column>
                <Column field="name" header="Tên Nhóm quyền" :sortable="true" headerStyle="width:30%; min-width:10rem;">
                    <template #body="slotProps">
                        {{ slotProps.data.name }}
                    </template>
                </Column>
                <Column field="description" header="Mô tả" headerStyle="width:50%; min-width:10rem;">
                    <template #body="slotProps">
                        {{ slotProps.data.description }}
                    </template>
                </Column>
                <Column header="Hành động" :exportable="false" headerStyle="min-width:8rem;">
                    <template #body="slotProps">
                        <Button icon="pi pi-pencil" class="p-button-rounded p-button-success mr-2"
                            @click="editRole(slotProps.data)" />
                        <Button icon="pi pi-trash" class="p-button-rounded p-button-warning"
                            @click="confirmDeleteRole(slotProps.data)" />
                    </template>
                </Column>
            </DataTable>

            <Dialog v-model:visible="roleDialog" :style="{ width: '750px' }" header="Chi tiết Nhóm quyền" :modal="true">

                <div class="field mt-2">
                    <FloatLabel variant="on">
                        <label for="name">Tên</label>
                        <InputText id="name" v-model.trim="role.name" required="true" autofocus style="width: 100%;"
                            :class="{ 'p-invalid': submitted && !role.name }" />
                    </FloatLabel>
                    <small class="p-invalid" v-if="submitted && !role.name">Tên nhóm quyền không được để
                        trống.</small>

                </div>
                <div class="field mt-3">
                    <FloatLabel variant="on">
                        <label for="description">Mô tả</label>
                        <Textarea id="description" v-model="role.description" required="true" rows="2"
                            style="width: 100%;" />
                    </FloatLabel>

                </div>

                <div class="field">
                    <label class="mb-3">Quyền hạn</label>
                    <PickList v-model="pickListPermissions" listStyle="height:342px" dataKey="id" filter>
                        <template #sourceheader>Có sẵn</template>
                        <template #targetheader>Đã gán</template>
                        <template #item="slotProps">
                            <div class="flex align-items-center p-2" :title="slotProps.item.description">
                                <div class="font-bold">{{ slotProps.item.name }}</div>
                            </div>
                        </template>
                    </PickList>
                </div>
                <template #footer>
                    <Button label="Hủy" icon="pi pi-times" class="p-button-text" @click="hideDialog" />
                    <Button label="Lưu" icon="pi pi-check" class="p-button-text" @click="saveRole" />
                </template>
            </Dialog>

            <Dialog v-model:visible="deleteRoleDialog" :style="{ width: '450px' }" header="Xác nhận" :modal="true">
                <div class="flex align-items-center justify-content-center">
                    <i class="pi pi-exclamation-triangle mr-3" style="font-size: 2rem" />
                    <span v-if="role">Bạn có chắc chắn muốn xóa <b>{{ role.name }}</b>?</span>
                </div>
                <template #footer>
                    <Button label="Không" icon="pi pi-times" class="p-button-text" @click="deleteRoleDialog = false" />
                    <Button label="Có" icon="pi pi-check" class="p-button-text" @click="deleteRole" />
                </template>
            </Dialog>

            <Dialog v-model:visible="deleteRolesDialog" :style="{ width: '450px' }" header="Xác nhận" :modal="true">
                <div class="flex align-items-center justify-content-center">
                    <i class="pi pi-exclamation-triangle mr-3" style="font-size: 2rem" />
                    <span>Bạn có chắc chắn muốn xóa các nhóm quyền đã chọn?</span>
                </div>
                <template #footer>
                    <Button label="Không" icon="pi pi-times" class="p-button-text" @click="deleteRolesDialog = false" />
                    <Button label="Có" icon="pi pi-check" class="p-button-text" @click="deleteSelectedRoles" />
                </template>
            </Dialog>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';
import { FilterMatchMode } from '@primevue/core/api';
import { useToast } from 'primevue/usetoast';
import { AdminService } from '@/modules/admin/services/AdminService';

const toast = useToast();
const dt = ref(null);
const roles = ref([]);
const permissions = ref([]);
const pickListPermissions = ref([[], []]); // Source and target lists for PickList
const roleDialog = ref(false);
const deleteRoleDialog = ref(false);
const deleteRolesDialog = ref(false);
const role = ref({});
const selectedRoles = ref(null);
const filters = ref({});
const submitted = ref(false);
const loading = ref(true);

const adminService = new AdminService();

onMounted(() => {
    adminService.getRoles().then((data) => {
        roles.value = data;
        loading.value = false;
    });
    adminService.getPermissions().then((data) => (permissions.value = data));
});

const initFilters = () => {
    filters.value = {
        global: { value: null, matchMode: FilterMatchMode.CONTAINS }
    };
};
initFilters();

const openNew = () => {
    role.value = {};
    submitted.value = false;
    // Set up PickList: all permissions available, none assigned
    pickListPermissions.value = [permissions.value, []];
    roleDialog.value = true;
};

const hideDialog = () => {
    roleDialog.value = false;
    submitted.value = false;
};

const saveRole = () => {
    submitted.value = true;
    if (!role.value.name || !role.value.name.trim()) {
        return;
    }

    // Assigned permissions are in the target list
    role.value.permissions = pickListPermissions.value[1].map(p => p.id);

    const isUpdate = !!role.value.id;

    const savePromise = isUpdate
        ? adminService.updateRole(role.value)
        : adminService.createRole(role.value);

    savePromise
        .then(savedRole => {
            if (isUpdate) {
                const index = roles.value.findIndex(r => r.id === savedRole.id);
                if (index !== -1) {
                    roles.value[index] = savedRole;
                }
            } else {
                roles.value.push(savedRole);
            }

            roleDialog.value = false;
            role.value = {};

            toast.add({
                severity: 'success',
                summary: 'Thành công',
                detail: `Nhóm quyền đã được ${isUpdate ? 'cập nhật' : 'tạo'}`,
                life: 3000
            });
        })
        .catch(error => {
            console.error(`Error ${isUpdate ? 'updating' : 'creating'} role:`, error);
            toast.add({
                severity: 'error',
                summary: 'Lỗi',
                detail: `Không thể ${isUpdate ? 'cập nhật' : 'tạo'} nhóm quyền`,
                life: 3000
            });
        });
};

const editRole = (editRole) => {
    role.value = { ...editRole };
    const assignedIds = new Set(role.value.permissions || []);
    const assigned = permissions.value.filter(p => assignedIds.has(p.id));
    const available = permissions.value.filter(p => !assignedIds.has(p.id));
    pickListPermissions.value = [available, assigned];
    roleDialog.value = true;
};

const confirmDeleteRole = (deleteRole) => {
    role.value = deleteRole;
    deleteRoleDialog.value = true;
};

const deleteRole = () => {
    adminService.deleteRole(role.value.id).then(() => {
        roles.value = roles.value.filter((val) => val.id !== role.value.id);
        deleteRoleDialog.value = false;
        role.value = {};
        toast.add({ severity: 'success', summary: 'Thành công', detail: 'Nhóm quyền đã được xóa', life: 3000 });
    }).catch(error => {
        console.error("Error deleting role:", error);
        toast.add({ severity: 'error', summary: 'Lỗi', detail: 'Không thể xóa nhóm quyền', life: 3000 });
    });
};

const confirmDeleteSelected = () => {
    deleteRolesDialog.value = true;
};

const deleteSelectedRoles = () => {
    const promises = selectedRoles.value.map(roleToDelete => adminService.deleteRole(roleToDelete.id));

    Promise.all(promises).then(() => {
        roles.value = roles.value.filter((val) => !selectedRoles.value.includes(val));
        deleteRolesDialog.value = false;
        selectedRoles.value = null;
        toast.add({ severity: 'success', summary: 'Thành công', detail: 'Các nhóm quyền đã chọn đã được xóa', life: 3000 });
    }).catch(error => {
        console.error("Error deleting selected roles:", error);
        toast.add({ severity: 'error', summary: 'Lỗi', detail: 'Không thể xóa các nhóm quyền đã chọn', life: 3000 });
    });
};



</script>
