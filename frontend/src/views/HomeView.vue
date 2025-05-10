<script setup lang="ts">
import FeedPost from '@/components/FeedPost.vue';
</script>

<template>
  <div id="content_container">
    <div id="sidebar">
      <h2>Sidebar</h2>
      <p>Links</p>
      <p>Links</p>
      <p>Links</p>
    </div>
    <div id="post_feed">
      <FeedPost maxWidth="700px"/>
      <FeedPost maxWidth="700px"/>
      <FeedPost maxWidth="700px"/>
    </div>
  </div>
</template>

<style scoped>
#content_container {
  display: flex;
  flex-direction: row;
}

#post_feed {
  display: flex;
  flex-direction: column;
  width: 100%;
}
</style>