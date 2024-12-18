using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IPotterService
    {
        Task<List<PotterBook>> GetAllBooksAsync();
        Task<PotterCharacter?> GetPotterCharacterByNameAsync(string name);
        Task<List<PotterCharacter>?> GetPotterCharactersByHouseAsync(string house);
    }
}
