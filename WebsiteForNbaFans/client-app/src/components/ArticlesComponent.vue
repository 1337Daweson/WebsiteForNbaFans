<template>
  <div class="grid grid-cols-2 h-24 m-10">
    <div class="flex justify-center">
      <PrimeCard class="m-2">
        <template #header>
          <img
            alt="article header"
            src="../assets/vite.svg"
          >
        </template>
        <template #title>
          Článek
        </template>
        <template #content>
          <p class="m-0">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque quas!
          </p>
        </template>
        <template #footer>
          <div class="flex justify-center mt-1">
            <PrimeButton
              label="View Details"
              class="w-full"
              @click="navigateToArticleDetail"
            />
          </div>  
        </template>
      </PrimeCard>
    </div>
  </div>
</template>

<script setup>

</script>

<style lang="scss" scoped>

</style>