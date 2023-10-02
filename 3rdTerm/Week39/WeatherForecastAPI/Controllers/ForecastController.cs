using Microsoft.AspNetCore.Mvc;
using WeatherForecastAPI.Models.ViewModels;
using WeatherForecastAPI.Utility;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController : Controller
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IConfiguration _config;
        private HttpClient _httpClient;

        private IApiKey _apiKey;

        public ForecastController(ILogger<ForecastController> logger, IConfiguration config, HttpClient httpClient)
        {
            _logger = logger;
            _config = config;

            _httpClient = httpClient;

            string? apiKey = _config["apiKey"];

            if (!string.IsNullOrEmpty(apiKey))
                _apiKey = new ApiKey("openWeather", apiKey);
            else
                throw new Exception("Can't retrieve API key from user secrets!");
        }


        [HttpGet("{cityName}"), ActionName("Forecast")]
        public async Task<IActionResult> PostForecast(string cityName, string? stateCode, string? countryCode)
        {
            GeoCodingCoordSet[]? coordSets = await _httpClient.GetFromJsonAsync<GeoCodingCoordSet[]>($"http://api.openweathermap.org/geo/1.0/direct?q={cityName},{stateCode},{countryCode}&limit=1&appid={_apiKey.Value}");

            if (coordSets.Count() == 0)
                return BadRequest();

            ForecastResultVM? forecastResult = await _httpClient.GetFromJsonAsync<ForecastResultVM>($"https://api.openweathermap.org/data/3.0/onecall?lat={coordSets[0].Latitude}&lon={coordSets[0].Longitude}&exclude=current,minutely,hourly,alerts&appid={_apiKey.Value}");

            return Ok(forecastResult);
        }
    }
}