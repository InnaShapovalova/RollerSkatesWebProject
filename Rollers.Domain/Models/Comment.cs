using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollerSkatesWebProject.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RollerSkateMapLocationId { get; set; }
        public string CommentText { get; set; }

    }
}
