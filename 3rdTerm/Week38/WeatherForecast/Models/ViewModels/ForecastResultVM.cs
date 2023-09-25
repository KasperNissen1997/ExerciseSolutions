using Humanizer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WeatherForecast.Models.ViewModels
{
    public class ForecastResultVM
    {
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
            public string DateFormatted { get => FormatDate(); }

            private string FormatDate()
            {
                string dayOfWeek = Date.ToString("ddd").Titleize();
                string month = Date.ToString("MMM").Titleize();
                string dayOfMonth = Date.ToString("dd");

                bool isToday = DateTime.Today.Date == Date.Date;

                string formattedDate = $"{dayOfWeek}, {month} {dayOfMonth}";

                if (isToday)
                    formattedDate += " (Today)";

                return formattedDate;
            }
        }

        public class DailyWeatherData : WeatherDataBase
        {
            [JsonPropertyName("temp")]
            [DisplayName("Temperature (°C)"), DisplayFormat(DataFormatString = "{0:0.0}")]
            public TemperatureData Temperatures { get; set; } = new();
            [JsonPropertyName("feels_like")]
            public TemperatureData TemperaturesFeelsLike { get; set; } = new();
        }

        public class TemperatureData
        {
            [JsonPropertyName("day")]
            public double DayKelvin { get; set; }
            [JsonPropertyName("night")]
            public double NightKelvin { get; set; }
            [JsonPropertyName("eve")]
            public double EveningKelvin { get; set; }
            [JsonPropertyName("morn")]
            public double MorningKelvin { get; set; }

            [DisplayName("Day"), DisplayFormat(DataFormatString = "{0:0.0}")]
            public double DayCelsius { get => DayKelvin - 273.15; }
            [DisplayName("Night"), DisplayFormat(DataFormatString = "{0:0.0}")]
            public double NightCelsius { get => NightKelvin - 273.15; }
            [DisplayName("Evening"), DisplayFormat(DataFormatString = "{0:0.0}")]
            public double EveningCelsius { get => EveningKelvin - 273.15; }
            [DisplayName("Morning"), DisplayFormat(DataFormatString = "{0:0.0}")]
            public double MorningCelsius { get => MorningKelvin - 273.15; }
        }

        public class CurrentWeatherData : WeatherDataBase
        {
            [JsonPropertyName("temp")]
            public double TemperatureKelvin { get; set; }
            [JsonPropertyName("feels_like")]
            public double TemperatureFeelsLikeKelvin { get; set; }

            [DisplayName("Temperature (°C)"), DisplayFormat(DataFormatString = "{0:0.0}")]
            public double TemperatureCelsius { get => TemperatureKelvin - 273.15; }
            public double TemperatureFeelsLikeCelsius { get => TemperatureFeelsLikeKelvin - 273.15; }
        }

        public class WeatherDataEntry
        {
            [JsonPropertyName("main")]
            public string Title { get; set; } = string.Empty;

            [JsonPropertyName("description")]
            public string Description { get; set; } = string.Empty;

            [JsonPropertyName("icon")]
            public string IconCode { get; set; } = string.Empty;

            public string TitleizedDescription { get => Description.Titleize(); }
            public string IconUrl { get => $"https://openweathermap.org/img/wn/{IconCode}@2x.png"; }
        }
    }
}
