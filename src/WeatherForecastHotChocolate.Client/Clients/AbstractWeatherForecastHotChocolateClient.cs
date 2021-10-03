using GraphQL.Client.Abstractions;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Headers;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace WeatherForecastHotChocolate.Client.Clients
{
    public class AbstractWeatherForecastHotChocolateClient
    {
        protected readonly HttpClient HttpClient;
        protected readonly IGraphQLClient GraphQLClient;

        public AbstractWeatherForecastHotChocolateClient(HttpClient httpClient, IConfiguration configuration)
        {
            HttpClient = httpClient;

            HttpClient.BaseAddress = new Uri(configuration["WeatherForecastHotChocolateApi:BaseUrl"]);
            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(configuration["WeatherForecastHotChocolateApi:AuthToken"]
            );

            GraphQLClient = new GraphQLHttpClient(
                new GraphQLHttpClientOptions
                {
                    EndPoint = new Uri($"{HttpClient.BaseAddress}graphql"),
                },
                new SystemTextJsonSerializer(),
                HttpClient
            );
        }
    }
}
