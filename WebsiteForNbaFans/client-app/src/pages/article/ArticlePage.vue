<template>
  <div class="flex flex-col h-full w-full mb-5 justify-center items-center">
    <PrimeCard
      v-for="(article, index) in articles"
      :key="index"
      class="m-2 w-1/4"
    >
      <template #content>
        <div class="article-content">
          <img
            src="@/assets//sample.jpg"
            alt="Article Image"
            class="article-image"
          >
          <div class="article-header">
            <h3>{{ article.title }}</h3>
          </div>
        </div>
      </template>
    </PrimeCard>
  </div>
</template>

<script setup>
import { allArticles } from '@/services/ArticlesProvider.js';

const articles = allArticles;
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
</style>