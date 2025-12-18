using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;
using GraphQL.Common.LeakEFCoreClasses;
using GreenDonut.Data;

namespace GraphQL.Presentation.GraphQL.GraphQLTypes
{
    [ExtendObjectType(typeof(Query))]
    //public class ProjectQuery(IHandleProjectQueries projectUseCases)
    public class ProjectQuery()
    {
        public List<ProjectAgg> GetProjects(IHandleProjectQueries projectUseCases) =>
            projectUseCases.GetProjects();
        [UseFiltering]
        public List<Project> GetProjectsWithFilter(int? organizationId,int? departmentId, 
                                                      IHandleProjectQueries projectUseCases,
                                                      QueryContext<Project> queryContext) =>            
            projectUseCases.GetProjectsByFilterCriteria(organizationId, departmentId, queryContext);
    }
}
