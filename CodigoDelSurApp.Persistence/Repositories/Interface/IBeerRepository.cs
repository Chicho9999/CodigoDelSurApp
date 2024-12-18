using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IBeerRepository
    {
        Task<List<Beer>> GetBeersByNameAsync(string name);
    }
}
