using SmartShoppingAssistant.BusinessLogic.DTOs.Category;
using SmartShoppingAssistant.BusinessLogic.Mappers;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAccess.Entities;
using SmartShoppingAssistant.DataAccess.Repositories;
using SmartShoppingAssistant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<CategoryGetDTO> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            return CategoryMapper.ToGetDTO(category);
        }

        public async Task<List<CategoryGetDTO>> GetAllAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            return categories.Select(CategoryMapper.ToGetDTO).ToList();
        }

        public async Task<CategoryGetDTO> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            var category = CategoryMapper.ToEntity(categoryCreateDTO);
            var created = await categoryRepository.AddAsync(category);
            return CategoryMapper.ToGetDTO(created);
        }

        public async Task<CategoryGetDTO> UpdateAsync(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            category.Name = categoryUpdateDTO.Name;
            category.Description = categoryUpdateDTO.Description;

            var updated = await categoryRepository.UpdateAsync(category);
            return CategoryMapper.ToGetDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await categoryRepository.DeleteAsync(id);
        }
    }
}
