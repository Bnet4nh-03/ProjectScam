<script setup>
import { useToast } from "primevue/usetoast";
import { onMounted, onBeforeUnmount } from 'vue';
import { eventBus } from  '@/plugin/eventBus';

const toast = useToast();

const handleNewMessage = (message) => {
    console.log("GlobalToastHandler received message:", message);
    toast.add({
        severity: 'info',
        summary: `New Message from ${message.topic}`,
        // Fallback for different message structures
        detail: message.body.content || JSON.stringify(message.body),
        life: 5000
    });
};

onMounted(() =>{
    // Make the toast instance globally available for other parts of the app if they need to show toasts directly.
    eventBus.toast = toast;

    // Listen for new messages from the messaging service
    eventBus.on('new-message', handleNewMessage);
});

onBeforeUnmount(() => {
    // Clean up the event listener to prevent memory leaks
    eventBus.off('new-message', handleNewMessage);
});
</script>

<template>
  <!-- This is a non-visual component, so its template is empty. -->
</template>
