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
            services.AddScoped<ProjectMutation>();
            /*The above scoped resgistration for graphQL types is required for each top level types
            Query is my top level type [it is a querytype] and ProjectQuery is annotated as [ExtendObjectType(typeof(Query))]
            thus ProjectQuery type is not added as AddScoped
            However look at the ProjectMutation, it is itself a root type thus registering it as AddScoped
            if I have another mutation as extendedobject typeof ProjectMutation then that was not needed as AddScoped
            ****** Also the root type does not required to be decorated with attributes like [QueryType] or [MutationType]
            */
            services.AddGraphQLServer()
                .AddProjections()
                .AddSorting()
                .AddFiltering()                                
                .AddQueryType<Query>()                
                .AddTypeExtension<ProjectQuery>()
                .AddMutationType<ProjectMutation>();
            return services;
        }
    }
    
}
