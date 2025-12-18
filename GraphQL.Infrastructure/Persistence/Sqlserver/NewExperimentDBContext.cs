using GraphQL.Domain.Entities;
using GraphQL.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Infrastructure.Persistence.Sqlserver
{
    public class NewExperimentDBContext : DbContext
    {
        public NewExperimentDBContext(DbContextOptions<NewExperimentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommentEntity> Comments { get; set; }

        public virtual DbSet<DepartmentEntity> Departments { get; set; }

        public virtual DbSet<OrganizationEntity> Organizations { get; set; }

        public virtual DbSet<ProjectAggregate> Projects { get; set; }

        public virtual DbSet<TaskEntity> Tasks { get; set; }
    }
}
