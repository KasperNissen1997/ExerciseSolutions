using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WeatherForecastAPI.Models.ViewModels
{
    public class ForecastResultVM
    {
        public string CityName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;

        [JsonPropertyName("current")]
        public CurrentWeatherData? CurrentWeather { get; set; }
        [JsonPropertyName("daily")]
        public List<DailyWeatherData>? DailyWeather { get; set; }

        public class WeatherDataBase
        {
            [JsonPropertyName("dt")]
            public double UnixTimestamp { get; set; }
            [JsonPropertyName("weather")]
            public List<WeatherDataEntry>? WeatherDataEntries { get; set; }

            public DateTime Date { get => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(UnixTimestamp); }
        }

        public class DailyWeatherData : WeatherDataBase
        {
            [JsonPropertyName("temp")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public TemperatureData TemperatureData { get; set; } = new();
            [JsonPropertyName("feels_like")]
            public TemperatureData TemperatureFeelsLikeData { get; set; } = new();
        }

        public class TemperatureData
        {
            [JsonPropertyName("day")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public double Day { get; set; }
            [JsonPropertyName("night")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public double Night { get; set; }
            [JsonPropertyName("eve")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public double Evening { get; set; }
            [JsonPropertyName("morn")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public double Morning { get; set; }
        }

        public class CurrentWeatherData : WeatherDataBase
        {
            [JsonPropertyName("temp")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public double Temperature { get; set; }
            [JsonPropertyName("feels_like")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
            public double TemperatureFeelsLike { get; set; }
        }

        public class WeatherDataEntry
        {
            [JsonPropertyName("main")]
            public string Title { get; set; } = string.Empty;

            [JsonPropertyName("description")]
            public string Description { get; set; } = string.Empty;

            [JsonPropertyName("icon")]
            public string IconCode { get; set; } = string.Empty;

            public string IconUrl { get => $"https://openweathermap.org/img/wn/{IconCode}@2x.png"; }
        }
    }
}
