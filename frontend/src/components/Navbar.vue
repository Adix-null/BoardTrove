<script setup lang="ts">
</script>

<template>
    <div id="container">
        <div class="header-left">
            <a href="/">
                <h1>BoardTrove</h1>
            </a>
        </div>
        <div class="header-center">
            <a href="/">
                <img src="../assets/icons/home.png" alt="Icon 1" class="inv icon" />
            </a>
            <img src="../assets/icons/fire.png" alt="Icon 2" class="inv icon" />
            <img src="../assets/icons/user.png" alt="Icon 3" class="inv icon" />
        </div>
        <div class="header-right">
            <a href="/create-post">
                <span id="new_post">+ New post</span>
            </a>
            <a href="">
                <img src="../assets/icons/bell.png" alt="Icon 4" class="inv icon" />
            </a>
            <a href="/profile">
                <img src="../assets/icons/profile.png" alt="Icon 5" class="inv icon" />
            </a>
            <a href="/login">
                <span id="new_post">Login</span>
            </a>
        </div>
    </div>
</template>

<style scoped>
#container {
    box-sizing: border-box;
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 10px;
    margin-bottom: 20px;
    background-color: var(--background-color-accent);
    height: 60px;
    position: sticky;
    top: 0;
    left: 0;
    z-index: 1000;
}

.header-left h1 {
    font-size: 2em;
    margin: 0;
    color: var(--text-color-main, #333);
}

.header-center {
    display: flex;
    gap: 16px;
}

.header-right {
    display: flex;
    align-items: center;
    gap: 16px;
}

#new_post {
    padding: 5px;
    border: 2px solid var(--text-color-main);
    border-radius: 5px;
}

.icon {
    width: 30px;
    aspect-ratio: 1/1;
    cursor: pointer;
}
</style>