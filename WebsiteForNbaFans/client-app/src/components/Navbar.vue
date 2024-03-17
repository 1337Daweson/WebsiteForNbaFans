<script setup>
import { RouterLink } from 'vue-router';

</script>


<template>
  <nav class="bg-slate-500 h-full">
    <div class="max-w-7xl mx-auto px-2 sm:px-6 lg:px-8">
      <div class="relative flex items-center justify-between h-1">
        <div
          class="flex-1 flex items-center justify-center sm:items-stretch sm:justify-start"
        >
          <div class="flex-shrink-0 flex items-center">
            <img
              class="block lg:hidden h-6 w-auto"
              src="../assets/nbalogo.avif"
              alt="NBA Logo"
            >
            <h1 class="text-white">
              Český web pro fanoušky NBA
            </h1>
          </div>
          <div class="hidden sm:block sm:ml-6">
            <div class="flex space-x-4">
              <RouterLink
                to="/"
                class="text-gray-300 hover:bg-gray-700 hover:text-white px-3 py-2 rounded-md text-sm font-medium"
              >
                Home
              </RouterLink>
              <RouterLink
                to="/about"
                class="text-gray-300 hover:bg-gray-700 hover:text-white px-3 py-2 rounded-md text-sm font-medium"
              >
                About
              </RouterLink>
              <!-- Add more links as needed -->
            </div>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>
