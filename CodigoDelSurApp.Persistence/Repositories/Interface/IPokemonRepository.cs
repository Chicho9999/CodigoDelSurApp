using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IPokemonRepository
    {
        Task<Pokemon> GetPokemonByNameAsync(string pokemonName);

        Task<Pokemon> GetPokemonByIdAsync(int id);

        Task<List<Pokemon>> GetAllPokemonAsync();

        Task<List<Pokemon>> GetAllPokemonByTypeAsync(string type);
    }
}
