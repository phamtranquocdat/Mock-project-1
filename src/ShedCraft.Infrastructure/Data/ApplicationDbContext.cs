using Microsoft.EntityFrameworkCore;
using ShedCraft.Domain.Entities;

namespace ShedCraft.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<ProductShed> ProductSheds => Set<ProductShed>();
    public DbSet<Quote> Quotes => Set<Quote>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cấu hình kiểu dữ liệu decimal cho giá tiền trong EF Core
        modelBuilder.Entity<ProductShed>()
            .Property(p => p.BasePrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Quote>()
            .Property(q => q.BasePrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Quote>()
            .Property(q => q.CustomizationFee)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Quote>()
            .Property(q => q.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Quote>()
            .Property(q => q.TotalAmount)
            .HasColumnType("decimal(18,2)");
    }
}