using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace WeatherForecastHotChocolate.Api.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationContext(
            this IServiceCollection services,
            IConfiguration configuration
        ) => services.AddScoped(sp => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
    }
}
