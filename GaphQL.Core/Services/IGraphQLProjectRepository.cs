using GraphQL.Domain.Aggregates;
using GreenDonut.Data;
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
        public List<ProjectAgg> GetProjectsByFilterCriteria(int? organizationId, int? departmentId, QueryContext<ProjectAgg> querycontext);
    }
}
