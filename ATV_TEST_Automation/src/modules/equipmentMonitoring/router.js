import AppLayout from '@/layout/AppLayout.vue';

export const equipmentMonitoringRoutes = [
    {
        path: '/equipment-monitoring',
        component: AppLayout,
        name: 'EquipmentMonitoring',
        meta: {
            title: 'PM Monitoring',
            // requiresAuth: true,
            // requiredPermissions: ['CS_C_CM_V'] // Example permission for safety module access
        },
        children: [
            {
                path: '/equipment-monitoring/pmmonitoring',
                name: 'PMmonitoring',
                component: () => import('@/modules/equipmentMonitoring/pages/PMmonitoring.vue'),
                meta: {
                    title: 'PMmonitoring',
                    // requiresAuth: true,
                    // requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            },
            {
                path: '/equipment-monitoring/jammonitor',
                name: 'JAMmonitor',
                component: () => import('@/modules/equipmentMonitoring/pages/JAMmonitor.vue'),
                meta: {
                    title: 'JAMmonitor',
                    // requiresAuth: true,
                    // requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            },
            {
                path: '/equipment-monitoring/mtbarecord',
                name: 'MTBArecord',
                component: () => import('@/modules/equipmentMonitoring/pages/MTBArecord.vue'),
                meta: {
                    title: 'MTBArecord',
                    // requiresAuth: true,
                    // requiredPermissions: ['CS_C_CM_V'] // Specific permission for this page
                }
            }
        ]
    }
];

