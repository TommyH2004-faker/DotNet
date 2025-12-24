using Microsoft.EntityFrameworkCore;
using DotnetC_.Infrastructure.Data;
using DotNetEnv;
using DotnetC_.Middlewares;
using DotnetC_.Application.Interfaces;
using DotnetC_.Application.Services;
using DotnetC_.Domain.Interfaces;
using DotnetC_.Infrastructure.Repositories;

// Load biến môi trường từ .env
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// ===== Register services =====
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Tạo connection string từ biến môi trường
    var connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")};"
        + $"Port={Environment.GetEnvironmentVariable("DB_PORT")};"
        + $"Database={Environment.GetEnvironmentVariable("DB_NAME")};"
        + $"User={Environment.GetEnvironmentVariable("DB_USER")};"
        + $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";
    
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));
});

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Register Services
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===== Middleware =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

// ===== Map Controllers (API sẽ viết sau) =====
app.MapControllers();

app.Run();
