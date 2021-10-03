using HotChocolate.Types;
using WeatherForecastHotChocolate.Api.GraphQL.Types;
using WeatherForecastHotChocolate.Api.Services;
using WeatherForecastHotChocolate.Domain.Models;

namespace WeatherForecastHotChocolate.Api.GraphQL.Mutations
{
    public class SummaryMutation : ObjectTypeExtension
    {
        private readonly SummaryService _service;

        public SummaryMutation(SummaryService service) => _service = service;

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Mutation);

            descriptor
                .Field("createSummary")
                .Type<NonNullType<BooleanType>>()
                .Argument("summary", s => s.Type<NonNullType<SummaryInputType>>())
                .Resolve(async context =>
                {
                    await _service.CreateAsync(context.ArgumentValue<Summary>("summary"));

                    return true;
                });
        }
    }
}
