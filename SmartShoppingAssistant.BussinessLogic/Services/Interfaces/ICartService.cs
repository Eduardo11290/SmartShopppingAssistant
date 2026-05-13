using SmartShoppingAssistant.BusinessLogic.DTOs.Cart;
using SmartShoppingAssistant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartGetDTO> GetCartAsync();
        Task<CartItemGetDTO> AddItemAsync(AddCartItemDTO dto);
        Task<CartItemGetDTO> UpdateItemAsync(int itemId, CartItemUpdateDTO dto);
        Task RemoveItemAsync(int itemId);
        Task ClearCartAsync();

        Task<AnalysisResponse> AnalyzeCartAsync();
    }
}
