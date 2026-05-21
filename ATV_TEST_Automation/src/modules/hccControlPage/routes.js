import AppLayout from '@/layout/AppLayout.vue';

export const hccControlPageRoutes = [
    {
        path: '/hcc-control-page',
        component: AppLayout,
        name: 'HccControlPage',
        meta: {
            title: 'HCC Control Page',
        },
        children: [
            {
                path: '/hcc-control-page/hcc-dashboard',
                component: () => import('@/modules/hccControlPage/pages/HccDashBoard.vue'),
                name: 'HCC Dashboard',
                meta: {
                    title: 'HCC Dashboard',
                    requiresAuth: true,
                    requiredPermissions: ['T_HRC_RHI_R'],
                }
            },
            {
                path: '/hcc-control-page/hcc-request',
                component: () => import('@/modules/hccControlPage/pages/HccRequest.vue'),
                name: 'HCC Request',
                meta: {
                    title: 'HCC Request',
                    requiresAuth: true,
                    requiredPermissions: ['T_HRC_RHI_R'],
                }
            },
            {
                path: '/hcc-control-page/socket-close-rate',
                component: () => import('@/modules/hccControlPage/pages/SocketCloseRate.vue'),
                name: 'Socket Close Rate',
                meta: {
                    title: 'Socket Close Rate'
                }
            },
            {
                path: '/hcc-control-page/socket-close-rate-history',
                component: () => import('@/modules/hccControlPage/pages/SocketCloseRateHistory.vue'),
                name: 'Socket Close Rate History',
                meta: {
                    title: 'Socket Close Rate History'
                }
            }
        ]
    }
];