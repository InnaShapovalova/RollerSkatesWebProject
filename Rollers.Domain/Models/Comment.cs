using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int RollerSkateMapLocationId { get; set; }
        public RollerSkateMapLocation RollerSkateMapLocation { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentCreatedDateTime { get; set; } = DateTime.MinValue;
        public int Likes { get; set; } 
        public int Dislikes { get; set; } 
    }
}
