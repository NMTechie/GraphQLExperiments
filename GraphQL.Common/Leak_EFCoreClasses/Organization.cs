using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Common.LeakEFCoreClasses;

[Table("organization")]
[Index("OrgCode", Name = "UQ__organiza__68B12E5C51A336A8", IsUnique = true)]
public partial class Organization
{
    [Key]
    [Column("org_id")]
    public int OrgId { get; set; }

    [Column("org_code")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrgCode { get; set; } = null!;

    [Column("org_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string OrgName { get; set; } = null!;

    [Column("founded_on")]
    public DateOnly? FoundedOn { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Org")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
