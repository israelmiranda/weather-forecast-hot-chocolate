using GraphQL;
using WeatherForecastHotChocolate.Client.GraphQL.Types;

namespace WeatherForecastHotChocolate.Client.GraphQL.Mutations
{
    public static class SummaryMutation
    {
        public static GraphQLRequest CreateSummary(SummaryInputType summary) =>
            new GraphQLRequest
            {
                Query = @"
                    mutation createSummary($summary: SummaryInput!) {
                        createSummary(summary: $summary)
                    }
                ",
                Variables = new
                {
                    summary,
                },
            };
    }
}
