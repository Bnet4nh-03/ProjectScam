import AppLayout from '@/layout/AppLayout.vue';

export const holdLotManagementRoutes = [
    {
        path: '/hold-lot-management',
        component: AppLayout,
        name: 'HoldLotManagement',
        meta: {
            title: 'Hold Lot Management',
            // requiresAuth: true,
            // requiredPermissions: ['CS_C_CM_V'] // Example permission for safety module access
        },
        children: [
            {
                path: '/hold-lot-management/dashboard',
                name: 'Dashboard',
                component: () => import('@/modules/holdLotManagement/pages/Dashboard.vue'),
                meta: {
                    title: 'Dashboard',
                    // requiresAuth: true,
                    // requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            },
            {
                path: '/hold-lot-management/history',
                name: 'Hold Lot History',
                component: () => import('@/modules/holdLotManagement/pages/History.vue'),
                meta: {
                    title: 'History',
                    // requiresAuth: true,
                    // requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            }
        ]
    }
];
