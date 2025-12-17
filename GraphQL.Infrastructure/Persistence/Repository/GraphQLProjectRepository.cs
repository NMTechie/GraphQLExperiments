using GraphQL.Application.Services;
using GraphQL.Domain.Aggregates;
using GraphQL.Domain.Entities;
using GraphQL.Infrastructure.Persistence.Sqlserver;
using GreenDonut.Data;
using GraphQL.Common.LeakEFCoreClasses;

namespace GraphQL.Infrastructure.Persistence.Repository
{
    public class GraphQLProjectRepository : IGraphQLProjectRepository
    {
        private readonly ExperimentDbContext _experimentDbContext;
        public GraphQLProjectRepository(ExperimentDbContext experimentDbContext)
        {
            _experimentDbContext = experimentDbContext;
        }
        public List<ProjectAgg> GetProjectsDetails()
        {
            return MapToDomainObejct<ProjectAgg>(_experimentDbContext.Projects.ToList());
        }
        public List<Project> GetProjectsByFilterCriteria(int? organizationId, int? departmentId, QueryContext<Project> querycontext)
        {
            var queryResult = _experimentDbContext.Projects                                                 
                                                 .Where(p =>
                                                  (departmentId == null || p.Dept.DeptId == departmentId) &&
                                                  (organizationId == null || p.Dept.OrgId == organizationId)
                                                 );
            
            return queryResult.Select(querycontext.Selector).ToList();
        }

        private List<T> MapToDomainObejct<T>(List<Project> projects)
        {
            switch (typeof(T).Name)
            {
                case nameof(ProjectAgg):
                    var projectList = new List<ProjectAgg>();
                    foreach (var project in projects)
                    {
                        var projectAgg = new ProjectAgg(project.ProjectCode, project.ProjectName)
                        {
                            // Map other properties as needed
                        };
                        // Map tasks
                        //var tasks = experimentDbContext.Tasks.Where(t => t.ProjectId == project.ProjectId).ToList();
                        foreach (var task in project.Tasks)
                        {
                            var taskEnt = new TaskEnt(task.TaskCode, task.Title, task.Status)
                            {
                                // Map other properties as needed
                            };
                            // Map comments
                            //var comments = experimentDbContext.Comments.Where(c => c.TaskId == task.TaskId).ToList();
                            foreach (var comment in task.Comments)
                            {
                                var commentEnt = new CommentEnt(comment.AuthorName, comment.CommentText);
                                taskEnt.AddComment(commentEnt);
                            }
                            projectAgg.AddTask(taskEnt);
                        }
                        projectList.Add(projectAgg);
                    }
                    return projectList as List<T>;
                default:
                    throw new NotSupportedException($"Mapping for type {typeof(T).Name} is not supported.");
                }
            }
    }
}
