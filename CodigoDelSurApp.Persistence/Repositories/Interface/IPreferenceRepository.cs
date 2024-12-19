using CodigoDelSurApp.Domain.Entities;

namespace CodigoDelSurApp.Persistence.Repositories.Interface
{
    public interface IPreferenceRepository
    {
        Task<IList<UserPreference>> GetAllPreferenceByUserAsync();
        Task<bool> CreatePreferenceAsync(UserPreference preference);
        Task<bool> UpdatePreferenceAsync(UserPreference preference);
        Task<bool> DeletePreferenceAsync(string key);
    }
}
