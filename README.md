# EfCoreSqliteApp

A learning project for building a RESTful API using **Entity Framework Core** with **SQLite** and **.NET 8**.  
This project follows a **Layered Architecture** and includes several useful practices.

## 🔧 Features
- ✅ Layered Architecture (Controller, Service, Repository)
- 🛠️ Custom Exception Handling & Middleware
- 📏 IActionFilter for Request Validation
- 🔗 Entity Relationships via Navigation Properties
- 🔄 AutoMapper for DTO Mapping

## 🚀 How to Run

### 1. Install Required Tools

- Ensure [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download) is installed.
- Install `dotnet-ef` CLI tool if not already:
     dotnet tool install --global dotnet-ef --version 8.0.15
- Install DB Browser for SQLite or any SQLite client.

### 2. Build and Set Up the Database
- From the project root:
     dotnet build
- Run the EF Core migration commands to create the database:
     dotnet ef migrations add InitialCreate --project EfCoreSqliteLibs --startup-project EfCoreSqliteServiceApi --context AppDbContext
     dotnet ef database update --project EfCoreSqliteLibs --startup-project EfCoreSqliteServiceApi --context AppDbContext
  
### 3. Run the Application
- Run the API project:
   dotnet run --project EfCoreSqliteServiceApi
- Visit Swagger UI at:
   [Swagger UI (Localhost)](https://localhost:7146/swagger)

