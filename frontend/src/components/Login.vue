<script setup lang="ts">
import { ref } from "vue";
import { RouterLink } from 'vue-router';

import axios from "axios";
import { useToast } from "@/composables/useToast";
import router from "@/router";
import { useJWT } from '@/composables/jwt'

const username = ref("");
const password = ref("");

const { showToast } = useToast();

const handleLogin = async () => {
    let url = `https://localhost:7167/api/Auth/login`;
    try {
        const response = await axios.post(url, {
            username: username.value,
            password: password.value
        });
        console.log(response.data);
        useJWT().setJWT(response.data);
        showToast("Login successful");
        router.push("/");
    } catch (error: any) {
        showToast("Incorrect credentials");
    }
};

</script>

<template>
    <div id="container">
        <h2>Log In to BoardTrove</h2>
        <form @submit.prevent="handleLogin" class="login-form">
            <div class="form-group">
                <label for="username">Username</label>
                <input id="username" type="text" v-model="username" placeholder="Choose a username" required />
            </div>

            <div class="form-group">
                <label for="password">Password</label>
                <input id="password" type="password" v-model="password" placeholder="Enter your password" required />
            </div>
            <button type="submit" class="action-btn">Log In</button>
        </form>

        <!-- <div class="divider">or</div>

        <div class="other-options">
            <button class="option-btn google">
                <span class="icon-circle">
                    <img src="../assets/google.jpg" alt="Google" />
                </span>
                Continue with Google
            </button>
        </div> -->

        <div class="text_link">
            <!-- <span><RouterLink to="/register">Forgot password?</RouterLink></span> -->
        </div>
        <div class="text_link">
            <span>Don't have an account? <RouterLink to="/signup">Sign Up</RouterLink></span>
        </div>
    </div>
</template>

<style scoped>
#container {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-top: 40px;
    width: 300px;
    background: var(--background-color-accent);
    padding: 32px 24px;
    border-radius: 12px;
    box-shadow: 0 2px 16px 0 rgba(0, 0, 0, 0.12);
}

h2 {
    margin-bottom: 24px;
    color: var(--text-color-main);
}

.login-form {
    display: flex;
    flex-direction: column;
    width: 100%;
}

.form-group {
    margin-bottom: 15px;
    display: flex;
    flex-direction: column;
}

label {
    margin-bottom: 6px;
    color: var(--text-color-main, #fff);
    font-size: 0.95em;
}

.divider {
    margin: 16px 0;
    color: #888;
    font-size: 0.95em;
}

.text_link {
    margin-top: 10px;
}

.other-options {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 12px;
    width: 100%;
    margin-top: 8px;
}

.option-btn {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 12px;
    padding: 10px 18px;
    border: none;
    border-radius: 10px;
    font-size: 1em;
    cursor: pointer;
    background: #333;
    color: #fff;
    transition: background 0.2s;
    width: 100%;
    max-width: 260px;
}

.icon-circle {
    width: 32px;
    height: 32px;
    border-radius: 50%;
    background: #fff;
    display: flex;
    align-items: center;
    justify-content: center;
    margin-right: 8px;
    overflow: hidden;
}

.icon-circle img {
    width: 22px;
    height: 22px;
}

.option-btn.google:hover {
    background: #ea4335;
}

.option-btn.github:hover {
    background: #24292e;
}
</style>