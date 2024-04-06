<template>
  <div class="h-full">
    <PrimeCarousel
      :value="articles"
      :num-visible="5"
      :num-scroll="3"
    >
      <template #item="slotProps">
        <div class="border-2 w-full surface-border border-round m-2  p-3 bg-white">
          <div class="mb-3">
            <div class="relative mx-auto">
              <img
                src="../assets//sample.jpg"
                :alt="slotProps.data.title"
                class="w-full border-round article-image"
              >
            </div>
          </div>
          <div class="mb-3 font-bold">
            <TextClamp
              :text="slotProps.data.title"
              :max-lines="2"
            />
          </div>
          <div class="flex justify-content-between align-items-center items-end">
            <div class="mt-0 text-xl">
              <TextClamp
                :text="slotProps.data.content"
                :max-lines="3"
              />
            </div>
          </div>
          <PrimeButton
            label="Celý článek zde"
            @click="navigateToArticle(slotProps.data.id)"
          />
        </div>
      </template>
    </PrimeCarousel>
  </div>
  <div class="w-full flex flex-row justify-center">
    <PrimeButton
      class="text-2xl font-bold mb-4 border-2 button-class"
      label="Ostatní články"
    />
  </div>
</template>

<script setup>
import { allArticles } from '@/services/ArticlesProvider.js';
import { useRouter } from 'vue-router';
import { computed } from 'vue';
const articles = computed(() => allArticles.filter(article => article.homepage === true)); 
const router = useRouter(); 

const navigateToArticle = (id) => {
  router.push('/articles/' + id);
};

</script>

<style scoped>

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
  width: 400px;
  height: 300px;
  object-fit: cover;
  margin-right: 1rem;
}
.article-header {
  flex-grow: 1;
}
</style>
