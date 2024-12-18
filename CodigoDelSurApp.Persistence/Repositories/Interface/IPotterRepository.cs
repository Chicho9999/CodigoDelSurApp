using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IPotterRepository
    {
        Task<List<PotterBook>> GetAllPotterBooksAsync();
        Task<PotterCharacter?> GetPotterCharactersByNameAsync(string potterName);
        Task<List<PotterCharacter>?> GetPotterCharactersByHouseAsync(string house);
    }
}
