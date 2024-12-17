using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemon();
        Task<List<Pokemon>> GetAllPokemonByType(string type);
        Task<Pokemon> GetPokemonByNumber(int number);
        Task<Pokemon> GetPokemonByName (string name);
    }
}
