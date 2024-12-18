using CodigoDelSurApp.Persistence.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
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
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, password);

            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == hashedPassword);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
