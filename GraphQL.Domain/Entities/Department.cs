using GraphQL.Domain.Aggregates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Domain.Entities
{
    [Table("department")]
    public class DepartmentEntity
    {
        [Key]
        [Column("dept_id")]
        public int DeptId { get; set; }
        [Column("org_id")]
        public int OrgId { get; set; }

        [Column("dept_code")]
        [StringLength(20)]
        public string? DeptCode { get; set; }

        [Column("dept_name")]
        [StringLength(100)]
        public string DeptName { get; set; } = null!;

        [Column("head_email")]
        [StringLength(100)]
        public string? HeadEmail { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("OrgId")]
        [InverseProperty("Departments")]
        public virtual OrganizationEntity Org { get; set; } = null!;

        [InverseProperty("Dept")]
        public virtual ICollection<ProjectAggregate> Projects { get; set; } = new List<ProjectAggregate>();
    }
}
