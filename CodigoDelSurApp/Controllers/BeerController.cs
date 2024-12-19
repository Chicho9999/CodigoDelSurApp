using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
             _beerService = beerService;
        }

        /// <summary>
        /// Get All Beers that Matches with the respective name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Beers</returns>
        /// <respose code="200">The Beers was retrieved </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpGet]
        [Route("Name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Beer>>> GetBeersByNameAsync(string name)
        {
            try
            {
                var beers = await _beerService.GetBeersByNameAsync(name);
                return Ok(beers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
