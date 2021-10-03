using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastHotChocolate.Client.GraphQL.Types;

namespace WeatherForecastHotChocolate.Client.Clients.Summaries
{
    public interface ISummaryClient
    {
        Task<IEnumerable<SummaryType>> GetSummariesAsync();
        Task CreateSummaryAsync(SummaryInputType summary);
    }
}
