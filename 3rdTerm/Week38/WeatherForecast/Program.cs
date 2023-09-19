using WeatherForecast.Models;

namespace WeatherForecast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            HttpClient httpClient = new HttpClient();
            ApiKey apiKey = new() 
            {
                Name = (string) builder.Configuration.GetValue(typeof(string), "openWeatherMapApiKey") 
            };

            // Add services to the container.
            builder.Services.AddSingleton(typeof(HttpClient), httpClient);
            builder.Services.AddSingleton(typeof(ApiKey), apiKey);
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