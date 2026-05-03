using SmartShoppingAssistant.BusinessLogic.DTOs.Category;
using SmartShoppingAssistant.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryGetDTO ToGetDTO(Category category)
        {
            return new CategoryGetDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public static Category ToEntity(CategoryCreateDTO dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
