using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IPotterService
    {
        Task<List<PotterBook>> GetAllBooksAsync();
        Task<PotterCharacter?> GetPotterCharacterByNameAsync(string name);
        Task<PotterCharacter?> GetPotterCharactersByHouseAsync(string house);
    }
}
