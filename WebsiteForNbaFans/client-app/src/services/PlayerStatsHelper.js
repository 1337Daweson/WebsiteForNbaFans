class PlayerStatsCalculator {
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

      // if (playerId === '963') {
      //   console.log(games);
      // }
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
}

export { PlayerStatsCalculator };