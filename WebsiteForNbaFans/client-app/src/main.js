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
import Paginator from 'primevue/paginator';
import Carousel from 'primevue/carousel';
import Card from 'primevue/card';
import ProgressSpinner from 'primevue/progressspinner';

const pinia = createPinia();

const app = createApp(App);
app.use(router);
app.use(PrimeVue, {
    unstyled: true,
    pt: Lara,
});
app.use(pinia);

app.component('DataTable', DataTable);
app.component('MenuBar', Menubar);
app.component('PrimeColumn', Column);
app.component('DataView', DataView);
app.component('PrimeButton', Button);
app.component('PrimePaginator', Paginator);
app.component('PrimeCarousel', Carousel);
app.component('PrimeCard', Card);
app.component('ProgressSpinner', ProgressSpinner);

app.mount('#app');
