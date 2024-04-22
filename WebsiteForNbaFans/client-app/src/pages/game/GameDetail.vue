<template>
  <LoadingModal :loaded="loaded" />
  <div class="h-full flex flex-row items-center justify-center">
    <div
      v-if="game"
      class="p-5 w-1/2"
    >
      <div class="w-full bg-white">
        <table class="text-xs">
          <tr>
            <th>TÝM</th>
            <th>Q1</th>
            <th>Q2</th>
            <th>Q3</th>
            <th>Q4</th>
            <th>KONEC</th>
          </tr>
          <tr>
            <td>{{ game.teams.visitors.code }}</td>
            <td>{{ game.scores.visitors.linescore[0] }}</td>
            <td>{{ game.scores.visitors.linescore[1] }}</td>
            <td>{{ game.scores.visitors.linescore[2] }}</td>
            <td>{{ game.scores.visitors.linescore[3] }}</td>
            <td>{{ game.scores.visitors.points }}</td>
          </tr>
          <tr>
            <td>{{ game.teams.home.code }}</td>
            <td>{{ game.scores.home.linescore[0] }}</td>
            <td>{{ game.scores.home.linescore[1] }}</td>
            <td>{{ game.scores.home.linescore[2] }}</td>
            <td>{{ game.scores.home.linescore[3] }}</td>
            <td>{{ game.scores.home.points }}</td>
          </tr>
        </table>
      </div>
    </div>
    <div class="w-1/2 h-full pr-10 bg-white mr-8 mt-9">
      <PrimeChart
        type="bar"
        :data="chartData"
        :options="chartOptions"
        class="h-full w-full"
        :width="500"
        :height="300"
      />
    </div>
  </div>
  <DataTable 
    v-if="game"
    ref="dtb"
    :value="groupedStats[0]"
    size="small"
    :rows="20"
    class="m-4 p-4"
    :rows-hover="true"
  >
    <template #header>
      {{ game.teams.visitors.name }}
    </template>
    <PrimeColumn 
      field="player.firstname"
      header="Hráč"
      class="text-xs w-56"
    >
      <template #body="slotProps">
        {{ slotProps.data.player.firstname }} {{ slotProps.data.player.lastname }}  
      </template>
    </PrimeColumn>

    <PrimeColumn 
      field="min"
      header="MIN"
      class="text-xs "
    />

    <PrimeColumn 
      field="fgm"
      header="FGM"
      class="text-xs "
    />

    <PrimeColumn 
      field="fga"
      header="FGA"
      class="text-xs "
    />

    <PrimeColumn 
      field="fgp"
      header="FG%"
      class="text-xs "
    />

    <PrimeColumn 
      field="tpm"
      header="3PM"
      class="text-xs "
    />

    <PrimeColumn 
      field="tpa"
      header="3PA"
      class="text-xs "
    />

    <PrimeColumn 
      field="tpp"
      header="3P%"
      class="text-xs "
    />

    <PrimeColumn 
      field="ftm"
      header="FTM"
      class="text-xs "
    />

    <PrimeColumn 
      field="fta"
      header="FTA"
      class="text-xs "
    />

    <PrimeColumn 
      field="ftp"
      header="FT%"
      class="text-xs "
    />

    <PrimeColumn 
      field="offReb"
      header="OREB"
      class="text-xs "
    />

    <PrimeColumn 
      field="defReb"
      header="DREB"
      class="text-xs "
    />

    <PrimeColumn 
      field="totReb"
      header="REB"
      class="text-xs "
    />

    <PrimeColumn 
      field="assists"
      header="AST"
      class="text-xs "
    />

    <PrimeColumn 
      field="steals"
      header="STL"
      class="text-xs "
    />

    <PrimeColumn 
      field="blocks"
      header="BLK"
      class="text-xs "
    />

    <PrimeColumn 
      field="turnovers"
      header="TO"
      class="text-xs "
    />

    <PrimeColumn 
      field="pFouls"
      header="PF"
      class="text-xs "
    />

    <PrimeColumn
      field="points"
      header="BODY"
      class="text-xs"
    />

    <PrimeColumn 
      field="plusMinus"
      header="+/-"
      class="text-xs "
    />
  </DataTable>

  <DataTable 
    v-if="game"
    ref="dtb"
    :value="groupedStats[1]"
    size="small"
    :rows="20"
    class="m-4 p-4"
    :rows-hover="true"
  >
    <template #header>
      {{ game.teams.home.name }}
    </template>
    <PrimeColumn 
      field="player.firstname"
      header="Hráč"
      class="text-xs w-56"
    >
      <template #body="slotProps">
        {{ slotProps.data.player.firstname }} {{ slotProps.data.player.lastname }}  
      </template>
    </PrimeColumn>

    <PrimeColumn 
      field="min"
      header="MIN"
      class="text-xs "
    />

    <PrimeColumn 
      field="fgm"
      header="FGM"
      class="text-xs "
    />

    <PrimeColumn 
      field="fga"
      header="FGA"
      class="text-xs "
    />

    <PrimeColumn 
      field="fgp"
      header="FG%"
      class="text-xs "
    />

    <PrimeColumn 
      field="tpm"
      header="3PM"
      class="text-xs "
    />

    <PrimeColumn 
      field="tpa"
      header="3PA"
      class="text-xs "
    />

    <PrimeColumn 
      field="tpp"
      header="3P%"
      class="text-xs "
    />

    <PrimeColumn 
      field="ftm"
      header="FTM"
      class="text-xs "
    />

    <PrimeColumn 
      field="fta"
      header="FTA"
      class="text-xs "
    />

    <PrimeColumn 
      field="ftp"
      header="FT%"
      class="text-xs "
    />

    <PrimeColumn 
      field="offReb"
      header="OREB"
      class="text-xs "
    />

    <PrimeColumn 
      field="defReb"
      header="DREB"
      class="text-xs "
    />

    <PrimeColumn 
      field="totReb"
      header="REB"
      class="text-xs "
    />

    <PrimeColumn 
      field="assists"
      header="AST"
      class="text-xs "
    />

    <PrimeColumn 
      field="steals"
      header="STL"
      class="text-xs "
    />

    <PrimeColumn 
      field="blocks"
      header="BLK"
      class="text-xs "
    />

    <PrimeColumn 
      field="turnovers"
      header="TO"
      class="text-xs "
    />

    <PrimeColumn 
      field="pFouls"
      header="PF"
      class="text-xs "
    />

    <PrimeColumn
      field="points"
      header="BODY"
      class="text-xs"
    />

    <PrimeColumn 
      field="plusMinus"
      header="+/-"
      class="text-xs "
    />
  </DataTable>
</template>

<script setup>
import { computed, onMounted, ref } from 'vue';
import { useLeagueStore } from '../../stores/leagueStore';
import { useRoute } from 'vue-router';
import { StatsCalculator } from '../../services/StatsHelper';


const leagueStore = useLeagueStore();
const route = useRoute();
const id = Number.parseInt(route.params.id);
const loaded = computed(() => leagueStore.loaded);
const game = computed(() => leagueStore.currentGame);
const games = computed(() => leagueStore.finishedGames);

const gameStats = computed(() => leagueStore.gameStats);

const groupedStats = computed(() => StatsCalculator.groupPlayersByTeamId(gameStats.value, game.value));

const visitorTotalStats = computed(() => StatsCalculator.calculateTotalStatsByTeam(groupedStats.value[0]));
const homeTotalStats = computed(() => StatsCalculator.calculateTotalStatsByTeam(groupedStats.value[1]));


const chartData = ref();
const chartOptions = ref();

const labels = ['points', 'totReb', 'assists', 'steals', 'blocks', 'turnovers', 'fgp', 'tpp', 'ftp'];

const changeToChart = (stats) => {
  return labels.map(label => {
   const subArray = stats.find(sub => sub[0] === label);
   return subArray ? subArray[1] : null; // Return the value if found, otherwise null
  });
};

const setChartOptions = () => {
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--text-color');
    const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
    const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

    return {
        indexAxis: 'y',
        maintainAspectRatio: false,
        aspectRatio: 0.8,
        plugins: {
            legend: {
                labels: {
                    color: textColor,
                },
            },
        },
        scales: {
            x: {
                ticks: {
                    color: textColorSecondary,
                    font: {
                        weight: 500,
                    },
                },
                grid: {
                    display: false,
                    drawBorder: false,
                },
            },
            y: {
                ticks: {
                    color: textColorSecondary,
                },
                grid: {
                    color: surfaceBorder,
                    drawBorder: false,
                },
            },
        },
    };
};

const getTeamColor = (teamName) => {
    const teamColors = {
        'Atlanta Hawks': '--atl-red',
        'Boston Celtics': '--bos-green',
        'Brooklyn Nets': '--bkn-black',
        'Charlotte Hornets': '--cha-purple',
        'Chicago Bulls': '--chi-red',
        'Cleveland Cavaliers': '--cle-wine',
        'Dallas Mavericks': '--dal-royal-blue',
        'Denver Nuggets': '--den-midnight-blue',
        'Detroit Pistons': '--det-red',
        'Golden State Warriors': '--gsw-blue',
        'Houston Rockets': '--hou-red',
        'Indiana Pacers': '--ind-yellow',
        'LA Clippers': '--lac-silver',
        'Los Angeles Lakers': '--lal-gold',
        'Memphis Grizzlies': '--mem-blue',
        'Miami Heat': '--mia-red',
        'Milwaukee Bucks': '--mil-green',
        'Minnesota Timberwolves': '--min-midnight-blue',
        'New York Knicks': '--nyk-orange',
        'New Orleans Pelicans': '--nop-navy-blue',
        'Oklahoma City Thunder': '--okc-blue',
        'Orlando Magic': '--orl-blue',
        'Philadelphia 76ers': '--phi-blue',
        'Phoenix Suns': '--phx-orange',
        'Portland Trail Blazers': '--por-red',
        'San Antonio Spurs': '--sas-silver',
        'Sacramento Kings': '--sac-purple',
        'Toronto Raptors': '--tor-red',
        'Utah Jazz': '--utah-navy',
        'Washington Wizards': '--was-navy',
        // Add more teams as needed
    };

    return teamColors[teamName] || '--default-color'; // Fallback to a default color if the team is not found
};

const setChartData = () => {
    const documentStyle = getComputedStyle(document.documentElement);

    return {
        labels: ['PTS', 'REB', 'AST', 'STL', 'BLK', 'TO', 'FG%', '3P%', 'FT%'],
        datasets: [
            {
                label: game.value.teams.visitors.name,
                backgroundColor: documentStyle.getPropertyValue(getTeamColor(game.value.teams.visitors.name)),
                borderColor: documentStyle.getPropertyValue(getTeamColor(game.value.teams.visitors.name)),
                data: changeToChart(visitorTotalStats.value),
            },
            {
                label: game.value.teams.home.name,
                backgroundColor: documentStyle.getPropertyValue(getTeamColor(game.value.teams.home.name)),
                borderColor: documentStyle.getPropertyValue(getTeamColor(game.value.teams.home.name)),
                data: changeToChart(homeTotalStats.value),
            },
        ],
    };
};

onMounted( async () => {
  if (games.value === undefined || games.value === null || games.value.length === 0) {
    await leagueStore.getGamesPerSeason();
    leagueStore.currentGame = games.value.find(g => g.id === id);
  }

  await leagueStore.GetPlayerStatsPerGame(id);


  chartData.value = setChartData();
    chartOptions.value = setChartOptions();
});

</script>

<style scoped>

table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #e5e7eb;
  text-align: left;
  padding: 8px;
}



</style>