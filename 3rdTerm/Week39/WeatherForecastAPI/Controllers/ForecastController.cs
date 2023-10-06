using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using WeatherForecastAPI.Data;
using WeatherForecastAPI.Models;
using WeatherForecastAPI.Models.DTOs;
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

        [ResponseCache(Duration = 3600)]
        [HttpGet("{city}"), ActionName("Forecast")]
        public async Task<IActionResult> PostForecast(string city, string? state, string? countryCode, string? unitType)
        {
            // GEOCODING ---------------------------------
            string apiUrl = $"https://api.openweathermap.org/geo/1.0/direct?q={city},{state},{countryCode}&limit=1&appid={_openWeatherApiKey.Value}";

            GeoCodingResult[]? geoCodingResults = await _httpClient.GetFromJsonAsync<GeoCodingResult[]>(apiUrl); // Send a new API call.
            
            // If no locations could be found using the provided search parameters, we let them know they messed up - bad request, yeah buddy.
            if (geoCodingResults!.Length == 0)
                return BadRequest();

            GeoCodingResult geoCodingResult = geoCodingResults.First();

            // OPENWEATHER ---------------------------------
            if (unitType.IsNullOrEmpty())
                unitType = "metric";

            apiUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={geoCodingResult.Latitude}&lon={geoCodingResult.Longitude}&units={unitType}&exclude=current,minutely,hourly,alerts&appid={_openWeatherApiKey.Value}";

            ForecastResult? oneCallResult = await _httpClient.GetFromJsonAsync<ForecastResult>(apiUrl); // Send a new API call.

            // Same as before here - if something happened to the data we've received, blame the user!
            if (oneCallResult == null)
                return BadRequest();

            oneCallResult.CityName = geoCodingResults[0].CityName;
            oneCallResult.CountryName = geoCodingResults[0].CountryName;
            oneCallResult.RegionName = geoCodingResults[0].RegionName;

            return Ok(oneCallResult);
        }
    }
}