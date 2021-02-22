using Rollers.Data.Contexts;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rollers.Data.Repositories
{
    public class CommentMsSqlRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext = null;
        public CommentMsSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddComment(Comment newComment)
        {
            _appDbContext.Comments.Add(newComment);
            _appDbContext.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _appDbContext.Comments.FirstOrDefault(p => p.Id == id);
            if (comment != null)
            {
                _appDbContext.Comments.Remove(comment);
                _appDbContext.SaveChanges();
            }
        }

        public List<Comment> GetAllComments()
        {
            return _appDbContext.Comments.ToList();
        }

        public Comment GetComment(int id)
        {
            return _appDbContext.Comments.First(x => x.Id == id);
        }

        public Comment UpdateComment(Comment updatedComment)
        {
            _appDbContext.Entry(_appDbContext.Users.FirstOrDefault(x => x.Id == updatedComment.Id)).CurrentValues.SetValues(updatedComment);
            _appDbContext.SaveChanges();
            return updatedComment;
        }
    }
}
