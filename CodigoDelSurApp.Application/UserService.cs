using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Persistence.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;

namespace CodigoDelSurApp.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateUserAsync(User user)
        {
            return _userRepository.CreateUserAsync(user);
        }

        public Task<User?> GetLoggedUserAsync(string username, string password)
        {
            return _userRepository.GetUserByUserNameAndPasswordAsync(username, password);
        }
    }
}
