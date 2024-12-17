using CodigoDelSurApp.Persistence.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace CodigoDelSurApp.Persistence.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly CodigoDelSurDbContext _dbContext;
        private const string pokemonApiUrl = "https://pokeapi.co/api/v2/";

        public PokemonRepository(CodigoDelSurDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int number)
        {
            var client = new RestClient($"{pokemonApiUrl}/pokemon/{number}");
            var response = await client.ExecuteAsync(new RestRequest());
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            return pokemon;
        }

        public async Task<Pokemon> GetPokemonByNameAsync(string pokemonName)
        {
            var client = new RestClient($"{pokemonApiUrl}/pokemon/{pokemonName}");
            var response = await client.ExecuteAsync(new RestRequest());
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            return pokemon;
        }

        public async Task<List<Pokemon>> GetAllPokemonAsync()
        {
            var client = new RestClient($"{pokemonApiUrl}/pokemon?limit=100000&offset=0");
            var response = await client.ExecuteAsync(new RestRequest());
            var pokemon = JsonConvert.DeserializeObject<List<Pokemon>>(response.Content);

            return pokemon;
        }

        public async Task<List<Pokemon>> GetAllPokemonByTypeAsync(string type)
        {
            var numberType = PokemonHelper.GetPokemonTypeByHisName(type);
            var client = new RestClient($"{pokemonApiUrl}/type/{numberType}");
            var response = await client.ExecuteAsync(new RestRequest());
            var pokemon = JsonConvert.DeserializeObject<List<Pokemon>>(response.Content);

            return pokemon;
        }
    }
}
