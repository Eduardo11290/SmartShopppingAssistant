using SmartShoppingAssistant.BussinessLogic.DTOs;
using SmartShoppingAssistant.BussinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BussinessLogic.Services
{
    public class ProductService(IRepository<Product> productRepository) : IProductService
    {
        public async Task<ProductGetDTO> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return new ProductGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

        }
    }
}
