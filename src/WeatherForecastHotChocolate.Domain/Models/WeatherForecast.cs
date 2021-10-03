using System;

namespace WeatherForecastHotChocolate.Domain.Models
{
    public class WeatherForecast : AbstractEntity
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
        public string Summary { get; set; }
    }
}
