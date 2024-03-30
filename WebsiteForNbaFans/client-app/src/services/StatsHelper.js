class StatsCalculator {
  static calculatePlayerStats(gameStatsArray) {
    // Step 1: Group statistics by player
    const groupedByPlayer = gameStatsArray.reduce((acc, gameStat) => {
      const playerId = gameStat.player.id;
      if (!acc[playerId]) {
        acc[playerId] = {
          name: gameStat.player.firstname + ' ' + gameStat.player.lastname,
          games: [],
          totalPoints: 0,
          totalMinutes: 0,
          totalShotsMade: 0,
          totalShotsAttempted: 0,
          team: gameStat.team.code,
          totalTreesMade: 0,
          totalTreesAttempted: 0,
          totalFreeThrowsMade: 0,
          totalFreeThrowsAttempted: 0,
          totalOffReb: 0,
          totalDefReb: 0,
          totalReb: 0,
          totalAssists: 0,
          totalTurnovers: 0,
          totalSteals: 0,
          totalBlocks: 0,
          totalPersonalFouls: 0,
          totalPlusMinus: 0,
        };
      }
      acc[playerId].games.push(gameStat);
      acc[playerId].totalPoints += gameStat.points;
      acc[playerId].totalMinutes += Number.parseFloat(gameStat.min);
      acc[playerId].totalShotsMade += gameStat.fgm; // fgm is the number of shots made
      acc[playerId].totalShotsAttempted += gameStat.fga; // fga is the number of shots attempted
      acc[playerId].totalTreesMade += gameStat.tpm;
      acc[playerId].totalTreesAttempted += gameStat.tpa;
      acc[playerId].totalFreeThrowsMade += gameStat.ftm;
      acc[playerId].totalFreeThrowsAttempted += gameStat.fta;
      acc[playerId].totalOffReb += gameStat.offReb;
      acc[playerId].totalDefReb += gameStat.defReb;
      acc[playerId].totalReb += gameStat.totReb;
      acc[playerId].totalAssists += gameStat.assists;
      acc[playerId].totalTurnovers += gameStat.turnovers;
      acc[playerId].totalSteals += gameStat.steals;
      acc[playerId].totalBlocks += gameStat.blocks;
      acc[playerId].totalPersonalFouls += gameStat.pFouls;
      acc[playerId].totalPlusMinus += Number.parseFloat(gameStat.plusMinus);
      return acc;
    }, {});

    // Step 2: Calculate points per game, average minutes played per game, field goals made, etc. for each player
    const playerStats = [];
    for (const playerId in groupedByPlayer) {
      const { name, games, totalPoints, totalMinutes, team,
        totalShotsMade, totalShotsAttempted,
        totalTreesMade, totalTreesAttempted,
        totalFreeThrowsMade, totalFreeThrowsAttempted,
        totalOffReb, totalDefReb, totalReb,
        totalAssists, totalTurnovers, totalSteals, totalBlocks,
        totalPersonalFouls, totalPlusMinus,
      } = groupedByPlayer[playerId];

      const numberOfGames = games.length;
      const averageMinutesPerGame = parseFloat((totalMinutes / numberOfGames).toFixed(1));

      const fieldGoalsMade = parseFloat((totalShotsMade / numberOfGames).toFixed(1));
      const fieldGoalsAttempted = parseFloat((totalShotsAttempted / numberOfGames).toFixed(1));
      const fieldGoalPercentage = parseFloat((totalShotsMade / totalShotsAttempted * 100).toFixed(1));

      const treePointersMade = parseFloat((totalTreesMade / numberOfGames).toFixed(1));
      const treePointersAttempted = parseFloat((totalTreesAttempted / numberOfGames).toFixed(1));
      const treePointersPercentage = parseFloat((totalTreesMade / totalTreesAttempted * 100).toFixed(1));

      const freeThrowsMade = parseFloat((totalFreeThrowsMade / numberOfGames).toFixed(1));
      const freeThrowsAttempted = parseFloat((totalFreeThrowsAttempted / numberOfGames).toFixed(1));
      const freeThrowsPercentage = parseFloat((totalFreeThrowsMade / totalFreeThrowsAttempted * 100).toFixed(1));

      const offRebMade = parseFloat((totalOffReb / numberOfGames).toFixed(1));
      const defRebMade = parseFloat((totalDefReb / numberOfGames).toFixed(1));
      const rebMade = parseFloat((totalReb / numberOfGames).toFixed(1));

      const assistsMade = parseFloat((totalAssists / numberOfGames).toFixed(1));
      const turnoversMade = parseFloat((totalTurnovers / numberOfGames).toFixed(1));
      const stealsMade = parseFloat((totalSteals / numberOfGames).toFixed(1));
      const blocksMade = parseFloat((totalBlocks / numberOfGames).toFixed(1));

      const personalFouls = parseFloat((totalPersonalFouls / numberOfGames).toFixed(1));
      const plusMinusPerGame = parseFloat((totalPlusMinus / numberOfGames).toFixed(1));


      playerStats.push({
        playerId,
        name,
        team,
        numberOfGames,
        averageMinutesPerGame,
        pointsPerGame: parseFloat((totalPoints / numberOfGames).toFixed(1)),
        fieldGoalsMade,
        fieldGoalsAttempted,
        fieldGoalPercentage,
        treePointersMade,
        treePointersAttempted,
        treePointersPercentage,
        freeThrowsMade,
        freeThrowsAttempted,
        freeThrowsPercentage,
        offRebMade,
        defRebMade,
        rebMade,
        assistsMade,
        turnoversMade,
        stealsMade,
        blocksMade,
        personalFouls,
        plusMinusPerGame,
      });
    }

    return playerStats.sort((a, b) => b.pointsPerGame - a.pointsPerGame);
  }

  static calculateTeamStats(gameStatsArray, teams) {
    // Step 1: Create a mapping object for teamStats
    const teamStatsMap = gameStatsArray.reduce((acc, teamStat) => {
      acc[teamStat.id] = teamStat.stats;
      return acc;
    }, {});

    // Step 2 & 3: Merge the arrays and collect the merged objects
    const mergedArray = teams.map(team => ({
      id: team.id,
      name: team.name,
      stats: teamStatsMap[team.id] || {}, // Use an empty object if no stats are found
    }));
    return mergedArray;
  }

  static getTeamWinsLosses(games) {

    const teamStats = games.reduce((acc, game) => {
      // Check if the game's stage is set to 2
      if (game.stage !== 2) {
        return acc;
      }

      // For each team in the game
      ['home', 'visitors'].forEach(teamKey => {
        const team = game.teams[teamKey];
        const score = game.scores[teamKey];

        // Initialize team stats if not already present
        if (!acc[team.id]) {
          acc[team.id] = {
            teamId: team.id,
            teamName: team.name,
            wins: 0,
            losses: 0,
            totalGames: 0, // Initialize totalGames for each team
          };
        }

        // Compare points to determine the winner
        const opponentScore = game.scores[teamKey === 'home' ? 'visitors' : 'home'].points;
        if (score.points > opponentScore) {
          acc[team.id].wins++;
        } else if (score.points < opponentScore) {
          acc[team.id].losses++;
        }
        // Increment totalGames for each team
        acc[team.id].totalGames = acc[team.id].wins + acc[team.id].losses;
      });

      return acc;
    }, {});

    // Convert the teamStats object to an array
    const teamStatsArray = Object.values(teamStats);
    return teamStatsArray;
  }

  static transformTeamStats(gameStatsArray) {
    // Step 1: Group statistics by player
    const groupedByTeam = gameStatsArray.reduce((acc, gameStat) => {
      const teamId = gameStat.teamId;
      if (!acc[teamId]) {
        acc[teamId] = {
          name: gameStat.teamName,
          games: gameStat.totalGames,
          statsGames: gameStat.stats.games,
          wins: gameStat.wins,
          losses: gameStat.losses,
          totalPoints: 0,
          totalMinutes: 0,
          totalShotsMade: 0,
          totalShotsAttempted: 0,
          totalTreesMade: 0,
          totalTreesAttempted: 0,
          totalFreeThrowsMade: 0,
          totalFreeThrowsAttempted: 0,
          totalOffReb: 0,
          totalDefReb: 0,
          totalReb: 0,
          totalAssists: 0,
          totalTurnovers: 0,
          totalSteals: 0,
          totalBlocks: 0,
          totalPersonalFouls: 0,
          totalPlusMinus: 0,
        };
      }
      if (teamId === 15) {
        acc[teamId].games = acc[teamId].games - 1;
        acc[teamId].losses = acc[teamId].losses - 1;
      }
      else if (teamId === 17) {
        acc[teamId].games = acc[teamId].games - 1;
        acc[teamId].wins = acc[teamId].wins - 1;

      }
      acc[teamId].totalPoints += gameStat.stats.points;
      acc[teamId].totalShotsMade += gameStat.stats.fgm; // fgm is the number of shots made
      acc[teamId].totalShotsAttempted += gameStat.stats.fga; // fga is the number of shots attempted
      acc[teamId].totalTreesMade += gameStat.stats.tpm;
      acc[teamId].totalTreesAttempted += gameStat.stats.tpa;
      acc[teamId].totalFreeThrowsMade += gameStat.stats.ftm;
      acc[teamId].totalFreeThrowsAttempted += gameStat.stats.fta;
      acc[teamId].totalOffReb += gameStat.stats.offReb;
      acc[teamId].totalDefReb += gameStat.stats.defReb;
      acc[teamId].totalReb += gameStat.stats.totReb;
      acc[teamId].totalAssists += gameStat.stats.assists;
      acc[teamId].totalTurnovers += gameStat.stats.turnovers;
      acc[teamId].totalSteals += gameStat.stats.steals;
      acc[teamId].totalBlocks += gameStat.stats.blocks;
      acc[teamId].totalPersonalFouls += gameStat.stats.pFouls;
      acc[teamId].totalPlusMinus += Number.parseFloat(gameStat.stats.plusMinus);
      return acc;
    }, {});

    // Step 2: Calculate points per game, average minutes played per game, field goals made, etc. for each player
    const teamStats = [];
    for (const teamId in groupedByTeam) {
      const { name, games, wins, losses, totalPoints,
        totalShotsMade, totalShotsAttempted, 
        totalTreesMade, totalTreesAttempted, 
        totalFreeThrowsMade, totalFreeThrowsAttempted, 
        totalOffReb, totalDefReb, totalReb,
        totalAssists, totalTurnovers, totalSteals, totalBlocks, 
        totalPersonalFouls, totalPlusMinus, statsGames,
      } = groupedByTeam[teamId];

      const numberOfGames = statsGames;

      const fieldGoalsMade = parseFloat((totalShotsMade / numberOfGames).toFixed(1));
      const fieldGoalsAttempted = parseFloat((totalShotsAttempted / numberOfGames).toFixed(1));
      const fieldGoalPercentage = parseFloat((totalShotsMade / totalShotsAttempted * 100).toFixed(1)); 

      const treePointersMade = parseFloat((totalTreesMade / numberOfGames).toFixed(1));
      const treePointersAttempted = parseFloat((totalTreesAttempted / numberOfGames).toFixed(1));
      const treePointersPercentage = parseFloat((totalTreesMade / totalTreesAttempted * 100).toFixed(1));

      const freeThrowsMade = parseFloat((totalFreeThrowsMade / numberOfGames).toFixed(1));
      const freeThrowsAttempted = parseFloat((totalFreeThrowsAttempted / numberOfGames).toFixed(1));
      const freeThrowsPercentage = parseFloat((totalFreeThrowsMade / totalFreeThrowsAttempted * 100).toFixed(1));

      const offRebMade = parseFloat((totalOffReb / numberOfGames).toFixed(1));
      const defRebMade = parseFloat((totalDefReb / numberOfGames).toFixed(1));
      const rebMade = parseFloat((totalReb / numberOfGames).toFixed(1));

      const assistsMade = parseFloat((totalAssists / numberOfGames).toFixed(1));
      const turnoversMade = parseFloat((totalTurnovers / numberOfGames).toFixed(1));
      const stealsMade = parseFloat((totalSteals / numberOfGames).toFixed(1));
      const blocksMade = parseFloat((totalBlocks / numberOfGames).toFixed(1));

      const personalFouls = parseFloat((totalPersonalFouls / numberOfGames).toFixed(1));
      const plusMinusPerGame = parseFloat((totalPlusMinus / numberOfGames).toFixed(1));


      teamStats.push({
        teamId,
        name,
        wins,
        losses,
        games,  
        pointsPerGame: parseFloat((totalPoints / numberOfGames).toFixed(1)),
        fieldGoalsMade,
        fieldGoalsAttempted,
        fieldGoalPercentage,
        treePointersMade,
        treePointersAttempted,
        treePointersPercentage,
        freeThrowsMade,
        freeThrowsAttempted,
        freeThrowsPercentage,
        offRebMade,
        defRebMade,
        rebMade,
        assistsMade,
        turnoversMade,
        stealsMade,
        blocksMade,
        personalFouls,
        plusMinusPerGame,
      });
    }

    return teamStats.sort((a, b) => b.pointsPerGame - a.pointsPerGame);
 }




}

export { StatsCalculator };