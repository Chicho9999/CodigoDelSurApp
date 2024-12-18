using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Helpers;

namespace CodigoDelSurApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register User in the System
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "Register")]
        public ActionResult Register()
        {
            return Ok();
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
