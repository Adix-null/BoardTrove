<script setup lang="ts">
import { onMounted, ref } from 'vue';
import FeedPost from './FeedPost.vue';
import FriendList from './FriendList.vue';
import { useFormattedDate } from '@/composables/dateUtils'
import { useJWT } from '@/composables/jwt';

const user = ref<any>(null);

onMounted(() => {
    useJWT().returnUser().then(data => {
        user.value = data;
    }).catch(error => {
        console.error('Error fetching user data:', error);
    });
});

</script>

<template>
    <div id="main">
        <div id="profile-wrapper">
            <div id="profile-header">
                <img class="profile-pic" :src="user?.pfpLink" alt="Profile Picture" />
                <div id="profile-info">
                    <div id="profile-name">
                        <p id="username">{{ user?.username }}</p>
                        <p id="joined-date">joined {{ useFormattedDate().formatTimestamp(user?.created, 'en-US', {
                            dateStyle: 'long',
                            timeStyle: 'short'
                        }) }}</p>
                    </div>

                    <div id="actions">
                        <button class="action-btn">Add Friend</button>
                        <button class="action-btn">Follow</button>
                    </div>
                    <div id="stats">
                        <p>0 posts</p>
                        <p>0 followers</p>
                        <p>0 following</p>
                    </div>
                </div>
            </div>

            <div id="bio">
                <p>{{ user?.bio }}
                </p>
                <p>Links:
                    <a href="https://chess.com/user" target="_blank">chess.com</a>,
                    <a href="https://lichess.org/user" target="_blank">lichess.org</a>
                </p>
            </div>

            <div id="content-container">
                <div class="content_box" id="personal_posts">
                    <FeedPost v-for="i in 3" max-width="600px" postID="random" />
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
#main {
    display: flex;
    justify-content: center;
    padding: 16px;
}

#profile-wrapper {
    width: 100%;
    max-width: 700px;
}

#profile-header {
    display: flex;
    align-items: center;
    margin-bottom: 20px;
}

#username {
    font-size: 2.5em;
    margin-bottom: 7px;
    margin-top: 0px;
}

#joined-date {
    align-self: center;
    margin: 0;
    font-size: 1em;
}

.profile-pic {
    width: 175px;
    aspect-ratio: 1;
    object-fit: cover;
    margin-right: 30px;
}

#profile-info {
    flex: 1;
}

#actions {
    display: flex;
    gap: 20px;
    margin: 10px 0;
}

#stats {
    display: flex;
    justify-content: start;
    gap: 40px
}

#stats p {
    margin: 0;
    font-size: 1em;
}

#bio {
    margin-bottom: 20px;
    font-size: 14px;
}

#bio p {
    margin-top: 10px;
}

#bio a {
    color: var(--accent-highlight);
    text-decoration: none;
}

#bio a:hover {
    text-decoration: underline;
}

#content-container {
    width: 100%;
    display: flex;
    gap: 20px;
    justify-content: center;
}

.content_box {
    min-width: 200px;
    display: flex;
    flex-direction: column;
    align-items: center;
    font-size: 16px;
}
</style>