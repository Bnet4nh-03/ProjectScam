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
        name: 'RegisterDashboard',
        meta: {
          title: 'Register Machine',
          requiresAuth: true,
          requiredPermissions: ['T_RM_SRR_PM'],
        },
      },
      {
        path: '/register-machine/manager',
        component: () => import('@/modules/registerMachine/pages/ManagerMachine.vue'),
        name: 'ManagerDashboard',
        meta: {
          title: 'Manager Machine',
          requiresAuth: true,
          requiredPermissions: ['T_RM_SRR_PM'],
        },
      },

    ],
  },
];