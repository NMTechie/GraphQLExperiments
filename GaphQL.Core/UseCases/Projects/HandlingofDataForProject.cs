using GraphQL.Application.Services;
using GraphQL.Domain.Aggregates;
using GraphQL.Common.LeakEFCoreClasses;
using GreenDonut.Data;

namespace GraphQL.Application.UseCases.Projects
{
    public class HandleProjectQueries(IGraphQLProjectRepository projectRepo) : IHandleProjectQueries
    {
        public List<ProjectAgg> GetProjects()
        {
            return projectRepo.GetProjectsDetails();
        }
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? departmentId)
        {
            return projectRepo.GetProjectsDetails();
        }

        public List<Project> GetProjectsByFilterCriteria(int? organizationId, int? departmentId, QueryContext<Project> querycontext)
        {
            return projectRepo.GetProjectsByFilterCriteria(organizationId, departmentId,querycontext);
        }
        
    }
    public interface IHandleProjectQueries
    {
        public List<ProjectAgg> GetProjects();
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId);
        public List<Project> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId, QueryContext<Project> querycontext);
        
    }
}
