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
        public List<ProjectAggregate> GetProjects(IHandleProjectQueries projectUseCases) =>
            projectUseCases.GetProjects();

        [UseFiltering]
        public List<Project> GetProjectsWithFilter(int? organizationId,int? departmentId, 
                                                      IHandleProjectQueries projectUseCases,
                                                      QueryContext<Project> queryContext) =>            
            projectUseCases.GetProjectsByFilterCriteria(organizationId, departmentId, queryContext);


        [UseProjection]
        [UseFiltering]
        [UseSorting]        
        public IQueryable<ProjectAggregate> GetProjectsWithNewDBContext(int? organizationId, int? departmentId,
                                                      IHandleProjectQueries projectUseCases)=>
            projectUseCases.GetProjectsDetailsWithNewDBContext();
    }
}
