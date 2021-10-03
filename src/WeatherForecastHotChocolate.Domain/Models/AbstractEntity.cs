using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherForecastHotChocolate.Domain.Models
{
    public abstract class AbstractEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
    }
}
