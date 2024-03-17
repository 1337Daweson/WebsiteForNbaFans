<template>
  <h1>HOME HOME</h1>
  <div class="flex flex-row">
    <span>hihi</span>
    <span>hehe</span>
  </div>
</template>

<script setup>
import { onMounted } from 'vue';
import { useTeamStore } from '../stores/teamStore';

const store = useTeamStore();

onMounted(() => store.getTeams());
</script>

<style scoped>

</style>