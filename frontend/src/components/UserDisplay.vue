<script setup lang="ts">
</script>

<template>
    <div class="user-display">
        <img class="profile-pic" src="../assets/test.jpg" alt="Profile Picture" />
        <h1 class="username">Magnus Carlsen</h1>
    </div>
</template>

<style scoped>
.user-display {
    display: flex;
    align-items: center;
    gap: 15px;
}

.profile-pic {
    width: 40px;
    aspect-ratio: 1/1;
    border-radius: 50%; 
    object-fit: cover;
    padding: 10px;
}

.username {
    font-size: 1.2em;
    margin: 0;
}
</style>