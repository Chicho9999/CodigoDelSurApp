using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IPotterRepository
    {
        Task<List<PotterBook>> GetAllPotterBooksAsync();
        Task<PotterCharacter?> GetPotterCharactersByNameAsync(string potterName);
        Task<PotterCharacter?> GetPotterCharactersByHouseAsync(string house);
    }
}
