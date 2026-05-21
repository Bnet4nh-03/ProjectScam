import AppLayout from '@/layout/AppLayout.vue';

export const approvalRoutes = [
    {
        path: '/approval',
        component: AppLayout,
        name: 'Approval',
        meta: {
            icon: 'pi pi-shield',
            requiresAuth: true,
            requiredPermissions: ['CS_C_CM_V'] // Example permission for safety module access
        },
        children: [
            {
                path: '/approval/approval-management',
                name: 'Approval Request',
                component: () => import('@/modules/approval/pages/ApproveRequest.vue'),
                meta: {
                    requiresAuth: true,
                    requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            },
            {
                path: '/approval/approval-his-management',
                name: 'Approval History',
                component: () => import('@/modules/approval/pages/MyApprovalHis.vue'),
                meta: {
                    requiresAuth: true,
                    requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            }
        ]
    }
];