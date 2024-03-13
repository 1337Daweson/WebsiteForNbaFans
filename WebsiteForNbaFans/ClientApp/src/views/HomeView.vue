<template>
  <div class="container mx-auto px-4">
     <div class="flex flex-wrap -mx-2">
       <div class="w-full md:w-1/2 px-2">
         <div class="rounded overflow-hidden shadow-lg">
           <img class="w-full" src="path/to/your/image.jpg" alt="Image description">
            <HelloWorld msg="Welcome to Your Vue.js App" />
           <div class="px-6 py-4">
             <div class="font-bold text-xl mb-2">Title of the Article</div>
             <p class="text-gray-700 text-base">
               Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet.
             </p>
           </div>
         </div>
       </div>
       <!-- Repeat the above div for more articles -->
     </div>
  </div>
 </template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue';
import { useTeamStore } from '@/stores/teamStore';
import { onMounted } from 'vue';

export default {
  name: 'HomeView',
  components: {
    HelloWorld,
  },
  setup() {
    const store = useTeamStore();
    
    onMounted(() => store.getTeams());
  },
};
</script>
