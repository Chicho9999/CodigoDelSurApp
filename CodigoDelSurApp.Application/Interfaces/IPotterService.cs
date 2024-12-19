using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IPotterService
    {
        Task<IList<PotterBook>> GetAllBooksAsync();
        Task<PotterCharacter?> GetPotterCharacterByNameAsync(string name);
        Task<IList<PotterCharacter>?> GetPotterCharactersByHouseAsync(string house);
    }
}
