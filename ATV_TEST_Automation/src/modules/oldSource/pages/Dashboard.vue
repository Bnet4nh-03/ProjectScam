<script setup>
import BestSellingWidget from '@/modules/oldSource/components/dashboard/BestSellingWidget.vue';
import NotificationsWidget from '@/modules/oldSource/components/dashboard/NotificationsWidget.vue';
import RecentSalesWidget from '@/modules/oldSource/components/dashboard/RecentSalesWidget.vue';
import RevenueStreamWidget from '@/modules/oldSource/components/dashboard/RevenueStreamWidget.vue';
import StatsWidget from '@/modules/oldSource/components/dashboard/StatsWidget.vue';
import { ref } from 'vue';
// // Biến trong cha
// const parentMessage = ref('Hello from Parent!');
// const childMessage = ref("");
// // Hàm xử lý khi nhận dữ liệu từ con
// const handleUpdate = (data) => {
//     childMessage.value = data;
// };

</script>

<template>


        <div class="col-span-12 xl:col-span-6">
            <RevenueStreamWidget />

        </div>

</template>
