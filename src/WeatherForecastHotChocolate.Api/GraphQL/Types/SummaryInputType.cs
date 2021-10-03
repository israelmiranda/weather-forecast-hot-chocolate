using HotChocolate.Types;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Api.GraphQL.Types
{
    public class SummaryInputType : InputObjectType<Summary>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Summary> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(s => s.Description).Type<NonNullType<StringType>>();
        }
    }
}
