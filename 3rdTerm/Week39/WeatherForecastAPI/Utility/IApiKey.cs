namespace WeatherForecastAPI.Utility
{
    public interface IApiKey
    {
        public ApiKeyName Name { get; }
        public string Value { get; }
    }
}
