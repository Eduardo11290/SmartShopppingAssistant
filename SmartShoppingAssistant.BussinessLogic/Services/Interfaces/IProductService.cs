using SmartShoppingAssistant.BusinessLogic.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BussinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductGetDTO> GetByIdAsync(int id);
        Task<List<ProductGetDTO>> GetAllAsync(ProductFilterDTO filter);
        public Task<ProductGetDTO> AddAsync(ProductCreateDTO productCreateDTO);
        public Task<ProductGetDTO> UpdateAsync(int id, ProductUpdateDTO productUpdateDTO);
        public Task DeleteAsync(int id);

    }
}
