using System;
using GraphQL;

namespace WeatherForecastHotChocolate.Client.GraphQL.Queries
{
    public static class WeatherForecastQuery
    {
        public static GraphQLRequest WeatherForecasts() =>
            new GraphQLRequest
            {
                Query = @"
                    query {
                        weatherForecasts {
                            id
                            date
                            temperatureC
                            temperatureF
                            summary
                        }
                    }
                ",
            };

        public static GraphQLRequest WeatherForecast(Guid id) =>
            new GraphQLRequest
            {
                Query = @"
                    query($id: ID!) {
                        weatherForecast(id: $id) {
                            id
                            date
                            temperatureC
                            temperatureF
                            summary
                        }
                    }
                ",
                Variables = new
                {
                    id
                },
            };
    }
}
