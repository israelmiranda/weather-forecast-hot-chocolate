using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.Extensions.Configuration;
using WeatherForecastHotChocolate.Client.Exceptions;
using WeatherForecastHotChocolate.Client.GraphQL.Queries;
using WeatherForecastHotChocolate.Client.GraphQL.Types;

namespace WeatherForecastHotChocolate.Client.Clients.WeatherForecasts
{
    public class WeatherForecastClient : AbstractWeatherForecastHotChocolateClient, IWeatherForecastClient
    {
        public WeatherForecastClient(
            HttpClient httpClient,
            IConfiguration configuration
        ) : base(httpClient, configuration) { }

        public async Task<IEnumerable<WeatherForecastType>> GetWeatherForecastsAsync()
        {
            try
            {
                var response = await GraphQLClient.SendQueryAsync(
                    WeatherForecastQuery.WeatherForecasts(),
                    () => new
                    {
                        weatherForecasts = new List<WeatherForecastType>()
                    }
                );

                return response.Data.weatherForecasts;
            }
            catch(GraphQLHttpRequestException e)
            {
                throw new WeatherForecastClientException(e.Content);
            }
        }

        public async Task<WeatherForecastType> GetWeatherForecastByIdAsync(Guid id)
        {
            try
            {
                var response = await GraphQLClient.SendQueryAsync(
                    WeatherForecastQuery.WeatherForecast(id),
                    () => new
                    {
                        weatherForecast = new WeatherForecastType()
                    }
                );

                return response.Data.weatherForecast;
            }
            catch(GraphQLHttpRequestException e)
            {
                throw new WeatherForecastClientException(e.Content);
            }
        }
    }
}
