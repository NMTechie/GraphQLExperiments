using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.Entities
{
    public class OrganizationEnt
    {
        public int OrgId { get; private set; }
        public string OrgCode { get; private set; }
        public string OrgName { get; private set; }
        public DateTime? FoundedOn { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Optionally, could add navigation property for Departments
    }
}
