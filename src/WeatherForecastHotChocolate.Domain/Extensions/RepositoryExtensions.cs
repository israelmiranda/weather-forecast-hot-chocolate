using Microsoft.Extensions.DependencyInjection;
using WeatherForecastHotChocolate.Domain.Repositories;

namespace WeatherForecastHotChocolate.Domain.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>()
                .AddScoped<ISummaryRepository, SummaryRepository>();
    }
}
