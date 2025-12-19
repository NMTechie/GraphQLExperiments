using GraphQL.Application.DTO;
using GraphQL.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Projects
{
    public interface IProjectDomainHydration
    {
        public ProjectAggregate PrepareForPersistance(CreateProject createProject);        
    }

    public class ProjectDomainHydration : IProjectDomainHydration
    {
        public ProjectAggregate PrepareForPersistance(CreateProject createProject)
        {
            ProjectAggregate projectAggregate = new ProjectAggregate()
            {
                DeptId = createProject.DeptId,
                ProjectCode = createProject.ProjectCode,
                ProjectName = createProject.ProjectName,
                StartDate = createProject.StartDate,
                EndDate = createProject.EndDate,
                Budget = createProject.Budget,
                CreatedAt = DateTime.UtcNow
            };
            return projectAggregate;
        }
    }
}
