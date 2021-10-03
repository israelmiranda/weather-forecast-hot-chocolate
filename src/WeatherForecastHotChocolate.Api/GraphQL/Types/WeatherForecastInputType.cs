using HotChocolate.Types;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Api.GraphQL.Types
{
    public class WeatherForecastInputType : InputObjectType<WeatherForecast>
    {
        protected override void Configure(IInputObjectTypeDescriptor<WeatherForecast> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(w => w.Date).Type<NonNullType<DateTimeType>>();
            descriptor.Field(w => w.TemperatureC);
            descriptor.Field(w => w.Summary);
        }
    }
}
