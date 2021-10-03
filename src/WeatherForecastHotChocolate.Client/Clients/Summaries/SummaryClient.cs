using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GraphQL.Client.Abstractions;
using WeatherForecastHotChocolate.Client.GraphQL.Mutations;
using WeatherForecastHotChocolate.Client.GraphQL.Queries;
using WeatherForecastHotChocolate.Client.GraphQL.Types;
using GraphQL.Client.Http;
using WeatherForecastHotChocolate.Client.Exceptions;

namespace WeatherForecastHotChocolate.Client.Clients.Summaries
{
    public class SummaryClient : AbstractWeatherForecastHotChocolateClient, ISummaryClient
    {
        public SummaryClient(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration) { }

        public async Task<IEnumerable<SummaryType>> GetSummariesAsync()
        {
            try
            {
                var response = await GraphQLClient.SendQueryAsync(
                    SummaryQuery.Summaries(),
                    () => new
                    {
                        summaries = new List<SummaryType>()
                    }
                );

                return response.Data.summaries;
            }
            catch(GraphQLHttpRequestException e)
            {
                throw new SummaryClientException(e.Content);
            }
        }

        public async Task CreateSummaryAsync(SummaryInputType summary)
        {
            try
            {
                var response = await GraphQLClient.SendMutationAsync(
                    SummaryMutation.CreateSummary(summary),
                    () => new { }
                );
            }
            catch(GraphQLHttpRequestException e)
            {
                throw new SummaryClientException(e.Content);
            }
        }
    }
}
