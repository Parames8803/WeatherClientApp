namespace MyWeatherApp.DataFormats
{
    public class ApiResponses
    {
        public class AuthRequest
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
        }

        public class LoginResponse
        {
            public string? Token { get; set; }
            public string? RefreshToken { get; set; }
            public User? User { get; set; }
        }

        public class User
        {
            public string? Id { get; set; }
            public string? Email { get; set; }
        }

        

        public class FavCitiesResponse
        {
            public string UserId { get; set; }
            public List<City> FavCities { get; set; } = new List<City>();
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Country { get; set; } = string.Empty;
            public Coord Coord { get; set; } = new Coord();
            public int Population { get; set; }
            public int Timezone { get; set; }
            public int Sunrise { get; set; }
            public int Sunset { get; set; }
        }

        public class Coord
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

        public class SessionResponse
        {
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
            public string ProviderToken { get; set; }
            public string ProviderRefreshToken { get; set; }
            public string RefreshToken { get; set; }
            public string TokenType { get; set; }
            public UserDetail User { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class UserDetail
        {
            public AppMetadata AppMetadata { get; set; }
            public string Aud { get; set; }
            public DateTime? ConfirmationSentAt { get; set; }
            public DateTime? ConfirmedAt { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Email { get; set; }
            public DateTime? EmailConfirmedAt { get; set; }
            public string Id { get; set; }
            public List<Identity> Identities { get; set; }
            public DateTime? InvitedAt { get; set; }
            public DateTime? LastSignInAt { get; set; }
            public string Phone { get; set; }
            public DateTime? PhoneConfirmedAt { get; set; }
            public DateTime? RecoverySentAt { get; set; }
            public string Role { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime? BannedUntil { get; set; }
            public bool IsAnonymous { get; set; }
            public List<object> Factors { get; set; }
            public UserMetadata UserMetadata { get; set; }
        }

        public class AppMetadata
        {
            public string Provider { get; set; }
            public List<object> Providers { get; set; }
        }

        public class Identity
        {
            public string Id { get; set; }
            public string UserId { get; set; }
            public IdentityData IdentityData { get; set; }
            public string IdentityId { get; set; }
            public string Provider { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime LastSignInAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class IdentityData
        {
            public string Email { get; set; }
            public bool EmailVerified { get; set; }
            public bool PhoneVerified { get; set; }
            public string Sub { get; set; }
        }

        public class UserMetadata
        {
            public string Email { get; set; }
            public bool EmailVerified { get; set; }
            public bool PhoneVerified { get; set; }
            public string Sub { get; set; }
        }

    }
}
