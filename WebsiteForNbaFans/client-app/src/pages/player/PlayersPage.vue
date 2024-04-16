<template>
  <div>
    <LoadingModal :loaded="loaded" />
    <div class="bg-white w-2/4 m-auto p-auto mt-10 mb-10">
      <DataTable 
        v-model:filters="filters"
        :value="allPlayers"
        size="small"
        :paginator="true" 
        :rows="10"
        :rows-per-page-options="[5, 10, 20, 50]"
        paginator-template="FirstPageLink PrevPageLink CurrentPageReport NextPageLink LastPageLink RowsPerPageDropdown "
        current-page-report-template="{first} do {last} z {totalRecords}"
        class="m-4 p-4"
        sort-field="lastname"
        :sort-order="1"
        :global-filter-fields="['lastname', 'firstname']"
      >
        <template #header>
          <div class="flex justify-content-between">
            <PrimeButton
              type="button"
              icon="pi pi-filter-slash"
              label="Clear"
              outlined
              @click="clearFilter()"
            />
            <IconField icon-position="left">
              <InputIcon>
                <i class="pi pi-search" />
              </InputIcon>
              <InputText
                v-model="filters['global'].value"
                placeholder="Keyword Search"
              />
            </IconField>
          </div>
        </template>
        <template #filter="{ filterModel }">
          <InputText
            v-model="filterModel.value"
            type="text"
            class="p-column-filter"
            placeholder="Search by name"
          />
        </template>
        <PrimeColumn
          field="id"
          header="Id"
          class="w-1/12 text-xs"        
        />
        <PrimeColumn
          field="lastname"
          header="Hráč"
          class="w-4/12 text-xs"
        >
          <template #body="slotProps">
            <RouterLink :to="'/player/' + slotProps.data.id">
              {{ slotProps.data.firstname + ' ' + slotProps.data.lastname }}
            </RouterLink>
            <span />
          </template>
        </PrimeColumn>

        <PrimeColumn
          field="leagues.standard.jersey"
          header="Dres"
          class="w-1/12 text-xs"
          :sortable="true"
        />
        <PrimeColumn
          field="leagues.standard.pos"
          header="Pozice"
          class="w-1/12 text-xs"        
        />

        <PrimeColumn       
          field="height.meters"
          header="Výška"
          :sortable="true"
          class="text-xs"
        >
          <template #body="slotProps">
            <span>{{ slotProps.data.height.meters }}m</span>
          </template>
        </PrimeColumn>

        <PrimeColumn
          field="weight.kilograms"
          header="Váha"
          class="text-xs"
          :sortable="true"       
        >
          <template #body="slotProps">
            <span>{{ slotProps.data.weight.kilograms }}kg</span>
          </template>
        </PrimeColumn>

        <PrimeColumn
          field="birth.date"
          header="Datum narození"
          class="w-1/12 text-xs"
        >
          <template #body="slotProps">
            {{ DateTransformer.toCzLocale(slotProps.data.birth.date) }}
          </template>
        </PrimeColumn>

        <PrimeColumn
          field="birth.date"
          header="Věk"
          :sortable="true" 
          class="text-xs"
        >
          <template #body="slotProps">
            {{ DateTransformer.getAge(slotProps.data.birth.date) }}
          </template>
        </PrimeColumn>

        <PrimeColumn 
          field="nba.start"
          header="Zkušenosti"
          class="text-center text-xs"
        >
          <template #body="slotProps">
            {{ DateTransformer.yearsInLeague(slotProps.data.nba.start) }}
          </template>
        </PrimeColumn>

        <PrimeColumn 
          field="college"
          header="Škola"
          class="w-2/12 text-xs"
        />
      </DataTable>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted, ref } from 'vue';
import { useTeamStore } from '../../stores/teamStore';
import { DateTransformer } from '../../services/DateTransformer';
import { FilterMatchMode, FilterOperator } from 'primevue/api';

const teamStore = useTeamStore();
const loaded = computed(() => teamStore.loaded);

const teams = computed(() => teamStore.NbaTeams);
const allPlayers = computed(() => {
 const uniqueIds = new Set();
 return teamStore.players.reduce((acc, curr) => {
    curr.players.forEach(player => {
      if (!uniqueIds.has(player.id)) {
        uniqueIds.add(player.id);
        acc.push(player);
      }
    });
    return acc;
 }, []);
});

const filters = ref();

const initFilters = () => {
    filters.value = {
        global: { value: null, matchMode: FilterMatchMode.CONTAINS },
        firstname: { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
        lastname: { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
    };
};

initFilters();

const clearFilter = () => {
    initFilters();
};

onMounted(  async () => {
  if (!teams.value || teams.value.length === 0) {
    await teamStore.getTeams();
  }
  
  for (const team of teams.value) {
 await teamStore.getAllPlayers(team.id);
}
});
</script>

<style  scoped>

</style>