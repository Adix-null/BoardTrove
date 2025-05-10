<script setup lang="ts">
import FeedPost from './FeedPost.vue';
</script>

<template>
    <div id="main">
        <div id="profile-container">
            <div id="profile-header">
                <img class="profile-pic" src="../assets/test.jpg" alt="Profile Picture" />
                <div id="profile-info">
                    <h1>Username</h1>
                    <div id="actions">
                        <button class="action-btn">Add Friend</button>
                        <button class="action-btn">Follow</button>
                    </div>
                    <div id="stats">
                        <p>Posts: <span>10</span></p>
                        <p>Followers: <span>200</span></p>
                        <p>Following: <span>150</span></p>
                    </div>
                </div>
            </div>

            <div id="bio">
                <p>My bio Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lacinia odio vitae
                    vestibulum.
                </p>
                <p>Links:
                    <a href="https://chess.com/user" target="_blank">chess.com</a>,
                    <a href="https://lichess.org/user" target="_blank">lichess.org</a>
                </p>
            </div>

            <div id="content-container">
                <div class="content-box">

                    <FeedPost />
                </div>
                <div class=" content-box">Box 2</div>
            </div>
        </div>
    </div>
</template>

<style scoped>
#main {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 16px;
}

#profile-container {
    width: 100%;
    max-width: 800px;
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
    gap: 10px;
    margin: 10px 0;
}

.action-btn {
    padding: 8px 16px;
    background-color: var(--accent-main);
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.action-btn:hover {
    background-color: var(--accent-highlight);
}

#stats {
    display: flex;
    gap: 20px;
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
    display: flex;
    gap: 20px;
    justify-content: center;
}

.content-box {
    flex: 1;
    min-width: 200px;
    height: 150px;
    border: 1px solid var(--text-color-main, #ccc);
    display: flex;
    justify-content: center;
    font-size: 16px;
}
</style>