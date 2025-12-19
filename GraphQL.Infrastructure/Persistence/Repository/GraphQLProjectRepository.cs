using GraphQL.Application.Services;
using GraphQL.Domain.Aggregates;
using GraphQL.Domain.Entities;
using GraphQL.Infrastructure.Persistence.Sqlserver;
using GreenDonut.Data;
using GraphQL.Common.LeakEFCoreClasses;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Infrastructure.Persistence.Repository
{
    public class GraphQLProjectRepository : IGraphQLProjectRepository
    {
        private readonly ExperimentDbContext _experimentDbContext;
        private readonly NewExperimentDBContext _newExperimentDbContext;
        public GraphQLProjectRepository(ExperimentDbContext experimentDbContext,NewExperimentDBContext newExperimentDBContext)
        {
            _experimentDbContext = experimentDbContext;
            _newExperimentDbContext = newExperimentDBContext;
        }
        public List<ProjectAggregate> GetProjectsDetails()
        {
            return MapToDomainObejct<ProjectAggregate>(_experimentDbContext.Projects.ToList());
        }
        public List<Project> GetProjectsByFilterCriteria(int? organizationId, int? departmentId, QueryContext<Project> queryContext)
        {
            var queryResult = _experimentDbContext.Projects                                                 
                                                 .Where(p =>
                                                  (departmentId == null || p.Dept.DeptId == departmentId) &&
                                                  (organizationId == null || p.Dept.OrgId == organizationId)
                                                 ).With(queryContext);

            return queryResult.ToList();
        }
        public IQueryable<ProjectAggregate> GetProjectsDetailsWithNewDBContext()
        {
            return _newExperimentDbContext.Projects.AsQueryable();
        }

        #region WriteOperations
        public ProjectAggregate CreateProject(ProjectAggregate project)
        {
            _newExperimentDbContext.Projects.Add(project);
            _newExperimentDbContext.SaveChanges();
            /*After SaveChanges , ProjectId will be populated
             * to have all the fields in ProjectAggregate populated,
             * with related entities, we can fetch the project again from DB
            */
            return _newExperimentDbContext.Projects
                                          .AsNoTracking()
                                          .Include(p => p.Dept)
                                          .Include(p => p.Tasks)
                                          .ThenInclude(t => t.Comments)
                                          .First(p => p.ProjectId == project.ProjectId);
        }
        #endregion

        private List<T> MapToDomainObejct<T>(List<Project> projects)
        {
            switch (typeof(T).Name)
            {
                case nameof(ProjectAggregate):
                    var projectList = new List<ProjectAggregate>();
                    foreach (var project in projects)
                    {
                        var projectAgg = new ProjectAggregate
                        {
                            // Map other properties as needed
                            ProjectName = project.ProjectName,
                            StartDate = project.StartDate??DateOnly.FromDateTime(DateTime.Now.Date),
                            EndDate = project.EndDate
                        };
                        // Map tasks
                        //var tasks = experimentDbContext.Tasks.Where(t => t.ProjectId == project.ProjectId).ToList();
                        foreach (var task in project.Tasks)
                        {
                            var taskEnt = new TaskEntity
                            {
                                // Map other properties as needed
                            };
                            // Map comments
                            //var comments = experimentDbContext.Comments.Where(c => c.TaskId == task.TaskId).ToList();
                            foreach (var comment in task.Comments)
                            {
                                var commentEnt = new CommentEntity()
                                {
                                    // Map other properties as needed
                                };
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
