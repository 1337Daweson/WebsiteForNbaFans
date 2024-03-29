<template>
  <LoadingModal :loaded="loaded" />
  <div class="bg-white w-1/2 m-auto p-auto mt-10">
    <h1 class="pl-6 pt-4 mb-2 font-bold text-3xl">
      Všechny Týmy
    </h1>
    <hr class="mx-5">
    <div class="grid grid-cols-3 place-items-center h-full w-full p-2">
      <div
        v-for="(teams, division) in sortedGroupedTeams"
        :key="division"
        class="mb-8 w-full pl-5"
      >
        <h2 class="text-2xl font-bold mb-5">
          {{ translateDivision(division) }}
        </h2>
        <ul class="list-none list-inside text-lg">
          <li
            v-for="team in teams"
            :key="team.name"
            class="mb-2 w-full"
          >
            <RouterLink
              class="flex flex-row items-center"
              :to="'/team/' + team.id"
            >
              <img
                class="object-contain h-8 w-8 mr-5"
                :src="`${team.logo}`"
              >
              {{ team.name }} 
            </RouterLink>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted  } from 'vue';
import { useTeamStore } from '../stores/teamStore';
export default {
  setup() {
    const store = useTeamStore();
    const teams = computed(() => store.NbaTeams);
    const loaded = computed(() => store.loaded);

    const groupedTeams = computed(() => {
      return teams.value.reduce((acc, team) => {
        if (!acc[team.leagues.standard.division]) {
          acc[team.leagues.standard.division] = [];
        }
        acc[team.leagues.standard.division].push(team);
        return acc;
      }, {});
    });

    const sortedGroupedTeams = computed(() => {
      return Object.entries(groupedTeams.value)
        .sort(([divisionA], [divisionB]) => divisionA.localeCompare(divisionB))
        .reduce((acc, [division, teams]) => {
          acc[division] = teams;
          return acc;
        }, {});
    });



    const translateDivision = (division) => {
      switch (division) {
        case 'Atlantic':
          return 'Atlantická';
        case 'Central':
          return 'Centrální';
        case 'Northwest':
          return 'Severovýchodní';
          case 'Pacific':
          return 'Pacifická';
          case 'Southeast':
          return 'Jihovýchodní';
          case 'Southwest':
          return 'Jihozápadní';
    
        default:
          break;
      }
    };


    onMounted(() => store.getTeams());

    return {
      teams,
      groupedTeams,
      sortedGroupedTeams,
      loaded,
      translateDivision,
    };

  },
};
</script>

<style scoped>

.loading-container {
 display: flex;
 justify-content: center;
 align-items: center;
 position: fixed;
 top: 0;
 left: 0;
 right: 0;
 bottom: 0;
 z-index: 9999; /* Ensure it's above other content */
}

.loading-container::before {
 content: '';
 position: absolute;
 top: 0;
 left: 0;
 right: 0;
 bottom: 0;
 background-color: rgba(255, 255, 255, 0.5); /* Semi-transparent white */
 z-index: -1; /* Ensure it's behind the spinner */
}

</style>

