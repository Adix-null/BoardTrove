<script setup lang="ts">
import { RouterView } from 'vue-router';
import Toast from "@/components/Toast.vue";
</script>

<template>
  <div id="master">
    <RouterView />
    <Toast />
  </div>
</template>

<style scoped>
#master {
  height: 101vh;
}
</style>
