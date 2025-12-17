using GraphQL.Application.Services;
using GraphQL.Domain.Aggregates;
using GraphQL.Domain.Entities;
using GreenDonut.Data;

namespace GraphQL.Application.UseCases.Projects
{
    public class HandleProjectQueries(IGraphQLProjectRepository projectRepo) : IHandleProjectQueries
    {
        public List<ProjectAgg> GetProjects()
        {
            return projectRepo.GetProjectsDetails();
        }

        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? departmentId, QueryContext<OrganizationEnt> querycontext)
        {
            //return projectRepo.GetProjectsByFilterCriteria(organizationId, departmentId,querycontext);
            return projectRepo.GetProjectsDetails();
        }
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? departmentId)
        {
            //return projectRepo.GetProjectsByFilterCriteria(organizationId, departmentId,querycontext);
            return projectRepo.GetProjectsDetails();
        }
    }
    public interface IHandleProjectQueries
    {
        public List<ProjectAgg> GetProjects();
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId, QueryContext<OrganizationEnt> querycontext);
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId);
    }
}
