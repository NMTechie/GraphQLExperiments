using GraphQL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.CleanArchCallChain
{
    public class CleanArchGraphQLQuery(IGraphQLQueryRepository repo) : ICleanArchGraphQLQuery
    {
        public string CleanArchitectureQuery(string queryName)
        {
            return repo.GetQueryAsync(queryName).GetAwaiter().GetResult();
        }
    }
    public interface ICleanArchGraphQLQuery
    {
        string CleanArchitectureQuery(string queryName);
    }
}
