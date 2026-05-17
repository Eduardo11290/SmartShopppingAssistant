using Microsoft.EntityFrameworkCore;
using SmartShoppingAssistant.DataAccess;
using SmartShoppingAssistant.DataAccess.Entities;
using SmartShoppingAssistant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public class PromotionRepository(SmartShoppingAssistantDbContext context)
        : BaseRepository<Promotion>(context), IPromotionRepository
    {
        public async Task<List<Promotion>> GetForProductAsync(int productId)
        {
            var categoryIds = await Context.Products
                .Where(p => p.Id == productId)
                .SelectMany(p => p.Categories.Select(c => c.Id))
                .ToListAsync();

            return await GetAllAsQueryable()
                .Where(p => p.IsActive &&
                            (p.ProductId == productId ||
                             (p.CategoryId.HasValue && categoryIds.Contains(p.CategoryId.Value))))
                .ToListAsync();
        }
    }
}
