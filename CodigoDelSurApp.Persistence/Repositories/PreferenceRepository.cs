using CodigoDelSurApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly CodigoDelSurDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;

        public PreferenceRepository(CodigoDelSurDbContext dbContext, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        public async Task<IList<UserPreference>> GetAllPreferenceByUserAsync()
        {
            var userId = _httpContext.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

            return await _dbContext.UserPreferences.Where(sp => sp.UserId == Guid.Parse(userId)).ToListAsync();
        }

        public async Task<bool> CreatePreferenceAsync(UserPreference preference)
        {
            var userId = Guid.Parse(_httpContext.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);

            var preferenceExist = await _dbContext.UserPreferences.FirstOrDefaultAsync(sp => sp.UserId == userId && sp.PreferenceKey == preference.PreferenceKey);
            if(preferenceExist != null) {
                return false;
            }
            preference.UserId = userId;

            _dbContext.UserPreferences.Add(preference);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdatePreferenceAsync(UserPreference preference)
        {
            var userId = _httpContext.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            var preferenceExist = await _dbContext.UserPreferences.FirstOrDefaultAsync(sp => sp.UserId == Guid.Parse(userId) && sp.PreferenceKey == preference.PreferenceKey);
            if (preferenceExist != null)
            {
                preferenceExist.PreferenceValue = preference.PreferenceValue;
                _dbContext.UserPreferences.Update(preferenceExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePreferenceAsync(string key)
        {
            var userId = _httpContext.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            var preferenceExist = await _dbContext.UserPreferences.FirstOrDefaultAsync(sp => sp.UserId == Guid.Parse(userId) && sp.PreferenceKey == key);
            if (preferenceExist != null)
            {
                _dbContext.UserPreferences.Remove(preferenceExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
