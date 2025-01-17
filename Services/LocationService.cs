namespace MyWeatherApp.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using static System.Net.WebRequestMethods;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LocationService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "31accee574574bb88a7bda13b3aa2d5a";
        private readonly string AbstractApiUrl;
        private readonly string CountriesNowApiUrl;

        public LocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            AbstractApiUrl = configuration["AbstractApiUrl"] ?? string.Empty;
            CountriesNowApiUrl = configuration["CountriesNowApiUrl"] ?? string.Empty;
        }

        public async Task<DataFormats.CurrentLocation?> GetCurrentLocationAsync()
        {
            string apiUrl = AbstractApiUrl;

            try
            {
                var jsonResponse = await _httpClient.GetStringAsync(apiUrl);
                var cleanedJson = jsonResponse.Replace("geoip(", "").Replace(")", "");               
                var location = JsonConvert.DeserializeObject<DataFormats.CurrentLocation>(cleanedJson);              
                return location;
            }
            catch
            {
                return null; 
            }
        }

        public async Task<List<string>?> GetAllCountries(string selectedCountry)
        {
            var cityResponse = await _httpClient.PostAsJsonAsync(CountriesNowApiUrl+"/countries/cities", new { country = selectedCountry });
            var cityData = await cityResponse.Content.ReadFromJsonAsync<DataFormats.LocationDetails.CityApiResponse>();
            if(cityData != null)
            {
                return cityData.Data ?? new List<string>();
            }
            else
            {
                return null;
            }
        }
    }
}