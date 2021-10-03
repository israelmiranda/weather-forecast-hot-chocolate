using HotChocolate.Types;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Api.GraphQL.Types
{
    public class WeatherForecastType : ObjectType<WeatherForecast>
    {
        protected override void Configure(IObjectTypeDescriptor<WeatherForecast> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(wf => wf.Id);
            descriptor.Field(wf => wf.Date);
            descriptor.Field(wf => wf.TemperatureC);
            descriptor.Field(wf => wf.TemperatureF);
            descriptor.Field(wf => wf.Summary).Type<NonNullType<StringType>>();
        }
    }
}
