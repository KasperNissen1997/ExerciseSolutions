using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Data
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options) : base(options) { }

        public DbSet<ApiCallData> StoredApiCallData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiCallData>()
                .HasKey(key => new { key.Name, key.Url });

            base.OnModelCreating(modelBuilder);
        }
    }
}
