<script setup lang="ts">
import FeedPost from './components/FeedPost.vue';

</script>

<template>
  <div id="main">
    <div id="post_feed">
      <FeedPost />
      <FeedPost />
      <FeedPost />
    </div>
  </div>
</template>

<style scoped>
#main {
  display: flex;
  flex-direction: row;
}

#post_feed {
  display: flex;
  flex-direction: column;
  width: 100%;
  align-items: center;
}
</style>
