import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import ProfileView from "../views/ProfileView.vue";
import CreatePostView from "../views/CreatePostView.vue";
import LoginView from "../views/LoginView.vue";
import SignUp from "../views/SignUpView.vue";
import NotFoundView from "../views/NotFoundView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/profile",
      name: "profile",
      component: ProfileView,
    },
    {
      path: "/create-post",
      name: "create-post",

      component: CreatePostView,
    },
    {
      path: "/Login",
      name: "login",
      component: LoginView,
    },
    {
      path: "/SignUp",
      name: "signup",
      component: SignUp,
    },
    {
      path: "/:catchAll(.*)",
      name: "404",
      component: NotFoundView,
    },
  ],
});

export default router;
