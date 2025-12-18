using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Domain.Entities
{
    [Table("organization")]
    public class OrganizationEntity
    {
        [Key]
        [Column("org_id")]
        public int OrgId { get; private set; }
        [Column("org_code")]
        [StringLength(20)]
        [Required]
        public string OrgCode { get; set; }=string.Empty;
        [Column("org_name")]
        [StringLength(100)]
        [Required]
        public string OrgName { get; set; }=string.Empty;
        [Column("founded_on")]
        public DateTime? FoundedOn { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [InverseProperty("Org")]
        public virtual ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();

        // Optionally, could add navigation property for Departments
    }
}
