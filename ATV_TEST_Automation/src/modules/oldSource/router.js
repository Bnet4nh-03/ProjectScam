import AppLayout from '@/layout/AppLayout.vue';

export const oldSourceRoutes = [
    {
        path: '/rpa',
        component: AppLayout,
        name: 'rpa',
        meta: {
            icon: 'pi pi-chart-line',
            requiresAuth: true,
            permissions: ['F_D_QRE_V']
        },
        children: [
            {
                path: '/rpa/create-schedule',
                name: '1. Create Schedule',
                component: () => import('@/modules/oldSource/pages/rpa/CreateSchedule.vue'),
                meta: {
                    icon: '',
                    requiresAuth: true,
                    permissions: ['F_D_QRE_V']
                }
            },
            {
                path: '/rpa/list-schedule',
                name: '2. List Schedule',
                component: () => import('@/modules/oldSource/pages/rpa/ListSchedule.vue'),
                meta: {
                    icon: '',
                    requiresAuth: true,
                    permissions: ['F_D_QRE_V']
                }
            },
            {
                path: '/rpa/execute-history',
                name: '3. Execute History',
                component: () => import('@/modules/oldSource/pages/rpa/ExecuteHistory.vue'),
                meta: {
                    icon: '',
                    requiresAuth: true,
                    permissions: ['F_D_QRE_V']
                }
            },
        ]
    },
    {
        path: '/canva',
        component: AppLayout,
        name: 'canva',
        meta: {
            icon: 'pi pi-chart-line',
            requiresAuth: true,
            permissions: ['F_D_QRE_V']
        },
        children: [
                {
                path: '/canva/material-handling-checklist',
                name: 'Material Handling Checklist',
                component: () => import('@/modules/oldSource/pages/canva/MaterialHandlingChecklist.vue'),
                meta: {
                    requiresAuth: true,
                    permissions: ['F_D_QRE_V']
                }
            },
        ]
    },
    {
        path: '/app',
        component: AppLayout,
        children: [
            {
                path: '/dashboard',
                name: 'dashboard',
                component: () => import('@/modules/oldSource/pages/Dashboard.vue'),
                meta: { requiresAuth: true },
            },
            {
                path: 'uikit',  // Parent route for UIKit
                    children: [
                    {
                        path: '/uikit/formlayout',
                        name: 'formlayout',
                        component: () => import('@/modules/oldSource/pages/uikit/FormLayout.vue')
                    },
                    {
                        path: '/uikit/input',
                        name: 'input',
                        component: () => import('@/modules/oldSource/pages/uikit/InputDoc.vue')
                    },
                    {
                        path: '/uikit/button',
                        name: 'button',
                        component: () => import('@/modules/oldSource/pages/uikit/ButtonDoc.vue')
                    },
                    {
                        path: '/uikit/table',
                        name: 'table',
                        component: () => import('@/modules/oldSource/pages/uikit/TableDoc.vue')
                    },
                    {
                        path: '/uikit/list',
                        name: 'list',
                        component: () => import('@/modules/oldSource/pages/uikit/ListDoc.vue')
                    },
                    {
                        path: '/uikit/tree',
                        name: 'tree',
                        component: () => import('@/modules/oldSource/pages/uikit/TreeDoc.vue')
                    },
                    {
                        path: '/uikit/panel',
                        name: 'panel',
                        component: () => import('@/modules/oldSource/pages/uikit/PanelsDoc.vue')
                    },
                    {
                        path: '/uikit/overlay',
                        name: 'overlay',
                        component: () => import('@/modules/oldSource/pages/uikit/OverlayDoc.vue')
                    },
                    {
                        path: '/uikit/media',
                        name: 'media',
                        component: () => import('@/modules/oldSource/pages/uikit/MediaDoc.vue')
                    },
                    {
                        path: '/uikit/message',
                        name: 'message',
                        component: () => import('@/modules/oldSource/pages/uikit/MessagesDoc.vue')
                    },
                    {
                        path: '/uikit/file',
                        name: 'file',
                        component: () => import('@/modules/oldSource/pages/uikit/FileDoc.vue')
                    },
                    {
                        path: '/uikit/menu',
                        name: 'menu',
                        component: () => import('@/modules/oldSource/pages/uikit/MenuDoc.vue')
                    },
                    {
                        path: '/uikit/charts',
                        name: 'charts',
                        component: () => import('@/modules/oldSource/pages/uikit/ChartDoc.vue')
                    },
                    {
                        path: '/uikit/misc',
                        name: 'misc',
                        component: () => import('@/modules/oldSource/pages/uikit/MiscDoc.vue')
                    },
                    {
                        path: '/uikit/timeline',
                        name: 'timeline',
                        component: () => import('@/modules/oldSource/pages/uikit/TimelineDoc.vue')
                    },
                    {
                        path: '/pages/empty',
                        name: 'empty',
                        component: () => import('@/modules/oldSource/pages/Empty.vue')
                    },
                    {
                        path: '/pages/crud',
                        name: 'crud',
                        component: () => import('@/modules/oldSource/pages/Crud.vue')
                    },
                    {
                        path: '/documentation',
                        name: 'documentation',
                        component: () => import('@/modules/oldSource/pages/Documentation.vue')
                    }                
                ]
            },

        ]
    },
    {
        path: '/landing',
        name: 'landing',
        component: () => import('@/modules/oldSource/pages/Landing.vue')
    },
];
