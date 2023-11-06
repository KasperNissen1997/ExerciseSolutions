using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Data;

namespace WeatherForecastAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WeatherForecastContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherForecastAPI") ?? throw new InvalidOperationException("Connection string 'WeatherForecastAPI' not found.")));

            // Add services to the container.
            HttpClient httpClient = new();
            builder.Services.AddSingleton(typeof(HttpClient), httpClient);
            builder.Services.AddControllers();

            // Should only be enabled in the dev environment.
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            
            app.UseCors();

            app.Run();
        }
    }
}