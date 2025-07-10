<template>
    <div v-if="visible" class="toast-message">
        {{ message }}
    </div>
</template>

<script setup lang="ts">
import { useToast } from "@/composables/useToast";
const { visible, message } = useToast();
</script>

<style scoped>
.toast-message {
    position: fixed;
    left: 50%;
    bottom: 40px;
    transform: translateX(-50%);
    background: var(--secondary-highlight);
    color: #fff;
    padding: 15px 30px;
    border-radius: 24px;
    font-size: 1.1em;
    z-index: 9999;
    box-shadow: 0 2px 12px rgba(0, 0, 0, 0.18);
    pointer-events: none;
    animation: toast-fade-move 3s;
}

@keyframes toast-fade-move {
    0% {
        opacity: 0;
        transform: translateX(-50%) translateY(20px);
    }

    10% {
        opacity: 1;
        transform: translateX(-50%) translateY(0);
    }

    90% {
        opacity: 1;
        transform: translateX(-50%) translateY(0);
    }

    100% {
        opacity: 0;
        transform: translateX(-50%) translateY(20px);
    }
}
</style>