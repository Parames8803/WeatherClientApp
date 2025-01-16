namespace MyWeatherApp.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using static System.Net.WebRequestMethods;

    public class LocationService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "31accee574574bb88a7bda13b3aa2d5a";
        private string AbstractApiUrl;
        private string CountriesNowApiUrl;

        public LocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            AbstractApiUrl = configuration["AbstractApiUrl"];
            CountriesNowApiUrl = configuration["CountriesNowApiUrl"];
        }

        public async Task<DataFormats.LocationDetails?> GetCurrentLocationAsync()
        {
            string apiUrl = AbstractApiUrl;

            try
            {
                return await _httpClient.GetFromJsonAsync<DataFormats.LocationDetails>(apiUrl);
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
                return cityData?.Data ?? new List<string>();
            }
            else
            {
                return null;
            }
        }
    }

}
