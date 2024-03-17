import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const useTeamStore = defineStore('teamStore', {
    state: () => ({
        teams: [],
        currentTeam: null
    }),

    actions: {
        async getTeams() {
            try {
                const response = await HttpRequestor.get('Nba/Teams');
                this.teams = response.data.data.filter(team => team.city);
            } catch (error) {
                console.error(error);
            }
        },
        async getTeamById(id) {
            try {
                const response = await HttpRequestor.get('Nba/TeamById', { id });
                this.currentTeam = response.data.data;
            } catch (error) {
                console.error(error);
            }
        }
    }
});