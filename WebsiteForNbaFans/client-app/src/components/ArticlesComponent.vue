<template>
  <div class="grid grid-cols-2 h-24 m-10">
    <div class="flex justify-center">
      <PrimeCard class="m-2">
        <template #header>
          <img
            alt="user header"
            src="../assets//vite.svg"
          >
        </template>
        <template #title>
          Článek
        </template>
        <template #subtitle>
          Popis
        </template>
        <template #content>
          <p class="m-0">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
            quas!
          </p>
        </template>
        <template #footer>
          <div class="flex gap-3 mt-1">
            <PrimeButton
              label="Cancel"
              severity="secondary"
              outlined
              class="w-full"
            />
            <PrimeButton
              label="Save"
              class="w-full"
            />
          </div>
        </template>
      </PrimeCard>
      <PrimeCard class="m-2">
        <template #header>
          <img
            alt="user header"
            src="../assets//vue.svg"
          >
        </template>
        <template #title>
          Článek
        </template>
        <template #subtitle>
          popis
        </template>
        <template #content>
          <p class="m-0">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
            quas!
          </p>
        </template>
        <template #footer>
          <div class="flex gap-3 mt-1">
            <PrimeButton
              label="Cancel"
              severity="secondary"
              outlined
              class="w-full"
            />
            <PrimeButton
              label="Save"
              class="w-full"
            />
          </div>
        </template>
      </PrimeCard>
    </div>
    <div class="flex justify-center">
      <PrimeCard class="m-2">
        <template #header>
          <img
            alt="user header"
            src="../assets//vite.svg"
          >
        </template>
        <template #title>
          Článek
        </template>
        <template #subtitle>
          popis
        </template>
        <template #content>
          <p class="m-0">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
            quas!
          </p>
        </template>
        <template #footer>
          <div class="flex gap-3 mt-1">
            <PrimeButton
              label="Cancel"
              severity="secondary"
              outlined
              class="w-full"
            />
            <PrimeButton
              label="Save"
              class="w-full"
            />
          </div>
        </template>
      </PrimeCard>
      <PrimeCard class="m-2">
        <template #header>
          <img
            alt="user header"
            src="../assets//vue.svg"
          >
        </template>
        <template #title>
          Článek
        </template>
        <template #subtitle>
          popis
        </template>
        <template #content>
          <p class="m-0">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
            quas!
          </p>
        </template>
        <template #footer>
          <div class="flex gap-3 mt-1">
            <PrimeButton
              label="Cancel"
              severity="secondary"
              outlined
              class="w-full"
            />
            <PrimeButton
              label="Save"
              class="w-full"
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