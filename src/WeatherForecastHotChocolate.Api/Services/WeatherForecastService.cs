using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IronSnappy;
using StackExchange.Redis;
using WeatherForecastHotChocolate.Domain.Models;
using WeatherForecastHotChocolate.Domain.Repositories;

namespace WeatherForecastHotChocolate.Api.Services
{
    public class WeatherForecastService
    {
        private readonly IDatabase _redis;
        private readonly IWeatherForecastRepository _repository;
        private readonly ISummaryRepository _summaryRepository;

        public WeatherForecastService(
            ConnectionMultiplexer conn,
            IWeatherForecastRepository repository,
            ISummaryRepository summaryRepository
        )
        {
            _redis = conn.GetDatabase();
            _repository = repository;
            _summaryRepository = summaryRepository;
        }

        public async Task<IEnumerable<WeatherForecast>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task CreateAsync()
        {
            var weatherForecast = await BuildAsync();

            var json = weatherForecast.ToJson();
            var jsonByte = System.Text.Encoding.UTF8.GetBytes(json);
            var compressed = Snappy.Encode(jsonByte);

            await _repository.InsertOneAsync(weatherForecast);
            await _redis.StringSetAsync($"weatherforecast:weatherforecast:{weatherForecast.Id}", compressed);
        }

        private async Task<WeatherForecast> BuildAsync()
        {
            var rng = new Random();
            var summaries = await _summaryRepository.GetAllDescriptionsAsync();
            return Enumerable.Range(1, 7).Select(index => new WeatherForecast
            {
                Date = DateTime.SpecifyKind(DateTime.Today.AddDays(index - 1), DateTimeKind.Utc),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            })
            .First();
        }

        public async Task<WeatherForecast> FindByIdAsync(Guid id)
        {
            var redisValue = await _redis.StringGetAsync($"weatherforecast:weatherforecast:{id}");
            var bytes = (byte[]) redisValue;
            var uncompressed = Snappy.Decode(bytes);
            var result = System.Text.Encoding.UTF8.GetString(uncompressed);

            return result.FromJson<WeatherForecast>();
        }
    }

    public static class JsonSerializerExtensions
    {
        public static string ToJson(this object request)
        {
            return JsonSerializer.Serialize(request,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter() }
                });
        }

        public static T FromJson<T>(this string request)
        {
            return JsonSerializer.Deserialize<T>(request,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                });
        }
    }
}
