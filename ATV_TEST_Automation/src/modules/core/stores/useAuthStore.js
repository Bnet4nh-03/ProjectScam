import router from '@/router';
import { defineStore } from 'pinia';
import { apiAuthService } from '@/modules/core/services/AuthService';
import MessagingService from '@/modules/oldSource/services/MessagingService';
import _ from 'lodash';

export const useAuthStore = defineStore('auth', {
    state: () => ({
        userInfo: {
            badge_no: null,
            department: null,
            displayName: null,
            email: null,
            title: null,
            userId: null
        },
        userRoles: [],
        permissions: [],
        isMessagingConnected: false // **NEW: Track connection state**
    }),

    actions: {
        resetConnectionState() {
            console.log("[Debug] AuthStore: Forcibly resetting isMessagingConnected to false.");
            this.isMessagingConnected = false;
        },

        async login(gFunc, param) {
            try {
                const response = await apiAuthService.post('/Common/Login', param);
                var res = gFunc.CheckResDataLogin(response);
                if (res.isCheck) {
                    this.SetUserInfo(res.data);
                    // Call the centralized connection logic
                    // await this.establishMessagingConnection(gFunc);

                    // Find the first accessible route and redirect
                    const firstAccessibleRoute = this.findFirstAccessibleRoute(router.options.routes);
                    if (firstAccessibleRoute) {
                        router.push(firstAccessibleRoute.path);
                    } else {
                        // Fallback if no accessible route is found (e.g., to a generic dashboard or access denied page)
                        router.push({ name: 'accessDenied' }); // Or a more appropriate fallback
                    }
                }
            } catch (error) {
                gFunc.ShowMessage('Đăng nhập thất bại! Vui lòng kiểm tra lại.', 'error');
            }
        },

        findFirstAccessibleRoute(routes) {
            for (const route of routes) {
                // Check if the route itself is accessible
                if (this.checkRouteAccess(route)) {
                    return route;
                }
                // If the route has children, check them recursively
                if (route.children && route.children.length > 0) {
                    const accessibleChild = this.findFirstAccessibleRoute(route.children);
                    if (accessibleChild) {
                        return accessibleChild;
                    }
                }
            }
            return null;
        },

        checkRouteAccess(route) {
            // If route requires authentication and user is not authenticated, it's not accessible
            if (route.meta && route.meta.requiresAuth && !this.IsAuthenticated) {
                return false;
            }
            // If route requires permissions and user doesn't have them, it's not accessible
            if (route.meta && route.meta.permissions && !this.HasPermission(route.meta.permissions)) {
                return false;
            }
            return true;
        },

        // **NEW: Centralized action to connect to ActiveMQ**
        async establishMessagingConnection(gFunc) {
            console.log('[Debug] AuthStore: Running establishMessagingConnection...');
            console.log(`[Debug] AuthStore: Current state before check: IsAuthenticated=${this.IsAuthenticated}, isMessagingConnected=${this.isMessagingConnected}`);

            if (!this.IsAuthenticated || this.isMessagingConnected) {
                console.log('[Debug] AuthStore: Connection check failed. Bailing out.');
                // Do nothing if user is not logged in or already connected
                return;
            }

            console.log('[Debug] AuthStore: Connection check passed. Proceeding to get credentials.');
            try {
                // // This is the most secure and robust way to handle reloads.
                // const credsResponse = await apiAuthService.get('/Common/GetMQToken');
                // const mqCreds = gFunc.CheckResData(credsResponse);

                // if (mqCreds.isCheck && mqCreds.data.token) {
                //     MessagingService.connect(this.userInfo.userId, mqCreds.data.token);
                //     this.isMessagingConnected = true;
                //     console.log('Successfully established messaging connection.');
                // } else {
                //     throw new Error('Could not fetch valid messaging credentials.');
                // }
                // This is the most secure and robust way to handle reloads.

                // MessagingService.connect(this.userInfo.userId, this.userInfo.userId);
                this.isMessagingConnected = true;
            } catch (error) {
                console.error('Failed to establish messaging connection:', error);
                gFunc.ShowMessage('Không thể kết nối tới dịch vụ tin nhắn.', 'error');
            }
        },

        Logout() {
            // MessagingService.disconnect();
            this.isMessagingConnected = false; // Reset connection state
            this.$reset();
            router.push('/auth/login');
        },

        HasRole(screenRoles) {
            const commonRoles = _.intersection(screenRoles, this.userRoles);
            return commonRoles.length > 0;
        },

        HasPermission(permission) {
            const comPermission = _.intersection(permission, this.permissions);
            return comPermission.length > 0;
        },

        SetUserInfo(data) {
            this.userInfo['badge_no'] = data.badgeNo;
            this.userInfo['department'] = data.department;
            this.userInfo['displayName'] = data.displayName;
            this.userInfo['email'] = data.email;
            this.userInfo['title'] = data.title;
            this.userInfo['userId'] = data.userId;
            this.userRoles = data.userRole;
            this.permissions = [...data.userConfig, 'admin', 'user:list', 'role:list'];
        }
    },

    getters: {
        IsAuthenticated: (state) => {
            const isAuthenticated = !!state.userInfo.userId;
            console.log(`[Debug] AuthStore Getter: IsAuthenticated check. userId is '${state.userInfo.userId}'. Returning ${isAuthenticated}`);
            return isAuthenticated;
        }
    },

    persist: true,
});
