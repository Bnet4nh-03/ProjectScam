import AppLayout from '@/layout/AppLayout.vue';

export const panelYieldMonitoringRoutes = [
  {
    path: '/panel-yield-monitoring',
    component: AppLayout,
    name: 'Panel Yield Monitoring',
    meta:{
        title : 'Panel Yield Monitoring',
    },
    children: [
        {
            path: '/panel-yield-monitoring/dashboard',
            name: 'Panel Yield Dashboard',
            component: () => import('@/modules/panelYieldMonitoring/pages/Dashboard.vue'),
            meta: {
                title: 'Dashboard',
            }
        },
    ]
  }
];