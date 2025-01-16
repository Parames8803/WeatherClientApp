namespace MyWeatherApp.DataFormats
{
    public class LocationDetails
    {
        public string IpAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int CityGeonameId { get; set; }
        public string Region { get; set; } = string.Empty;
        public string RegionIsoCode { get; set; } = string.Empty;
        public int RegionGeonameId { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Country_Code { get; set; } = string.Empty;
        public int CountryGeonameId { get; set; }
        public bool CountryIsEu { get; set; }
        public string Continent { get; set; } = string.Empty;
        public string ContinentCode { get; set; } = string.Empty;
        public int ContinentGeonameId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public TimezoneInfo Timezone { get; set; } = new();
        public FlagInfo Flag { get; set; } = new();
        public CurrencyInfo Currency { get; set; } = new();

        public class TimezoneInfo
        {
            public string Name { get; set; } = string.Empty;
            public string Abbreviation { get; set; } = string.Empty;
            public int GmtOffset { get; set; }
            public string CurrentTime { get; set; } = string.Empty;
            public bool IsDst { get; set; }
        }

        public class FlagInfo
        {
            public string Emoji { get; set; } = string.Empty;
            public string Unicode { get; set; } = string.Empty;
            public string Png { get; set; } = string.Empty;
            public string Svg { get; set; } = string.Empty;
        }

        public class CurrencyInfo
        {
            public string CurrencyName { get; set; } = string.Empty;
            public string CurrencyCode { get; set; } = string.Empty;
        }

        public class CityApiResponse
        {
            public bool Error { get; set; }
            public string Msg { get; set; }
            public List<string> Data { get; set; }
        }

        public class CountryApiResponse
        {
            public bool Error { get; set; }
            public string Msg { get; set; }
            public List<CountryDetails> Data { get; set; }
        }

        public class CountryDetails
        {
            public string Name { get; set; }
            public string Currency { get; set; }
            public string UnicodeFlag { get; set; }
            public string Flag { get; set; }
            public string Dialcode { get; set; }
        }

    }
}
