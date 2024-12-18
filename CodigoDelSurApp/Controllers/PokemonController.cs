using CodigoDelSurApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
             _pokemonService = pokemonService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllPokemon()
        {
            var pokemons = await _pokemonService.GetAllPokemon();
            return Ok();
        }
    }
}
