// src/composables/useJwt.ts
import { ref, computed } from "vue";
import { jwtDecode } from "jwt-decode";
import axios from "axios";

export const jwt = ref<JwtPayload | null>(null);
export const userId = ref<string | null>(null);

interface JwtPayload {
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name": string;
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": string;
  exp: string;
  iss: string;
  aud: string;
}

export function useJWT() {
  function getCookie(name: string): string | null {
    const match = document.cookie.match(new RegExp("(^| )" + name + "=([^;]+)"));
    return match ? decodeURIComponent(match[2]) : null;
  }

  function getJWT(): string | null {
    const cookie = ref<any | null>(getCookie("jwt"));

    if (cookie.value) {
      try {
        jwt.value = jwtDecode<JwtPayload>(cookie.value);
        userId.value =
          jwt.value["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] || null;
        console.log("JWT decoded:", userId.value);
        return userId!.value;
      } catch (err) {
        clearJWT();
        return null;
      }
    }
    return null;
  }

  function setJWT(newToken: string): void {
    try {
      document.cookie = `jwt=${newToken}; path=/; secure; samesite=strict;`;
      getJWT();
    } catch (err) {
      console.error("cookie error:", err);
      clearJWT();
    }
  }

  function clearJWT(): void {
    const date = new Date();
    document.cookie = `jwt=; path=/; expires=${date.setTime(date.getTime() - 1)}`;
    jwt.value = null;
  }

  const returnUser = async () => {
    useJWT().getJWT();
    console.log(userId.value);
    let url = `https://localhost:7167/api/User/${userId.value}`;
    const response = await axios.get(url);
    return response.data;
  };

  return {
    jwt,
    getJWT,
    setJWT,
    clearJWT,
    returnUser,
  };
}
