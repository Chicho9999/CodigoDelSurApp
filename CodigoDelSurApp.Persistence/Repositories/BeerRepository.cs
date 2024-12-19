using CodigoDelSurApp.Persistence.Repositories.Interface;
using Newtonsoft.Json;
using System.Security.Claims;
using RestSharp;
using CodigoDelSurApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using CodigoDelSurApp.Persistence.Helper;

namespace CodigoDelSurApp.Persistence.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly CodigoDelSurDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;

        public BeerRepository(CodigoDelSurDbContext dbContext, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        public async Task<IList<Beer>> GetBeersByNameAsync(string name)
        {
            var client = new RestClient($"https://punkapi.online/v3/beers?beer_name={name}&query=10&page=1");
            var response = await client.ExecuteAsync(new RestRequest());
            var characters = JsonConvert.DeserializeObject<IList<Beer>>(response.Content)
                                        .AsQueryable();

            var userId = _httpContext.HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

            var userPreferences = _dbContext.UserPreferences.Where(sp => sp.UserId == Guid.Parse(userId));

            //using Preferences
            foreach (var userPreference in userPreferences) {
                if (QueryHelper.PropertyExists(characters, userPreference.PreferenceKey))
                {
                    var characterOrdered = userPreference.PreferenceValue == "desc" ? 
                        QueryHelper.OrderByPropertyDescending(characters, userPreference.PreferenceKey) : 
                        QueryHelper.OrderByProperty(characters, userPreference.PreferenceKey);

                    return characterOrdered.ToList();
                }
            }

            return characters.ToList() ?? [];
        }
    }
}
