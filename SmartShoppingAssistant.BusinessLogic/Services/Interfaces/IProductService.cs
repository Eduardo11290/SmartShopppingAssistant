using SmartShoppingAssistant.BusinessLogic.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductGetDTO> GetByIdAsync(int id);
        Task<List<ProductGetDTO>> GetAllAsync(int? categoryId, string? name, decimal? minPrice, decimal? maxPrice);
        Task<ProductGetDTO> CreateAsync(ProductCreateDTO productCreateDTO);
        Task<ProductGetDTO> UpdateAsync(int id, ProductUpdateDTO productUpdateDTO);
        Task DeleteAsync(int id);
        Task<List<ProductGetDTO>> GetForProductAsync(int productId);
    }
}
