using SmartShoppingAssistant.BusinessLogic.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartGetDTO> GetCartAsync();
        Task<CartItemGetDTO> AddItemAsync(CartItemCreateDTO cartItemCreateDTO);
        Task<CartItemGetDTO> UpdateItemAsync(int itemId, CartItemUpdateDTO cartItemUpdateDTO);
        Task DeleteItemAsync(int itemId);
        Task ClearCartAsync();
    }
}
