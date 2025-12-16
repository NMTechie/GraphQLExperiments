using GraphQL.Application.UseCases.AboutTask;
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
    public class ProjectQuery(IHandlingofDataForProject projectUseCases)
    {
        public string GetProjects() =>
            projectUseCases.GetProjects();
    }
}
