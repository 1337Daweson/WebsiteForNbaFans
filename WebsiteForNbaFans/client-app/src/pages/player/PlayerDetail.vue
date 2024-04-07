<template>
  <div
    v-if="transformedStats"
    class="w-full flex flex-col mt-1 items-center mb-5"
  >
    <div class="h-full bg-white border-b-2 border-[#f6f6f6] text-center flex flex-col items-center w-1/4">
      <div class="playerAvatar-content">
        <img
          src="@/assets//player-profile.png"
          alt="Article Image"
          class="playerAvatar-image"
        >
      </div>
      <h1 class="text-4xl font-semibold pb-1 w-full border-t-2 border-[#f6f6f6]">
        {{ transformedStats.name }}
      </h1>
      <span
        class="link"
        @click="toTeamPage()"
      >
        {{ playerStats[0].team.name }} 
      </span>
      <span>
        {{ player.leagues.standard.pos }}
      </span>
    </div>
    <div class="bg-white flex flex-row gap-1">
      <div class="w-40 h-20 border-l-4 border-r-2 border-[#f6f6f6] flex flex-col justify-center items-center">
        <h1>
          Body za zápas
        </h1>
        <h1 class="text-2xl">
          {{ transformedStats.pointsPerGame }}
        </h1>
      </div>
      <div class="w-40 h-20 border-r-2 border-[#f6f6f6] flex flex-col justify-center items-center">
        <h1>
          Doskoky za zápas
        </h1>
        <h1 class="text-2xl">
          {{ transformedStats.rebMade }}
        </h1>
      </div>
      <div class="w-40 h-20 border-r-4 border-[#f6f6f6]  flex flex-col justify-center items-center">
        <h1>
          Asistence za zápas
        </h1>
        <h1 class="text-2xl">
          {{ transformedStats.assistsMade }}
        </h1>
      </div>
    </div>
    <div class="flex flex-row gap-1 bg-white  w-1/4 border-[#f6f6f6] border-t-2">
      <div class="w-full h-14 border-r-2 border-[#f6f6f6] flex flex-col justify-center items-center">
        <h2 class="text-sm">
          Výška
        </h2>
        <h2 class="text-sm">
          {{ player.height.meters }}m
        </h2>
      </div>
      <div class="w-full h-14 flex flex-col justify-center items-center">
        <h2 class="text-sm">
          Váha
        </h2>
        <h2 class="text-sm">
          {{ player.weight.kilograms }}kg
        </h2>
      </div>
    </div>
    <div class="flex flex-row gap-1 bg-white w-1/4 border-[#f6f6f6] border-t-2">
      <div class="w-full h-14 border-r-2 border-[#f6f6f6] flex flex-col justify-center items-center">
        <h2 class="text-sm">
          Věk
        </h2>
        <h2 class="text-sm">
          {{ DateTransformer.getAge(player.birth.date) }} let
        </h2>
      </div>
      <div class="w-full h-14 border-r-2 border-[#f6f6f6] flex flex-col justify-center items-center">
        <h2 class="text-sm">
          Datum narození
        </h2>
        <h2 class="text-sm">
          {{ DateTransformer.toCzBirthdate(player.birth.date) }}
        </h2>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useTeamStore } from '@/stores/teamStore';
import { useRoute, useRouter } from 'vue-router';
import { StatsCalculator } from '@/services/StatsHelper';
import { DateTransformer } from '../../services/DateTransformer';

const store = useTeamStore();
const route = useRoute();
const router = useRouter();
const player = computed(() => store.currentPlayer[0]);
const playerStats = computed(() => store.playerStats);
const transformedStats = computed(() => StatsCalculator.calculatePlayerStats(playerStats.value)[0]);
const playerId = route.params.playerId;

const toTeamPage = () => {
  const id = playerStats.value[0].team.id;
  router.push('/team/' + id);
};


onMounted(() => {
  store.getPlayer(playerId);
  store.getPlayerStats(playerId);
});
</script>

<style scoped>

.playerAvatar-content {
  display: flex;
  align-items: center;
}
.playerAvatar-image {
  width: 200px;
  height: 200px;
  object-fit: contain;
  margin-right: 1rem;
}

.link {
  cursor: pointer;
}
</style>
