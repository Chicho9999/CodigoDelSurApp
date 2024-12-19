using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Application.Interfaces
{
    public interface IPreferenceService
    {
        Task<bool> CreatePreferenceAsync(UserPreference preference);
        Task<bool> DeletePreferenceAsync(string key);
        Task<IList<UserPreference>> GetAllPreferenceByUserAsync();
        Task<bool> UpdatePreferenceAsync(UserPreference preference);
    }
}
