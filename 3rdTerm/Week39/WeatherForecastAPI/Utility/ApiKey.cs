namespace WeatherForecastAPI.Utility
{
    public class ApiKey : IApiKey
    {
        public ApiKeyName Name { get; set; }

        public string Value { get; set; }

        public ApiKey(ApiKeyName name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
