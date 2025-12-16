using GraphQL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.Aggregates
{
    public class ProjectAgg
    {
        public int ProjectId { get; private set; }
        public string ProjectCode { get; private set; }
        public string ProjectName { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public decimal? Budget { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Aggregate: A project contains multiple tasks
        private readonly List<TaskEnt> _tasks = new List<TaskEnt>();
        public IReadOnlyCollection<TaskEnt> Tasks => _tasks.AsReadOnly();

        public ProjectAgg(string projectCode, string projectName)
        {
            ProjectCode = projectCode;
            ProjectName = projectName;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddTask(TaskEnt task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _tasks.Add(task);
        }
    }
}
