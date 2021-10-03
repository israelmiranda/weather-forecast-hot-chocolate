using GraphQL;

namespace WeatherForecastHotChocolate.Client.GraphQL.Queries
{
    public static class SummaryQuery
    {
        public static GraphQLRequest Summaries() =>
            new GraphQLRequest
            {
                Query = @"
                    query {
                        summaries {
                            id
                            description
                        }
                    }
                ",
            };
    }
}
