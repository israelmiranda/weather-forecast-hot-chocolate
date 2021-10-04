using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecastHotChocolate.Domain.Extensions;
using WeatherForecastHotChocolate.Api.Extensions;
using WeatherForecastHotChocolate.Domain.Models;
using HotChocolate.Types;
using WeatherForecastHotChocolate.Api.GraphQL.Queries;
using WeatherForecastHotChocolate.Api.GraphQL.Mutations;

namespace WeatherForecastHotChocolate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DbContext.ConfigureMongoDbSerialization();

            services
                .AddLogging(configure =>
                {
                    configure
                        .AddConfiguration(Configuration.GetSection("Logging"))
                        .AddConsole();
                })
                .AddAuthorizationContext(Configuration)
                .AddMongoClientConfiguration(Configuration)
                .AddDbContext(Configuration)
                .AddRepositories()
                .AddServices();

            services
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                    .AddTypeExtension<SummaryQuery>()
                    .AddTypeExtension<WeatherForecastQuery>()
                .AddMutationType(m => m.Name("Mutation"))
                    .AddTypeExtension<SummaryMutation>()
                    .AddTypeExtension<WeatherForecastMutation>()
                .AddType(new UuidType('D'));
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
        }
    }
}
