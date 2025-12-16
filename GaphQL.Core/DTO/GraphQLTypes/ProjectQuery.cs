using GraphQL.Application.UseCases.Projects;
using GraphQL.Domain.Aggregates;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Application.DTO.GraphQLTypes
{
    [ExtendObjectType(typeof(Query))]
    public class ProjectQuery(IHandleProjectQueries projectUseCases)
    {
        public List<ProjectAgg> GetProjects() =>
            projectUseCases.GetProjects();
        public List<ProjectAgg> GetProjectsWithFilter(int? organizationId,int? DepartmentId) =>
            projectUseCases.GetProjectsByFilterCriteria(organizationId,DepartmentId);
    }
}
