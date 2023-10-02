using System.ComponentModel.DataAnnotations.Schema;
using WeatherForecastAPI.Utility;

namespace WeatherForecastAPI.Models
{
    public class ApiCallData
    {
        /// <summary>
        /// The name of the API that was called.
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// The <see cref="System.DateTime"/> of the API call.
        /// </summary>
        public DateTime CallDateTime { get; set; }
        /// <summary>
        /// The URL of the API call.
        /// </summary>
        public string CallUrl { get; set; }
        /// <summary>
        /// The data that the API call returned.
        /// </summary>
        public string? CallJsonData { get; set; }

        public ApiCallData(string apiName, DateTime callDateTime, string callUrl, string? callJsonData)
        {
            ApiName = apiName;
            CallDateTime = callDateTime;
            CallUrl = callUrl;
            CallJsonData = callJsonData;
        }
    }
}
