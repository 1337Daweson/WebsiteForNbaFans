<template>
  <div>
    {{ team }}
    <br>
    {{ players }}
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { useTeamStore } from '../stores/teamStore';
import { useRoute } from 'vue-router';
import { usePlayerStore } from '../stores/playerStore';
export default {
    setup () {
        
      const store = useTeamStore();
      const playerStore = usePlayerStore();
      const route = useRoute();

      const team = computed(() => store.currentTeam);
      const players = computed(() => playerStore.players);      
      onMounted(() => {
        store.getTeamById(route.params.id);
        playerStore.getPlayersByTeam(route.params.id);
      });

        return {
          team,
          players
        };
    }
};
</script>

