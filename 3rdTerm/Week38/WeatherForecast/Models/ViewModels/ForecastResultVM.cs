using System.Text.Json.Serialization;

namespace WeatherForecast.Models.ViewModels
{
    public class ForecastResultVM
    {
        [JsonPropertyName("current")]
        public CurrentWeatherData? CurrentWeatherData { get; set; }
    }

    public class CurrentWeatherData
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        [JsonPropertyName("feels_like")]
        public double TemperatureFeelsLike { get; set; }
        [JsonPropertyName("weather")]
        public List<WeatherDataEntry>? WeatherDataEntries { get; set; }
    }

    public class WeatherDataEntry
    {
        [JsonPropertyName("main")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string IconPath { get; set; } = string.Empty;
    }
}
