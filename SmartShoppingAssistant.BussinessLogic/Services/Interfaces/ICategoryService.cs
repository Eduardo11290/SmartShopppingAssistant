using SmartShoppingAssistant.BusinessLogic.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryGetDTO> GetByIdAsync(int id);
        Task<List<CategoryGetDTO>> GetAllAsync();
        Task<CategoryGetDTO> AddAsync(CategoryCreateDTO categoryCreateDTO);
        Task<CategoryGetDTO> UpdateAsync(int id, CategoryUpdateDTO categoryUpdateDTO);
        Task DeleteAsync(int id);
    }
}
