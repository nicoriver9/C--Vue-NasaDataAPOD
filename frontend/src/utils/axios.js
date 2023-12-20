import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5067/', // Reemplaza con la URL de tu API backend
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;