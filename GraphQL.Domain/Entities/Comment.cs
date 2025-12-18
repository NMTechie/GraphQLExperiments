using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.Entities
{
    [Table("comment")]
    public class CommentEntity
    {
        [Key]
        [Column("comment_id")]
        public int CommentId { get; set; }

        [Column("task_id")]
        public int TaskId { get; set; }

        [Column("author_name")]
        [StringLength(100)]
        public string? AuthorName { get; set; }

        [Column("comment_text")]
        public string? CommentText { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Comments")]
        public virtual TaskEntity Task { get; set; } = null!;
    }
}
