import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../pages/HomePage.vue';
import AboutPage from '../pages/AboutPage.vue';
import TeamsPage from '../pages/TeamsPage.vue';
import TeamDetail from '../pages/TeamDetail.vue';
import PlayerDetail from '../pages/PlayerDetail.vue';
import StandingsPage from '../pages/StandingsPage.vue';
import StatsPage from '../pages/StatsPage.vue';


const routes = [
    {
        path: '/',
        name: 'Domov',
        component: HomePage,
    },
    {
        path: '/about',
        name: 'O nás',
        component: AboutPage,
    },
    {
        path: '/teams',
        name: 'Týmy',
        component: TeamsPage,
    },
    {
        path: '/team/:id',
        name: 'Tým',
        component: TeamDetail,
    },
    {
        path: '/player/:playerId',
        name: 'Hráč',
        component: PlayerDetail,
    },
    {
        path: '/standings',
        name: 'Tabulky',
        component: StandingsPage,
    },
    {
        path: '/stats',
        name: 'Statistika',
        component: StatsPage,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;