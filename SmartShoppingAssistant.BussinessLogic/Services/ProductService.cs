using SmartShoppingAssistant.BusinessLogic.DTOs.Product;
using SmartShoppingAssistant.BusinessLogic.Mappers;
using SmartShoppingAssistant.BussinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using SmartShoppingAssistant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BussinessLogic.Services
{
    public class ProductService(
    IRepository<Product> productRepository,
    IProductRepository productRepositoryWithCategories) : IProductService
    {
        public async Task<ProductGetDTO> GetByIdAsync(int id)
        {
            var product = await productRepositoryWithCategories.GetByIdWithCategoriesAsync(id);
            return ProductMapper.ToGetDTO(product);
        }

        public async Task<List<ProductGetDTO>> GetAllAsync(ProductFilterDTO filter)
        {
            var products = await productRepositoryWithCategories.GetAllWithCategoriesAsync();

            if (filter.CategoryId.HasValue)
                products = products
                    .Where(p => p.Categories.Any(c => c.Id == filter.CategoryId.Value))
                    .ToList();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                products = products
                    .Where(p => p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            if (filter.MinPrice.HasValue)
                products = products
                    .Where(p => p.Price >= filter.MinPrice.Value)
                    .ToList();

            if (filter.MaxPrice.HasValue)
                products = products
                    .Where(p => p.Price <= filter.MaxPrice.Value)
                    .ToList();

            return products.Select(ProductMapper.ToGetDTO).ToList();
        }

        public async Task<ProductGetDTO> AddAsync(ProductCreateDTO productCreateDTO)
        {
            var product = ProductMapper.ToEntity(productCreateDTO);
            var created = await productRepository.AddAsync(product);
            var withCategories = await productRepositoryWithCategories.GetByIdWithCategoriesAsync(created.Id);
            return ProductMapper.ToGetDTO(withCategories);
        }

        public async Task<ProductGetDTO> UpdateAsync(int id, ProductUpdateDTO productUpdateDTO)
        {
            var product = await productRepository.GetByIdAsync(id);

            product.Name = productUpdateDTO.Name;
            product.Description = productUpdateDTO.Description;
            product.ImageUrl = productUpdateDTO.ImageUrl;
            product.Price = productUpdateDTO.Price;

            await productRepository.UpdateAsync(product);
            var withCategories = await productRepositoryWithCategories.GetByIdWithCategoriesAsync(id);
            return ProductMapper.ToGetDTO(withCategories);
        }

        public async Task DeleteAsync(int id)
        {
            await productRepository.DeleteAsync(id);
        }
    }
}
