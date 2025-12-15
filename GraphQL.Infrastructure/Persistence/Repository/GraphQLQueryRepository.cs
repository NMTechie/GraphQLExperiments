using GraphQL.Application.Services;

namespace GraphQL.Infrastructure.Persistence.Repository
{
    public class GraphQLQueryRepository : IGraphQLQueryRepository
    {
        public Task<string> GetQueryAsync(string queryName)
        {
            return Task.FromResult($"The input echoed back as query is {queryName}");
        }
    }
}
