import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const useTeamStore = defineStore('teamStore', {
    state: () => ({
        teams: []
    }),

    actions: {
        async getTeams() {
            try {
                const response = await HttpRequestor.get('Home/Teams');
                this.teams = response.data.data;
            } catch (error) {
                console.error(error);
            }
        }
    }
});