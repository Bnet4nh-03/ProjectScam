import { createRouter, createWebHistory } from 'vue-router';
import { useAuthStore } from '@/modules/core/stores/useAuthStore';
import { coreRoutes } from '@/modules/core/router';
import { oldSourceRoutes } from '@/modules/oldSource/router';
import { holdLotManagementRoutes } from '@/modules/holdLotManagement/router';
import { registerMachineRoutes } from '@/modules/registerMachine/router';
import { equipmentMonitoringRoutes } from '@/modules/equipmentMonitoring/router';
import { hccControlPageRoutes } from '@/modules/hccControlPage/routes';
import { panelYieldMonitoringRoutes } from '@/modules/panelYieldMonitoring/router';
import { autoControlHwRoutes } from '@/modules/autoControlHw/router';

const router = createRouter({
    history: createWebHistory(),
    routes: [...coreRoutes,...oldSourceRoutes,...holdLotManagementRoutes, ...equipmentMonitoringRoutes,...hccControlPageRoutes
        ,...panelYieldMonitoringRoutes,...registerMachineRoutes, ...autoControlHwRoutes
    ]
});

router.beforeEach((to, from, next) => {
    // const authStore = useAuthStore();
    // if (to.meta.requiresAuth && !authStore.IsAuthenticated) {
    //     next({ name: 'login' });
    // } else if (to.meta.requiredPermissions && !authStore.HasPermission(to.meta.requiredPermissions)) {
    //     next({ name: 'accessDenied' });
    // } else {
    //     next();
    // }
    next();

});


export default router;
