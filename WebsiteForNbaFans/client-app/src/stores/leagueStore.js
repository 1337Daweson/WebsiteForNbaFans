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
        async getGames(date) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/GamesByDate', { date });
                this.games = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
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