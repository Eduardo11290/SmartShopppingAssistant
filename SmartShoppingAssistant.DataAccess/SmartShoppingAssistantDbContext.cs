using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartShoppingAssistant.DataAccess.Configurations;
using SmartShoppingAssistant.DataAccess.Entities;
using SmartShoppingAssistant.DataAccess.Entities.Enums;
using SmartShoppingAssistant.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess
{
    public class SmartShoppingAssistantDbContext(DbContextOptions<SmartShoppingAssistantDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Promotion> Promotions { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartShoppingAssistantDbContext).Assembly);

            // Seeding Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dairy", Description = "Milk, cheese, yogurt" },
                new Category { Id = 2, Name = "Pasta & Grains", Description = "Dried pasta, rice, and grain products" },
                new Category { Id = 3, Name = "Meat", Description = "Fresh and processed meat products" },
                new Category { Id = 4, Name = "Vegetables", Description = "Fresh and frozen vegetables" },
                new Category { Id = 5, Name = "Beverages", Description = "Water, juice, and soft drinks" }
            );

            // Seeding Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Spaghetti", Description = "Classic Italian spaghetti, 500g", Price = 5.99m, ImageUrl = "/images/spaghetti.jpg" },
                new Product { Id = 2, Name = "Parmesan Cheese", Description = "Aged parmesan, 200g block", Price = 12.50m, ImageUrl = "/images/parmesan.jpg" },
                new Product { Id = 3, Name = "Whole Milk", Description = "Fresh whole milk, 1L", Price = 4.99m, ImageUrl = "/images/milk.jpg" },
                new Product { Id = 4, Name = "Chicken Breast", Description = "Fresh chicken breast, 500g", Price = 15.99m, ImageUrl = "/images/chicken.jpg" },
                new Product { Id = 5, Name = "Mineral Water", Description = "Still mineral water, 1.5L", Price = 2.99m, ImageUrl = "/images/water.jpg" },
                new Product { Id = 6, Name = "Brown Rice", Description = "Whole grain brown rice, 1kg", Price = 7.99m, ImageUrl = "/images/rice.jpg" },
                new Product { Id = 7, Name = "Greek Yogurt", Description = "Creamy Greek yogurt, 400g", Price = 6.49m, ImageUrl = "/images/yogurt.jpg" },
                new Product { Id = 8, Name = "Tomatoes", Description = "Fresh ripe tomatoes, 500g", Price = 3.99m, ImageUrl = "/images/tomatoes.jpg" }
            );
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { Id = 4, ProductId = 1, Quantity = 2 },
                new CartItem { Id = 5, ProductId = 3, Quantity = 1 },
                new CartItem { Id = 6, ProductId = 5, Quantity = 3 }
            );

            // Seeding junction table ProductCategories
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.HasData(
                    new { ProductsId = 1, CategoriesId = 2 }, 
                    new { ProductsId = 2, CategoriesId = 1 }, 
                    new { ProductsId = 3, CategoriesId = 1 }, 
                    new { ProductsId = 4, CategoriesId = 3 }, 
                    new { ProductsId = 5, CategoriesId = 5 }, 
                    new { ProductsId = 6, CategoriesId = 2 }, 
                    new { ProductsId = 7, CategoriesId = 1 }, 
                    new { ProductsId = 8, CategoriesId = 4 }  
                ));

            // Seeding Promotions
            modelBuilder.Entity<Promotion>().HasData(
                new Promotion
                {
                    Id = 1,
                    Name = "Buy 5 Get 1 Free Spaghetti",
                    Type = PromotionType.Quantity,
                    Threshold = 5,
                    Reward = PromotionReward.FreeItems,
                    RewardValue = 1,
                    ProductId = 1,
                    CategoryId = null,
                    IsActive = true
                },
                new Promotion
                {
                    Id = 2,
                    Name = "10% off orders over 100 RON",
                    Type = PromotionType.CartTotal,
                    Threshold = 100.00m,
                    Reward = PromotionReward.PercentDiscount,
                    RewardValue = 10,
                    ProductId = null,
                    CategoryId = null,
                    IsActive = true
                }
            );
        }

    }
}
