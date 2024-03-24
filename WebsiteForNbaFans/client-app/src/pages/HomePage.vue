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

onMounted(() => store.getTeams());
</script>

<style scoped>

</style>