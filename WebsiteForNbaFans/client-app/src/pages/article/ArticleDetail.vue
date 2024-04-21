<template>
  <div>
    <div
      v-if="article"
      class="w-full flex flex-col items-center"
    >
      <div class="bg-white w-1/2 h-full p-5 mt-10 border-b-2 border-black">
        <h1 class="font-semibold text-2xl">
          {{ article.title }}
        </h1>
      </div>
      <div class="bg-white w-1/2 h-full p-5">
        {{ article.content }}
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useLeagueStore } from '../../stores/leagueStore';
import { useRoute } from 'vue-router';

const leagueStore = useLeagueStore();
const route = useRoute();
const article = computed(() => leagueStore.currentArticle);

onMounted(() => {
  leagueStore.getArticle(route.params.id);
});
</script>

<style lang="scss" scoped>

</style>