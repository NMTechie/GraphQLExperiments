using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;

namespace GraphQL.Presentation.GraphQL.GraphQLTypes
{
    
    public class ProjectMutation
    {
        public ProjectAggregate CreateProject(ProjectAggregate project, IHandleProjectMutations projectMutations)
        {
            return projectMutations.CreateProject(project);
        }
        public ProjectAggregate UpdateProject(ProjectAggregate project, IHandleProjectMutations projectMutations)
        {
            return projectMutations.CreateProject(project);
        }
        public ProjectAggregate DeleteProject(int projectId, IHandleProjectMutations projectMutations)
        {
            return projectMutations.CreateProject(new ProjectAggregate());
        }
    }
}
