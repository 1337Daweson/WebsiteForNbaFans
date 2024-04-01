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
      >
        <template #header>
          Východní konference BOSTON JE 58/16
        </template>
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
        <PrimeColumn
          header="HOME"
        >
          <template #body="slotProps">
            {{ slotProps.data.win.home }} - {{ slotProps.data.loss.home }}
          </template>
        </PrimeColumn>
        <PrimeColumn
          header="ROAD"
        >
          <template #body="slotProps">
            {{ slotProps.data.win.away }} - {{ slotProps.data.loss.away }}
          </template>
        </PrimeColumn>

        <PrimeColumn
          header="LAST10"
        >
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
      >
        <template #header>
          Východní konference
        </template>
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
        <PrimeColumn
          header="HOME"
        >
          <template #body="slotProps">
            {{ slotProps.data.win.home }} - {{ slotProps.data.loss.home }}
          </template>
        </PrimeColumn>
        <PrimeColumn
          header="ROAD"
        >
          <template #body="slotProps">
            {{ slotProps.data.win.away }} - {{ slotProps.data.loss.away }}
          </template>
        </PrimeColumn>

        <PrimeColumn
          header="LAST10"
        >
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

onMounted(() => {
    store.getStandings();
});

</script>

<style lang="scss" scoped>

</style>