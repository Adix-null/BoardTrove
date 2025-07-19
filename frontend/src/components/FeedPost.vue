<script setup lang="ts">
import { onMounted, reactive, ref, watch } from "vue";
import { TheChessboard, type BoardConfig, BoardApi } from "vue3-chessboard";
import { RouterLink } from 'vue-router';
import "vue3-chessboard/style.css";
import axios from "axios";

let boardAPI: BoardApi | undefined;
const post = ref<any>(null);

const fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

const props = defineProps({
    maxWidth: {
        type: String,
        default: "100%", // Default max-width
    },
    postID: {
        type: String,
        required: true
    }
});

onMounted(async () => {
    let url = props.postID == "random" ?
        "https://localhost:7167/api/Post/random" :
        `https://localhost:7167/api/Post/${props.postID}`;

    console.log(`Fetching post from: ${url}`);
    const response = await axios.get(url);
    post.value = response.data;
});

const boardConfig = reactive({
    fen: post.value?.fen || fen,
    coordinates: true,
    viewOnly: true,
});

watch(post, (newPost) => {
    if (newPost && newPost.fen) {
        boardConfig.fen = newPost.fen;
    }
});
</script>


<template>
    <div id="container" :style="{ maxWidth: maxWidth }">
        <div class="post-header">
            <RouterLink to="/profile">
                <img class="profile-pic" src="../assets/test.jpg" alt="Profile Picture" />
            </RouterLink>
            <div class="user-info">
                <RouterLink to="/profile" class="username">Username</RouterLink>
                <p class="date-posted">{{ post?.created }}</p>
            </div>
        </div>
        <h1>{{ post?.title }}</h1>
        <a class="chessboard-container">
            <TheChessboard :board-config="boardConfig" reactive-config />
        </a>
        <div id="description">
            <p>
                {{ post?.description }}
            </p>
        </div>
    </div>
</template>

<style scoped>
#container {
    padding: 16px;
    border: 1px solid var(--text-color-main);
    background: var(--background-color-accent);
    border-radius: 5px;
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
    display: none;
    font-size: 1em;
    margin: 1em;
    cursor: text;
}
</style>
