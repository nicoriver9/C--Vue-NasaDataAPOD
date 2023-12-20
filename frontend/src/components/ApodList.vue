<template>
  <div>
    <h1>Imágenes de la NASA</h1>
    <ul>
      <li v-for="apod in apodList" :key="apod.title">
        <h3>{{ apod.title }}</h3>
        <img :src="apod.url" :alt="apod.title" />
      </li>
    </ul>
  </div>
</template>

<script>
import apiClient from '../utils/axios.js';
export default {
  data() {
    return {
      apodList: [],
    };
  },
  mounted() {
    // Llamar a la API backend para obtener la lista de imágenes
    // Asegúrate de instalar Axios y configurarlo según las instrucciones anteriores
    // Puedes hacer la llamada a la API en el ciclo de vida 'mounted'
    // Puedes utilizar apiClient desde axios.js para hacer la solicitud
     apiClient.get('/api/nasa/GetApodList')  // Asegúrate de ajustar la ruta correcta según tu configuración de rutas
      .then(response => {
        // Asignar la respuesta a la propiedad apodList
        this.apodList = response.data;
      })
      .catch(error => {
        console.error('Error al obtener la lista de imágenes:', error);
      });
    },

  
};
</script>

<style scoped>
/* Estilos específicos para este componente */
</style>
