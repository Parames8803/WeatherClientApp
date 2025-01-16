namespace MyWeatherApp.DataFormats
{
    public class WeatherResponse
    {
        public string Cod { get; set; } = string.Empty;
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ForecastItem> List { get; set; } = new List<ForecastItem>();
        public City City { get; set; } = new City();
    }

    public class ForecastItem
    {
        public long Dt { get; set; }
        public MainInfo Main { get; set; } = new MainInfo();
        public List<WeatherInfo> Weather { get; set; } = new List<WeatherInfo>();
        public CloudsInfo Clouds { get; set; } = new CloudsInfo();
        public WindInfo Wind { get; set; } = new WindInfo();
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public SysInfo Sys { get; set; } = new SysInfo();
        public string Dt_txt { get; set; } = string.Empty;
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Sea_level { get; set; }
        public int Grnd_level { get; set; }
        public int Humidity { get; set; }
        public double Temp_kf { get; set; }
    }

    public class WeatherInfo
    {
        public int Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class CloudsInfo
    {
        public int All { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class SysInfo
    {
        public string Pod { get; set; } = string.Empty;
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


    public class WeatherResponseCurrent
    {
        public Coord Coord { get; set; } = new Coord();
        public List<WeatherInfoCurrent> Weather { get; set; } = new List<WeatherInfoCurrent>();
        public string Base { get; set; } = string.Empty;
        public MainWeather Main { get; set; } = new MainWeather();
        public int Visibility { get; set; }
        public Wind Wind { get; set; } = new Wind();
        public Rain Rain { get; set; } = new Rain();
        public Clouds Clouds { get; set; } = new Clouds();
        public long Dt { get; set; }
        public Sys Sys { get; set; } = new Sys();
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Cod { get; set; }
    }

    public class WeatherInfoCurrent
    {
        public int Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class MainWeather
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Rain
    {
        public double _1h { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}