# JokesAPI  
A simple REST API for managing jokes and categories, built with **ASP.NET Core** and **Entity Framework Core**.

## Features  
- **CRUD operations** for jokes and categories  
- **3-tier architecture** (Controller - Service - Repository)  
- Uses **Entity Framework Core** for database access  
- **Swagger UI** for API testing  
- **Generic repository pattern** implementation  

## Technologies Used  
- **.NET 8**  
- **ASP.NET Core Web API**  
- **Entity Framework Core**  
- **Swagger** 
- **PostgreSQL** for database storage 

## Database Setup  
1. Install **PostgreSQL** on your machine or use a cloud database.  
2. Create a new database (e.g., `jokesapi`).
3. Update the connection string in the `appsettings.json` file to point to your PostgreSQL database:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=jokesapi;Username=yourusername;Password=yourpassword"
   }
4. Apply migrations to create the database schema.

## Installation & Running  
1. Clone the repository:
   ```bash 
   git clone https://github.com/basileia/JokesApi.git  
   cd JokesApi

2. Restore dependencies:
   ```bash
   dotnet restore
   
3. Apply migrations (if using EF Core with PostgreSQL):
   ```bash 
   dotnet ef database update

4. Run the project:
   ```bash 
   dotnet run

5. Open Swagger UI at:
   ```bash 
   https://localhost:7089/swagger/index.html
