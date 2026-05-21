import { createApp } from 'vue';
import { createPinia } from 'pinia';
import piniaPersist from 'pinia-plugin-persistedstate';
import App from './App.vue';
import router from './router';

import Aura from '@primevue/themes/aura';
import PrimeVue from 'primevue/config';
import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice';
import { FontAwesomeIcon } from './plugin/FontAwesome';
import { HighchartsVue } from './plugin/HighChart';
import '@/assets/styles.scss';
import '@/assets/tailwind.css';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import createI18nInstance from './plugin/i18n';
import gFunc from './utils/func';
import gVariable from './utils/variable';
import {EnCoApiClientService} from '@/modules/core/services/EnCoApiClientService';
import { useLayout } from '@/layout/composables/layout';
import { updateSurfacePalette } from '@primevue/themes';

const { layoutConfig, isDarkTheme } = useLayout();


import { useAuthStore } from '@/modules/core/stores/useAuthStore';

// Clone Aura and override semantic.primary with Amkor's Royal Blue
const AmkorAura = {
    ...Aura,
    semantic: {
        ...Aura.semantic,
        primary: {
            50:  '#e8f0f8',  // very light tint
            100: '#c5d8ec',200: '#9fc0df',300: '#78a7d2',400: '#4f8dc4',
            500: '#0F4B8F', // Amkor Blue (PMS 293)
            600: '#0d437f',700: '#0b3b6f',800: '#09335f',900: '#072b4f'
        }
    }
};

createI18nInstance().then(i18n => {
    const app = createApp(App);

    const pinia = createPinia();
    pinia.use(piniaPersist);
    app.use(pinia);
    app.component('font-awesome-icon', FontAwesomeIcon);
    app.provide('gVariable', gVariable);
    app.provide('gFunc', gFunc);
    const apiClient = new EnCoApiClientService(import.meta.env.VITE_API_AUTH_URL);
    app.provide('apiClient', apiClient);
    app.use(router);

    app.use(PrimeVue, {
        theme: {
        preset: AmkorAura,
        options: {
            darkModeSelector: '.app-dark'
        }
        }
    });

    app.use(ToastService);
    app.use(ConfirmationService);
    app.use(HighchartsVue);
    app.use(i18n);

    const authStore = useAuthStore();
    authStore.resetConnectionState();
    authStore.establishMessagingConnection(gFunc);

    app.mount('#app');
});
