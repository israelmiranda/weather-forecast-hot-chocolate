using System;

namespace WeatherForecastHotChocolate.Client.Exceptions
{
    public class SummaryClientException : Exception
    {
        public SummaryClientException(string message) : base(message) { }
    }
}
