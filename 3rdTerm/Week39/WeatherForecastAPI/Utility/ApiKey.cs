namespace WeatherForecastAPI.Utility
{
    public class ApiKey : IApiKey
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public ApiKey(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
