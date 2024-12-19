using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;

namespace CodigoDelSurApp.Application
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<IList<Beer>> GetBeersByNameAsync(string name)
        {
            return await _beerRepository.GetBeersByNameAsync(name);
        }
    }
}
