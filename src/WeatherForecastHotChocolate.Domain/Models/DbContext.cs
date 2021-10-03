using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace WeatherForecastHotChocolate.Domain.Models
{
    public class DbContext
    {
        public DbContext(IMongoDatabase database) => Database = database;

        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<WeatherForecast> WeatherForecasts =>
            Database.GetCollection<WeatherForecast>("WeatherForecasts");
        public IMongoCollection<Summary> Summaries =>
            Database.GetCollection<Summary>("Summaries");

        public static void ConfigureMongoDbSerialization()
        {
            var conventions = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String),
                new IgnoreIfNullConvention(true),
                new IgnoreExtraElementsConvention(true),
            };

            ConventionRegistry.Register("MongoConvention", conventions, _ => true);
            BsonSerializer.RegisterIdGenerator(typeof(Guid), CombGuidGenerator.Instance);
        }
    }
}
