using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastHotChocolate.Client.GraphQL.Types;

namespace WeatherForecastHotChocolate.Client.Clients.WeatherForecasts
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecastType>> GetWeatherForecastsAsync();
        Task<WeatherForecastType> GetWeatherForecastByIdAsync(Guid id);
    }
}
