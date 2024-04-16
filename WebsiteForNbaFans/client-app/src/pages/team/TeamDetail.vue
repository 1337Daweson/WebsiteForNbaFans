<!-- eslint-disable vue/attribute-hyphenation -->
<template>
  <LoadingModal :loaded="loaded" />
  <div class="bg-white w-1/2">
    <h2 />
  </div>
  <div class="bg-white w-1/2 m-auto p-auto mt-10 mb-10">
    <DataTable 
      :value="roster"
      size="small"
      :paginator="true"
      :rows="10" 
      :rowsPerPageOptions="[5, 10, 20, 50]"
      paginatorTemplate="FirstPageLink PrevPageLink CurrentPageReport NextPageLink LastPageLink RowsPerPageDropdown "
      currentPageReportTemplate="{first} do {last} z {totalRecords}"
      class="m-4 p-4"
    >
      <PrimeColumn
        field="firstname"
        header="Hráč"
        class="w-3/12"
      >
        <template #body="slotProps">
          <RouterLink :to="'/player/' + slotProps.data.id">
            {{ slotProps.data.firstname + ' ' + slotProps.data.lastname }}
          </RouterLink>
          <span />
          <!-- <PrimeButton
            label="test"
            @click="getPlayer(slotProps.data.id)"
          /> -->
        </template>
      </PrimeColumn>

      <PrimeColumn
        field="leagues.standard.jersey"
        header="Dres"
        class="w-1/12"
        :sortable="true"
      />
      <PrimeColumn
        field="leagues.standard.pos"
        header="Pozice"
        class="w-1/12"        
      />

      <PrimeColumn       
        field="height.meters"
        header="Výška"
        :sortable="true"
      >
        <template #body="slotProps">
          <span>{{ slotProps.data.height.meters }}m</span>
        </template>
      </PrimeColumn>

      <PrimeColumn
        field="weight.kilograms"
        header="Váha"
        :sortable="true"       
      >
        <template #body="slotProps">
          <span>{{ slotProps.data.weight.kilograms }}kg</span>
        </template>
      </PrimeColumn>

      <PrimeColumn
        field="birth.date"
        header="Datum narození"
        class="w-1/3"
      >
        <template #body="slotProps">
          {{ DateTransformer.toCzLocale(slotProps.data.birth.date) }}
        </template>
      </PrimeColumn>

      <PrimeColumn
        field="birth.date"
        header="Věk"
        :sortable="true" 
      >
        <template #body="slotProps">
          {{ DateTransformer.getAge(slotProps.data.birth.date) }}
        </template>
      </PrimeColumn>

      <PrimeColumn 
        field="nba.start"
        header="Zkušenosti"
        class="text-center"
      >
        <template #body="slotProps">
          {{ DateTransformer.yearsInLeague(slotProps.data.nba.start) }}
        </template>
      </PrimeColumn>

      <PrimeColumn 
        field="college"
        header="Škola"
        class="w-1/3"
      />
    </DataTable>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { useTeamStore } from '@/stores/teamStore';
import { useRoute, useRouter } from 'vue-router';
import { DateTransformer } from '@/services/DateTransformer.js';
export default {
    setup () {
        
      const store = useTeamStore();
      const route = useRoute();
      const router = useRouter();
      const loaded = computed(() => store.loaded);
      const team = computed(() => store.currentTeam);
      const roster = computed(() => store.roster);

      const getPlayer = (id) => {
        router.push({ path: `/player/${id}` });
        store.getPlayer(id);
      };
      
      onMounted(() => {
        // store.getTeamById(route.params.id);
        // playerStore.getPlayersByTeam(route.params.id);
        store.getRoster(route.params.id);
      });

        return {
          loaded,
          team,
          roster,
          DateTransformer,
          getPlayer,
        };
    },
};
</script>

