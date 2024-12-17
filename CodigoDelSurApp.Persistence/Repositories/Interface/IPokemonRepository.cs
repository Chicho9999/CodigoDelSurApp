using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IPokemonRepository
    {
        Task<Pokemon> GetPokemonByName(string pokemonName);

        Task<Pokemon> GetPokemonByIdAsync(int id);
    }
}
