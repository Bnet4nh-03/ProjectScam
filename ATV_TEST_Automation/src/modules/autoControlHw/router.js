import AppLayout from '@/layout/AppLayout.vue';

export const autoControlHwRoutes = [
    {
        path: '/auto-control-hw',
        component: AppLayout,
        name: 'AutoControlHw',
        meta: {
            title: 'Auto Control Hardware',
            requiresAuth: true
        },
        children: [
            {
                path: '/auto-control-hw/master-registration',
                name: 'TPE',
                component: () => import('@/modules/autoControlHw/pages/MasterRegistration.vue'),
                meta: {
                    title: 'TPE',
                    requiredPermissions: ['T_ACHW_TPE_V'],
                }
            },
            // {
            //     path: '/auto-control-hw/double-check',
            //     name: 'TPE 2 Confirm',
            //     component: () => import('@/modules/autoControlHw/pages/DoubleCheck.vue'),
            //     meta: {
            //         title: 'TPE 2 Confirm'
            //     }
            // },
            // {
            //     path: '/auto-control-hw/matrix-registration',
            //     name: 'Register HW Matrix',
            //     component: () => import('@/modules/autoControlHw/pages/MatrixRegistration.vue'),
            //     meta: {
            //         title: 'Register HW Matrix',
            //         requiredPermissions: ['T_ACHW_RHWM_V'],
            //     }
            // },
            {
                path: '/auto-control-hw/tester-summary',
                name: 'Matrix Summary',
                component: () => import('@/modules/autoControlHw/pages/TesterSummary.vue'),
                meta: {
                    title: 'Matrix Summary Dashboard'
                }
            },

            {
                path: '/auto-control-hw/management_hw',
                name: 'HW Manegement',
                component: () => import('@/modules/autoControlHw/pages/DeleteKits.vue'),
                meta: {
                    title: 'HW Manegement',
                    requiredPermissions: ['T_ACHW_TPE_D'],
                }
            }
        ]
    }
];
