<template>
  <LoadingModal :loaded="loaded" />
  <div class="h-full min-h-full">
    <GameCalendar />
    <ArticlesComponent />
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useTeamStore } from '../stores/teamStore';
import ArticlesComponent from '../components/ArticlesComponent.vue';
import { useLeagueStore } from '../stores/leagueStore';
import GameCalendar from '../components/GameCalendar.vue';

const teamStore = useTeamStore();
const leagueStore = useLeagueStore();
const loaded = computed(() => teamStore.loaded);

const getTeamIds = async () => {
  teamStore.getTeams();
  teamStore.NbaTeams.forEach(async team => {
    await teamStore.getPlayersStats(team.id);
  });

  leagueStore.getGamesPerSeason();
};

onMounted(async () =>{
  // await teamStore.getTeams();
  await getTeamIds();
});
</script>

<style scoped>

</style>