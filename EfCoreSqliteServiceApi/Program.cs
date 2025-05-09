using EfCoreSqliteLibs;
using Microsoft.EntityFrameworkCore;
using EfCoreSqliteLibs.Service.Interfaces;
using EfCoreSqliteLibs.Service.Implementations;
using EfCoreSqliteLibs.Repository.Interfaces;
using EfCoreSqliteLibs.Repository.Implementations;
using EfCoreSqliteServiceApi.Mapping;
using EfCoreSqliteServiceApi.Middleware;
using EfCoreSqliteServiceApi.Filters;

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

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResponseWrapperFilter>();
});
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

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
