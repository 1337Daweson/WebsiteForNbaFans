import { defineStore } from 'pinia';
import HttpRequestor from '../requestor/HttpRequestor';

export const useTeamStore = defineStore('teamStore', {
    state: () => ({
        loaded: false,
        teams: [],
        currentTeam: null,
        roster: [],
        currentPlayer: null,
        playersStats: [],
        teamsStats: [],

    }),

    actions: {
        async getTeams() {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Teams');
                this.teams = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },
        async getTeamById(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Team', { teamId: id });
                this.currentTeam = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },
        async getRoster(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Roster', { teamId: id });
                this.roster = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
            
        },
        async getPlayer(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Player', { playerId: id });
                this.currentPlayer = response.data.response;
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
            
        },
        async getPlayersStats(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/PlayersStats', { teamId: id });
                this.playersStats = [...this.playersStats, ...response.data.response];
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },
        async getTeamsStats(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/TeamsStats', { teamId: id });
                const newTeamsStats = response.data.response.map(teamStats => {
                    return {
                        id, 
                        stats: teamStats,
                    };
                });
                // Merge the new teams stats with the existing ones using the spread operator
                this.teamsStats = [...this.teamsStats, ...newTeamsStats];
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },
        
    },
    getters: {
        NbaTeams: (state) => state.teams.filter(team => team.nbaFranchise === true && team.name !== 'Home Team Stephen A'),
        currentActiveRoster: (state) => state.roster.filter(player => player.nba.pro !== 0 && player.nba.start !== 0 ),
        
    },
});