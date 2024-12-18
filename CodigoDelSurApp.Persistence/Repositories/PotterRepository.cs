using CodigoDelSurApp.Persistence.Entities;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace CodigoDelSurApp.Persistence.Repositories
{
    public class PotterRepository : IPotterRepository
    {
        private const string potterApiUrl = "https://potterapi-fedeperin.vercel.app/en";

        public async Task<List<PotterBook>> GetAllPotterBooksAsync()
        {
            var client = new RestClient($"{potterApiUrl}/books");
            var response = await client.ExecuteAsync(new RestRequest());
            var books = JsonConvert.DeserializeObject<List<PotterBook>>(response.Content);

            return books ?? [];
        }

        public async Task<PotterCharacter?> GetPotterCharactersByNameAsync(string potterName)
        {
            List<PotterCharacter> characters = await GetAllHarryPotterCharacters();

            return characters.FirstOrDefault(c => c.FullName.Contains(potterName, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<PotterCharacter?> GetPotterCharactersByHouseAsync(string house)
        {
            List<PotterCharacter> characters = await GetAllHarryPotterCharacters();

            return characters.FirstOrDefault(c => c.HogwartsHouse.Contains(house, StringComparison.CurrentCultureIgnoreCase));
        }

        private static async Task<List<PotterCharacter>> GetAllHarryPotterCharacters()
        {
            var client = new RestClient($"{potterApiUrl}/characters");
            var response = await client.ExecuteAsync(new RestRequest());
            var characters = JsonConvert.DeserializeObject<List<PotterCharacter>>(response.Content);
            return characters ?? [];
        }
    }
}
