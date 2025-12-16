using GraphQL.Presentation.GraphQL.GraphQLTypes;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Presentation.GraphQL
{
    public static class GraphQLRegistration
    {        
        public static IRequestExecutorBuilder RegisterGraphQLTypes(this IRequestExecutorBuilder grapgQLBuilder)
        {            
            grapgQLBuilder.AddQueryType<Query>().AddTypeExtension<ProjectQuery>();
            return grapgQLBuilder;
        }
        public static IServiceCollection RegisterGraphQLDependencies(this IServiceCollection services)
        {
            services.AddScoped<Query>();
            services.AddScoped<ProjectQuery>();
            services.AddGraphQLServer().AddQueryType<Query>().AddTypeExtension<ProjectQuery>();
            return services;
        }
    }
    
}
