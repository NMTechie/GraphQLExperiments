using GraphQL.Application.Services;
using GraphQL.Infrastructure.Persistence.Repository;
using GraphQL.Infrastructure.Persistence.Sqlserver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.Persistence
{
    public static class DIRegistration
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ExperimentDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<NewExperimentDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IGraphQLQueryRepository, GraphQLQueryRepository>();
            services.AddScoped<IGraphQLProjectRepository, GraphQLProjectRepository>();

            return services;
        }
    }
}
