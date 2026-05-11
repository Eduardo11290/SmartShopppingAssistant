using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAccess.Repositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        Task<List<Promotion>> GetForProductAsync(int productId);
    }
}
