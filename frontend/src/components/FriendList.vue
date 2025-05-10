<script setup lang="ts">
import UserDisplay from './UserDisplay.vue';
</script>

<template>
    <div id="container">
        <UserDisplay/>
        <UserDisplay/>
        <UserDisplay/>
        <UserDisplay/>
        <UserDisplay/>
        <UserDisplay/>
        <UserDisplay/>
    </div>
</template>

<style scoped>
#container{
    display: flex;
    flex-direction: column;
    margin-top: 10px;
    width: 250px;
}
</style>