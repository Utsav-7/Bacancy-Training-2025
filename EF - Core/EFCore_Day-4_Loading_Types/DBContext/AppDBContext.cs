using System.Reflection.Metadata;
using EFCore_Day_4_Loading_Types.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Day_4_Loading_Types.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }

        // Use Lazy loading with Proxies package
        // Enabling Lazy Loading
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(b => b.Email).IsUnique();

            modelBuilder.Entity<Customer>()
                        .HasIndex(c => c.Email)
                        .IsUnique();
                
            modelBuilder.Entity<Order>()
                        .HasOne(s => s.customer)
                        .WithMany(o => o.orders)
                        .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(o => o.orders)
                        .WithMany(op => op.orderProduct)
                        .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(p => p.products)
                        .WithMany(op => op.orderProduct)
                        .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Jay", Email = "jay@gmail.com", IsVIP = true },
                new Customer { CustomerId = 2, Name = "Mahesh", Email = "mahesh@gmail.com", IsVIP = false },
                new Customer { CustomerId = 3, Name = "Raju", Email = "raju@gmail.com", IsVIP = true },
                new Customer { CustomerId = 4, Name = "Mukesh", Email = "mukesh@gmail.com", IsVIP = false },
                new Customer { CustomerId = 5, Name = "Suresh", Email = "suresh@gmail.com", IsVIP = true }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderDate = new DateTime(2023, 12, 04), CustomerId = 1, IsDeleted = false },
                new Order { OrderId = 2, OrderDate = new DateTime(2023, 12, 05), CustomerId = 2, IsDeleted = false },
                new Order { OrderId = 3, OrderDate = new DateTime(2023, 12, 06), CustomerId = 3, IsDeleted = false },
                new Order { OrderId = 4, OrderDate = new DateTime(2023, 12, 07), CustomerId = 1, IsDeleted = false },
                new Order { OrderId = 5, OrderDate = new DateTime(2023, 12, 08), CustomerId = 4, IsDeleted = false },
                new Order { OrderId = 6, OrderDate = new DateTime(2023, 12, 09), CustomerId = 2, IsDeleted = false },
                new Order { OrderId = 7, OrderDate = new DateTime(2023, 12, 10), CustomerId = 3, IsDeleted = false },
                new Order { OrderId = 8, OrderDate = new DateTime(2023, 12, 11), CustomerId = 5, IsDeleted = false }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 49999.00m, Stock = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 29999.00m, Stock = 25 },
                new Product { Id = 3, Name = "Headphones", Price = 1999.99m, Stock = 10 },
                new Product { Id = 4, Name = "Keyboard", Price = 1499.50m, Stock = 15 },
                new Product { Id = 5, Name = "Mouse", Price = 799.75m, Stock = 20 },
                new Product { Id = 6, Name = "Monitor", Price = 8999.99m, Stock = 7 },
                new Product { Id = 7, Name = "Printer", Price = 12999.00m, Stock = 3 },
                new Product { Id = 8, Name = "Speaker", Price = 2999.49m, Stock = 120 },
                new Product { Id = 9, Name = "Webcam", Price = 2499.99m, Stock = 18 },
                new Product { Id = 10, Name = "External Hard Drive", Price = 6999.99m, Stock = 6 }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
                new OrderProduct { Id = 2, OrderId = 2, ProductId = 2, Quantity = 2 },
                new OrderProduct { Id = 3, OrderId = 3, ProductId = 3, Quantity = 1 },
                new OrderProduct { Id = 4, OrderId = 4, ProductId = 4, Quantity = 3 },
                new OrderProduct { Id = 5, OrderId = 5, ProductId = 5, Quantity = 2 },
                new OrderProduct { Id = 6, OrderId = 6, ProductId = 6, Quantity = 1 },
                new OrderProduct { Id = 7, OrderId = 7, ProductId = 7, Quantity = 4 },
                new OrderProduct { Id = 8, OrderId = 8, ProductId = 8, Quantity = 2 }
            );
        }
    }
}