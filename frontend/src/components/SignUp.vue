<script setup lang="ts">
import { ref } from "vue";
import { RouterLink } from 'vue-router';
import { supabase } from '../../../backend/supabase.js'

const email = ref("");
const username = ref("");
const password = ref("");
const confirmPassword = ref("");

// Sign up
const { data, error } = await supabase.auth.signUp({
    email: email.value,
    password: password.value,
})

function handleSignUp() {
    if (password.value !== confirmPassword.value) {
        alert("Make sure the passwords match");
        return;
    }
    // Proceed with registration (API call, etc.)
    console.log("Register:", email.value, username.value, password.value);
}
</script>

<template>
    <div id="container">
        <h2>Create an account</h2>
        <form @submit.prevent="handleSignUp" class="signup-form">
            <div class="form-group">
                <label for="email">Email</label>
                <input id="email" type="email" v-model="email" placeholder="Enter your email" required />
            </div>
            <div class="form-group">
                <label for="username">Username</label>
                <input id="username" type="text" v-model="username" placeholder="Choose a username" required />
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input id="password" type="password" v-model="password" placeholder="Create a password" required />
            </div>
            <div class="form-group">
                <label for="confirmPassword">Confirm Password</label>
                <input id="confirmPassword" type="password" v-model="confirmPassword" placeholder="Repeat your password"
                    required />
            </div>
            <button type="submit" class="action-btn">Sign Up</button>
        </form>

        <div class="divider">or</div>

        <div class="other-options">
            <button class="option-btn google">
                <span class="icon-circle">
                    <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Google_Favicon_2025.svg/250px-Google_Favicon_2025.svg.png"
                        alt="Google" />
                </span>
                Continue with Google
            </button>
        </div>

        <div class="text_link">
            <span>Already have an account? <RouterLink to="/login">Log In</RouterLink></span>
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

.signup-form {
    width: 100%;
    display: flex;
    flex-direction: column;
    gap: 14px;
}

.form-group {
    display: flex;
    flex-direction: column;
    gap: 4px;
}

label {
    font-weight: bold;
    font-size: 0.98em;
}

.divider {
    margin: 18px 0 10px 0;
    text-align: center;
    color: var(--text-color-secondary, #888);
}

.other-options {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 12px;
    width: 100%;
    margin-bottom: 10px;
}

.option-btn {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 12px;
    padding: 10px 18px;
    border: none;
    border-radius: 6px;
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
    object-fit: contain;
}

.option-btn.google:hover {
    background: #ea4335;
}

.option-btn.github:hover {
    background: #24292e;
}

.text_link {
    margin-top: 10px;
}
</style>