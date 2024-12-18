using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace CodigoDelSurApp.Persistence.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        public async Task<List<Beer>> GetBeersByNameAsync(string name)
        {
            var client = new RestClient($"https://punkapi.online/v3/beers?beer_name={name}&query=10&page=1");
            var response = await client.ExecuteAsync(new RestRequest());
            var characters = JsonConvert.DeserializeObject<List<Beer>>(response.Content);

            return characters ?? [];
        }
    }
}
