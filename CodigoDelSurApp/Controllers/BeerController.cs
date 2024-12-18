using Microsoft.AspNetCore.Mvc;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
             _beerService = beerService;
        }


        [HttpGet]
        [Route("Character/FullName")]
        public async Task<ActionResult> GetHarryCharacterByName(string name)
        {
            var chars = await _beerService.GetBeerCharacterByNameAsync(name);
            return Ok(new { Characters = chars });
        }
    }
}
