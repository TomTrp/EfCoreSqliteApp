using EfCoreSqliteLibs;
using Microsoft.EntityFrameworkCore;
using EfCoreSqliteLibs.Service.Interfaces.Books;
using EfCoreSqliteLibs.Service.Interfaces.Borrowed;
using EfCoreSqliteLibs.Service.Implementations.Books;
using EfCoreSqliteLibs.Service.Implementations.Borrowed;
using EfCoreSqliteLibs.Repository.Interfaces.Books;
using EfCoreSqliteLibs.Repository.Interfaces.Borrowed;
using EfCoreSqliteLibs.Repository.Implementations.Books;
using EfCoreSqliteLibs.Repository.Implementations.Borrowed;
using EfCoreSqliteServiceApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Use SQLlite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
