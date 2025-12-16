using GraphQL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Projects
{
    public class HandleProjectQueries(IGraphQLProjectRepository projectRepo) : IHandleProjectQueries
    {
        public string GetProjects()
        {
            return projectRepo.GetProjectsDetails().ToString();
        }
    }
    public interface IHandleProjectQueries
    {
        public string GetProjects();
    }
}
