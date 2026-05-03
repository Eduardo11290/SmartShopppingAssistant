using SmartShoppingAssistant.BusinessLogic.DTOs.Promotion;
using SmartShoppingAssistant.BusinessLogic.Mappers;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services
{
    public class PromotionService(IRepository<Promotion> promotionRepository) : IPromotionService
    {
        public async Task<PromotionGetDTO> GetByIdAsync(int id)
        {
            var promotion = await promotionRepository.GetByIdAsync(id);
            return PromotionMapper.ToGetDTO(promotion);
        }

        public async Task<List<PromotionGetDTO>> GetAllAsync()
        {
            var promotions = await promotionRepository.GetAllAsync();
            return promotions.Select(PromotionMapper.ToGetDTO).ToList();
        }

        public async Task<PromotionGetDTO> AddAsync(PromotionCreateDTO promotionCreateDTO)
        {
            var promotion = PromotionMapper.ToEntity(promotionCreateDTO);
            var created = await promotionRepository.AddAsync(promotion);
            return PromotionMapper.ToGetDTO(created);
        }

        public async Task<PromotionGetDTO> UpdateAsync(int id, PromotionUpdateDTO promotionUpdateDTO)
        {
            var promotion = await promotionRepository.GetByIdAsync(id);

            promotion.Name = promotionUpdateDTO.Name;
            promotion.Type = promotionUpdateDTO.Type;
            promotion.Threshold = promotionUpdateDTO.Threshold;
            promotion.Reward = promotionUpdateDTO.Reward;
            promotion.RewardValue = promotionUpdateDTO.RewardValue;
            promotion.IsActive = promotionUpdateDTO.IsActive;
            promotion.ProductId = promotionUpdateDTO.ProductId;
            promotion.CategoryId = promotionUpdateDTO.CategoryId;

            var updated = await promotionRepository.UpdateAsync(promotion);
            return PromotionMapper.ToGetDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await promotionRepository.DeleteAsync(id);
        }
    }
}
