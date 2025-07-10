import { ref } from "vue";

const visible = ref(false);
const message = ref("");
const duration = ref(3000);
let timer: number | undefined;

export function useToast() {
  function showToast(msg: string) {
    message.value = msg;
    duration.value = 3000;
    visible.value = true;
    clearTimeout(timer);
    timer = window.setTimeout(() => {
      visible.value = false;
    }, 3000);
  }
  return { visible, message, duration, showToast };
}
