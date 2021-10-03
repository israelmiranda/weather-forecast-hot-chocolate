using Microsoft.Extensions.DependencyInjection;
using WeatherForecastHotChocolate.Api.Services;

namespace WeatherForecastHotChocolate.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<WeatherForecastService>()
                .AddScoped<SummaryService>();
    }
}
