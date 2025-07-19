<script setup lang="ts">
import { RouterLink, useRoute } from 'vue-router';
import axios from 'axios';
import { onMounted } from 'vue';
import { useJWT } from '@/composables/jwt'

onMounted(() => {
    useJWT().returnUser().then(user => {
        console.log('User data:', user);
    }).catch(error => {
        console.error('Error fetching user data:', error);
    });
});

const isCurrentLink = (routePath: string) => {
    const route = useRoute();
    return route.path === routePath;
}

</script>

<template>
    <div id="container">
        <div class="header-left">
            <RouterLink to="/">
                <h1>BoardTrove</h1>
            </RouterLink>
        </div>
        <div class="header-center">
            <RouterLink to="/" :class="isCurrentLink('/') ? 'current-link' : 'hover'">
                <img src="../assets/icons/home.png" alt="home" class="inv icon" />
            </RouterLink>
            <RouterLink to="/trending" :class="isCurrentLink('/trending') ? 'current-link' : 'hover'">
                <img src="../assets/icons/fire.png" alt="trending page" class="inv icon" />
            </RouterLink>
            <RouterLink to="/friendfeed" :class="isCurrentLink('/friendfeed') ? 'current-link' : 'hover'">
                <img src="../assets/icons/user.png" alt="friend feed" class="inv icon" />
            </RouterLink>
        </div>
        <div class="header-right">
            <RouterLink to="/create-post" :class="isCurrentLink('/create-post') ? 'current-link' : 'hover'">
                <span id="new_post">+ New post</span>
            </RouterLink>
            <RouterLink to="/notifications" :class="isCurrentLink('/notifications') ? 'current-link' : 'hover'">
                <img src="../assets/icons/bell.png" alt="notifications" class="inv icon" />
            </RouterLink>
            <RouterLink to="/profile" :class="isCurrentLink('/profile') ? 'current-link' : 'hover'">
                <img src="../assets/icons/profile.png" alt="profile" class="inv icon" />
            </RouterLink>
            <RouterLink to="/login" :class="isCurrentLink('/login') ? 'current-link' : 'hover'">
                <span id="new_post">Login</span>
            </RouterLink>
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
    padding: 0px 10px;
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

a {
    padding: 12px;
    height: 34px;
    display: flex;
    align-items: center;
}

.header-center {
    display: flex;
}

.header-right {
    display: flex;
    align-items: center;
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

.current-link {
    background: linear-gradient(to top, var(--accent-dim), transparent 60%);
}

.hover:hover {
    background: linear-gradient(to top, var(--accent-main), transparent 60%);
    background-size: 200% 200%;

    animation: Animation 0.3s ease forwards;
}

@keyframes Animation {
    0% {
        background-position: 100% 0%
    }

    100% {
        background-position: 10% 50%
    }

}
</style>