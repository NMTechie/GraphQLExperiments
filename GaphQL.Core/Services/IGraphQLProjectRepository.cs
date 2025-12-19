using GraphQL.Domain.Aggregates;
using GreenDonut.Data;
using GraphQL.Common.LeakEFCoreClasses;

namespace GraphQL.Application.Services
{
    public interface IGraphQLProjectRepository
    {
        public List<ProjectAggregate> GetProjectsDetails();
        public List<Project> GetProjectsByFilterCriteria(int? organizationId, int? departmentId, QueryContext<Project> querycontext);
        public IQueryable<ProjectAggregate> GetProjectsDetailsWithNewDBContext();
        public ProjectAggregate CreateProject(ProjectAggregate project);
    }
}
