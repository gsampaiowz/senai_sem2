import axios from "axios";

// const apiPort = "5000";
// const localApi = `http://localhost:${apiPort}/api`;
const externalApi = "https://event-apiweb-sampaio.azurewebsites.net/api"

const api = axios.create({
    baseURL: externalApi
    // baseURL: localApi
});

export default api;
