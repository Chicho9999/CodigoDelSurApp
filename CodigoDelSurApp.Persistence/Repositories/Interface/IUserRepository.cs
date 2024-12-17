using CodigoDelSurApp.Persistence.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password);

        Task<User> CreateUserAsync(User user);
    }
}
