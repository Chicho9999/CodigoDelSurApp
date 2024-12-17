using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var loggedUSer = await _userService.GetLoggedUserAsync(model.Username, model.Password);
            if (loggedUSer != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, model.Username),
                };

                var token = TokenGeneratorHelper.GenerateJwtToken(claims);

                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
