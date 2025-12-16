using GraphQL.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Application.Services
{
    public interface IGraphQLProjectRepository
    {
        public List<ProjectAgg> GetProjectsDetails();
    }
}
