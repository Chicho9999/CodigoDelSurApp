using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PotterController : ControllerBase
    {
        private readonly IPotterService _potterService;

        public PotterController(IPotterService potterService)
        {
             _potterService = potterService;
        }

        /// <summary>
        /// Get All Books From the Harry Potter Franchise 
        /// </summary>
        /// <returns>All HP Books</returns>
        /// <respose code="200">The Books was retrieved </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpGet]
        [Route("Books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PotterBook>>> GetAllHarryPotterBooks()
        {
            try
            {
                var potters = await _potterService.GetAllBooksAsync();
                return Ok(potters);
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Obtain the characters from Harry Potter by name 
        /// </summary>
        /// <param name="nameFilter"></param>
        /// <returns>All Characters that their FullName contains the value passed by parameter</returns>
        /// <respose code="200">The HP Characters was retrieved </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpGet]
        [Route("Character/FullName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PotterCharacter>>> GetHarryCharacterByName(string nameFilter)
        {
            try
            {
                var chars = await _potterService.GetPotterCharacterByNameAsync(nameFilter);
                return Ok(chars);

            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Obtain the characters from Harry Potter by their House 
        /// </summary>
        /// <param name="houseFilter"></param>
        /// <returns>All Characters that their House contains the value passed by parameter</returns>
        /// <respose code="200">The HP Characters was retrieved </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpGet]
        [Route("Character/House")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PotterCharacter>>> GetHarryCharactersByHouse(string houseFilter)
        {
            try
            {
                var chars = await _potterService.GetPotterCharactersByHouseAsync(houseFilter);
                return Ok(chars);
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
