using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Linq;
using Snapshooter.Xunit;
using WeatherForecastHotChocolate.Api.GraphQL.Queries;
using WeatherForecastHotChocolate.Api.GraphQL.Types;
using WeatherForecastHotChocolate.Api.Services;
using WeatherForecastHotChocolate.Domain.Models;
using WeatherForecastHotChocolate.Domain.Repositories;
using Xunit;

namespace WeatherForecastHotChocolate.Api.Tests.GraphQL.Queries.Summaries
{
    public class SummaryQueryGetSummariesAsyncTest
    {
        [Fact]
        public async Task Get_Summary_Schema_Async()
        {
            // arrange
            // act
            var schema = await new ServiceCollection()
                .AddScoped<ISummaryRepository, SummaryRepositoryStub>()
                .AddScoped<SummaryService>()
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                    .AddTypeExtension<SummaryQuery>()
                .AddType<SummaryType>()
                .BuildSchemaAsync();

            // assert
            schema.Print().MatchSnapshot();
        }

        [Fact]
        public async Task Get_Summaries_Returns_Async()
        {
            // arrange
            var executor = await new ServiceCollection()
                .AddScoped<ISummaryRepository, SummaryRepositoryStub>()
                .AddScoped<SummaryService>()
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                    .AddTypeExtension<SummaryQuery>()
                .AddType<SummaryType>()
                .BuildRequestExecutorAsync();

            // act
            var result = await executor.ExecuteAsync(@"
                    query {
                        summaries {
                            id
                            description
                        }
                    }
                ");

            // assert
            Snapshot.Match(result.ToJson(), matchOptions => matchOptions.IgnoreField("data.summaries[*].id"));
        }
    }

    public class SummaryRepositoryStub : ISummaryRepository
    {
        public async Task<IEnumerable<Summary>> FindAllAsync()
        {
            await Task.CompletedTask;

            return new List<Summary>
            {
                new Summary
                {
                    Id = Guid.NewGuid(),
                    Description = "SummaryTest",
                },
            };
        }

        public async Task<string[]> GetAllDescriptionsAsync()
        {
            await Task.CompletedTask;

            return new List<string>().ToArray();
        }

        public IMongoQueryable<Summary> GetQuery()
        {
            throw new NotImplementedException();
        }

        public Task<Summary> InsertOneAsync(Summary entity)
        {
            throw new NotImplementedException();
        }
    }
}
