using GraphQL.Application.Services;
using GraphQL.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return projectRepo.GetProjectsByFilterCriteria(organizationId, departmentId);
        }
    }
    public interface IHandleProjectQueries
    {
        public List<ProjectAgg> GetProjects();
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId);
    }
}
