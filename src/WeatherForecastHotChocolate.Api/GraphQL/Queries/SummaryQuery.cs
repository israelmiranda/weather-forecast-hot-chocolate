using HotChocolate.Types;
using WeatherForecastHotChocolate.Api.GraphQL.Types;
using WeatherForecastHotChocolate.Api.Services;

namespace WeatherForecastHotChocolate.Api.GraphQL.Queries
{
    public class SummaryQuery : ObjectTypeExtension
    {
        private readonly SummaryService _service;

        public SummaryQuery(SummaryService service) => _service = service;

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);

            descriptor
                .Field("summaries")
                .Type<NonNullType<ListType<NonNullType<SummaryType>>>>()
                .Resolve(async context => await _service.FindAllAsync());
        }
    }
}
