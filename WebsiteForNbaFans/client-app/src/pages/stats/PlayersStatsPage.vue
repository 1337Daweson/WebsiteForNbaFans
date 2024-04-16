<template>
  <div>
    <LoadingModal :loaded="loaded" />
    <div class="bg-white mx-52 mt-10 mb-10 pb-2 ">
      <DataTable 
        ref="dtb"
        :value="transformedStats"
        size="small"
        :paginator="true"
        paginator-position="top"
        :rows="20"
        paginator-template="FirstPageLink PrevPageLink NextPageLink LastPageLink CurrentPageReport"
        current-page-report-template="{first} do {last} z {totalRecords}"
        sort-field="pointsPerGame"
        :sort-order="-1"
        class="m-4 p-4"
        :rows-hover="true"
      >
        <template #header>
          <div class="flex flex-row w-full h-full bg-white">
            <div class="self-start w-full">
              <h2>Průměry hráčů na zápas za sezónu 2023/24</h2>
            </div>
            <div class="self-end w-full flex flex-row justify-end">
              <PrimeButton
                class="text-2xl self-end font-bold mb-4 border-2 gloss"
                label="Slovník"
                @click="glossary = !glossary"
              />              
            </div>
          </div>
          <div class="grid grid-cols-4">
            <div
              v-for="(item, index) in glossaryItems"
              :key="index"
              class="mb-2"
              :class="{'hidden': glossary}"
            >
              <div class="mb-2 flex flex-row items-center gap-1">
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
          header="Hráč"
          class="w-4/12 text-xs"
        >
          <template #body="slotProps">
            <RouterLink :to="'/player/' + slotProps.data.playerId">
              {{ slotProps.data.name }}
            </RouterLink>
          </template>
        </PrimeColumn>
        <PrimeColumn 
          field="team"
          header="TÝM"
          class="text-xs "
        />
        <PrimeColumn
          field="numberOfGames"
          header="GP"
          :sortable="true"
          class="text-xs"
        >
          <template #header>
            <div class="hidden">
              IDK
            </div>
          </template>
        </PrimeColumn>
        <PrimeColumn 
          field="averageMinutesPerGame"
          header="MIN"
          :sortable="true"
          class="text-xs"
        />
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
        
        
        <template #paginatorstart>
          <div class="w-full flex flex-row justify-center">
            <div class=" opacity-0 w-80" />
            <div class=" opacity-0 w-80" />
            <div class=" opacity-0 w-80" />
          </div>
        </template>
      </DataTable>
    </div>
  </div>
</template>
<script setup>
import { computed, onMounted, ref } from 'vue';
import { useTeamStore } from '@/stores/teamStore';
import { StatsCalculator } from '@/services/StatsHelper.js';
import { playersStatsGlossary } from '../../services/ObjectsProvider';

// continue with stats
// https://www.phind.com/search?cache=c7pk8u3evr4v8wxnppgc5ct6
const store = useTeamStore();
const stats = computed(() => store.playersStats);
const teams = computed(() => store.NbaTeams);
const loaded = computed(() => store.loaded);
const transformedStats = computed(() => StatsCalculator.calculatePlayerStats(stats.value));

const glossaryItems = playersStatsGlossary;

const glossary = ref(true);  



const getTeamIds = async () => {
  teams.value.forEach(async team => {
    await store.getPlayersStats(team.id);
  });
};

onMounted(async () => {
  if (teams.value === null || teams.value.length === 0) {
    await store.getTeams();
    console.log('teams null');
  }
  if (stats.value === null || stats.value.length === 0) {
    await getTeamIds();        
  }
});

</script>

<style scoped>

.gloss {
  border-color: #dfe7f1;
  outline-width: 0cm;
  outline-offset: 0cm;
  
}

.gloss:hover {
  background-color: #dfe7f1;
  color: white;
}

</style>  