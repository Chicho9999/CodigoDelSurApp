using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Helpers;
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
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = System.Security.Cryptography.SHA256.HashData(data);
            String hashedPassword = System.Text.Encoding.ASCII.GetString(data);

            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == hashedPassword);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var existUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (existUser != null) {
                return user;
            }

            byte[] data = System.Text.Encoding.ASCII.GetBytes(user.Password);
            data = System.Security.Cryptography.SHA256.HashData(data);
            user.Password = System.Text.Encoding.ASCII.GetString(data);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
