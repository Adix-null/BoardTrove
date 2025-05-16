<script setup lang="ts">
import Profile from '@/components/Profile.vue';
import FriendList from '@/components/FriendList.vue';
</script>

<template>
  <div id="main">
    <Profile />
    <FriendList />
  </div>
</template>

<style scoped>
#main {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
</style>