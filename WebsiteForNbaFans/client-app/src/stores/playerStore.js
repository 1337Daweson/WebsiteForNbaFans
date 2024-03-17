import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const usePlayerStore = defineStore('playerStore', {
    state: () => ({
        players: []
    }),

    actions: {
        async getPlayersByTeam(teamId) {
            try {
                const response = await HttpRequestor.get('Nba/PlayersByTeamId', { teamId });
                this.players = response.data.data.filter(player => player.draft_year >= 2003);
            } catch (error) {
                console.error(error);
            }
        }
    }
});