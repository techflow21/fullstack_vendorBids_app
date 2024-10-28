# Fullstack Vendor Bidding App
This is a Vendor Bidding Application with a .NET Core backend and Angular frontend, designed to handle vendor logins, project listings, bid submissions, and more.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Backend Setup](#backend-setup)
- [Frontend Setup](#frontend-setup)
- [Technologies Used](#technologies-used)

---

## Features

- **Backend**: ASP.NET Core Web API with JWT authentication, CORS enabled, integrated with SQL Server, and Swagger for API documentation.
- **Frontend**: Angular for the client-side, with Bootstrap for responsive design.
- **Database**: SQL Server with Entity Framework Core for database management.

---

## Prerequisites

Make sure you have the following installed:

- **Node.js** (for frontend)
- **Visual Studio** (for Backend code Editor)
- **Visual Studio Code** (for Frontend code Editor)
- **.NET SDK** (for backend)
- **SQL Server** (for database)
- **Git** (for cloning repository)

---

## Installation
Launch the installed Git bash or any other terminal, then enter the command below:
```bash
   git clone https://github.com/techflow21/fullstack_vendorBids_app.git
```
## Backend Setup
1. Locate the Project:
Locate the Backend folder and click open, then search for the .sln file and double-click, This automactically launch open the Visual Studio. The NuGet Package Dependencies will be restored using internet connectivity.

3. Update the connection string in appsettings.json under "ConnectionStrings":
Upadate the appsettings.json file in the project with your database connection string like below:

```bash
   "ConnectionStrings": {
       "LocalConnection": "Server=server_name;Initial Catalog=database_name;Trusted_Connection=True;Trust Server   
        Certificate=True;MultipleActiveResultSets=True"
   }
```

3. Run Entity Framework Core migrations to set up the database:
Locate the Tools menu on the Visual Studio and click, then click on NuGet Package Manager, then Package Manager Console.
Once the Window has opened up, run the following command to update the database with available Migrations.
```bash
   update-database
```
5. Run the backend server:
Click on any of the green play icon to run the backend server.
The backend API should now be running on https://localhost:5001 with Swagger UI loaded.

---

## Frontend Setup
1. Open the clone project folder, right-click and Select Git-bash here and navigate to the frontend folder with the command below:

```bash
   cd VendorBiddingApp_Frontend
```
Then, enter the following to automatically load up the project on Visual Studio Code:
```bash
   code .
```
2. Then, locate terminal menu, the window opens up. Install the necessary libraries using the command below:
```bash
   npm install
```
3. Run the frontend application:
```bash
   ng serve -o
```
The frontend should now be running on http://localhost:4200.
The app should be ready for testing at this point.

---

## Technologies Used
Backend: .NET Core, Entity Framework Core, SQL Server, JWT for authentication
Frontend: Angular, Bootstrap
Others: Swagger for API documentation, Git for version control
