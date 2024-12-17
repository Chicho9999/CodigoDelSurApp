using CodigoDelSurApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Validate user credentials (replace with your actual logic)
            if (ValidateUser(model.Username, model.Password))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, model.Username),
                    // Add other claims as needed (e.g., roles, permissions)
                };

                var token = GenerateJwtToken(claims);

                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
