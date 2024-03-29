<template>
  <div
    v-if="!loaded"
    class="loading-container"
  >
    <ProgressSpinner />
  </div>
</template>

<script setup>
import ProgressSpinner from 'primevue/progressspinner';
// eslint-disable-next-line no-unused-vars
const props = defineProps( {
    loaded: {
        type: Boolean,
         default: true,
    },
});

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
    z-index: 9999;
}

.loading-container::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(255, 255, 255, 0.5);
    z-index: -1;
}
</style>