<script setup lang="ts">
import Navbar from './components/Navbar.vue';
import FooterMy from './components/Footer.vue';
import { RouterView } from 'vue-router';

</script>

<template>
  <div id="main">
    <Navbar />
    <RouterView />
    <FooterMy />
  </div>
</template>
