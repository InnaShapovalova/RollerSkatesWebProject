using Rollers.Data.Contexts;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
            return _appDbContext.Comments.Include("User").Include("RollerSkateMapLocation").ToList();
        }

        public Comment GetComment(int id)
        {
            return _appDbContext.Comments.First(x => x.Id == id);
        }

        public void UpdateCommentTextById(int commentId, string editedText)
        {
            Comment comment = _appDbContext.Comments.FirstOrDefault(x => x.Id == commentId);

            if (comment != null)
            {
                comment.CommentText = editedText;
                _appDbContext.SaveChanges();
            }

        }

        public void UpdateComment(Comment comment)
        {
            Comment _comment = _appDbContext.Comments.FirstOrDefault(x => x.Id == comment.Id);

            if (_comment != null)
            {
                _comment = comment;
                _appDbContext.SaveChanges();
            }
        }
    }
}
