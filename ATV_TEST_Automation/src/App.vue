<script setup>
import GlobalToastHandler from '@/modules/oldSource/components/GlobalToastHandler.vue';
</script>

<template>
    <Toast position="top-center"/>
    <GlobalToastHandler />
    <router-view />
</template>

<style scoped></style>
