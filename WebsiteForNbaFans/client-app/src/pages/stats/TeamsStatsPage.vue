<template>
  <div>
    <LoadingModal :loaded="loaded" />
    <div
      v-if="teamStats"
      class="bg-white mx-48 mt-10 mb-10 pb-2 "
    >
      <DataTable
        ref="dtb"
        :value="teamStats"
        size="small"
        :rows="30"
        paginator-template="FirstPageLink PrevPageLink NextPageLink LastPageLink CurrentPageReport"
        current-page-report-template="{first} do {last} z {totalRecords}"
        sort-field="wins"
        :sort-order="-1"
        class="m-4 p-4"
        :rows-hover="true"
      >
        <template #header>
          <div class="flex flex-row w-full h-full bg-white">
            <div class="self-start w-full">
              <h2>Průměry týmů na zápas za sezónu 2023/24</h2>
            </div>
            <div class="self-end w-full flex flex-row justify-end">
              <PrimeButton
                class="text-2xl self-end font-bold mb-4 border-2 gloss"
                label="Slovník"
                @click="glossary = !glossary"
              />              
            </div>
          </div>
          <div class="grid grid-cols-4 gap-2 grid-flow-row">
            <div
              v-for="(item, index) in glossaryItems"
              :key="index"
              class="mr-2 w-full h-full"
              :class="{'hidden': glossary}"
            >
              <div class="flex flex-row items-center gap-1 w-full">
                <h3 class="text-xs font-semibold">  
                  {{ item.term }} -
                </h3>
                <p class="text-xs font-normal">
                  {{ item.definition }}
                </p>
              </div>
            </div>
          </div>
        </template>
        <PrimeColumn
          field="name"
          header="Tým"
          :sortable="true"
          class="text-xs w-4/12"
        />

        <PrimeColumn
          field="games"
          header="Hry"
          :sortable="true"
          class="text-xs"
        />


        <PrimeColumn
          field="wins"
          header="W"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn
          field="losses"
          header="L"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn
          field="wins"
          header="WIN%"
          :sortable="true"
          class="text-xs"
        >
          <template #body="slotProps">
            {{ ((slotProps.data.wins / slotProps.data.games) * 100).toFixed(1) }}   
          </template>
        </PrimeColumn>


        <PrimeColumn
          field="pointsPerGame"
          header="PTS"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn
          field="fieldGoalsMade"
          header="FGM"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn
          field="fieldGoalsAttempted"
          header="FGA"
          :sortable="true"
          class="text-xs"
        />


        <PrimeColumn
          field="fieldGoalPercentage"
          header="FG%"
          :sortable="true"
          class="text-xs"
        />


        <PrimeColumn
          field="treePointersMade"
          header="3PM"
          :sortable="true"
          class="text-xs"
        />


        <PrimeColumn
          field="treePointersAttempted"
          header="3PA"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn
          field="treePointersPercentage"
          header="3P%"
          :sortable="true"
          class="text-xs"
        />



        <PrimeColumn
          field="freeThrowsMade"
          header="FTM"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn
          field="freeThrowsAttempted"
          header="FTA"
          :sortable="true"
          class="text-xs"
        />


        <PrimeColumn
          field="freeThrowsPercentage"
          header="FT%"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn 
          field="offRebMade"
          header="OREB"
          class="text-xs"
        />
        <PrimeColumn 
          field="defRebMade"
          header="DREB"
          class="text-xs"
        />

        <PrimeColumn 
          field="rebMade"
          header="REB"
          :sortable="true"
          class="text-xs"
        />

        <PrimeColumn 
          field="assistsMade"
          header="AST"
          :sortable="true"
          class="text-xs"
        />
        <PrimeColumn 
          field="turnoversMade"
          header="TOV"
          class="text-xs"
        />
        <PrimeColumn 
          field="stealsMade"
          header="STL"
          class="text-xs"
        />
        <PrimeColumn 
          field="blocksMade"
          header="BLK"
          class="text-xs"
        />

        <PrimeColumn 
          field="personalFouls"
          header="PF"
          class="text-xs"
        />
        <PrimeColumn 
          field="plusMinusPerGame"
          header="+/-"
          class="text-xs"
        />
      </DataTable>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted, ref } from 'vue';
import { useTeamStore } from '@/stores/teamStore';
import { StatsCalculator } from '@/services/StatsHelper.js';
import { useLeagueStore } from '../../stores/leagueStore';
import { teamsStatsGlossary } from '../../services/ObjectsProvider';

const store = useTeamStore();
const leagueStore = useLeagueStore();
const loaded = computed(() => store.loaded);

const teams = computed(() => store.NbaTeams);
const stats = computed(() => store.teamsStats);
const games = computed(() => leagueStore.games);

const calculatedTeamStats = computed(() => StatsCalculator.calculateTeamStats(stats.value, teams.value));
const teamWinsAndLosses = computed(() => StatsCalculator.getTeamWinsLosses(games.value));
const teamStats = computed(() => StatsCalculator.transformTeamStats(mergeArrays(teamWinsAndLosses.value, calculatedTeamStats.value)));

const getTeamIds = async () => {
  teams.value.forEach(async team => {
    await store.getTeamsStats(team.id);
  });
};



const glossaryItems = teamsStatsGlossary;
const glossary = ref(true);  

const mergeArrays = (array1, array2) => {
 // Use reduce to create a map of the first array's objects by teamId
 const map = array1.reduce((acc, item) => {
    acc[item.teamId] = item;
    return acc;
 }, {});

 // Iterate over the second array and merge stats into the map
 array2.forEach(item => {
    if (map[item.id]) {
      map[item.id].stats = item.stats;
    }
 });

 // Convert the map back into an array
 return Object.values(map);
};


onMounted(async () => {
  if (teams.value === null || teams.value.length === 0) {
    await store.getTeams();
  }
  if (stats.value === null || stats.value.length === 0) {
    await getTeamIds();        
  }

  leagueStore.getGamesPerSeason();
});

</script>

<style scoped>


.p-datatable-table .p-sortable-column .p-sortable-column-icon {
    color: white !important;
    background-color: white !important;
}   

</style>