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
        public static IServiceCollection RegisterGraphQLDependencies(this IServiceCollection services, WebApplicationBuilder builder)
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
                .ModifyRequestOptions(options =>
                {
                    /*Hard disables stacktrace (default is true and if you want env dependency
                     * then use the line below
                     */
                    //options.IncludeExceptionDetails = false; 
                    options.IncludeExceptionDetails = builder.Environment.IsDevelopment();
                })
                .AddProjections()
                .AddSorting()
                .AddFiltering()
                .AddQueryType<Query>()
                .AddTypeExtension<ProjectQuery>()
                .AddMutationType<ProjectMutation>();
            /* The below two lines actually impacts the schema
             * if you want to have some conventions (like Error<T> attributes for queries and mutations
             * However this seems to be not working with the latest hotchocolate version
             * as per the flexibility that would occur in practical projects
             * look at the ProjectMutation class where I have used Error<T> attribute by enabling the line
             * and check the schema generated
             */
            //.AddQueryConventions()
            //.AddMutationConventions(applyToAllMutations: true);
            return services;
        }
    }
    
}
