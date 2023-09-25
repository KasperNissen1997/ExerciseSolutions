using WeatherForecast.Utility;

namespace WeatherForecast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Retrieve the API key from the configuration file.
            string? retrievedApiKey = builder.Configuration.GetValue<string>("openWeatherMapApiKey");
            ApiKey openWeatherMapApiKey = new("OpenWeatherMap", retrievedApiKey != null ? retrievedApiKey : "");

            // Add services to the container.
            builder.Services.AddSingleton(typeof(IApiKey), openWeatherMapApiKey);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}