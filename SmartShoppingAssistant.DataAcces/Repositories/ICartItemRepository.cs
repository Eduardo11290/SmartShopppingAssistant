using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        Task<List<CartItem>> GetAllWithProductAsync();
        Task<CartItem?> GetByProductIdAsync(int productId);
        Task<CartItem> GetByIdWithProductAsync(int id);
        Task ClearAsync();
    }
}
