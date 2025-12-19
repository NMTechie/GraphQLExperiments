using GraphQL.Application.Services;
using GraphQL.Domain.Aggregates;
using GraphQL.Common.LeakEFCoreClasses;
using GreenDonut.Data;
using GraphQL.Application.DTO;

namespace GraphQL.Application.UseCases.Projects
{
    public class HandleProjectQueries(IGraphQLProjectRepository projectRepo) : IHandleProjectQueries
    {
        public List<ProjectAggregate> GetProjects()
        {
            return projectRepo.GetProjectsDetails();
        }
        public IQueryable<ProjectAggregate> GetProjectsDetailsWithNewDBContext()
        {
            return projectRepo.GetProjectsDetailsWithNewDBContext();
        }
        public List<ProjectAggregate> GetProjectsByFilterCriteria(int? organizationId, int? departmentId)
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
        public List<ProjectAggregate> GetProjects();
        public IQueryable<ProjectAggregate> GetProjectsDetailsWithNewDBContext();
        public List<ProjectAggregate> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId);
        public List<Project> GetProjectsByFilterCriteria(int? organizationId, int? DepartmentId, QueryContext<Project> querycontext);
        
    }

    public interface IHandleProjectMutations
    {
        public ProjectAggregate CreateProject(CreateProject project);
    }

    public class HandleProjectMutations(IGraphQLProjectRepository projectRepo,IProjectDomainHydration projectDomainHydration) : IHandleProjectMutations
    {
        public ProjectAggregate CreateProject(CreateProject project)
        {
            return projectRepo.CreateProject(projectDomainHydration.PrepareForPersistance(project));
        }
    }
}
