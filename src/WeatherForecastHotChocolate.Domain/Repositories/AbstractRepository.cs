using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Domain.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly DbContext Context;

        public AbstractRepository(DbContext context) => Context = context;

        public abstract IMongoCollection<T> GetCollection();
        public IMongoQueryable<T> GetQuery() => GetCollection().AsQueryable();
        public async Task<IEnumerable<T>> FindAllAsync() => await GetQuery().ToListAsync();
        public async Task<T> InsertOneAsync(T entity)
        {
            await GetCollection().InsertOneAsync(entity);

            return entity;
        }
    }
}
