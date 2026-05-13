using Microsoft.AspNetCore.Mvc;
using OpenAI.Realtime;
using SmartShoppingAssistant.BusinessLogic.Agents;
using SmartShoppingAssistant.BusinessLogic.DTOs.Cart;
using SmartShoppingAssistant.BusinessLogic.Models;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using System.Text.Json;

namespace SmartShoppingAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController(
        ICartService cartService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CartGetDTO>> GetCart()
        {
            var cart = await cartService.GetCartAsync();
            return Ok(cart);
        }
        
        [HttpPost("items")]
        public async Task<ActionResult<CartItemGetDTO>> AddItem([FromBody] AddCartItemDTO dto)
        {
            try
            {
                var item = await cartService.AddItemAsync(dto);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("items/{itemId}")]
        public async Task<ActionResult<CartItemGetDTO>> UpdateItem(int itemId, [FromBody] CartItemUpdateDTO dto)
        {
            try
            {
                var item = await cartService.UpdateItemAsync(itemId, dto);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("items/{itemId}")]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            try
            {
                await cartService.RemoveItemAsync(itemId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> ClearCart()
        {
            await cartService.ClearCartAsync();
            return NoContent();
        }
        [HttpPost(template: "analyze")]
        public async Task<IActionResult> AnalyzeCart()
        {
            var analysisResposne = await cartService.AnalyzeCartAsync();
            return Ok(analysisResposne);

        }
    }
}