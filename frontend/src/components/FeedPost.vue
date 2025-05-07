<script setup lang="ts">
import { onMounted } from "vue";
import { TheChessboard, type BoardConfig, BoardApi } from "vue3-chessboard";
import "vue3-chessboard/style.css";

let boardAPI: BoardApi | undefined;

onMounted(() => {
    //console.log(boardAPI?.getBoardPosition());
});

const fen = "5rkq/3prp1p/5RpP/p1p5/5QP1/1B6/P4PK1/8 w - - 1 1";

const boardConfig: BoardConfig = {
    fen: fen,
    coordinates: true,
    viewOnly: true
};
</script>


<template>
    <div id="container">
        <div class="post-header">
            <img class="profile-pic" src="../assets/test.jpg" alt="Profile Picture" />
            <div class="user-info">
                <p class="username">Username</p>
                <p class="date-posted">Posted on Jan 1st, 1970</p>
            </div>
        </div>
        <h1>Feed Post</h1>
        <div class="chessboard-container">
            <TheChessboard :board-config="boardConfig" />
        </div>
        <p id="description">
            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Earum veritatis repellendus minima quibusdam ullam
            sequi officiis dolor reiciendis sit possimus.
        </p>
    </div>
</template>

<style scoped>
#container {
    padding: 16px;
    border: 1px solid var(--text-color-main);
    border-radius: 5px;
    max-width: 600px;
    margin: 16px auto;
}

.post-header {
    display: flex;
    align-items: center;
    margin-bottom: 16px;
}

.profile-pic {
    width: 50px;
    height: 50px;
    border-radius: 50%;
    object-fit: cover;
    margin-right: 16px;
}

.user-info {
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.username {
    font-size: 1em;
    font-weight: bold;
    margin-bottom: 5px;
}

.date-posted {
    font-size: 1em;
    margin: 0;
}

.chessboard-container {
    display: flex;
    justify-content: center;
    margin-top: 16px;
}

#description {
    font-size: 1em;
    margin: 1em;
    cursor: text;
}
</style>
