using MongoDB.Driver;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Domain.Repositories
{
    public class WeatherForecastRepository : AbstractRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(DbContext context) : base(context) { }

        public override IMongoCollection<WeatherForecast> GetCollection()
        {
            return Context.WeatherForecasts;
        }
    }
}
