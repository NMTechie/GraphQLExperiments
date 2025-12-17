using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Common.LeakEFCoreClasses;

[Table("task")]
public partial class Task
{
    [Key]
    [Column("task_id")]
    public int TaskId { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("task_code")]
    [StringLength(30)]
    [Unicode(false)]
    public string? TaskCode { get; set; }

    [Column("title")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column("description")]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("status")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("due_date", TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [Column("completed_at", TypeName = "datetime")]
    public DateTime? CompletedAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Task")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [ForeignKey("ProjectId")]
    [InverseProperty("Tasks")]
    public virtual Project Project { get; set; } = null!;
}
