/**
 * Tiện ích xử lý trạng thái cho Module Auto Control Hardware
 */
export const getStatusStyle = (status) => {
    switch (status) {
        case 'REGISTERED':
            return {
                severity: 'success',
                icon: 'pi pi-check-circle',
                class: 'bg-green-500/10 text-green-600 border-green-500'
            };
        case 'WAIT REGISTER':
            return {
                severity: 'warn',
                icon: 'pi pi-clock',
                class: 'bg-yellow-500/10 text-yellow-600 border-yellow-500'
            };
        case 'REJECTED':
            return {
                severity: 'danger',
                icon: 'pi pi-times-circle',
                class: 'bg-red-500/10 text-red-600 border-red-500'
            };
        case 'RETURNED':
            return {
                severity: 'danger',
                icon: 'pi pi-backward',
                class: 'bg-orange-500/10 text-orange-600 border-orange-500'
            };
        case 'PENDING':
            return {
                severity: 'secondary',
                icon: 'pi pi-spinner',
                class: 'bg-blue-500/10 text-blue-600 border-blue-500'
            };
        default:
            return {
                severity: 'info',
                icon: 'pi pi-info-circle',
                class: 'bg-gray-500/10 text-gray-600 border-gray-500'
            };
    }
};
