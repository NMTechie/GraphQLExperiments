using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Common.LeakEFCoreClasses;

[Table("comment")]
public partial class Comment
{
    [Key]
    [Column("comment_id")]
    public int CommentId { get; set; }

    [Column("task_id")]
    public int TaskId { get; set; }

    [Column("author_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? AuthorName { get; set; }

    [Column("comment_text")]
    [Unicode(false)]
    public string? CommentText { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("TaskId")]
    [InverseProperty("Comments")]
    public virtual Task Task { get; set; } = null!;
}
