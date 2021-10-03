using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Domain.Repositories
{
    public class SummaryRepository : AbstractRepository<Summary>, ISummaryRepository
    {
        public SummaryRepository(DbContext context) : base(context) { }

        public override IMongoCollection<Summary> GetCollection()
        {
            return Context.Summaries;
        }

        public async Task<string[]> GetAllDescriptionsAsync()
        {
            var summaries = await FindAllAsync();
            return summaries.Select(s => s.Description).ToArray();
        }
    }
}
