<template>
  <div class="bg-white mx-52 mt-10 mb-10 pb-2 ">
    <DataTable 
      ref="dtb"
      :value="model"
      size="small"
      :paginator="true"
      paginator-position="top"
      :rows="20"
      paginator-template="FirstPageLink PrevPageLink NextPageLink LastPageLink CurrentPageReport"
      current-page-report-template="{first} do {last} z {totalRecords}"
      sort-field="season"
      :sort-order="-1"
      class="m-4 p-4"
      :rows-hover="true"
    >
      <template #header>
        <div class="flex flex-row w-full h-full bg-white">
          <div class="self-start w-full">
            <h2>Průměry za odehrané sezóny</h2>
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
            <div class="mb-2 flex flex-row items-center gap-1 mr-2">
              <h3 class="text-xs font-semibold w-12">  
                {{ item.term }} -
              </h3>
              <p class="text-xs font-normal ml-1">
                {{ item.definition }}
              </p>
            </div>
          </div>
        </div>
      </template>
      <PrimeColumn
        field="season"
        header="Sezóna"
        class="w-4/12 text-xs"
        :sortable="true"
      />
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
</template>

<script setup>
import { ref } from 'vue';
import { playersStatsGlossary } from '../../src/services/ObjectsProvider';
// eslint-disable-next-line vue/require-prop-types
const model = defineModel();

const glossary = ref(true);  
const glossaryItems = playersStatsGlossary;


</script>

<style lang="scss" scoped>

</style>