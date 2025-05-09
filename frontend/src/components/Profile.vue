<script setup lang="ts">
import Navbar from './Navbar.vue';
import FooterMy from './Footer.vue';
import Friendlist from './FriendList.vue';

</script>

<template>
    <div id="main">
        <Navbar />
        <div id="personal_info">
            <img class="profile-pic" src="../assets/test.jpg" alt="Profile Picture" />
            <h1>Username</h1>
            <p>Bio: Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <p>Location: City, Country</p>
            <p>Joined: January 1st, 1970</p>
        </div>
        <div id="content_container">
            <div id="post_feed">
                <FeedPost />
                <FeedPost />
                <FeedPost />
            </div>
            <Friendlist />
        </div>
        <FooterMy />
    </div>
</template>


<style scoped>
#content_container {
    display: flex;
    flex-direction: row;
}
</style>
