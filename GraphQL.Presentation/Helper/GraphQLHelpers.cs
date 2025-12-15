using GraphQL.Application.DTO.GraphQLTypes;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Presentation.Helper
{
    public static class GraphQLHelpers
    {        
        public static IRequestExecutorBuilder RegisterGraphQLTypes(this IRequestExecutorBuilder value)
        {
            IRequestExecutorBuilder var = value;            
            var.AddType<Query>();
            return value;
        }
    }
    
}
