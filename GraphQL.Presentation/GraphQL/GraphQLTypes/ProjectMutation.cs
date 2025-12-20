using GraphQL.Application.DTO;
using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;

namespace GraphQL.Presentation.GraphQL.GraphQLTypes
{
    
    public class ProjectMutation
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectMutation(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        //[Error<GraphQLMyAppExceptions>()]
        public ProjectAggregate CreateProject(CreateProject project, IHandleProjectMutations projectMutations)
        {
            return projectMutations.CreateProject(project);
        }
        
        public ProjectAggregate UpdateProject(UpdateProject project, IHandleProjectMutations projectMutations)
        {
            try
            {
                return projectMutations.UpdateProject(project.ProjectId);

            }
            catch (Exception ex)
            {
                if(_webHostEnvironment.IsDevelopment())
                {
                    throw;
                }
                throw new GraphQLException(ex.Message,ex);
            }
            
        }
        public ProjectAggregate DeleteProject(int projectId, IHandleProjectMutations projectMutations)
        {
            return new ProjectAggregate();
        }
    }
}
