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

        private IApiKey _openWeatherApiKey;
        private IApiKey _stormGlassApiKey;

        public ForecastController(ILogger<ForecastController> logger, IConfiguration config, HttpClient httpClient)
        {
            _logger = logger;
            _config = config;

            _httpClient = httpClient;

            _openWeatherApiKey = GetApiKey(ApiKeyName.OpenWeather);
            _stormGlassApiKey = GetApiKey(ApiKeyName.StormGlass);
        }

        /// <summary>
        /// Retrieves the matching API key stored in the user secrets service.
        /// </summary>
        /// <param name="apiKeyName">The <see cref="ApiKeyName"/> matching the API key that should be retrieved.</param>
        /// <returns>A <see cref="ApiKey"/> object containing the value of the API key.</returns>
        /// <exception cref="NotSupportedException">Thrown if no API key matching <paramref name="apiKeyName"/> has been registered in the user secrets service.</exception>
        private ApiKey GetApiKey(ApiKeyName apiKeyName)
        {
            string userSecretApiKeyName = apiKeyName switch
            {
                ApiKeyName.OpenWeather => "openWeatherApiKey",
                ApiKeyName.StormGlass => "stormGlassApiKey",
                _ => throw new NotSupportedException("No registered user secret API key of type: " + apiKeyName),
            };

            string? apiKey = _config[userSecretApiKeyName];

            return new(apiKeyName, apiKey!);
        }

        [HttpGet("{cityName}"), ActionName("Forecast")]
        public async Task<IActionResult> PostForecast(string cityName, string? stateCode, string? countryCode)
        {
            GeoCodingResult[]? geoCodingResults = await _httpClient.GetFromJsonAsync<GeoCodingResult[]>($"http://api.openweathermap.org/geo/1.0/direct?q={cityName},{stateCode},{countryCode}&limit=1&appid={_openWeatherApiKey.Value}");

            if (geoCodingResults!.Count() == 0)
                return BadRequest();

            ForecastResultVM? forecastResult = await _httpClient.GetFromJsonAsync<ForecastResultVM>($"https://api.openweathermap.org/data/3.0/onecall?lat={geoCodingResults[0].Latitude}&lon={geoCodingResults[0].Longitude}&exclude=current,minutely,hourly,alerts&appid={_openWeatherApiKey.Value}");
            
            if (forecastResult == null)
                return BadRequest();

            forecastResult.CityName = geoCodingResults[0].CityName;
            forecastResult.CountryName = geoCodingResults[0].CountryName;
            forecastResult.RegionName = geoCodingResults[0].RegionName;

            return Ok(forecastResult);
        }
    }
}