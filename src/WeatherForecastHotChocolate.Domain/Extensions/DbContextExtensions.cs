using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Domain.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContext(
           this IServiceCollection services,
           IConfiguration configuration
        ) => services.AddScoped(sp =>
            new DbContext(
                sp.GetRequiredService<MongoClient>().GetDatabase(configuration.GetConnectionString("WeatherForecastDatabase"))
            )
        );
    }
}
