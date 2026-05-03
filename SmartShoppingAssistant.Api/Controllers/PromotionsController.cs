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
            try
            {
                var promotions = await promotionService.GetAllAsync();
                return Ok(promotions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<ActionResult<PromotionGetDTO>> Add(PromotionCreateDTO promotionCreateDTO)
        {
            try
            {
                var promotion = await promotionService.AddAsync(promotionCreateDTO);
                return Ok(promotion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PromotionGetDTO>> Update(int id, PromotionUpdateDTO promotionUpdateDTO)
        {
            try
            {
                var promotion = await promotionService.UpdateAsync(id, promotionUpdateDTO);
                return Ok(promotion);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await promotionService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
