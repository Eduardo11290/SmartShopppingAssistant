using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShoppingAssistant.BusinessLogic.DTOs.Promotion;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;

namespace SmartShoppingAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController(IPromotionService promotionService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PromotionGetDTO>>> GetAll()
        {
            var promotions = await promotionService.GetAllAsync();
            return Ok(promotions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionGetDTO>> GetById(int id)
        {
            try
            {
                var promotion = await promotionService.GetByIdAsync(id);
                return Ok(promotion);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PromotionGetDTO>> Create([FromBody] PromotionCreateDTO dto)
        {
            var promotion = await promotionService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = promotion.Id }, promotion);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PromotionGetDTO>> Update(int id, [FromBody] PromotionUpdateDTO dto)
        {
            try
            {
                var promotion = await promotionService.UpdateAsync(id, dto);
                return Ok(promotion);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await promotionService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
