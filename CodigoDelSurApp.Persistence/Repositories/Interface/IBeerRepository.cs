using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IBeerRepository
    {
        Task<IList<Beer>> GetBeersByNameAsync(string name);
    }
}
