<template>
  <div>
    <h1>Player</h1>
    <div>{{ player }}</div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useTeamStore } from '@/stores/teamStore';
import { useRoute } from 'vue-router';

const store = useTeamStore();
const route = useRoute();
const player = computed(() => store.currentPlayer);

onMounted(() => store.getPlayer(route.params.playerId));
</script>
