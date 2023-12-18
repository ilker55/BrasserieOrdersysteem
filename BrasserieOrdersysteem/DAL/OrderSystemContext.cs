﻿using BrasserieOrdersysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.DAL
{
    public class OrderSystemContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderRule> OrderRules { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        public OrderSystemContext(DbContextOptions<OrderSystemContext> options) : base(options)
        {
        }

        private static Product[] GetProducts()
            => new Product[]
            {
                new() {
                    Id = 1,
                    Name = "Croque Monsieur",
                    Description = "A classic French grilled ham and cheese sandwich, typically made with Gruyère cheese and topped with béchamel sauce.",
                    Price = 12.99
                },
                new() {
                    Id = 2,
                    Name = "Moules Frites",
                    Description = "Mussels served with a side of crispy French fries. This dish is often prepared with a flavorful broth, such as white wine, garlic, and herbs.",
                    Price = 16.99
                },
                new() {
                    Id = 3,
                    Name = "Quiche Lorraine",
                    Description = "A savory tart filled with a creamy mixture of eggs, cream, bacon or lardons, and Swiss cheese. Quiche Lorraine is a popular dish in French cuisine.",
                    Price = 14.99
                },
                new() {
                    Id = 4,
                    Name = "Bouillabaisse",
                    Description = "A traditional Provençal fish stew originating from the port city of Marseille. It typically includes a variety of fish, shellfish, and aromatic herbs in a broth seasoned with Mediterranean herbs and spices.",
                    Price = 22.99
                },
                new() {
                    Id = 5,
                    Name = "Tarte Tatin",
                    Description = "A caramelized upside-down pastry, usually made with apples. The tart is baked with the fruit on the bottom and a layer of pastry on top, then inverted before serving.",
                    Price = 8.99
                }
            };

        private static Customer[] GetCustomers()
            => new Customer[]
            {
                new() {
                    Id = 1,
                    Name = "Elena Martinez"
                },
                new() {
                    Id = 2,
                    Name = "Jonathan Turner"
                },
                new() {
                    Id = 3,
                    Name = "Sophie Anderson"
                }
            };

        private static Order[] GetOrders()
            => new Order[]
            {
                new() {
                    Id = 1,
                    OrderAt = DateTime.Now.AddHours(-13),
                    PaidAt = DateTime.Now.AddDays(-12),
                    CustomerId = 1
                },
                new() {
                    Id = 2,
                    OrderAt = DateTime.Now.AddHours(-4),
                    Canceled = true,
                    CustomerId = 2
                },
                new() {
                    Id = 3,
                    OrderAt = DateTime.Now.AddHours(-4),
                    PaidAt = DateTime.Now.AddHours(-2),
                    CustomerId = 2
                },
                new() {
                    Id = 4,
                    OrderAt = DateTime.Now,
                    CustomerId = 3
                }
            };

        private static OrderRule[] GetOrderRules()
            => new OrderRule[]
            {
                new() {
                    Id = 1,
                    Units = 4,
                    PricePerUnit = 12.99,
                    OrderId = 1,
                    ProductId = 1
                },
                new() {
                    Id = 2,
                    Units = 2,
                    PricePerUnit = 16.99,
                    OrderId = 2,
                    ProductId = 2
                },
                new() {
                    Id = 3,
                    Units = 1,
                    PricePerUnit = 16.99,
                    OrderId = 3,
                    ProductId = 2
                },
                new() {
                    Id = 4,
                    Units = 1,
                    PricePerUnit = 14.99,
                    OrderId = 3,
                    ProductId = 3
                },
                new() {
                    Id = 5,
                    Units = 1,
                    PricePerUnit = 22.99,
                    OrderId = 4,
                    ProductId = 4
                },
                new() {
                    Id = 6,
                    Units = 2,
                    PricePerUnit = 8.99,
                    OrderId = 4,
                    ProductId = 5
                }
            };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<Customer>().HasData(GetCustomers());
            modelBuilder.Entity<Order>().HasData(GetOrders());
            modelBuilder.Entity<OrderRule>().HasData(GetOrderRules());
        }
    }
}