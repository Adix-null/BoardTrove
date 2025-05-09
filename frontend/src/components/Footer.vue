<script setup lang="ts">
</script>

<template>
    <div id="container">
        <p>2025 BoardTrove by Adix Null</p>
        <div class="footer-links">
            <a href="#">Privacy Policy</a>
            <a href="#">Terms of Service</a>
            <a href="#">Contact Us</a>
        </div>
    </div>
</template>

<style scoped>
#container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 16px;
    background-color: var(--background-color-accent, #f8f9fa);
    border-top: 1px solid var(--text-color-main, #ccc);
    font-size: 0.9em;
    color: var(--text-color-main, #333);
}

.footer-links {
    display: none;
    gap: 16px;
    margin-top: 8px;
}

.footer-links a {
    text-decoration: none;
    color: var(--text-color-main, #333);
    transition: color 0.3s;
}

.footer-links a:hover {
    color: var(--primary-color, #007bff);
}
</style>