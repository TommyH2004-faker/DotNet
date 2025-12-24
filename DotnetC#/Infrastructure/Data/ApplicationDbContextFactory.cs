using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace DotnetC_.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Load biến môi trường từ .env
        Env.Load();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        // Lấy và validate biến môi trường
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") 
            ?? throw new InvalidOperationException("DB_HOST không được tìm thấy trong .env");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT") 
            ?? throw new InvalidOperationException("DB_PORT không được tìm thấy trong .env");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") 
            ?? throw new InvalidOperationException("DB_NAME không được tìm thấy trong .env");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER") 
            ?? throw new InvalidOperationException("DB_USER không được tìm thấy trong .env");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") 
            ?? throw new InvalidOperationException("DB_PASSWORD không được tìm thấy trong .env");
        
        // Tạo connection string
        var connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPassword};";
        
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
