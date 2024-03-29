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
      },
    },
    {
      label: 'O nás',
      command: () => {
        router.push('/about');
      },
    },
    {
      label: 'Týmy',
      command: () => {
        router.push('/teams');
      },
    },
    {
      label: 'Tabulky',
      command: () => {
        router.push('/standings');
      },
    },
    {
    label: 'Statistiky',
    command: () => {
    router.push('/stats');
    },
    items: [
    {
      label: 'Styled',
      route: '/theming',
    },
    {
      label: 'Unstyled',
      route: '/unstyled',
    },
  ],
 },
]);

</script>


<template>
  <div class="card bg-white">
    <MenuBar
      class="flex flex-row justify-center bg-white"
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
            <span class="ml-2">{{ item.label }}</span>
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
          <span class="customLink">{{ item.label }}</span>
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

.customLink::before {
 content: '';
 position: absolute;
 width: 100%;
 height: 4px;
 border-radius: 4px;
 background-color: #18272F;
 bottom: 0;
 left: 0;
 transform-origin: right;
 transform: scaleX(0);
 transition: transform .3s ease-in-out;
}

.customLink:hover::before {
 transform-origin: left;
 transform: scaleX(1);
}
</style>
