import AppLayout from '@/layout/AppLayout.vue';

export const adminRoutes = [
    {
        path: '/admin',
        component: AppLayout,
        name: 'Admin',
        meta: {
            icon: 'pi pi-users',
            requiresAuth: true,
            requiredPermissions: ['admin'] // Or more specific permissions
        },
        children: [
            {
                path: '/admin/user-management',
                name: 'User Management',
                component: () => import('@/modules/admin/pages/UserManagement.vue'),
                meta: {
                    requiresAuth: true,
                    requiredPermissions: ['CS_A_UM_V']
                }
            },
            {
                path: '/admin/role-management',
                name: 'Role Management',
                component: () => import('@/modules/admin/pages/RoleManagement.vue'),
                meta: {
                    requiresAuth: true,
                    requiredPermissions: ['CS_A_UM_V']
                }
            }
        ]
    },
];
