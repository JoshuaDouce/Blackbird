using Blackbird.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blackbird.Persistence;

public class BlackbirdDbContext : DbContext
{
    public BlackbirdDbContext(DbContextOptions<BlackbirdDbContext> options)
                : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    // Add other DbSet properties for additional entities here

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships and other model settings here
        var products = new List<Product>
        {
            new Product(1, "Product 1", 25.99m, "This is product 1 description."),
            new Product(2, "Product 2", 19.99m, "This is product 2 description."),
            new Product(3, "Product 3", 35.50m, "This is product 3 description."),
            new Product(4, "Product 4", 29.99m, "This is product 4 description."),
            new Product(5, "Product 5", 49.99m, "This is product 5 description."),
            new Product(6, "Product 6", 15.99m, "This is product 6 description."),
            new Product(7, "Product 7", 22.99m, "This is product 7 description."),
            new Product(8, "Product 8", 17.99m, "This is product 8 description."),
            new Product(9, "Product 9", 32.99m, "This is product 9 description."),
            new Product(10, "Product 10", 24.99m, "This is product 10 description."),
        };

        modelBuilder.Entity<Product>().HasData(products);
    }
}