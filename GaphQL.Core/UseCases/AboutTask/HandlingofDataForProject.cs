using GraphQL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.AboutTask
{
    public class HandlingofDataForProject(IGraphQLProjectRepository projectRepo) : IHandlingofDataForProject
    {
        public string GetProjects()
        {
            return projectRepo.GetProjectsDetails().ToString();
        }
    }
    public interface IHandlingofDataForProject
    {
        public string GetProjects();
    }
}
