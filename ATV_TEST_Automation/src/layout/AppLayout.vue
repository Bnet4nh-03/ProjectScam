<script setup>
import { useLayout } from '@/layout/composables/layout';
import { computed, ref, watch } from 'vue';
import AppFooter from './AppFooter.vue';
import AppSidebar from './AppSidebar.vue';
import AppTopbar from './AppTopbar.vue';
import { useRoute } from 'vue-router';

const { layoutConfig, layoutState, isSidebarActive } = useLayout();
const route = useRoute();

const outsideClickListener = ref(null);

watch(isSidebarActive, (newVal) => {
    if (newVal) {
        bindOutsideClickListener();
    } else {
        unbindOutsideClickListener();
    }
});

const containerClass = computed(() => {
    return {
        'layout-overlay': layoutConfig.menuMode === 'overlay',
        'layout-static': layoutConfig.menuMode === 'static',
        'layout-static-inactive': layoutState.staticMenuDesktopInactive && layoutConfig.menuMode === 'static',
        'layout-overlay-active': layoutState.overlayMenuActive,
        'layout-mobile-active': layoutState.staticMenuMobileActive
    };
});


const home = ref({
    icon: 'pi pi-home',
    label:"Home",
    route: '/'
});

// Tạo danh sách breadcrumb từ meta router
const ItemsBreadcrumb = computed(() => {
    const matchedRoutes = route.matched; // Lấy danh sách các route khớp với đường dẫn hiện tại
    const breadcrumbItems = matchedRoutes
        .filter(routeItem => routeItem.name) // Chỉ lấy những route có tiêu đề
        .map(routeItem => {
            return {
                label: routeItem.name, // Gán tiêu đề của breadcrumb
                icon: routeItem.meta.icon,
                to: routeItem.path !== route.path ? routeItem.path : null // Nếu không phải trang hiện tại thì có link
            };
        });
    return breadcrumbItems;
});

function bindOutsideClickListener() {
    if (!outsideClickListener.value) {
        outsideClickListener.value = (event) => {
            if (isOutsideClicked(event)) {
                layoutState.overlayMenuActive = false;
                layoutState.staticMenuMobileActive = false;
                layoutState.menuHoverActive = false;
            }
        };
        document.addEventListener('click', outsideClickListener.value);
    }
}

function unbindOutsideClickListener() {
    if (outsideClickListener.value) {
        document.removeEventListener('click', outsideClickListener);
        outsideClickListener.value = null;
    }
}

function isOutsideClicked(event) {
    const sidebarEl = document.querySelector('.layout-sidebar');
    const topbarEl = document.querySelector('.layout-menu-button');

    return !(sidebarEl.isSameNode(event.target) || sidebarEl.contains(event.target) || topbarEl.isSameNode(event.target) || topbarEl.contains(event.target));
}
</script>

<template>
    <div class="layout-wrapper" :class="containerClass">
        <app-topbar></app-topbar>
        <app-sidebar></app-sidebar>
        <div class="layout-main-container">
            <div class="layout-main">
                <!-- Hiển thị breadcrumb nếu có danh sách items -->
                <Breadcrumb style="padding: 0.5rem;" v-if="ItemsBreadcrumb.length >0" :home="home" :model="ItemsBreadcrumb"
                    class="bg-gray-100 rounded mb-1" />
                <router-view></router-view>
            </div>
            <app-footer></app-footer>
        </div>
        <div class="layout-mask animate-fadein"></div>
    </div>
</template>
