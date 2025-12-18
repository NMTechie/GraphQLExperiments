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
            /*
             * You need this when you want DI to happen at graphQL querytypes/mutationtypes
             * through constructor injection
             * In graphQL the DI actually happens at the field/resolver level
             * look at the constructors of the root Query vs 
             * ProjectQuery class DI injection at field level
            
            services.AddScoped<ProjectQuery>();
            */
            services.AddScoped<Query>();
            services.AddGraphQLServer()
                .AddProjections()
                .AddSorting()
                .AddFiltering()                                
                .AddQueryType<Query>()
                .AddTypeExtension<ProjectQuery>();
            return services;
        }
    }
    
}
