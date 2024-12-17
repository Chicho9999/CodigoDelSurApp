using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Persistence.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;

namespace CodigoDelSurApp.Application
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _userRepository;

        public PokemonService(IPokemonRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<Pokemon>> GetAllPokemon()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pokemon>> GetAllPokemonByType(string type)
        {
            throw new NotImplementedException();
        }

        public Task<Pokemon> GetPokemonByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Pokemon> GetPokemonByNumber(int number)
        {
            throw new NotImplementedException();
        }
    }
}
