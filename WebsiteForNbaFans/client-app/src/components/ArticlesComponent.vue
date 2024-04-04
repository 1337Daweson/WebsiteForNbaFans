<template>
  <div class="flex flex-row h-full w-full mb-5 justify-center items-center">
    <PrimeCard
      v-for="(article, index) in articles"
      :key="index"
      class="m-2 w-1/4"
    >
      <template #content>
        <div class="article-content">
          <img
            src="../assets//sample.jpg"
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
  <PrimeButton
    class="text-2xl font-bold mb-4 border-2 button-class"
    label="Ostatní články"
  />
</template>

<script setup>

const articles = [
  {
    title: 'Vít Krejčí si zlepšil osobní maximum v NBA',
    content: 'kontent',
  },
  {
    title: 'Článek 2',
    content: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque quas!',
  },
  {
    title: 'Článek 3',
    content: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque quas!',
  },
  {
    title: 'Článek 4',
    content: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque quas!',
  },

];
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
  width: 100px;
  height: 100px;
  object-fit: cover;
  margin-right: 1rem;
}
.article-header {
  flex-grow: 1;
}
</style>
