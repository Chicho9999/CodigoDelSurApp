using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;

namespace CodigoDelSurApp.Application
{
    public class PotterService : IPotterService
    {
        private readonly IPotterRepository _potterRepository;

        public PotterService(IPotterRepository potterRepository)
        {
            _potterRepository = potterRepository;
        }

        public async Task<List<PotterBook>> GetAllBooksAsync()
        {
            return await _potterRepository.GetAllPotterBooksAsync();
        }

        public async Task<PotterCharacter?> GetPotterCharacterByNameAsync(string name)
        {
            return await _potterRepository.GetPotterCharactersByNameAsync(name);
        }

        public async Task<List<PotterCharacter>?> GetPotterCharactersByHouseAsync(string name)
        {
            return await _potterRepository.GetPotterCharactersByHouseAsync(name);
        }
    }
}
