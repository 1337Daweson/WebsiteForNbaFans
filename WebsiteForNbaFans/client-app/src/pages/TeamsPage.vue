<template>
  <div class="bg-white w-1/2 m-auto p-auto mt-10">
    <h1 class="mb-5 p-3 font-bold text-3xl">
      TÝMY
    </h1>
    <div class="grid grid-cols-3 place-items-center h-full w-full p-2">
      <div
        v-for="(teams, division) in sortedGroupedTeams"
        :key="division"
        class="mb-8"
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
import { computed, onMounted } from 'vue';
import { useTeamStore } from '../stores/teamStore';
export default {
  setup() {
    const store = useTeamStore();
    const teams = computed(() => store.NbaTeams);

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
      translateDivision,
    };

  },
};
</script>

<style lang="scss" scoped>

</style>

