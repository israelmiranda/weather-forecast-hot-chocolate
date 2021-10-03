using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Domain.Repositories
{
    public interface IRepository<T> where T : AbstractEntity
    {
        IMongoQueryable<T> GetQuery();
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> InsertOneAsync(T entity);
    }
}
