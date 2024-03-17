import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import router from './router';
import PrimeVue from 'primevue/config';
import Lara from '../src/presets/lara';
import { createPinia } from 'pinia';
import DataTable from 'primevue/datatable';
import Menubar from 'primevue/menubar';
import Column from 'primevue/column';
import DataView from 'primevue/dataview';
import Button from 'primevue/button';

const pinia = createPinia();

const app = createApp(App);
app.use(router);
app.use(PrimeVue, {
    unstyled: true,
    pt: Lara
});
app.use(pinia);

app.component('DataTable', DataTable);
app.component('MenuBar', Menubar);
// eslint-disable-next-line vue/multi-word-component-names
app.component('Column', Column);
app.component('DataView', DataView);
app.component('PrimeButton', Button);

app.mount('#app');
