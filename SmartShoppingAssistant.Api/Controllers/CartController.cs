using Microsoft.AspNetCore.Mvc;
using SmartShoppingAssistant.BusinessLogic.DTOs.Cart;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;

namespace SmartShoppingAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CartGetDTO>> GetCart()
        {
            try
            {
                var cart = await cartService.GetCartAsync();
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("items")]
        public async Task<ActionResult<CartItemGetDTO>> AddItem(CartItemCreateDTO cartItemCreateDTO)
        {
            try
            {
                var item = await cartService.AddItemAsync(cartItemCreateDTO);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("items/{itemId}")]
        public async Task<ActionResult<CartItemGetDTO>> UpdateItem(int itemId, CartItemUpdateDTO cartItemUpdateDTO)
        {
            try
            {
                var item = await cartService.UpdateItemAsync(itemId, cartItemUpdateDTO);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("items/{itemId}")]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            try
            {
                await cartService.DeleteItemAsync(itemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> ClearCart()
        {
            try
            {
                await cartService.ClearCartAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
