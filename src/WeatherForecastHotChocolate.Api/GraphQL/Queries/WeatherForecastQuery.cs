using System;
using HotChocolate.Types;
using WeatherForecastHotChocolate.Api.GraphQL.Types;
using WeatherForecastHotChocolate.Api.Services;

namespace WeatherForecastHotChocolate.Api.GraphQL.Queries
{
    public class WeatherForecastQuery : ObjectTypeExtension
    {
        private readonly WeatherForecastService _service;

        public WeatherForecastQuery(WeatherForecastService service) => _service = service;

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);

            descriptor
                .Field("weatherForecasts")
                .Type<NonNullType<ListType<NonNullType<WeatherForecastType>>>>()
                .Resolve(async context => await _service.FindAllAsync());

            descriptor
                .Field("weatherForecast")
                .Type<NonNullType<WeatherForecastType>>()
                .Argument("id", w => w.Type<NonNullType<IdType>>())
                .Resolve(async context => await _service.FindByIdAsync(context.ArgumentValue<Guid>("id")));
        }
    }
}
