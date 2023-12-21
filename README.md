# NASA APOD Viewer

A simple web application that fetches and displays NASA's Astronomy Picture of the Day (APOD) using ASP.NET Core MVC for the backend and Vue.js for the frontend.

## Table of Contents

- [Overview](#overview)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Backend Configuration](#backend-configuration)
- [Frontend Configuration](#frontend-configuration)
- [Contributing](#contributing)
- [License](#license)

## Overview

This application provides a web interface to view NASA's Astronomy Picture of the Day. The backend is built with ASP.NET Core MVC, which serves as an API to deliver APOD data in JSON format. The frontend is developed using Vue.js to consume the API and display the images.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (3.1 or later)
- [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com/)
- Visual Studio or Visual Studio Code (optional)

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/your-username/nasa-apod-viewer.git
    cd nasa-apod-viewer
    ```

2. **Install backend dependencies:**

    ```bash
    cd backend
    dotnet restore
    ```

3. **Install frontend dependencies:**

    ```bash
    cd frontend
    npm install
    ```

## Usage

1. **Run the backend:**

    ```bash
    cd backend
    dotnet run
    ```

   The backend will be accessible at `https://localhost:5001` (or `http://localhost:5000`).

2. **Run the frontend:**

    ```bash
    cd frontend
    npm run serve
    ```

   The frontend will be accessible at `http://localhost:8080`.

## Backend Configuration

### CORS Configuration

The backend is configured to allow CORS from any origin, method, and header. This is suitable for development purposes, but for production, consider configuring CORS more restrictively.

Modify the CORS configuration in `Startup.cs`:

```csharp
services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
```

### Enable CORS in the application pipeline:
```csharp
app.UseCors("AllowAnyOrigin");
```
### API Endpoint
The backend provides a simple API endpoint to retrieve the APOD data in JSON format:

. Endpoint: /api/Home/GetApodList
. Method: GET
## Frontend Configuration
### Axios Configuration
Axios is used for making HTTP requests from the Vue.js frontend to the backend. Axios is configured in the axios.js file inside the src folder.

Adjust the base URL to point to your backend API:

```csharp
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:5001/api', // Adjust the URL according to your backend configuration
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;
```
### Vue Component
The Vue component ApodList.vue fetches and displays the APOD images.

Adjust the API endpoint URL in the mounted method:

```vue
<script>
import apiClient from '../axios';

export default {
  data() {
    return {
      apodList: [],
    };
  },
  mounted() {
    apiClient.get('/Home/GetApodList')
      .then(response => {
        this.apodList = response.data;
      })
      .catch(error => {
        console.error('Error fetching APOD data:', error);
      });
  },
};
</script>
```
## Contributing
Contributions are welcome! If you find any issues or have improvements to suggest, feel free to open an issue or create a pull request.

##  License
This project is licensed under the MIT License - see the LICENSE file for details.


Feel free to use this additional Markdown-formatted content for the GitHub repository. Adjust it as needed based on your project's details.
