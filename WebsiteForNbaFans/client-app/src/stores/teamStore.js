import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const useTeamStore = defineStore('teamStore', {
    state: () => ({
        teams: [],
        currentTeam: null,
        roster: [],
        currentPlayer: null,
    }),

    actions: {
        async getTeams() {
            try {
                const response = await HttpRequestor.get('Nba/Teams');
                this.teams = response.data.response;
            } catch (error) {
                console.error(error);
            }
        },
        async getTeamById(id) {
            try {
                const response = await HttpRequestor.get('Nba/Team', { teamId: id });
                this.currentTeam = response.data.response;
            } catch (error) {
                console.error(error);
            }
        },
        async getRoster(id) {
            try {
                const response = await HttpRequestor.get('Nba/Roster', { teamId: id });
                this.roster = response.data.response;
            } catch (error) {
                console.error(error);
            }
            
        },
        async getPlayer(id) {
            try {
                const response = await HttpRequestor.get('Nba/Player', { playerId: id });
                this.currentPlayer = response.data.response;
            } catch (error) {
                console.error(error);
            }
            
        },
    },
    getters: {
        NbaTeams: (state) => state.teams.filter(team => team.nbaFranchise === true && team.name !== 'Home Team Stephen A'),
        currentActiveRoster: (state) => state.roster.filter(player => player.nba.pro !== 0 && player.nba.start !== 0 ),
    },
});