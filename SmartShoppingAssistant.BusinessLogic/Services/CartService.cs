using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;
using SmartShoppingAssistant.BusinessLogic.Agents;
using SmartShoppingAssistant.BusinessLogic.DTOs.Cart;
using SmartShoppingAssistant.BusinessLogic.Mappers;
using SmartShoppingAssistant.BusinessLogic.Models;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAccess.Entities;
using SmartShoppingAssistant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SmartShoppingAssistant.BusinessLogic.Services
{
    public class CartService(
        ICartItemRepository cartItemRepository,
        IProductRepository productRepository,
        IPromotionCheckerAgent promotionCheckerAgent,
        ISuggestionComposerAgent suggestionComposerAgent,
        ICategoryRepository categoryRepository) : ICartService
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

        public async Task<AnalysisResponse> AnalyzeCartAsync()
        {
            var cart = await cartItemRepository.GetAllWithProductAsync();
            var categories = await categoryRepository.GetAllAsync();

            var cartJson = JsonSerializer.Serialize(cart.Select(c => new
            {
                c.ProductId,
                c.Product.Name,
                c.Product.Price,
                c.Quantity,
                LineTotal = c.Product.Price * c.Quantity,
                Categories = c.Product.Categories.Select(cat => new { CategoryId = cat.Id, CategoryName = cat.Name }).ToList()

            }));

             var categoryJson = JsonSerializer.Serialize(categories.Select(c => new { 
                 CategoryId = c.Id, 
                 CategoryName = c.Name 
             }));

             var promotionAgent = promotionCheckerAgent.Build(cartJson);
             var suggestionAgent = suggestionComposerAgent.Build(cartJson, categoryJson);

            var workflow = new WorkflowBuilder(promotionAgent).AddEdge(promotionAgent, suggestionAgent)
                .WithOutputFrom(suggestionAgent)
                .Build();

            var chatMessage = new List<ChatMessage>{
                new(ChatRole.User, "Analyze the cart and suggest improvements")
            };

            await using var result = await InProcessExecution.RunStreamingAsync(workflow, chatMessage);

            await result.TrySendMessageAsync(new TurnToken(emitEvents: true));

            var jsonBuilder = new System.Text.StringBuilder();

            await foreach (var message in result.WatchStreamAsync())
            {
                if (message is AgentResponseUpdateEvent update && update.ExecutorId.StartsWith("SuggestionComposer"))
                {
                    jsonBuilder.Append(update.Update.Text);
                }
                else if(message is WorkflowErrorEvent errorEvent) 
                {
                    throw new InvalidOperationException(errorEvent.Exception?.Message);

                }
            }
            var json = jsonBuilder.ToString();
            return JsonSerializer.Deserialize<AnalysisResponse>(json) ?? throw new InvalidOperationException("Failed to deserialize analysis response.");


        }

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
