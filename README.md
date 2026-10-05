<div align="center">
  <img src="https://user-images.githubusercontent.com/26848718/159296228-2465d6e2-2e6b-4f10-b541-13317c3801f4.png" width="150" />
  <h1>C# React JWT & SQLite Note App</h1>
  <p>A secure, full-stack note-taking application built with a C# .NET 6 backend, a responsive React frontend, and a lightweight SQLite database. Authentication is handled using JSON Web Tokens (JWT).</p>

  <p>
    <img alt="C#" src="https://img.shields.io/badge/C%23-11.0-512BD4?style=for-the-badge&logo=c-sharp&logoColor=white"/>
    <img alt="React" src="https://img.shields.io/badge/React-18.2.0-61DAFB?style=for-the-badge&logo=react&logoColor=black"/>
    <img alt=".NET" src="https://img.shields.io/badge/.NET-6.0-512BD4?style=for-the-badge&logo=.net&logoColor=white"/>
    <img alt="SQLite" src="https://img.shields.io/badge/SQLite-3-003B57?style=for-the-badge&logo=sqlite&logoColor=white"/>
    <img alt="JWT" src="https://img.shields.io/badge/JWT-Auth-black?style=for-the-badge&logo=JSON%20web%20tokens"/>
  </p>
</div>

---

## ⚙️ Getting Started & Testing

### 1. Prerequisites 📋
-   [.NET 6+ SDK](https://dotnet.microsoft.com/download)
-   [Node.js and npm](https://nodejs.org/)

### 2. Setup Instructions 🚀
1.  **Clone the Repository**:
    ```bash
    git clone https://github.com/sirawtadesse/Notes-API.git
    cd Notes.Api
    ```
2.  **Run the Backend API**: (The `notes.db` file will be created automatically)
    ```bash
    # Open a terminal and navigate to the backend folder
    cd Notes.Api
    dotnet restore
    dotnet run
    ```
    > ▶️ Your API will now be running on `https://localhost:5049`.

3.  **Run the Frontend App**:
    ```bash
    # Open a NEW terminal and navigate to the frontend folder
    cd notes-client
    npm install
    npm start
    ```
    > 🎉 Your React app will open automatically at `http://localhost:3000`.

### 3. How to Test 🧪
-   **Register**: Click the "Sign Up" link to create a new user.
-   **Login with Test User**:
    -   **Username**: `test`
    -   **Password**: `test123`
