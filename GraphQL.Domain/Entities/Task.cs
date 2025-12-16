using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.Entities
{
    public class TaskEnt
    {
        public int TaskId { get; private set; }
        public string TaskCode { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public DateTime? DueDate { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Each task contains multiple comments
        private readonly List<CommentEnt> _comments = new List<CommentEnt>();
        public IReadOnlyCollection<CommentEnt> Comments => _comments.AsReadOnly();

        public TaskEnt(string taskCode, string title, string status)
        {
            TaskCode = taskCode;
            Title = title;
            Status = status;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddComment(CommentEnt comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            _comments.Add(comment);
        }
    }
}
