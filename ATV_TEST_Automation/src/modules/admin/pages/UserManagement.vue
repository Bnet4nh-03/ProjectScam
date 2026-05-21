<template>
    <div class="grid">
        <div class="col-12">
            <DataTable ref="dt" :value="users" v-model:selection="selectedUsers" dataKey="id" :paginator="true"
                :rows="10" :filters="filters"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 25]"
                currentPageReportTemplate="Hiển thị từ {first} đến {last} của {totalRecords} người dùng"
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
                                    :disabled="!selectedUsers || !selectedUsers.length" />
                            </div>
                        </template>
                    </Toolbar>
                </template>

                <Column selectionMode="multiple" headerStyle="width: 3rem"></Column>
                <Column field="name" header="Tên" :sortable="true" headerStyle="width:20%; min-width:10rem;">
                    <template #body="slotProps">
                        {{ slotProps.data.name }}
                    </template>
                </Column>
                <Column field="email" header="Email" :sortable="true" headerStyle="width:25%; min-width:10rem;">
                    <template #body="slotProps">
                        {{ slotProps.data.email }}
                    </template>
                </Column>
                <Column field="roleId" header="Nhóm quyền" :sortable="true" headerStyle="width:20%; min-width:10rem;">
                    <template #body="slotProps">
                        <span class="image-text">{{ getRoleName(slotProps.data.roleId) }}</span>
                    </template>
                </Column>
                <Column field="status" header="Trạng thái" :sortable="true" headerStyle="width:20%; min-width:10rem;">
                    <template #body="slotProps">
                        <Tag :value="slotProps.data.status"
                            :severity="slotProps.data.status === 'Active' ? 'success' : 'danger'" />
                    </template>
                </Column>

                <Column header="Hành động" headerStyle="min-width:8rem;">
                    <template #body="slotProps">
                        <Button icon="pi pi-pencil" class="p-button-rounded p-button-success mr-2"
                            @click="editUser(slotProps.data)" />
                        <Button icon="pi pi-trash" class="p-button-rounded p-button-warning"
                            @click="confirmDeleteUser(slotProps.data)" />
                    </template>
                </Column>
            </DataTable>

            <Dialog v-model:visible="userDialog" :style="{ width: '750px' }" header="Chi tiết Người dùng" :modal="true">
                <div class="field mt-2">
                    <FloatLabel variant="on">
                        <label for="name">Tên</label>
                        <InputText id="name" v-model.trim="user.name" required="true" autofocus style="width: 100%;"
                            :class="{ 'p-invalid': submitted && !user.name }" />
                    </FloatLabel>
                    <small class="p-invalid" v-if="submitted && !user.name">Tên không được để trống.</small>
                </div>
                <div class="field mt-3">
                    <FloatLabel variant="on">
                        <label for="email">Email</label>
                        <InputText id="email" v-model.trim="user.email" required="true" style="width: 100%;"
                            :class="{ 'p-invalid': submitted && !user.email }" />
                    </FloatLabel>
                    <small class="p-invalid" v-if="submitted && !user.email">Email không được để trống.</small>
                </div>
                <div class="field mt-3">
                    <FloatLabel variant="on">
                        <Select id="role" v-model="user.roleId" :options="roles" optionLabel="name" optionValue="id"
                            style="width: 100%;"></Select>
                        <label for="role">Nhóm quyền</label>
                    </FloatLabel>
                </div>
                <div class="field mt-3">
                    <FloatLabel variant="on">
                        <Select id="status" v-model="user.status" :options="statuses" optionLabel="label"
                            optionValue="value"  style="width: 100%;"></Select>
                        <label for="status">Trạng thái</label>
                    </FloatLabel>
                </div>
                <template #footer>
                    <Button label="Hủy" icon="pi pi-times" class="p-button-text" @click="hideDialog" />
                    <Button label="Lưu" icon="pi pi-check" class="p-button-text" @click="saveUser" />
                </template>
            </Dialog>

            <Dialog v-model:visible="deleteUserDialog" :style="{ width: '450px' }" header="Xác nhận" :modal="true">
                <div class="flex align-items-center justify-content-center">
                    <i class="pi pi-exclamation-triangle mr-3" style="font-size: 2rem" />
                    <span v-if="user">Bạn có chắc chắn muốn xóa <b>{{ user.name }}</b>?</span>
                </div>
                <template #footer>
                    <Button label="Không" icon="pi pi-times" class="p-button-text" @click="deleteUserDialog = false" />
                    <Button label="Có" icon="pi pi-check" class="p-button-text" @click="deleteUser" />
                </template>
            </Dialog>

            <Dialog v-model:visible="deleteUsersDialog" :style="{ width: '450px' }" header="Xác nhận" :modal="true">
                <div class="flex align-items-center justify-content-center">
                    <i class="pi pi-exclamation-triangle mr-3" style="font-size: 2rem" />
                    <span>Bạn có chắc chắn muốn xóa các người dùng đã chọn?</span>
                </div>
                <template #footer>
                    <Button label="Không" icon="pi pi-times" class="p-button-text" @click="deleteUsersDialog = false" />
                    <Button label="Có" icon="pi pi-check" class="p-button-text" @click="deleteSelectedUsers" />
                </template>
            </Dialog>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { FilterMatchMode } from '@primevue/core/api';
import { useToast } from 'primevue/usetoast';
import { AdminService } from '@/modules/admin/services/AdminService';

const toast = useToast();
const dt = ref(null);
const users = ref([]);
const roles = ref([]);
const userDialog = ref(false);
const deleteUserDialog = ref(false);
const deleteUsersDialog = ref(false);
const user = ref({});
const selectedUsers = ref(null);
const filters = ref({});
const submitted = ref(false);
const loading = ref(true);
const statuses = ref([
    { label: 'Active', value: 'Active' },
    { label: 'Inactive', value: 'Inactive' }
]);

const adminService = new AdminService();

onMounted(() => {
    adminService.getUsers().then((data) => {
        users.value = data;
        loading.value = false;
    });
    adminService.getRoles().then((data) => (roles.value = data));
});

const initFilters = () => {
    filters.value = {
        global: { value: null, matchMode: FilterMatchMode.CONTAINS }
    };
};
initFilters();

const getRoleName = (roleId) => {
    const role = roles.value.find((r) => r.id === roleId);
    return role ? role.name : 'N/A';
};

const openNew = () => {
    user.value = {};
    submitted.value = false;
    userDialog.value = true;
};

const hideDialog = () => {
    userDialog.value = false;
    submitted.value = false;
};

const saveUser = () => {
    submitted.value = true;
    if (user.value.name && user.value.name.trim() && user.value.email) {
        if (user.value.id) {
            // Edit existing user
            const index = users.value.findIndex(u => u.id === user.value.id);
            users.value[index] = user.value;
            toast.add({ severity: 'success', summary: 'Thành công', detail: 'Người dùng đã được cập nhật', life: 3000 });
        } else {
            // Create new user
            user.value.id = createId();
            users.value.push(user.value);
            toast.add({ severity: 'success', summary: 'Thành công', detail: 'Người dùng đã được tạo', life: 3000 });
        }
        userDialog.value = false;
        user.value = {};
    }
};

const editUser = (editUser) => {
    user.value = { ...editUser };
    userDialog.value = true;
};

const confirmDeleteUser = (deleteUser) => {
    user.value = deleteUser;
    deleteUserDialog.value = true;
};

const deleteUser = () => {
    users.value = users.value.filter((val) => val.id !== user.value.id);
    deleteUserDialog.value = false;
    user.value = {};
    toast.add({ severity: 'success', summary: 'Thành công', detail: 'Người dùng đã được xóa', life: 3000 });
};

const confirmDeleteSelected = () => {
    deleteUsersDialog.value = true;
};

const deleteSelectedUsers = () => {
    users.value = users.value.filter((val) => !selectedUsers.value.includes(val));
    deleteUsersDialog.value = false;
    selectedUsers.value = null;
    toast.add({ severity: 'success', summary: 'Thành công', detail: 'Các người dùng đã chọn đã được xóa', life: 3000 });
};

const createId = () => {
    let id = '';
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (let i = 0; i < 5; i++) {
        id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
};

</script>
