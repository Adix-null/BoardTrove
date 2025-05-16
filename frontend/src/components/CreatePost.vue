<script setup lang="ts">
import { reactive, ref, watch, watchEffect } from "vue";
import { TheChessboard, type BoardConfig, BoardApi } from "vue3-chessboard";
import "vue3-chessboard/style.css";

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
//example 1. d4 Nf6 2. c4 e6 3. Nf3 b6 4. g3 Bb7 5. Bg2 Be7 6. Nc3 O-O 7. O-O d5 8. Ne5 c6 9. cxd5 cxd5 10. Bf4 a6 11. Rc1 b5 12. Qb3 Nc6 13. Nxc6 Bxc6 14. h3 Qd7 15. Kh2 Nh5 16. Bd2 f5 17. Qd1 b4 18. Nb1 Bb5 19. Rg1 Bd6 20. e4 fxe4 21. Qxh5 Rxf2 22. Qg5 Raf8 23. Kh1 R8f5 24. Qe3 Bd3 25. Rce1 h6 0-1

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

const handleSubmit = () => {
    if (inavlidFen.value || inavlidPgn.value) {
        alert("Invalid game information");
        return;
    }
    console.log("Title:", title.value);
    console.log("Post Type:", postType.value);
    // Add logic to handle form submission (e.g., API call)
};

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
            </div>

            <!-- Puzzle -->

            <!-- Submit Button -->
            <div id="submit_wrapper">
                <button type="submit" class="action-btn" onsubmit="handleSubmit">Create Post</button>
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