using System;

namespace WeatherForecastHotChocolate.Client.GraphQL.Types
{
    public class WeatherForecastType
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
