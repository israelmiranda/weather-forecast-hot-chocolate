using System;

namespace WeatherForecastHotChocolate.Client.GraphQL.Types
{
    public class SummaryType
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
