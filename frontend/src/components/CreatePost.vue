<script setup lang="ts">
import { reactive, ref, watch, watchEffect } from "vue";
import { TheChessboard, type BoardConfig, BoardApi } from "vue3-chessboard";
import { useRouter } from 'vue-router';
import "vue3-chessboard/style.css";
import axios from "axios";

const router = useRouter();

const title = ref("");
const postType = ref("game");

const fenInput = ref("");
const startFen: string = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
const inavlidFen = ref(false);

const pgnInput = ref("");
const startPgn: string = "";
const inavlidPgn = ref(false);
const ply = ref(0);
const plyMax = ref(0);

let boardAPI: BoardApi | undefined;

enum MoveAlteration {
    Back,
    Forward,
    Start,
    End
}

const boardConfig = reactive({
    fen: startFen,
    coordinates: true,
    viewOnly: true,
});

function validateSubmit(): boolean {
    if (inavlidFen.value || inavlidPgn.value || (pgnInput.value.trim() == "" && fenInput.value.trim() == "") || title.value.trim() === "") {
        return false;
    }
    //router.push(`/`);
    return true;
};

const submitPGN = () => {
    if (!validateSubmit()) {
        alert("Invalid PGN");
        return;
    }
    // const url = `https://localhost:7167/api/Post/`;
    // axios.post(url, {
    //     title: title.value,
    //     description: description.value,
    //     pgn: pgnInput.value,
    // })
}

const submitFEN = async () => {
    if (!validateSubmit()) {
        alert("Invalid FEN");
        return;
    }
    const url = `https://localhost:7167/api/Post/`;
    try {
        console.log(url);
        const response = await axios.post(url, {
            title: title.value,
            description: "",
            fen: fenInput.value,
        });
        console.log(response);
    } catch (error) {
        console.error(error);
    }
}


function changemove(move: MoveAlteration) {
    switch (move) {
        case MoveAlteration.Start:
            ply.value = 0;
            break;
        case MoveAlteration.End:
            ply.value = plyMax.value;
            break;
        case MoveAlteration.Back:
            ply.value = Math.max(0, ply.value - 1);
            break;
        case MoveAlteration.Forward:
            ply.value = Math.min(plyMax.value, ply.value + 1);
            break;
    }
    boardAPI?.viewHistory(ply.value);
}

watch(fenInput, (newValue) => {
    if (newValue == "") {
        boardAPI?.setPosition(startFen);
    } else {
        try {
            boardAPI?.setPosition(newValue);
            inavlidFen.value = false;
        }
        catch (error) {
            inavlidFen.value = true;
        }
    }
});

watch(pgnInput, (newValue) => {
    if (newValue == "") {
        boardAPI?.loadPgn(startPgn);
    } else {
        try {
            boardAPI?.loadPgn(newValue);
            inavlidPgn.value = false;
            ply.value = boardAPI?.getCurrentPlyNumber() ?? 1;
            plyMax.value = ply.value;
        }
        catch (error) {
            inavlidPgn.value = true;
        }
    }
});

//clear the board when the post type changes
watch(postType, _ => {
    pgnInput.value = "";
    fenInput.value = "";
    boardAPI?.resetBoard();
});

//https://qwerty084.github.io/vue3-chessboard-docs/
</script>

<template>
    <div id="create-post-form">
        <h1>Create a Post</h1>
        <form>
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
                <label for="title">PGN</label>
                <span v-if="inavlidPgn && pgnInput != ''" style="color: red">Invalid PGN string</span>
                <input id="pgn" type="text" v-model="pgnInput" placeholder="Enter a valid PGN string" />

                <a class="chessboard-container">
                    <TheChessboard @board-created="(api) => (boardAPI = api)" :board-config="boardConfig"
                        reactive-config />
                </a>
                <span>
                    <button type="button" class="action-btn move_position"
                        @click="changemove(MoveAlteration.Start)">|⬅</button>
                    <button type="button" class="action-btn move_position"
                        @click="changemove(MoveAlteration.Back)">⬅</button>
                    <button type="button" class="action-btn move_position"
                        @click="changemove(MoveAlteration.Forward)">➡</button>
                    <button type="button" class="action-btn move_position"
                        @click="changemove(MoveAlteration.End)">➡|</button>
                </span>

                <div id="submit_wrapper">
                    <button type="button" id="submit-pgn" class="action-btn" @click="submitPGN">Create
                        Post</button>
                </div>
            </div>

            <!-- Position -->
            <div v-if="postType === 'position'" class="form-group">
                <label for="title">FEN</label>
                <span v-if="inavlidFen" style="color: red">Invalid FEN string</span>
                <input id="fen" type="text" v-model="fenInput" placeholder="Enter a valid FEN string" />
                <a class="chessboard-container">
                    <TheChessboard @board-created="(api) => (boardAPI = api)" :board-config="boardConfig"
                        reactive-config />
                </a>

                <div id="submit_wrapper">
                    <button type="button" id="submit-fen" class="action-btn" @click="submitFEN">Create
                        Post</button>
                </div>
            </div>

            <!-- Puzzle -->

            <!-- Submit Button -->

        </form>
    </div>
</template>

<style scoped>
#create-post-form {
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid var(--text-color-main);
    box-shadow: 0 2px 16px 0 rgba(0, 0, 0, 0.12);
    background: var(--background-color-accent);
    border-radius: 8px;
}

.move_position {
    margin: 5px;
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
</style>