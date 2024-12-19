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
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST api/Register 
        ///     {
        ///         "firstName": "Example",
        ///         "lastName": "Example",
        ///         "email":"Example@gmail.com",
        ///         "userName":"Example",
        ///         "password":"Example"
        ///     }
        /// </remarks>
        /// <returns>If the operation was succesful</returns>
        /// <respose code="200">The User was registered succesfully</respose>
        /// <respose code="500">Error Ocurred while creating new user </respose>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            // Se puede usar Mapping
            var user = new User() { 
                FirstName = userDto.FirstName, 
                LastName = userDto.LastName, 
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
            };

            try
            {
                var userCreated = await _userService.CreateUserAsync(user);

                if (userCreated.Id != Guid.Empty)
                {
                    return Ok(new { isSuccess = true });
                }

                return Ok(new { isSuccess = false, Description = "Usuario ya existe" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="model"></param>
        /// <returns>If the User was logged or not</returns>
        /// <respose code="200">The User was logged succesfully</respose>
        /// <respose code="401">The User can't logged</respose>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

            return Unauthorized( new { Response = "Check your credentials" });
        }
    }
}
