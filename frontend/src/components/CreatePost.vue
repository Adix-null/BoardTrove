<script setup lang="ts">
import { reactive, ref, watch, watchEffect } from "vue";
import { TheChessboard, type BoardConfig, BoardApi } from "vue3-chessboard";
import "vue3-chessboard/style.css";

const title = ref("");
const postType = ref("game");
const fenInput = ref("");
const startFen: string = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
const fenError = ref("");

const boardConfig = reactive({
    fen: fenInput.value,
    coordinates: true,
    viewOnly: true,
});

const handleSubmit = () => {
    // Add logic to handle form submission (e.g., API call)
};

// Watch for changes in the FEN input
watchEffect(() => {
    if (fenInput.value == "") {
        boardConfig.fen = startFen; // Reset to the starting position
    } else {
        boardConfig.fen = fenInput.value; // Update the valid FEN
    }
});

watch(postType, _ => {
    boardConfig.fen = startFen;
});


</script>

<template>
    <div id="create-post-form">
        <h1>Create a Post</h1>
        <form @submit.prevent="handleSubmit">
            <div class="post-type-tabs">
                <button type="button" :class="{ active: postType === 'game' }" @click="postType = 'game'">
                    Game
                </button>
                <button type="button" :class="{ active: postType === 'position' }" @click="postType = 'position'">
                    Position
                </button>
                <!-- <button type="button" :class="{ active: postType === 'link' }" @click="postType = 'link'">
                    Puzzle
                </button> -->
            </div>

            <!-- Title Input -->
            <div class="form-group">
                <label for="title">Title</label>
                <input id="title" type="text" v-model="title" placeholder="Enter the title of your post" required />
            </div>

            <!-- Game -->
            <div v-if="postType === 'game'" class="form-group">
                <input type="text" placeholder="PGN" />
            </div>

            <!-- Position -->
            <div v-if="postType === 'position'" class="form-group">
                <input id="fen" type="text" v-model="fenInput" placeholder="Enter a valid FEN string" />
            </div>

            <!-- Puzzle -->

            <a class="chessboard-container">
                <TheChessboard :board-config="boardConfig" reactive-config />
            </a>

            <!-- Submit Button -->
            <div id="submit_wrapper">
                <button type="submit" class="action-btn">Create Post</button>
            </div>
        </form>
    </div>
</template>

<style scoped>
#create-post-form {
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid var(--text-color-main);
    border-radius: 8px;
}

.post-type-tabs {
    display: flex;
    width: min-content;
    text-wrap: nowrap;
    gap: 10px;
    margin-bottom: 20px;
}

.post-type-tabs button {
    flex: 1;
    padding: 10px;
}

.post-type-tabs button:hover {
    background-color: var(--background-color-hover);
    color: white;
}

.post-type-tabs button.active {
    color: white;
    border: 2px solid var(--accent-dim);
}

h1 {
    text-align: center;
    margin-bottom: 20px;
}

.form-group {
    margin-bottom: 15px;
    display: flex;
    flex-direction: column;
}

label {
    font-weight: bold;
    margin-bottom: 5px;
}

input,
select {
    padding: 10px;
    font-size: 1em;
    border: 1px solid var(--text-color-main);
    border-radius: 4px;
}

.chessboard-container {
    display: flex;
    justify-content: center;
    margin-top: 16px;
}

#submit_wrapper {
    display: flex;
    justify-content: center;
    margin-top: 10px;
}

input:focus,
select:focus {
    outline: none;
    border-color: var(--accent-highlight);
}
</style>