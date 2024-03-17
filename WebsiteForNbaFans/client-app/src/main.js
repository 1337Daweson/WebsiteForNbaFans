import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import router from './router';
import PrimeVue from 'primevue/config';
import Lara from '../src/presets/lara';
import { createPinia } from 'pinia';

const app = createApp(App);
const pinia = createPinia();
app.use(router);
app.use(PrimeVue, {
    unstyled: true,
    pt: Lara
});
app.use(pinia);
app.mount('#app');
