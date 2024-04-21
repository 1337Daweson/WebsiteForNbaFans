<template>
  <div class="flex box-border">
    <h1 class="text-2xl font-semibold m-2 opacity-0">
      Články
    </h1>
    <div class="flex flex-col h-full w-3/6 mb-5 justify-center items-end">
      <PrimeCard
        v-for="(article, index) in articles.sort((a, b) => b.title.length - a.title.length).slice(0, visibleArticles)"
        :key="index"
        class="mt-2 mr-1 w-5/6"
      >
        <template #content>
          <div class="article-content">
            <img
              src="@/assets//sample.jpg"
              alt="Article Image"
              class="article-image"
            >
            <div class="article-header">
              <h2 class="font-semibold text-xl mainArticles">
                <RouterLink :to="'/article/' + article.id">
                  {{ article.title }}
                </RouterLink>
              </h2>
            </div>
          </div>
        </template>
      </PrimeCard>
      <PrimeButton
        class="text-2xl font-bold mb-4 border-2 button-class self-start mt-4 ml-40"
        label="Zobrazit další"
        :disabled="visibleArticles >= articles.length"
        @click="visibleArticles += 5"
      />
    </div>
    <div class="flex flex-col mt-2 gap-1">
      <div
        v-for="(article, index) in sideArticles.slice(0, visible)"
        :key="index"
        class="w-96 h-24 bg-white pt-2 pl-3 pr-3"
      >
        <RouterLink :to="'/article/' + article.id">
          <h1 class="font-semibold">
            {{ article.title }}
          </h1>
          <div class="pb-3">
            <TextClamp
              class="text-sm"
              :text="article.content"
              :max-lines="2"
            />
          </div>
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<script setup>
// import { allArticles } from '@/services/ObjectsProvider.js';
import { computed, onMounted, ref } from 'vue';
import { useLeagueStore } from '../../stores/leagueStore';
import { RouterLink } from 'vue-router';

const leagueStore = useLeagueStore();
const articles = computed(() => leagueStore.articles);
const sideArticles = computed(() => JSON.parse(JSON.stringify(articles.value)).sort((a, b) => a.title.length - b.title.length));
const visibleArticles = ref(4);
const visible = 5;

onMounted( async () => await leagueStore.getArticles());
</script>

<style scoped>


.article-card {
  width: 100%;
  max-width: 600px;
  margin: 0 auto;
}
.article-content {
  display: flex;
  align-items: center;
}
.article-image {
  width: 100px;
  height: 100px;
  object-fit: cover;
  margin-right: 1rem;
}
.article-header {
  flex-grow: 1;
}

.mainArticles:hover {
  text-decoration: underline;
}


.button-class {
  border-color: #dfe7f1;
  outline-width: 0cm;
  outline-offset: 0cm;
  background-color: black;
  color: white;
}

.button-class >>> span {
  color: white !important;
}
</style>