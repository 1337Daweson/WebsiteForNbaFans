import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import PrimeVue from "primevue/config";
import Button from "primevue/button";
import Lara from "@/presets/lara";
import "./style.css";
import { createPinia } from 'pinia';

const app = createApp(App);
const pinia = createPinia();
app.use(PrimeVue, {
  unstyled: true,
  pt: Lara,
});
app.component("ButtonPrimeVue", Button);
app.use(pinia).use(router).mount("#app");
