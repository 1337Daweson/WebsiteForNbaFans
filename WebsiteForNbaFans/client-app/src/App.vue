<script setup>
import { RouterView } from 'vue-router';
import Navbar from './components/Navbar.vue';
import FooterComponent from '../src/components/FooterComponent.vue';
</script>

<template>
  <div class="text-black app">
    <Navbar />
    <div class="content-wrapper">
      <RouterView />
    </div>
    <FooterComponent />
  </div>
</template>

<style scoped>

.app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}

.content-wrapper {
  flex: 1;
 }


</style>
