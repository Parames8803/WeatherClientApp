namespace MyWeatherApp.Services
{
    using Blazored.LocalStorage;
    using static MyWeatherApp.Pages.Login;
    using static System.Net.WebRequestMethods;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.Json;
    using MudBlazor;

    public class LoginService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly string ServerUrl;

        public LoginService(ILocalStorageService localStorage, HttpClient http, IConfiguration configuration)
        {
            _localStorage = localStorage;
            _http = http;
            ServerUrl = configuration["ServerUrl"];
        }

        public async Task<DataFormats.ApiResponses.LoginResponse?> Login(string Email, string Password)
        {
            var loginRequest = new DataFormats.ApiResponses.AuthRequest { Email = Email, Password = Password };

            try
            {
                var response = await _http.PostAsJsonAsync(ServerUrl+"/api/auth/login", loginRequest);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<DataFormats.ApiResponses.LoginResponse>();
                    return result;
                }
                else
                {
                    Console.WriteLine($"Login failed: {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Register(string Email, string Password)
        {
            var registerRequest = new DataFormats.ApiResponses.AuthRequest { Email = Email, Password = Password };
            try
            {
                var response = await _http.PostAsJsonAsync(ServerUrl+"/api/auth/register", registerRequest);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return false;
            }
        }


        public async Task<DataFormats.ApiResponses.SessionResponse?> IsLoggedInAsync()
        {
            try
            {
                var res = await _http.GetFromJsonAsync<DataFormats.ApiResponses.SessionResponse>(ServerUrl+"/api/auth/session");
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return null;
            }
        }
        public async Task LogoutAsync()
        {
            var response = await _http.PostAsJsonAsync(ServerUrl+"/api/auth/logout", new { });
            Console.WriteLine(response);
        }
    }

}
