using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetLoggedUserAsync(string username, string password);
    }
}
