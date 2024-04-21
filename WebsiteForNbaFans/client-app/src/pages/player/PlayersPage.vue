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
        paginator-template="FirstPageLink PrevPageLink NextPageLink LastPageLink CurrentPageReport"
        current-page-report-template="{first} do {last} z {totalRecords}"
        class="m-4 p-4"
        sort-field="lastname"
        :sort-order="1"
        :global-filter-fields="['lastname', 'firstname', 'fullname']"
        paginator-position="top"
      >
        <template #header>
          <h1>SOUPISKA HRÁČŮ LIGY</h1>
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
          field="fullname"
          header="Hráč"
          class="w-4/12 text-xs"
        >
          <template #body="slotProps">
            <RouterLink :to="'/player/' + slotProps.data.id">
              <!-- {{ slotProps.data.firstname + ' ' + slotProps.data.lastname }}  -->
              {{ slotProps.data.fullname }}
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
        <template #paginatorstart>
          <div class="w-full">
            <div class="flex flex-row gap-x-1 justify-evenly w-full h-full">
              <PrimeButton
                class="border-2 gloss"
                icon="pi pi-filter-slash"
                label="Reset"
                @click="clearFilter()"
              />
              <InputText
                v-model="filters['global'].value"
                class="border-2 text-start w-2/3 self-center" 
                placeholder="Hledat.."
                icon="pi pi-search"
              />
            </div>
            <div class=" opacity-0 w-80 h-full" />
            <div class=" opacity-0 w-80 h-full" />
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
        // Create a new object that includes all properties of the player object
        // and adds a new property 'fullname' which is a combination of firstname and lastname
        const playerWithFullName = {
          ...player,
          fullname: `${player.firstname} ${player.lastname}`,
        };
        acc.push(playerWithFullName);
      }
    });
    return acc;
 }, []);
});

const filters = ref();

const initFilters = () => {
    filters.value = {
        global: { value: null, matchMode: FilterMatchMode.CONTAINS },
        fullname: { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
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

.gloss {
  border-color: #dfe7f1;
  outline-width: 0cm;
  outline-offset: 0cm;
  text-align: center;
  
}

button.gloss   >>> span {
  align-self: center;

}

.gloss:hover {
  background-color: #dfe7f1;
  color: white;
}
</style>