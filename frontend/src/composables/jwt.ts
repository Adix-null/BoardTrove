// src/composables/useJwt.ts
import { ref, computed } from "vue";
import { jwtDecode } from "jwt-decode";

interface JwtPayload {
  id: string;
  exp: string;
  iss: string;
  aud: string;
}

export function getJWT() {
  //change later to use cookies
  const token = ref<string | null>(localStorage.getItem("jwt"));
  const decodedToken = ref<any | null>(null);

  if (token.value) {
    try {
      decodedToken.value = jwtDecode(token.value);
      const userId = decodedToken.value?.id;
    } catch (err) {
      clearJWT();
    }
  }

  const userId = computed(() => decodedToken.value?.id || null);
  const isAuthenticated = computed(() => !!decodedToken.value);

  function setJWT(newToken: string) {
    try {
      document.cookie = `jwt=${newToken}; path=/; secure; samesite=strict;`;
      //localStorage.setItem("jwt", newToken);
      token.value = newToken;
      decodedToken.value = jwtDecode<JwtPayload>(newToken);
    } catch (err) {
      console.error("JWT decoding error:", err);
      clearJWT();
    }
  }

  function clearJWT() {
    //localStorage.removeItem("jwt");
    const date = new Date();
    document.cookie = `jwt=; path=/; expires=${date.setTime(date.getTime() - 1)}`;
    token.value = null;
    decodedToken.value = null;
  }

  return {
    token,
    decodedToken,
    userId,
    isAuthenticated,
    setToken: setJWT,
    clearJWT,
  };
}
