namespace MyWeatherApp.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string OpenWeatherUrl;
        private readonly string OpenWeatherApiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            OpenWeatherUrl = configuration["OpenWeatherUrl"];
            OpenWeatherApiKey = configuration["OpenWeatherApiKey"];
        }

        public async Task<DataFormats.WeatherResponse?> GetWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City name cannot be empty.", nameof(city));

            string url = $"{OpenWeatherUrl}/forecast?q={city}&appid={OpenWeatherApiKey}";
            return await _httpClient.GetFromJsonAsync<DataFormats.WeatherResponse>(url);
        }

        public async Task<DataFormats.WeatherResponseCurrent?> GetCurrentWeatherInfo(double lat, double lon)
        {
            string url = $"{OpenWeatherUrl}/weather?lat={lat}&lon=-{lon}&appid={OpenWeatherApiKey}";
            return await _httpClient.GetFromJsonAsync<DataFormats.WeatherResponseCurrent>(url);
        } 

    }

}
