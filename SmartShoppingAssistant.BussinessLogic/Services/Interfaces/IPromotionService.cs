using SmartShoppingAssistant.BusinessLogic.DTOs.Promotion;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<PromotionGetDTO> GetByIdAsync(int id);
        Task<List<PromotionGetDTO>> GetAllAsync();
        Task<PromotionGetDTO> AddAsync(PromotionCreateDTO promotionCreateDTO);
        Task<PromotionGetDTO> UpdateAsync(int id, PromotionUpdateDTO promotionUpdateDTO);
        Task DeleteAsync(int id);
    }
}
