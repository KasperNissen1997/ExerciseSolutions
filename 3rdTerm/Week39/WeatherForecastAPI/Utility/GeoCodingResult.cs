using System.Text.Json.Serialization;

namespace WeatherForecastAPI.Utility
{
    /// <summary>
    /// This is a utility class, used when deserializing the JSON body retrieved from a request to the GeoCoding API.
    /// </summary>
    public class GeoCodingResult
    {
        /// <summary>
        /// The latitude of the location.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        /// <summary>
        /// The longitude of the location.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("name")]
        public string CityName { get; set; } = string.Empty;
        [JsonPropertyName("country")]
        public string CountryName { get; set; } = string.Empty;
        [JsonPropertyName("state")]
        public string RegionName { get; set; } = string.Empty;
    }
}
