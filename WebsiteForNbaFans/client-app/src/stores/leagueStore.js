import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const useLeagueStore = defineStore('leagueStore', {
    state: () => ({
        standings: [],
        games: [],
    }),

    actions: {
        async getStandings() {
            try {
                const response = await HttpRequestor.get('Nba/Standings');
                this.standings = response.data.response;
            } catch (error) {
                console.error(error);
            }
        },
        async getGames(date) {
            try {
                const response = await HttpRequestor.get('Nba/GamesByDate', { date });
                this.games = response.data.response;
            } catch (error) {
                console.error(error);
            }
        },
    },
    getters: {
        eastStandings: (state) => state
            .standings
            .filter(standing => standing.conference.name === 'east'),
        westStandings: (state) => state
            .standings
            .filter(standing => standing.conference.name === 'west'),
    },
});