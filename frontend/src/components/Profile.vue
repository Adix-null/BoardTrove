<script setup lang="ts">
import FeedPost from './FeedPost.vue';
import FriendList from './FriendList.vue';
</script>

<template>
    <div id="main">
        <div id="profile-wrapper">
            <div id="profile-header">
                <img class="profile-pic" src="../assets/test.jpg" alt="Profile Picture" />
                <div id="profile-info">
                    <h1>Username</h1>
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
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi ut diam lacinia, posuere ante ac, commodo diam. Duis vitae auctor purus, et sagittis ligula. Nam eu posuere est. Duis at interdum massa, nec imperdiet metus. Duis convallis velit metus, at semper lectus laoreet nec. In cursus tincidunt augue ullamcorper ullamcorper. 
                </p>
                <p>Links:
                    <a href="https://chess.com/user" target="_blank">chess.com</a>,
                    <a href="https://lichess.org/user" target="_blank">lichess.org</a>
                </p>
            </div>

            <div id="content-container">
                <div class="content_box" id="personal_posts">
                    <FeedPost max-width="600px" />
                    <FeedPost max-width="600px" />
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

.profile-pic {
    width: 130px;
    height: 130px;
    border-radius: 50%;
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

#personal_posts{
}
</style>