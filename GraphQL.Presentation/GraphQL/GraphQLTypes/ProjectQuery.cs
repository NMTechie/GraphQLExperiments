using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;

namespace GraphQL.Presentation.GraphQL.GraphQLTypes
{
    [ExtendObjectType(typeof(Query))]
    public class ProjectQuery(IHandleProjectQueries projectUseCases)
    {
        public List<ProjectAgg> GetProjects() =>
            projectUseCases.GetProjects();
        public List<ProjectAgg> GetProjectsWithFilter(int? organizationId,int? DepartmentId) =>
            projectUseCases.GetProjectsByFilterCriteria(organizationId,DepartmentId);
    }
}
