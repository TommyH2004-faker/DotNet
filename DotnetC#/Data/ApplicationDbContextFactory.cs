using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace DotnetCSharp.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Load biến môi trường từ .env
        Env.Load();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        // Tạo connection string từ biến môi trường
        var connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")};"
            + $"Port={Environment.GetEnvironmentVariable("DB_PORT")};"
            + $"Database={Environment.GetEnvironmentVariable("DB_NAME")};"
            + $"User={Environment.GetEnvironmentVariable("DB_USER")};"
            + $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";
        
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
