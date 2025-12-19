using GraphQL.Application.UseCases.CleanArchCallChain;
using GraphQL.Application.UseCases.Projects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Application
{
    public static class ApplicationLayerDIRegistry
    {
        public static IServiceCollection AddApplicationLayer(
        this IServiceCollection services,
        IConfiguration configuration)
        {           
            services.AddScoped<ICleanArchGraphQLQuery, CleanArchGraphQLQuery>();
            services.AddScoped<IHandleProjectQueries, HandleProjectQueries>();
            services.AddScoped<IHandleProjectMutations, HandleProjectMutations>();
            services.AddScoped<IProjectDomainHydration, ProjectDomainHydration>();
            return services;
        }
    }
}
