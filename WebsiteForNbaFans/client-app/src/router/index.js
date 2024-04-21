import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../pages/HomePage.vue';
import AboutPage from '../pages/AboutPage.vue';
import TeamsPage from '../pages/team/TeamsPage.vue';
import TeamDetail from '../pages/team/TeamDetail.vue';
import PlayerDetail from '../pages/player/PlayerDetail.vue';
import StandingsPage from '../pages/standings/StandingsPage.vue';
import PlayersStatsPage from '../pages/stats/PlayersStatsPage.vue';
import TeamsStatsPage from '../pages/stats/TeamsStatsPage.vue';
import ArticlesPage from '../pages/article/ArticlesPage.vue';
import PlayersPage from '../pages/player/PlayersPage.vue';
import ArticleDetail from '../pages/article/ArticleDetail.vue';
import GameDetail from '../pages/game/GameDetail.vue';

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
        path: '/stats-players',
        name: 'Statistika - hráči',
        component: PlayersStatsPage,
    },
    {
        path: '/stats-teams',
        name: 'Statistika - týmy',
        component: TeamsStatsPage,
    },
    {
        path: '/articles',
        name: 'články',
        component: ArticlesPage,
    },
    {
        path: '/players',
        name: 'hráči',
        component: PlayersPage,
    },
    {
        path: '/article/:id',
        name: 'článek',
        component: ArticleDetail,
    },
    {
        path: '/game/:id',
        name: 'zápas',
        component: GameDetail,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;