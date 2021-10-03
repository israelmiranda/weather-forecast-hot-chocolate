using System;

namespace WeatherForecastHotChocolate.Client.Exceptions
{
    public class WeatherForecastClientException : Exception
    {
        public WeatherForecastClientException(string message) : base(message) { }
    }
}
