using System.Text.Json.Serialization;

namespace WeatherForecast.Utility
{
    /// <summary>
    /// This is a utility class, used when deserializing the JSON body retrieved from a request to the GeoCoding API.
    /// </summary>
    public class GeoCodingCoordSet
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
    }
}
