<template>
  <div>
    <div class="bg-white w-1/2 m-auto p-auto mt-10 mb-10">
      <ProgressSpinner
        v-if="!loaded"
        class="flex justify-center"
      />
      <DataTable
        :value="eastStandings"
        size="small"
        :row-class="setRowClass"
        class="p-5"
      >
        <template #header>
          <div class="w-full flex flex-row gap-5">
            <h1 class="w-full self-end">
              Východní konference
            </h1>
            <div class="w-full flex flex-col items-end">
              <div class="flex justify-start gap-3 items-center m-1">
                <span class="text-xs font-mono w-40">
                  zajištěné playoffs
                </span>
                <div class="w-5 h-5 bg-opacity-10 bg-green-500" />
              </div>
              <div class="flex justify-start gap-3 items-center m-1">
                <span class="text-xs font-mono w-40">
                  zajištěné play-in
                </span>
                <div class="w-5 h-5 bg-opacity-10 bg-yellow-500" />
              </div>
              <div class="flex justify-start gap-3 items-center m-1">
                <span class="text-xs font-mono w-40">
                  mimo post-season
                </span>
                <div class="w-5 h-5 bg-opacity-10 bg-red-500" />
              </div>
            </div>
          </div>
        </template>
        <PrimeColumn
          field="conference.rank"
          header="#"
        />
        <PrimeColumn
          field="team.name"
          header="Tým"
        >
          <template #body="slotProps">
            <div class="flex flex-row gap-1 items-center">
              <img
                class="object-contain h-5 w-4 mr-2"
                :src="`${slotProps.data.team.logo}`"
              >
              <span>{{ slotProps.data.team.name }}</span>
            </div>
          </template>
        </PrimeColumn>
        <PrimeColumn
          field="division.win"
          header="W"
        />
        <PrimeColumn
          field="division.loss"
          header="L"
        />
        <PrimeColumn
          field="win.percentage"
          header="W%"
        />
        <PrimeColumn
          field="gamesBehind"
          header="GB"
        />
        <PrimeColumn header="HOME">
          <template #body="slotProps">
            {{ slotProps.data.win.home }} - {{ slotProps.data.loss.home }}
          </template>
        </PrimeColumn>
        <PrimeColumn header="ROAD">
          <template #body="slotProps">
            {{ slotProps.data.win.away }} - {{ slotProps.data.loss.away }}
          </template>
        </PrimeColumn>

        <PrimeColumn header="LAST10">
          <template #body="slotProps">
            {{ slotProps.data.win.lastTen }} - {{ slotProps.data.loss.lastTen }}
          </template>
        </PrimeColumn>

        <PrimeColumn
          field="streak"
          header="Streak"
        >
          <template #body="slotProps">
            <div v-if="slotProps.data.winStreak">
              W {{ slotProps.data.streak }}
            </div>
            <div v-else>
              L {{ slotProps.data.streak }}
            </div>
          </template>
        </PrimeColumn>
      </DataTable>
    </div>
    <div class="bg-white w-1/2 m-auto p-auto mt-10 mb-10">
      <DataTable
        :value="westStandings"
        size="small"
        class="p-5"
        :row-class="setRowClass"
      >
        <template #header>
          <div class="w-full flex flex-row gap-5">
            <h1 class="w-full self-end">
              Západní konference
            </h1>
            <div class="w-full flex flex-col items-end">
              <div class="flex justify-start gap-3 items-center m-1">
                <span class="text-xs font-mono w-40">
                  zajištěné playoffs
                </span>
                <div class="w-5 h-5 bg-opacity-10 bg-green-500" />
              </div>
              <div class="flex justify-start gap-3 items-center m-1">
                <span class="text-xs font-mono w-40">
                  zajištěné play-in
                </span>
                <div class="w-5 h-5 bg-opacity-10 bg-yellow-500" />
              </div>
              <div class="flex justify-start gap-3 items-center m-1">
                <span class="text-xs font-mono w-40">
                  mimo post-season
                </span>
                <div class="w-5 h-5 bg-opacity-10 bg-red-500" />
              </div>
            </div>
          </div>
        </template>
        <PrimeColumn
          field="conference.rank"
          header="#"
        />
        <PrimeColumn
          field="team.name"
          header="Tým"
        >
          <template #body="slotProps">
            <div class="flex flex-row gap-1 items-center">
              <img
                class="object-contain h-5 w-4 mr-2"
                :src="`${slotProps.data.team.logo}`"
              >
              <span>{{ slotProps.data.team.name }}</span>
            </div>
          </template>
        </PrimeColumn>
        <PrimeColumn
          field="division.win"
          header="W"
        />
        <PrimeColumn
          field="division.loss"
          header="L"
        />
        <PrimeColumn
          field="win.percentage"
          header="W%"
        />
        <PrimeColumn
          field="gamesBehind"
          header="GB"
        />
        <PrimeColumn header="HOME">
          <template #body="slotProps">
            {{ slotProps.data.win.home }} - {{ slotProps.data.loss.home }}
          </template>
        </PrimeColumn>
        <PrimeColumn header="ROAD">
          <template #body="slotProps">
            {{ slotProps.data.win.away }} - {{ slotProps.data.loss.away }}
          </template>
        </PrimeColumn>

        <PrimeColumn header="LAST10">
          <template #body="slotProps">
            {{ slotProps.data.win.lastTen }} - {{ slotProps.data.loss.lastTen }}
          </template>
        </PrimeColumn>

        <PrimeColumn
          field="streak"
          header="Streak"
        >
          <template #body="slotProps">
            <div v-if="slotProps.data.winStreak">
              W {{ slotProps.data.streak }}
            </div>
            <div v-else>
              L {{ slotProps.data.streak }}
            </div>
          </template>
        </PrimeColumn>
      </DataTable>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useLeagueStore } from '@/stores/leagueStore';

const store = useLeagueStore();
const loaded = computed(() => store.loaded);
const eastStandings = computed(() => store.eastStandings);
const westStandings = computed(() => store.westStandings);

const setRowClass = (data) => {
  if (data.conference.rank <= 6) {
    return 'bg-opacity-10 bg-green-500';
  } else if (data.conference.rank > 6 && data.conference.rank <= 10) {
    return 'bg-opacity-10 bg-yellow-500';
  } else {
    return 'bg-opacity-10 bg-red-500';
  }
};

onMounted(() => {
    store.getStandings();
});

</script>

<style scoped>


</style>