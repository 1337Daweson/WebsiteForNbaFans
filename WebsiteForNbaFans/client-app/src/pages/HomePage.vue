<template>
  <div>
    <GameCalendar />
    <ArticlesComponent />
  </div>
</template>

<script setup>
import { onMounted } from 'vue';
import { useTeamStore } from '../stores/teamStore';
import ArticlesComponent from '../components/ArticlesComponent.vue';
import { useLeagueStore } from '../stores/leagueStore';
import GameCalendar from '../components/GameCalendar.vue';

const teamStore = useTeamStore();
const leagueStore = useLeagueStore();

const getTeamIds = async () => {
  teamStore.NbaTeams.forEach(async team => {
    await teamStore.getPlayersStats(team.id);
  });

  leagueStore.getGamesPerSeason();
};

onMounted(async () =>{
  // await store.getTeams();
  await getTeamIds();
});
</script>

<style scoped>

</style>