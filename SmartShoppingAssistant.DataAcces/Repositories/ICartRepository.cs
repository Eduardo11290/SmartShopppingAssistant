using SmartShoppingAssistant.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetAllWithProductsAsync();
        Task<CartItem> GetItemWithProductAsync(int itemId);
        Task ClearCartAsync();
    }
}
