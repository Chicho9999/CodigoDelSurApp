using CodigoDelSurApp.Application.Interfaces;
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
        [Route("Name")]
        public async Task<ActionResult> GetBeersByName(string name)
        {
            var chars = await _beerService.GetBeersNameAsync(name);
            return Ok(new { Beers = chars });
        }
    }
}
