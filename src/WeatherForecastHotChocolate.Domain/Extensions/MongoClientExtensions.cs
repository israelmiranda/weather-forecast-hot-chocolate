using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace WeatherForecastHotChocolate.Domain.Extensions
{
    public static class MongoClientExtensions
    {
        public static IServiceCollection AddMongoClientConfiguration(
           this IServiceCollection services,
           IConfiguration configuration
        ) => services.AddSingleton(_ =>
        {
            var settings = MongoClientSettings.FromUrl(
                new MongoUrl(configuration.GetConnectionString("DatabaseServer"))
            );
            settings.ClusterConfigurator = cb => cb.Subscribe<CommandStartedEvent>(e =>
                Console.WriteLine(e.Command.ToJson())
            );

            return new MongoClient(settings);
        });
    }
}
