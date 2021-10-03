using HotChocolate.Types;
using WeatherForecastHotChocolate.Api.Services;

namespace WeatherForecastHotChocolate.Api.GraphQL.Mutations
{
    public class WeatherForecastMutation : ObjectTypeExtension
    {
        private readonly WeatherForecastService _service;

        public WeatherForecastMutation(WeatherForecastService service) => _service = service;

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Mutation);

            descriptor
                .Field("createWeatherForecast")
                .Type<NonNullType<BooleanType>>()
                .Resolve(async context =>
                {
                    await _service.CreateAsync();

                    return true;
                });
        }
    }
}
