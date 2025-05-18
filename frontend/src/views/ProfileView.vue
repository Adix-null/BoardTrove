<script setup lang="ts">
import Profile from '@/components/Profile.vue';
import FriendList from '@/components/FriendList.vue';
import Navbar from '@/components/Navbar.vue';
import FooterMy from '@/components/Footer.vue';
</script>

<template>
  <Navbar />
  <div id="main">
    <Profile />
    <FriendList />
  </div>
  <FooterMy />
</template>

<style scoped>
#main {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
</style>