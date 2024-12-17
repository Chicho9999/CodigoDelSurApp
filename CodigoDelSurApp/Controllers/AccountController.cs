using Microsoft.AspNetCore.Mvc;

namespace CodigoDelSurApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Register")]
        public ActionResult Register()
        {
            return Ok();
        }
    }
}
