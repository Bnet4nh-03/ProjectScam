import AppLayout from '@/layout/AppLayout.vue';

export const coreRoutes = [
    {
        path: '/',
        component: AppLayout,
        children: [
            {
                path: '/',
                name: 'Dashboard ',
                component: () => import('@/modules/holdLotManagement/pages/Dashboard.vue'),
                meta: { requiresAuth: true }
            }
        ]
    },
    {
        path: '/auth/login',
        name: 'login',
        component: () => import('@/modules/core/pages/Login.vue')
    },
    {
        path: '/notfound',
        name: 'notfound',
        component: () => import('@/modules/core/pages/NotFound.vue')
    },
    {
        path: '/auth/access',
        name: 'accessDenied',
        component: () => import('@/modules/core/pages/AccessDenied.vue')
    },
    {
        path: '/auth/error',
        name: 'error',
        component: () => import('@/modules/core/pages/Error.vue')
    },
];
