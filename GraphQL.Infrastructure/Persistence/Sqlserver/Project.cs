using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Infrastructure.Persistence.Sqlserver;

[Table("project")]
[Index("ProjectCode", Name = "UQ__project__891B3A6FAEF18601", IsUnique = true)]
public partial class Project
{
    [Key]
    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("dept_id")]
    public int DeptId { get; set; }

    [Column("project_code")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ProjectCode { get; set; }

    [Column("project_name")]
    [StringLength(150)]
    [Unicode(false)]
    public string? ProjectName { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("budget", TypeName = "decimal(12, 2)")]
    public decimal? Budget { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("DeptId")]
    [InverseProperty("Projects")]
    public virtual Department Dept { get; set; } = null!;

    [InverseProperty("Project")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
