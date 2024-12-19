using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IBeerService
    {
        Task<IList<Beer>> GetBeersByNameAsync(string name);
    }
}
