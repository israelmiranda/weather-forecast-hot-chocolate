using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastHotChocolate.Domain.Models;
using WeatherForecastHotChocolate.Domain.Repositories;

namespace WeatherForecastHotChocolate.Api.Services
{
    public class SummaryService
    {
        private readonly ISummaryRepository _repository;

        public SummaryService(ISummaryRepository repository) => _repository = repository;

        public async Task<IEnumerable<Summary>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task CreateAsync(Summary summary)
        {
            await _repository.InsertOneAsync(summary);
        }
    }
}
