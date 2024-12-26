using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodigoDelSurApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CodigoDelSurDbContext _dbContext;

        public UserRepository(CodigoDelSurDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByUserNameAndPasswordAsync(string username, string password)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user.VerifyPassword(password) ? user : null;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var existUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (existUser != null) {
                return user;
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
