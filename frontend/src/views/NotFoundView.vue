<script setup lang="ts">
import { RouterLink } from 'vue-router';
import Navbar from '@/components/Navbar.vue';
</script>

<template>
    <Navbar />
    <h1 class="text">Page Not Found</h1>
</template>

<style scoped>
.text {
    text-align: center;
    margin-top: 20px;
    font-size: 4rem;
    color: var(--text-color);
}
</style>