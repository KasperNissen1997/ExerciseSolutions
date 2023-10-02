using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WeatherForecastAPI.Data;
using WeatherForecastAPI.Models;
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
        private WeatherForecastContext _context;

        private IApiKey _openWeatherApiKey;
        private IApiKey _stormGlassApiKey;

        public ForecastController(ILogger<ForecastController> logger, IConfiguration config, HttpClient httpClient, WeatherForecastContext context)
        {
            _logger = logger;
            _config = config;

            _httpClient = httpClient;
            _context = context;

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
            // GEOCODING ---------------------------------
            string apiUrl = $"https://api.openweathermap.org/geo/1.0/direct?q={cityName},{stateCode},{countryCode}&limit=1&appid={_openWeatherApiKey.Value}";

            ApiCallData? apiCallData = await _context.StoredApiCallData
                .Where(apiCall => apiCall.ApiName == ApiName.OpenWeatherGeoCoding.ToString())
                .SingleOrDefaultAsync(apiCall => apiCall.CallUrl == apiUrl);

            GeoCodingResult[]? geoCodingResults;

            if (apiCallData != null)
                geoCodingResults = JsonSerializer.Deserialize<GeoCodingResult[]>(apiCallData.CallJsonData!); // Use the data stored in the database.
            else
            {
                geoCodingResults = await _httpClient.GetFromJsonAsync<GeoCodingResult[]>(apiUrl); // Send a new API call.

                _context.StoredApiCallData.Add(new(ApiName.OpenWeatherGeoCoding.ToString(), DateTime.Now, apiUrl, JsonSerializer.Serialize(geoCodingResults)));
            }
            
            // If no locations could be found using the provided search parameters, we let them know they messed up - bad request, yeah buddy.
            if (geoCodingResults!.Length == 0)
                return BadRequest();


            // OPENWEATHER ---------------------------------
            apiUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={geoCodingResults[0].Latitude}&lon={geoCodingResults[0].Longitude}&exclude=current,minutely,hourly,alerts&appid={_openWeatherApiKey.Value}";

            apiCallData = await _context.StoredApiCallData
                .Where(apiCall => apiCall.ApiName == ApiName.OpenWeatherOneCall.ToString())
                .Where(apiCall => apiCall.CallUrl == apiUrl)
                .SingleOrDefaultAsync(apiCall => apiCall.CallDateTime.Date == DateTime.Now.Date);

            ForecastResultVM? oneCallResult;

            if (apiCallData?.CallDateTime.Date == DateTime.Now.Date)
                oneCallResult = JsonSerializer.Deserialize<ForecastResultVM>(apiCallData.CallJsonData!); // Use the data stored in the database.
            else
            {
                oneCallResult = await _httpClient.GetFromJsonAsync<ForecastResultVM>(apiUrl); // Send a new API call.

                _context.StoredApiCallData.Add(new(ApiName.OpenWeatherOneCall.ToString(), DateTime.Now, apiUrl, JsonSerializer.Serialize(oneCallResult!)));
            }

            // Same as before here - if something happened to the data we've received, blame the user!
            if (oneCallResult == null)
                return BadRequest();

            oneCallResult.CityName = geoCodingResults[0].CityName;
            oneCallResult.CountryName = geoCodingResults[0].CountryName;
            oneCallResult.RegionName = geoCodingResults[0].RegionName;

            if (_context.ChangeTracker.HasChanges())
                await _context.SaveChangesAsync();

            return Ok(oneCallResult);
        }
    }
}