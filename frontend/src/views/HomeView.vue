<script setup lang="ts">
import FeedPost from '@/components/FeedPost.vue';
import FriendList from '@/components/FriendList.vue';
import Navbar from '@/components/Navbar.vue';
import FooterMy from '@/components/Footer.vue';
</script>

<template>
  <Navbar />
  <div id="main">
    <div id="sidebar">
      <h2>Sidebar</h2>
      <p>Links</p>
      <p>Links</p>
      <p>Links</p>
    </div>
    <div id="post_feed">
      <FeedPost v-for="i in 10" maxWidth="700px" postID="random" />
    </div>
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

#post_feed {
  display: flex;
  flex-direction: column;
  margin: 0 30px;
}

#sidebar {
  width: 250px;
}
</style>