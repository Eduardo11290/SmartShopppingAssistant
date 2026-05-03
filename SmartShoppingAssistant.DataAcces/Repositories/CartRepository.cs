using Microsoft.EntityFrameworkCore;
using SmartShoppingAssistant.DataAcces;
using SmartShoppingAssistant.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public class CartRepository(SmartShoppingAssistantDbContext context) : ICartRepository
    {
        public async Task<List<CartItem>> GetAllWithProductsAsync()
        {
            return await context.CartItems
                .Include(c => c.Product)
                .ToListAsync();
        }

        public async Task<CartItem> GetItemWithProductAsync(int itemId)
        {
            var item = await context.CartItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == itemId);

            if (item == null)
                throw new Exception($"CartItem with id {itemId} not found.");

            return item;
        }

        public async Task ClearCartAsync()
        {
            var items = await context.CartItems.ToListAsync();
            context.CartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }
    }
}
