using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetLoggedUserAsync(string username, string password);
    }
}
