using SmartShoppingAssistant.BusinessLogic.DTOs.Promotion;
using SmartShoppingAssistant.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Mappers
{
    public static class PromotionMapper
    {
        public static PromotionGetDTO ToGetDTO(Promotion promotion)
        {
            return new PromotionGetDTO
            {
                Id = promotion.Id,
                Name = promotion.Name,
                Type = promotion.Type,
                Threshold = promotion.Threshold,
                Reward = promotion.Reward,
                RewardValue = promotion.RewardValue,
                IsActive = promotion.IsActive,
                ProductId = promotion.ProductId,
                CategoryId = promotion.CategoryId
            };
        }

        public static Promotion ToEntity(PromotionCreateDTO dto)
        {
            return new Promotion
            {
                Name = dto.Name,
                Type = dto.Type,
                Threshold = dto.Threshold,
                Reward = dto.Reward,
                RewardValue = dto.RewardValue,
                IsActive = dto.IsActive,
                ProductId = dto.ProductId,
                CategoryId = dto.CategoryId
            };
        }
    }
}
