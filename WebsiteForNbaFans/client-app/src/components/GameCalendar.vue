<template>
  <div class="flex flex-row gap-2 w-full mt-1">
    <div class="flex flex-col gap-2 p-4 bg-white shadow-md">
      <DropDown
        v-model="selectedDate"
        :options="dateOptions"
        option-label="label"
        placeholder="Select a Date"
        class="w-full"
        @change="toFirstPage()"
      />
      <div class="flex flex-row w-full items-center gap-2">
        <span class="text-xs">Schovat skóre</span>
        <InputSwitch v-model="hideScores" /> 
      </div>     
    </div>
    <div class="bg-white w-full h-1/2 m-auto shadow-md">
      <PrimeCarousel
        :key="carouselKey"
        :page="currentPage"
        :value="todayGames"
        :num-visible="5"
        :num-scroll="4" 
        :show-indicators="false"
        class="w-3/6"
      >
        <template #item="slotProps">
          <div class=" w-full border-2 border-spacing-28 surface-border rounded m-2 p-3 bg-slate-100">
            <div class="mb-3">
              <div class="relative mx-auto">
                <div class="flex flex-row items-center w-full h-full">
                  <!-- Display away team logo -->
                  <div class="flex flex-row items-center w-full">
                    <img
                      :src="slotProps.data.teams.visitors.logo"
                      :alt="slotProps.data.teams.visitors.code"
                      class="border-round object-contain h-5 w-4 mr-2"
                    >
                    <span class="text-xs font-semibold">{{ slotProps.data.teams.visitors.code }}</span>
                  </div>
                  <div class="flex flex-row items-center w-full justify-end">
                    <span class="text-xs font-semibold">{{ hideScores === false ? slotProps.data.scores.visitors.points : '-' }}</span>
                    <span :class="{'redTriangle': slotProps.data.scores.home.points < slotProps.data.scores.visitors.points && hideScores === false }" />
                  </div>
                </div>
                <!-- Display home team logo -->
                <div class="flex flex-row items-center w-full h-full">
                  <div class="flex flex-row items-center w-full">
                    <img
                      :src="slotProps.data.teams.home.logo"
                      :alt="slotProps.data.teams.home.code"
                      class="border-round object-contain h-5 w-4 mr-2"
                    >
                    <span class="text-xs font-semibold">{{ slotProps.data.teams.home.code }}</span>
                  </div>
                  <div class="flex flex-row items-center w-full justify-end">
                    <span class="text-xs font-semibold">{{ hideScores === false ? slotProps.data.scores.home.points : '-' }}</span>
                    <span :class="{'redTriangle': slotProps.data.scores.home.points > slotProps.data.scores.visitors.points && hideScores === false }" />
                  </div>
                </div>                
              </div>
            </div>
          </div>
        </template>
      </PrimeCarousel>
    </div>
  </div>
</template>

<script setup>
import { useLeagueStore } from '../stores/leagueStore';
import { computed, ref, onMounted } from 'vue';

const leagueStore = useLeagueStore();
const selectedDate = ref();
const dateOptions = [];
const hideScores = ref(false);
const currentPage = ref(0);
const carouselKey = ref(0);

const games = computed(() => leagueStore.finishedGames);
const todayGames = computed(() => games.value.filter(game => {
  const gameDate = new Date(game.date.start);
  gameDate.setHours(0, 0, 0, 0);

  if (selectedDate.value) {
    return gameDate.getTime() === selectedDate.value.value.getTime() && (game.status.long === 'Finished' || game.status.long === 'Scheduled');
  }
}).sort((a, b) => {
  if (a.status.long === 'Finished' && b.status.long !== 'Finished') {
    return -1;
  }
  if (a.status.long !== 'Finished' && b.status.long === 'Finished') {
    return 1;
  }
  const dateA = new Date(a.date.start).getTime();
  const dateB = new Date(b.date.start).getTime();
  return dateA - dateB; // Earliest first
}));

const toFirstPage = () => {
  currentPage.value = 0;
 carouselKey.value++;
};



onMounted(() => {
  const today = new Date();
  today.setHours(0, 0, 0, 0);
  for (let i = 0; i <= 3; i++) {
    const date = new Date(today);
    date.setDate(today.getDate() - i + 2);
    dateOptions.push({ label: date.toLocaleDateString(), value: date });
    selectedDate.value = dateOptions[2];
  }
});

</script>

<style scoped>

.redTriangle {
  margin-right: -10px;
  width: 0;
  height: 0;
  border-left: 5px solid transparent;
  border-right: 5px solid transparent;
  border-bottom: 5px solid red;
  transform: rotate(-90deg);
}

button.p-link {
    background-color: blue !important;
}
</style>