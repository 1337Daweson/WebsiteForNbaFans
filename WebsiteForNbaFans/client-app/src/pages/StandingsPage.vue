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
          Východní konference
        </template>
        <PrimeColumn
          field="team.name"
          header="Tým"
        />
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
      </DataTable>      
    </div>
    <div class="bg-white w-1/2 m-auto p-auto mt-10 mb-10">
      <DataTable 
        :value="westStandings"
        size="small"
      >
        <template #header>
          Západní konference
        </template>
        <PrimeColumn
          field="team.name"
          header="Tým"
        />
        <PrimeColumn
          field="division.win"
          header="W"
        />
        <PrimeColumn
          field="division.loss"
          header="L"
        />
      </DataTable>      
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useLeagueStore } from '../stores/leagueStore';

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