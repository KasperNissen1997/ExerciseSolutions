using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WeatherForecastAPI.Models.DTOs
{
    public class ForecastResult
    {
        public string CityName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;

        //[JsonPropertyName("current")]
        //public CurrentWeatherData? CurrentWeather { get; set; }
        [JsonPropertyName("daily")]
        public List<DailyWeatherData>? DailyWeather { get; set; }

        public class WeatherDataBase
        {
            [JsonPropertyName("dt")]
            public double Date { get; set; }
            [JsonPropertyName("weather")]
            public List<WeatherDataEntry>? WeatherDataEntries { get; set; }
        }

        public class DailyWeatherData : WeatherDataBase
        {
            [JsonPropertyName("sunrise")]
            public double Sunrise { get; set; }
            [JsonPropertyName("sunset")]
            public double Sunset { get; set; }
            [JsonPropertyName("temp")]
            public TemperatureData TemperatureData { get; set; } = new();
            [JsonPropertyName("feels_like")]
            public TemperatureData TemperatureFeelsLikeData { get; set; } = new();
            [JsonPropertyName("summary")]
            public string Summary { get; set; } = string.Empty;
            [JsonPropertyName("wind_speed")]
            public double WindSpeed { get; set; }
            [JsonPropertyName("rain")]
            public double RainFall { get; set; }
        }

        public class TemperatureData
        {
            [JsonPropertyName("day")]
            public double Day { get; set; }
            [JsonPropertyName("night")]
            public double Night { get; set; }
            [JsonPropertyName("eve")]
            public double Evening { get; set; }
            [JsonPropertyName("morn")]
            public double Morning { get; set; }
        }

        public class CurrentWeatherData : WeatherDataBase
        {
            [JsonPropertyName("temp")]
            public double Temperature { get; set; }
            [JsonPropertyName("feels_like")]
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
