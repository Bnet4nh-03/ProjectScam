import AppLayout from '@/layout/AppLayout.vue';

export const registerMachineRoutes = [
  {
    path: '/register-machine',
    component: AppLayout,
    name: 'RegisterMachine',
    meta: {
      title: 'Register Machine Page',
    },
    children: [
      {
        path: '/register-machine/register',
        component: () => import('@/modules/registerMachine/pages/RegisterMachine.vue'),
        name: 'RegisterTesterDashboard',
        meta: {
          title: 'Register Machine',
          requiresAuth: true,
          requiredPermissions: ['T_RM_SRR_PM'],
        },
      },

    ],
  },
];