using Microsoft.Extensions.DependencyInjection;
using WeatherForecastHotChocolate.Client.Clients.Summaries;
using WeatherForecastHotChocolate.Client.Clients.WeatherForecasts;

namespace WeatherForecastHotChocolate.Client.Extensions
{
    public static class WeatherForecastHotChocolateClientExtensions
    {
        public static void AddWeatherForecastHotChocolateClient(this IServiceCollection services)
        {
            services.AddHttpClient<ISummaryClient, SummaryClient>();
            services.AddHttpClient<IWeatherForecastClient, WeatherForecastClient>();
        }
    }
}
