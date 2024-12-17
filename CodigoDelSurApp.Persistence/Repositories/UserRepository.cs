using CodigoDelSurApp.Persistence.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace CodigoDelSurApp.Persistence.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly CodigoDelSurDbContext _dbContext;
        private const string pokemonApiUrl = "https://pokeapi.co/api/v2/\r\n/pokemon/";

        public PokemonRepository(CodigoDelSurDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            var client = new RestClient($"{pokemonApiUrl}{id}");
            var request = new RestRequest();
            var response = await client.ExecuteAsync(request);
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            return pokemon;
        }

        public Task<Pokemon> GetPokemonByName(string pokemonName)
        {
            throw new NotImplementedException();
        }
    }
}
