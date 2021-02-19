using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rollers.Domain.Abstractions
{
    public interface ICommentRepository
    {
        Comment GetComment(int id);
        void AddComment(Comment newComment);
        List<Comment> GetAllComments();
        void DeleteComment(int id);
        Comment UpdateComment(Comment updatedComment);
    }
}
