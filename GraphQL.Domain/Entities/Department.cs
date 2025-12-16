using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.Entities
{
    public class DepartmentEnt
    {
        public int DeptId { get; private set; }
        public string DeptCode { get; private set; }
        public string DeptName { get; private set; }
        public string HeadEmail { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Optionally, could add navigation property for Projects
    }
}
