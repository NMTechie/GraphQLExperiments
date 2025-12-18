using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GraphQL.Domain.Aggregates;

namespace GraphQL.Domain.Entities
{
    [Table("task")]
    public class TaskEntity
    {
        [Key]
        [Column("task_id")]
        public int TaskId { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("task_code")]
        [StringLength(30)]
        public string? TaskCode { get; set; }

        [Column("title")]
        [StringLength(200)]
        public string? Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        [StringLength(30)]
        public string? Status { get; set; }

        [Column("due_date", TypeName = "datetime")]
        public DateTime? DueDate { get; set; }

        [Column("completed_at", TypeName = "datetime")]
        public DateTime? CompletedAt { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty("Task")]
        public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();

        [ForeignKey("ProjectId")]
        [InverseProperty("Tasks")]
        public virtual ProjectAggregate Project { get; set; } = null!;

        public void AddComment(CommentEntity comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            Comments.Add(comment);
        }
    }
}
