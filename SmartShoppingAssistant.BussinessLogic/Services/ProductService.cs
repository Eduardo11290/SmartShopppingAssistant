using SmartShoppingAssistant.BusinessLogic.DTOs.Product;
using SmartShoppingAssistant.BusinessLogic.Mappers;
using SmartShoppingAssistant.BussinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAccess.Entities;
using SmartShoppingAssistant.DataAccess.Repositories;
using SmartShoppingAssistant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BussinessLogic.Services
{
    public class ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository) : IProductService
    {
        public async Task<List<ProductGetDTO>> GetAllAsync(int? categoryId, string? name, decimal? minPrice, decimal? maxPrice)
        {
            var products = await productRepository.GetAllAsync(categoryId, name, minPrice, maxPrice);
            return products.Select(ProductMapper.ToGetDTO).ToList();
        }

        public async Task<ProductGetDTO> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdWithCategoriesAsync(id);
            return ProductMapper.ToGetDTO(product);
        }

        public async Task<ProductGetDTO> CreateAsync(ProductCreateDTO dto)
        {
            var categories = await categoryRepository.GetByIdsAsync(dto.CategoryIds);
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Categories = categories
            };
            var created = await productRepository.AddAsync(product);
            return ProductMapper.ToGetDTO(created);
        }

        public async Task<ProductGetDTO> UpdateAsync(int id, ProductUpdateDTO dto)
        {
            var product = await productRepository.GetByIdWithCategoriesAsync(id);
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.ImageUrl = dto.ImageUrl;
            product.Price = dto.Price;
            product.Categories = await categoryRepository.GetByIdsAsync(dto.CategoryIds);
            var updated = await productRepository.UpdateAsync(product);
            return ProductMapper.ToGetDTO(updated);
        }

        public Task DeleteAsync(int id) => productRepository.DeleteAsync(id);

        public async Task<List<ProductGetDTO>> GetForProductAsync(int productId)
        {
            var products = await productRepository.GetByCategoryAsync(productId);
            return products.Select(ProductMapper.ToGetDTO).ToList();
        }
    }
}
