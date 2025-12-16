using GraphQL.Application.Services;
using GraphQL.Application.UseCases.CleanArchCallChain;
using GraphQL.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Presentation.Helper
{
    public static class ApplicationLayerDIRegistry
    {
        public static IServiceCollection AddApplicationLayer1(
        this IServiceCollection services,
        IConfiguration configuration)
        {           
            services.AddScoped<ICleanArchGraphQLQuery, CleanArchGraphQLQuery>();
            return services;
        }
    }
}
