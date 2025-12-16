using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.Entities
{
    public class CommentEnt
    {
        public int CommentId { get; private set; }
        public string AuthorName { get; private set; }
        public string CommentText { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CommentEnt(string authorName, string commentText)
        {
            AuthorName = authorName;
            CommentText = commentText;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
