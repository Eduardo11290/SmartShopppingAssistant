using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartShoppingAssistant.BussinessLogic.DTOs;
using SmartShoppingAssistant.BussinessLogic.Services.Interfaces;

namespace SmartShoppingAssistant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService): ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetDTO>> GetByIdAsync(int id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
