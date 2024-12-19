using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IPotterRepository
    {
        Task<IList<PotterBook>> GetAllPotterBooksAsync();
        Task<PotterCharacter?> GetPotterCharactersByNameAsync(string potterName);
        Task<IList<PotterCharacter>?> GetPotterCharactersByHouseAsync(string house);
    }
}
