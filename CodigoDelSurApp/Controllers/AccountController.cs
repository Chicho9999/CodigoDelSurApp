using CodigoDelSurApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CodigoDelSurApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Helpers;
using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenGeneratorHelper _tokenGeneratorHelper;

        public AccountController(IUserService userService, TokenGeneratorHelper tokenGeneratorHelper)
        {
            _userService = userService;
            _tokenGeneratorHelper = tokenGeneratorHelper;
        }

        /// <summary>
        /// Register User in the System
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "Register")]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            var user = new User() { 
                FirstName = userDto.FirstName, 
                LastName = userDto.LastName, 
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
            };

            var userCreated = await _userService.CreateUserAsync(user);

            if (userCreated.Id != Guid.Empty)
            {
                return Ok(new { isSuccess = true });
            }

            return Ok(new { isSuccess = false });

        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var loggedUSer = await _userService.GetLoggedUserAsync(model.Username, model.Password);
            if (loggedUSer != null)
            {
                return Ok(new
                {
                    isSuccess = true,
                    token = _tokenGeneratorHelper.JWTGenerator(loggedUSer)
                });
            }

            return Unauthorized();
        }
    }
}
