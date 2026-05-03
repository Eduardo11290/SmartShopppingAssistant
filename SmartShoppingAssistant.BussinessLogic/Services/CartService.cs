using SmartShoppingAssistant.BusinessLogic.DTOs.Cart;
using SmartShoppingAssistant.BusinessLogic.Mappers;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using SmartShoppingAssistant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Services
{
    public class CartService(
        IRepository<CartItem> cartItemRepository,
        ICartRepository cartRepository) : ICartService
    {
        public async Task<CartGetDTO> GetCartAsync()
        {
            var items = await cartRepository.GetAllWithProductsAsync();
            var itemDTOs = items.Select(CartMapper.ToGetDTO).ToList();

            return new CartGetDTO
            {
                Items = itemDTOs,
                Total = itemDTOs.Sum(i => i.TotalPrice)
            };
        }

        public async Task<CartItemGetDTO> AddItemAsync(CartItemCreateDTO cartItemCreateDTO)
        {
            var cartItem = new CartItem
            {
                ProductId = cartItemCreateDTO.ProductId,
                Quantity = cartItemCreateDTO.Quantity
            };

            var created = await cartItemRepository.AddAsync(cartItem);
            var withProduct = await cartRepository.GetItemWithProductAsync(created.Id);
            return CartMapper.ToGetDTO(withProduct);
        }

        public async Task<CartItemGetDTO> UpdateItemAsync(int itemId, CartItemUpdateDTO cartItemUpdateDTO)
        {
            var cartItem = await cartItemRepository.GetByIdAsync(itemId);
            cartItem.Quantity = cartItemUpdateDTO.Quantity;

            await cartItemRepository.UpdateAsync(cartItem);
            var withProduct = await cartRepository.GetItemWithProductAsync(itemId);
            return CartMapper.ToGetDTO(withProduct);
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await cartItemRepository.DeleteAsync(itemId);
        }

        public async Task ClearCartAsync()
        {
            await cartRepository.ClearCartAsync();
        }
    }
}
