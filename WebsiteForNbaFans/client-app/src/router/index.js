import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../pages/HomePage.vue';
import AboutPage from '../pages/AboutPage.vue';
import TeamsPage from '../pages/TeamsPage.vue';
import TeamDetail from '../pages/TeamDetail.vue';


const routes = [
    {
        path: '/',
        name: 'Domov',
        component: HomePage
    },
    {
        path: '/about',
        name: 'O nás',
        component: AboutPage
    },
    {
        path: '/teams',
        name: 'Týmy',
        component: TeamsPage
    },
    {
        path: '/teams/:id',
        name: 'Tým',
        component: TeamDetail
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;