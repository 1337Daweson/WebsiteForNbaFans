<script setup>
// import { RouterLink } from 'vue-router';
import { ref } from 'vue';
import { useRouter } from 'vue-router';
const router = useRouter();
const items = ref([
    {
      label: null,
      icon: 'custom-icon',
      command: () => {
        router.push('/');
      }
    },
    {
      label: 'About',
      icon: 'pi pi-link',
      command: () => {
        router.push('/about');
      }
    },
    {
      label: 'Teams',
      icon: 'pi pi-link',
      command: () => {
        router.push('/teams');
      }
    }
]);

</script>


<template>
  <div class="card bg-white">
    <MenuBar
      class="flex flex-row justify-center"
      :model="items"
    >
      <template #item="{ item, props, hasSubmenu }">
        <router-link
          v-if="item.route"
          v-slot="{ href, navigate }"
          :to="item.route"
          custom
        >
          <a
            v-ripple
            :href="href"
            v-bind="props.action"
            @click="navigate"
          >
            <span :class="item.icon" />
            <span
              v-if="item.label"
              class="ml-2"
            >{{ item.label }}</span>
          </a>
        </router-link>
        <a
          v-else
          v-ripple
          :href="item.url"
          :target="item.target"
          v-bind="props.action"
        >
          <span :class="item.icon" />
          <span
            v-if="item.label"
            class="ml-2"
          >{{ item.label }}</span>
          <span
            v-if="hasSubmenu"
            class="pi pi-fw pi-angle-down ml-2"
          />
        </a>
      </template>
    </MenuBar>
  </div>
</template>

<style scoped>

.custom-icon {
 background: url('../assets/nbalogo.avif') no-repeat center center;
 background-size: contain;
 height: 40px;
 width: 40px;
}

a:hover {
  text-decoration: none;
}
</style>
