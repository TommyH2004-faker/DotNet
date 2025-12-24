using DotnetC_.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DotnetC_.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public ApplicationDbContext(DbContextOptions options)
        : base(options) { }
}
