using SmartShoppingAssistant.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllWithCategoriesAsync();
        Task<Product> GetByIdWithCategoriesAsync(int id);
    }
}
