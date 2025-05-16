<script setup lang="ts">
import Navbar from './components/Navbar.vue';
import FooterMy from './components/Footer.vue';
import { RouterView } from 'vue-router';

</script>

<template>
  <div id="master">
    <Navbar />
    <RouterView />
  </div>
  <FooterMy />
</template>

<style scoped>
#master {
  min-height: 92%;
}
</style>
