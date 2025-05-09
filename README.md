# EfCoreSqliteApp
Learning to use EFCore, SQLite and AutoMapper for RESTFUL API

# How to run it
1. Build all projects
2. Run script to create sqlite database
   - dotnet ef migrations add InitialCreate --project EfCoreSqliteLibs --startup-project EfCoreSqliteServiceApi --context AppDbContext
   - dotnet ef database update --project EfCoreSqliteLibs --startup-project EfCoreSqliteServiceApi --context AppDbContext
3. Run Swagger and api is done
