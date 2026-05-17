using SmartShoppingAssistant.BusinessLogic.DTOs.Promotion;
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
    public class PromotionService(IPromotionRepository promotionRepository) : IPromotionService
    {
        public async Task<List<PromotionGetDTO>> GetAllAsync()
        {
            var promotions = await promotionRepository.GetAllAsync();
            return promotions.Select(PromotionMapper.ToGetDTO).ToList();
        }

        public async Task<PromotionGetDTO> GetByIdAsync(int id)
        {
            var promotion = await promotionRepository.GetByIdAsync(id);
            return PromotionMapper.ToGetDTO(promotion);
        }

        public async Task<PromotionGetDTO> AddAsync(PromotionCreateDTO dto)
        {
            var promotion = PromotionMapper.ToEntity(dto);
            var created = await promotionRepository.AddAsync(promotion);
            return PromotionMapper.ToGetDTO(created);
        }

        public async Task<PromotionGetDTO> UpdateAsync(int id, PromotionUpdateDTO dto)
        {
            var promotion = await promotionRepository.GetByIdAsync(id);
            promotion.Name = dto.Name;
            promotion.Type = dto.Type;
            promotion.Threshold = dto.Threshold;
            promotion.Reward = dto.Reward;
            promotion.RewardValue = dto.RewardValue;
            promotion.IsActive = dto.IsActive;
            promotion.ProductId = dto.ProductId;
            promotion.CategoryId = dto.CategoryId;
            var updated = await promotionRepository.UpdateAsync(promotion);
            return PromotionMapper.ToGetDTO(updated);
        }

        public Task DeleteAsync(int id) => promotionRepository.DeleteAsync(id);

        public async Task<List<PromotionGetDTO>> GetForProductAsync(int productId)
        {
            var promotions = await promotionRepository.GetForProductAsync(productId);
            return promotions.Select(PromotionMapper.ToGetDTO).ToList();
        }
    }
}
