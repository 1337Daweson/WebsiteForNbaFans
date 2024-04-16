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
        playerStats: [],
        players: [],
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
            // console.log('getPlayer');
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Player', { playerId: id });
                this.currentPlayer = response.data.response[0];
                // console.log(this.currentPlayer);
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
            
        },
        async getPlayersStats(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/PlayersStatsByTeam', { teamId: id });
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
        async getPlayerStats(id, year) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/PlayerStats', { playerId: id, season: year });

        
                // Create an object with the year and response data
                // console.log(year);
                // console.log(response.data.response);
                const responseObject = { season: year, games: response.data.response };
        
                // Push the object into the allResponses array
                this.playerStats.push(responseObject);
        
            } catch (error) {
                console.error(error);
            } finally {
                this.loaded = true;
            }
        },

        async getAllPlayers(id) {
            try {
                this.loaded = false;
                const response = await HttpRequestor.get('Nba/Roster', { teamId: id });
                this.players.push({teamId: id, players: response.data.response});
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