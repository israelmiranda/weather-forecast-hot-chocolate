using HotChocolate.Types;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Api.GraphQL.Types
{
    public class SummaryType : ObjectType<Summary>
    {
        protected override void Configure(IObjectTypeDescriptor<Summary> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(s => s.Id);
            descriptor.Field(s => s.Description).Type<NonNullType<StringType>>();;
        }
    }
}
