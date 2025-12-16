using GraphQL.Application.UseCases.Projects;
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
        public string GetProjects() =>
            projectUseCases.GetProjects();
    }
}
