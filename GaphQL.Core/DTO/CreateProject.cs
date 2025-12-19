using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Application.DTO
{
    public class CreateProject
    {   
        public int DeptId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public decimal? Budget { get; set; }
    }
}
