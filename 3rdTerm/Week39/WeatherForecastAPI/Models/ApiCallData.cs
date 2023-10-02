using System.ComponentModel.DataAnnotations.Schema;
using WeatherForecastAPI.Utility;

namespace WeatherForecastAPI.Models
{
    public class ApiCallData
    {
        /// <summary>
        /// The name of the API that was called.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="DateTime"/> of the API call.
        /// </summary>
        public DateTime CallDateTime { get; set; }
        /// <summary>
        /// The URL of the API call.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The data that the API call returned.
        /// </summary>
        public string? JsonData { get; set; }

        public ApiCallData(string name, DateTime callDateTime, string url, string? jsonData)
        {
            Name = name;
            CallDateTime = callDateTime;
            Url = url;
            JsonData = jsonData;
        }
    }
}
