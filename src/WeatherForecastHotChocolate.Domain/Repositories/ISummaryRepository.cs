using System.Threading.Tasks;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Domain.Repositories
{
    public interface ISummaryRepository : IRepository<Summary>
    {
        Task<string[]> GetAllDescriptionsAsync();
    }
}
