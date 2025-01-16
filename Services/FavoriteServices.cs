using System.Net.Http.Json;
using Blazored.LocalStorage;
using MudBlazor;
using static System.Net.WebRequestMethods;

namespace MyWeatherApp.Services
{
    public class FavoriteServices
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly string ServerEndpoint;

        public FavoriteServices(ILocalStorageService localStorage, HttpClient http, IConfiguration configuration)
        {
            _localStorage = localStorage;
            _http = http;
            ServerEndpoint = configuration["ServerUrl"];
        }

        public async Task<object?> SaveCity(string userId, DataFormats.City city)
        {
            var request = new { UserId = userId, Cities = new List<DataFormats.City> { city } };
            var response = await _http.PostAsJsonAsync(ServerEndpoint+"/api/favourites/addCity", request);
            if (response.IsSuccessStatusCode && response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<DataFormats.ApiResponses.FavCitiesResponse?> FetchFavoriteCities(string userId)
        {
            var url = $"{ServerEndpoint}/api/favourites/getFavourites/{userId}";
            var response = await _http.GetFromJsonAsync<DataFormats.ApiResponses.FavCitiesResponse>(url);
            if (response != null || response?.FavCities.Count > 0)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<object?> RemoveCity(string userId, string city)
        {
            var request = new { UserId = userId, CityName = city };
            var response = await _http.PostAsJsonAsync(ServerEndpoint+"/api/favourites/removeCity", request);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
