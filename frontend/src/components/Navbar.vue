<script setup lang="ts">
</script>

<template>
    <div id="container">
        <div class="header-left">
            <h1>BoardTrove</h1>
        </div>
        <div class="header-center">
            <img src="../assets/icon1.png" alt="Icon 1" class="icon" />
            <img src="../assets/icon2.png" alt="Icon 2" class="icon" />
            <img src="../assets/icon3.png" alt="Icon 3" class="icon" />
        </div>
        <div class="header-right">
            <img src="../assets/icon4.png" alt="Icon 4" class="icon" />
            <img src="../assets/icon5.png" alt="Icon 5" class="icon" />
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
    background-color: var(--background-color-accent);
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
    gap: 16px;
}

.icon {
    width: 24px;
    height: 24px;
    cursor: pointer;
}
</style>