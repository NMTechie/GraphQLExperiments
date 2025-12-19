using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;
using GraphQL.Common.LeakEFCoreClasses;
using GreenDonut.Data;
using HotChocolate.Data.Filters;

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
        [UseFiltering<ProjectAggregateFilterInputType>]
        [UseSorting]        
        public IQueryable<ProjectAggregate> GetProjectsWithNewDBContext(
                                                      IHandleProjectQueries projectUseCases)=>
            projectUseCases.GetProjectsDetailsWithNewDBContext();
    }

    public class ProjectAggregateFilterInputType : FilterInputType<ProjectAggregate>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ProjectAggregate> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(p => p.ProjectId);
            descriptor.Field(p => p.ProjectCode);
            descriptor.Field(p => p.DeptId);
        }

    }
}
