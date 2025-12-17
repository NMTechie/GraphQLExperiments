using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;
using GraphQL.Domain.Entities;
using GraphQL.Infrastructure.Persistence.Sqlserver;
using GreenDonut.Data;

namespace GraphQL.Presentation.GraphQL.GraphQLTypes
{
    [ExtendObjectType(typeof(Query))]
    //public class ProjectQuery(IHandleProjectQueries projectUseCases)
    public class ProjectQuery()
    {
        public List<ProjectAgg> GetProjects(IHandleProjectQueries projectUseCases) =>
            projectUseCases.GetProjects();
        public List<ProjectAgg> GetProjectsWithFilter(int? organizationId,int? DepartmentId, 
                                                      IHandleProjectQueries projectUseCases,
                                                      QueryContext<int> queryContext) =>
            projectUseCases.GetProjectsByFilterCriteria(organizationId,DepartmentId);
    }
}
