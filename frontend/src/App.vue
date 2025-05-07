<script setup lang="ts">
import FeedPost from './components/FeedPost.vue';
import Navbar from './components/Navbar.vue';
import FooterMy from './components/Footer.vue';

</script>

<template>
  <div id="main">
    <div id="navbar_wrapper">
      <Navbar />
    </div>
    <div id="content_container">
      <div id="sidebar">
        <h2>Sidebar</h2>
        <p>Links</p>
        <p>Links</p>
        <p>Links</p>
      </div>
      <div id="post_feed">
        <FeedPost />
        <FeedPost />
        <FeedPost />
      </div>
    </div>
    <FooterMy />
  </div>
</template>

<style scoped>
#main {
  display: flex;
  flex-direction: column;
}

#content_container {
  display: flex;
  flex-direction: row;
  margin: 50px;
}

#post_feed {
  display: flex;
  flex-direction: column;
  width: 100%;
  align-items: center;
}

#navbar_wrapper {
  width: 100%;
  position: fixed;
  top: 0;
  left: 0;
  z-index: 1000;
}
</style>
