import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const useLeagueStore = defineStore('leagueStore', {
    state: () => ({
        loaded: false,
        standings: [],
        games: [],
    }),

    actions: {
        async getStandings() {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Standings');
                this.standings = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },
        async getGamesPerSeason() {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/GamesPerSeason');
                // console.log(response.data.response);
                this.games = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },
    },
    getters: {
        eastStandings: (state) => state.standings.filter(standing => standing.conference.name === 'east').sort((a, b) => b.win.total - a.win.total),
        westStandings: (state) => state.standings.filter(standing => standing.conference.name === 'west').sort((a, b) => b.win.total - a.win.total),
        finishedGames: (state) => state.games
        .sort((a,b) => new Date(b.date.start) - new Date(a.date.start)),
    },
});