<template>
  <div>
    <ArticlesComponent />
  </div>
</template>

<script setup>
import { onMounted } from 'vue';
import { useTeamStore } from '../stores/teamStore';
import ArticlesComponent from '../components/ArticlesComponent.vue';

const store = useTeamStore();

const getTeamIds = async () => {
  store.NbaTeams.forEach(async team => {
    await store.getPlayersStats(team.id);
  });
};

onMounted(async () =>{
  // await store.getTeams();
  await getTeamIds();
});
</script>

<style scoped>

</style>