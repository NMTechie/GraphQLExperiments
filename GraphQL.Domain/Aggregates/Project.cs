using GraphQL.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Domain.Aggregates
{
    [Table("project")]
    public class ProjectAggregate
    {
        [Key]
        [Column("project_id")]        
        public int? ProjectId { get; set; }

        [Column("dept_id")]
        public int DeptId { get; set; }

        [Column("project_code")]
        [StringLength(30)]
        public string ProjectCode { get; set; }

        [Column("project_name")]
        [StringLength(150)]
        public string ProjectName { get; set; }

        [Column("start_date")]
        public DateOnly StartDate { get; set; }

        [Column("end_date")]
        public DateOnly? EndDate { get; set; }

        [Column("budget", TypeName = "decimal(12, 2)")]
        public decimal? Budget { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("DeptId")]
        [InverseProperty("Projects")]
        public virtual DepartmentEntity? Dept { get; set; } = null!;

        [InverseProperty("Project")]
        public virtual ICollection<TaskEntity>? Tasks { get; set; } = new List<TaskEntity>();

        public void AddTask(TaskEntity task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            Tasks?.Add(task);
        }

        public ProjectAggregate PrepareForPersistance()
        {
            this.CreatedAt = DateTime.Now;
            return this;
        }
    }
}
