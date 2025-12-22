
using DotnetC_.Models;

using Microsoft.EntityFrameworkCore;

namespace DotnetC_.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;
    public DbSet<FavoriteBook> FavoriteBooks { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Orders> Orders { get; set; } = null!;
    public DbSet<OrdersDetail> OrdersDetails { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;

    public DbSet<Delivery> Deliveries { get; set; } = null!;
    public DbSet<Feedback> Feedbacks { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cấu hình mối quan hệ Many-to-Many giữa Book và Genre
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity(j => j.ToTable("book_genre"));

        // Cấu hình mối quan hệ One-to-Many giữa Book và Image
        modelBuilder.Entity<Image>()
            .HasOne(i => i.Book)
            .WithMany(b => b.Images)
            .HasForeignKey(i => i.IdBook)
            .OnDelete(DeleteBehavior.Cascade);

        // Cấu hình mối quan hệ Many-to-Many giữa User và Role thông qua UserRole
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Cấu hình mối quan hệ FavoriteBook
        modelBuilder.Entity<FavoriteBook>()
            .HasOne(fb => fb.Book)
            .WithMany(b => b.FavoriteBooks)
            .HasForeignKey(fb => fb.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FavoriteBook>()
            .HasOne(fb => fb.User)
            .WithMany()
            .HasForeignKey(fb => fb.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Cấu hình mối quan hệ Review
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.OrderDetail)
            .WithMany()
            .HasForeignKey(r => r.OrderDetailId)
            .OnDelete(DeleteBehavior.SetNull);

        // Cấu hình mối quan hệ CartItem
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Book)
            .WithMany(b => b.CartItems)
            .HasForeignKey(ci => ci.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.User)
            .WithMany(u => u.CartItems)
            .HasForeignKey(ci => ci.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Cấu hình mối quan hệ Orders
        modelBuilder.Entity<Orders>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Payment)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.PaymentId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Delivery)
            .WithMany(d => d.Orders)
            .HasForeignKey(o => o.DeliveryId)
            .OnDelete(DeleteBehavior.SetNull);

        // Cấu hình mối quan hệ OrdersDetail
        modelBuilder.Entity<OrdersDetail>()
            .HasOne(od => od.Book)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(od => od.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrdersDetail>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Cấu hình mối quan hệ Feedback
        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
