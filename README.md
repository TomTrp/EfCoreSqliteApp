# EfCoreSqliteApp
Learning to use EFCore, SQLite for RESTFUL API and personal interest
- Clean Structure
- Custom Exception
- Middleware
- IActionFilter
- Navigation Properties
- AutoMapper

# How to run it
1. Build all projects
2. Run script to create sqlite database
   - dotnet ef migrations add InitialCreate --project EfCoreSqliteLibs --startup-project EfCoreSqliteServiceApi --context AppDbContext
   - dotnet ef database update --project EfCoreSqliteLibs --startup-project EfCoreSqliteServiceApi --context AppDbContext
3. Run Swagger and api is done
