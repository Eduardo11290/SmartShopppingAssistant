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
        ICartItemRepository cartItemRepository,
        IProductRepository productRepository) : ICartService
    {
        public async Task<CartGetDTO> GetCartAsync()
        {
            var items = await cartItemRepository.GetAllWithProductAsync();
            return new CartGetDTO { Items = items.Select(MapToDTO).ToList() };
        }

        public async Task<CartItemGetDTO> AddItemAsync(AddCartItemDTO dto)
        {
            await productRepository.GetByIdAsync(dto.ProductId);

            var existing = await cartItemRepository.GetByProductIdAsync(dto.ProductId);
            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
                await cartItemRepository.UpdateAsync(existing);
                return MapToDTO(existing);
            }

            var item = new CartItem { ProductId = dto.ProductId, Quantity = dto.Quantity };
            await cartItemRepository.AddAsync(item);
            var added = await cartItemRepository.GetByIdWithProductAsync(item.Id);
            return MapToDTO(added);
        }

        public async Task<CartItemGetDTO> UpdateItemAsync(int itemId, CartItemUpdateDTO dto)
        {
            var item = await cartItemRepository.GetByIdWithProductAsync(itemId);
            item.Quantity = dto.Quantity;
            await cartItemRepository.UpdateAsync(item);
            return MapToDTO(item);
        }

        public Task RemoveItemAsync(int itemId) => cartItemRepository.DeleteAsync(itemId);

        public Task ClearCartAsync() => cartItemRepository.ClearAsync();

        private static CartItemGetDTO MapToDTO(CartItem ci) => new()
        {
            Id = ci.Id,
            ProductId = ci.ProductId,
            ProductName = ci.Product.Name,
            UnitPrice = ci.Product.Price,
            Quantity = ci.Quantity
        };
    }
}
