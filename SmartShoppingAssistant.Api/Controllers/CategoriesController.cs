using Microsoft.AspNetCore.Mvc;
using SmartShoppingAssistant.BusinessLogic.DTOs.Category;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;

namespace SmartShoppingAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CategoryGetDTO>>> GetAll()
        {
            try
            {
                var categories = await categoryService.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetDTO>> GetById(int id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryGetDTO>> Add(CategoryCreateDTO categoryCreateDTO)
        {
            try
            {
                var category = await categoryService.AddAsync(categoryCreateDTO);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryGetDTO>> Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            try
            {
                var category = await categoryService.UpdateAsync(id, categoryUpdateDTO);
                return Ok(category);
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
                await categoryService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
