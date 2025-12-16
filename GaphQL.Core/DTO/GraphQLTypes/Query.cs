using GraphQL.Application.Services;
using GraphQL.Application.UseCases.CleanArchCallChain;
using HotChocolate.Types;

namespace GraphQL.Application.DTO.GraphQLTypes
{
    
    public class Query(ICleanArchGraphQLQuery graphQLUseCase)
    {
        public string SayHello(string greetings="Nilesh") => $"Hello, {greetings}!";

        public string CleanArchitectureQuery(string queryName) =>
            graphQLUseCase.CleanArchitectureQuery(queryName);
    }
}
