using GraphQL.Application.UseCases.CleanArchCallChain;

namespace GraphQL.Presentation.GraphQL.GraphQLTypes
{
    
    public class Query(ICleanArchGraphQLQuery graphQLUseCase)
    {
        public string SayHello(string greetings="Nilesh") => $"Hello, {greetings}!";

        public string CleanArchitectureQuery(string queryName) =>
            graphQLUseCase.CleanArchitectureQuery(queryName);
    }
}
