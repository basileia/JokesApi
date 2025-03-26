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
   
2. Update the connection string in the `appsettings.json` file to point to your PostgreSQL database.  
   Since the `appsettings.json` file is not included in the repository for security reasons, you'll need to create it in the `JokesApi/JokesApi` directory.
   Here is an example of how your `appsettings.json` should look:
   
   ```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=jokesapi;Username=yourusername;Password=yourpassword"
  }
}
```
   
3. Apply migrations to create the database schema:
   ```bash 
   dotnet ef database update
   ```

## Installation & Running  
1. Clone the repository:
   ```bash 
   git clone https://github.com/basileia/JokesApi.git  
   cd JokesApi/JokesApi
   ```

2. Run the project:
   ```bash 
   dotnet run
   ```

3. Open Swagger UI at:
   ```bash 
   https://localhost:<port>/swagger/index.html
   ```
   To find the correct port, check the console output after running the application. You should see a message like: Now listening on: https://localhost:xxxx
