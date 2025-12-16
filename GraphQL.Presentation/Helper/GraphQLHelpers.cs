using GraphQL.Application.DTO.GraphQLTypes;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Presentation.Helper
{
    public static class GraphQLHelpers
    {        
        public static IRequestExecutorBuilder RegisterGraphQLTypes(this IRequestExecutorBuilder grapgQLBuilder)
        {            
            grapgQLBuilder.AddQueryType<Query>().AddTypeExtension<ProjectQuery>();
            return grapgQLBuilder;
        }
    }
    
}
