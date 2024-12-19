using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;

namespace CodigoDelSurApp.Application.Interfaces
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferenceService(IPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        public async Task<IList<UserPreference>> GetAllPreferenceByUserAsync()
        {
            return await _preferenceRepository.GetAllPreferenceByUserAsync();
        }

        public async Task<bool> CreatePreferenceAsync(UserPreference preference)
        {
            return await _preferenceRepository.CreatePreferenceAsync(preference);
        }

        public async Task<bool> UpdatePreferenceAsync(UserPreference preference)
        {
            return await _preferenceRepository.UpdatePreferenceAsync(preference);
        }

        public async Task<bool> DeletePreferenceAsync(string key)
        {
            return await _preferenceRepository.DeletePreferenceAsync(key);
        }
    }
}
