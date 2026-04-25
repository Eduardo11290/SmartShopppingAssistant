using SmartShoppingAssistant.BusinessLogic.DTOs;
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
        public async Task<List<ProductGetDTO>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return products.Select(product => new ProductGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            }).ToList();

        }
        public async Task<ProductGetDTO> AddAsync(ProductCreateDTO productCreateDTO)
        {
            var product = new Product
            {
                Name = productCreateDTO.Name,
                Description = productCreateDTO.Description,
                ImageUrl = productCreateDTO.ImageUrl,
                Price = productCreateDTO.Price
            };

            var created = await productRepository.AddAsync(product);

            return new ProductGetDTO
            {
                Id = created.Id,
                Name = created.Name,
                Description = created.Description,
                ImageUrl = created.ImageUrl,
                Price = created.Price
            };
        }
        public async Task<ProductGetDTO> UpdateAsync(int id, ProductUpdateDTO productUpdateDTO)
        {
            var product = await productRepository.GetByIdAsync(id);

            product.Name = productUpdateDTO.Name;
            product.Description = productUpdateDTO.Description;
            product.ImageUrl = productUpdateDTO.ImageUrl;
            product.Price = productUpdateDTO.Price;

            var updated = await productRepository.UpdateAsync(product);

            return new ProductGetDTO
            {
                Id = updated.Id,
                Name = updated.Name,
                Description = updated.Description,
                ImageUrl = updated.ImageUrl,
                Price = updated.Price
            };
        }
        public async Task DeleteAsync(int id)
        {
            await productRepository.DeleteAsync(id);
        }
    }
}
