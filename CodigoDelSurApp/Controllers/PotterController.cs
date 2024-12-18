using CodigoDelSurApp.Application.Interfaces;
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


        [HttpGet]
        [Route("Books")]
        public async Task<ActionResult> GetAllHarryPotterBooks()
        {
            var potters = await _potterService.GetAllBooksAsync();
            return Ok(new { Books = potters });
        }

        [HttpGet]
        [Route("Character/FullName")]
        public async Task<ActionResult> GetHarryCharacterByName(string name)
        {
            var chars = await _potterService.GetPotterCharacterByNameAsync(name);
            return Ok(new { Characters = chars });
        }

        [HttpGet]
        [Route("Character/House")]
        public async Task<ActionResult> GetHarryCharactersByHouse(string house)
        {
            var chars = await _potterService.GetPotterCharactersByHouseAsync(house);
            return Ok(new { Characters = chars });
        }
    }
}
