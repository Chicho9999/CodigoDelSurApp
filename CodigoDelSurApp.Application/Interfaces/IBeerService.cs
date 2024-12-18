using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IBeerService
    {
        Task<List<Beer>?> GetBeersNameAsync(string name);
    }
}
