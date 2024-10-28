# Fullstack Vendor Bidding App
This is a Vendor Bidding Application with a .NET Core backend and Angular frontend, designed to handle vendor logins, project listings, bid submissions, and more.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Backend Setup and Run](#backend-setup-and-run)
- [Frontend Setup and Run](#frontend-setup-and-run)
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
- **.NET SDK** (for backend
- **SQL Server** (for database)
- **Git** (for cloning repository)

---

## Installation

1. To clone this repository using Visual Studio Editor:
Launch the Visual Studio, Once it opens, click on the link that says Clone repository and paste the link below:
   ```bash
   git clone https://github.com/techflow21/fullstack_vendorBids_app.git
```
The nugget package dependencies will be restored using internet connectivity.

2. Update the connection string in appsettings.json under "ConnectionStrings":
Upadate the appsettings.json file in the project with your database connection string like below:
```bash
"ConnectionStrings": {
    "LocalConnection": "Server=server_name;Initial Catalog=database_name;Trusted_Connection=True;Trust Server Certificate=True;MultipleActiveResultSets=True"
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
