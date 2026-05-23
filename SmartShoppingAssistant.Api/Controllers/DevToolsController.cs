using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShoppingAssistant.BusinessLogic.Tools;

namespace SmartShoppingAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DevToolsController(DatabaseSeeder seeder) : ControllerBase
    {
        [HttpPost("reset-db")]
        public async Task<IActionResult> ResetDatabase()
        {
            try
            {
                await seeder.ResetAndSeedAsync();
                return Ok(new { message = "Baza de date a fost stearsa si repopulata cu succes!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A aparut o eroare: {ex.Message}");
            }
        }
    }
}
