using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Infrastructure.Persistence.Sqlserver;

[Table("department")]
public partial class Department
{
    [Key]
    [Column("dept_id")]
    public int DeptId { get; set; }

    [Column("org_id")]
    public int OrgId { get; set; }

    [Column("dept_code")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DeptCode { get; set; }

    [Column("dept_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string DeptName { get; set; } = null!;

    [Column("head_email")]
    [StringLength(100)]
    [Unicode(false)]
    public string? HeadEmail { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("OrgId")]
    [InverseProperty("Departments")]
    public virtual Organization Org { get; set; } = null!;

    [InverseProperty("Dept")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
