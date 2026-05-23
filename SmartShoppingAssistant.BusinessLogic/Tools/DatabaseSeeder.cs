using SmartShoppingAssistant.DataAccess;
using SmartShoppingAssistant.DataAccess.Entities;
using SmartShoppingAssistant.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Tools
{
    public class DatabaseSeeder(SmartShoppingAssistantDbContext context)
    {
        public async Task ResetAndSeedAsync()
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var catGroceries = new Category { Name = "Alimente de baza", Description = "Ingrediente si alimente de zi cu zi" };
            var catElectronics = new Category { Name = "Electronice", Description = "Gadgeturi, cabluri si electrocasnice" };
            var catSnacks = new Category { Name = "Dulciuri & Snacks", Description = "Gustari dulci si sarate" };
            var catDrinks = new Category { Name = "Bauturi", Description = "Apa, sucuri si bauturi alcoolice" };

            await context.Categories.AddRangeAsync(catGroceries, catElectronics, catSnacks, catDrinks);
            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new() { Name = "Spaghete Barilla", Description = "Spaghete nr. 5, 500g", Price = 5.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Sos de rosii Mutti", Description = "Pulpa de rosii fine, 400g", Price = 7.20m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Parmezan ras", Description = "Parmigiano Reggiano, 100g", Price = 15.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Faina alba 000", Description = "Faina superioara, 1kg", Price = 4.30m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Zahar Margaritar", Description = "Zahar tos, 1kg", Price = 4.80m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Ulei de floarea soarelui", Description = "Ulei Unisol, 1L", Price = 8.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Orez cu bob lung", Description = "Orez Deroni, 1kg", Price = 9.90m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Unt 82%", Description = "Unt President, 200g", Price = 18.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catGroceries] },
                new() { Name = "Cablu HDMI", Description = "Cablu video 4K, 2m", Price = 25.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Mouse Wireless", Description = "Logitech M185", Price = 65.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Tastatura mecanica", Description = "Tastatura gaming RGB", Price = 250.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Baterii AA (4 buc)", Description = "Baterii alcaline Duracell", Price = 19.99m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Casti In-Ear", Description = "Casti cu fir si microfon", Price = 45.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Incarcator Telefon 20W", Description = "Fast charger USB-C", Price = 55.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Stick USB 64GB", Description = "Memorie USB 3.0", Price = 35.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Bec LED Inteligent", Description = "Bec smart Wi-Fi, RGB", Price = 49.90m, ImageUrl = "/img/placeholder.jpg", Categories = [catElectronics] },
                new() { Name = "Chipsuri cu sare", Description = "Lay's 140g", Price = 8.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Ciocolata cu lapte", Description = "Milka 100g", Price = 5.90m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Biscuiti cu crema", Description = "Oreo 154g", Price = 6.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Alune prajite", Description = "Nutline, 200g", Price = 12.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Jeleuri ursi", Description = "Haribo Goldbears, 100g", Price = 4.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Croissant cu ciocolata", Description = "7Days, 80g", Price = 3.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Popcorn pentru microunde", Description = "Chio cu unt", Price = 4.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catSnacks] },
                new() { Name = "Apa plata 2L", Description = "Dorna", Price = 3.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] },
                new() { Name = "Apa minerala 2L", Description = "Borsec", Price = 3.60m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] },
                new() { Name = "Suc de portocale", Description = "Santal 1L, 100%", Price = 9.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] },
                new() { Name = "Coca-Cola 2L", Description = "Bautura carbogazoasa", Price = 8.90m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] },
                new() { Name = "Bere blonda", Description = "Heineken 0.33L", Price = 5.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] },
                new() { Name = "Cafea boabe", Description = "Lavazza Oro 500g", Price = 45.00m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] },
                new() { Name = "Ceai verde", Description = "Lipton, 20 plicuri", Price = 7.50m, ImageUrl = "/img/placeholder.jpg", Categories = [catDrinks] }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            var promotions = new List<Promotion>
            {
                new() {
                    Name = "Reducere 10% la cosuri peste 150 RON",
                    Type = PromotionType.CartTotal,
                    Threshold = 150.00m,
                    Reward = PromotionReward.PercentDiscount,
                    RewardValue = 10,
                    ProductId = null,
                    CategoryId = null,
                    IsActive = true
                },
                new() {
                    Name = "Cumperi 3 Spaghete, primesti 1 gratis!",
                    Type = PromotionType.Quantity,
                    Threshold = 3,
                    Reward = PromotionReward.FreeItems,
                    RewardValue = 1,
                    ProductId = products[0].Id,
                    CategoryId = null,
                    IsActive = true
                },
                new() {
                    Name = "20% Reducere la toata categoria Snacks!",
                    Type = PromotionType.Quantity,
                    Threshold = 1,
                    Reward = PromotionReward.PercentDiscount,
                    RewardValue = 20,
                    ProductId = null,
                    CategoryId = catSnacks.Id,
                    IsActive = true
                },
                new() {
                    Name = "Black Friday: 50% la Electronice (Expirat)",
                    Type = PromotionType.Quantity,
                    Threshold = 1,
                    Reward = PromotionReward.PercentDiscount,
                    RewardValue = 50,
                    ProductId = null,
                    CategoryId = catElectronics.Id,
                    IsActive = false
                },
                new() {
                    Name = "Cumperi 10 sucuri, iei 5 gratis (Campanie oprita)",
                    Type = PromotionType.Quantity,
                    Threshold = 10,
                    Reward = PromotionReward.FreeItems,
                    RewardValue = 5,
                    ProductId = products[26].Id,
                    CategoryId = null,
                    IsActive = false
                }
            };

            await context.Promotions.AddRangeAsync(promotions);
            await context.SaveChangesAsync();
        }
    }
}
