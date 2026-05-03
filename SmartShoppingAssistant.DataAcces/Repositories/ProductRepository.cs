using Microsoft.EntityFrameworkCore;
using SmartShoppingAssistant.DataAcces;
using SmartShoppingAssistant.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public class ProductRepository(SmartShoppingAssistantDbContext context) : IProductRepository
    {
        public async Task<List<Product>> GetAllWithCategoriesAsync()
        {
            return await context.Products
                .Include(p => p.Categories)
                .ToListAsync();
        }

        public async Task<Product> GetByIdWithCategoriesAsync(int id)
        {
            var product = await context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new Exception($"Entity with id {id} not found.");

            return product;
        }
    }
}
