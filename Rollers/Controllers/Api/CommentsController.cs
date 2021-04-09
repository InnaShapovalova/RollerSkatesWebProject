using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;
using System;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _commentRepository = null;
        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [Route("")]
        [HttpGet]
        public IActionResult GetAllComments()
        {
            return Ok(_commentRepository.GetAllComments());
        }
        [Route("addcomment")]
        [HttpPost]
        public IActionResult AddComment([FromBody] CommentViewModel newCommentViewModel)
        {
            if (newCommentViewModel.UserId < 1 || newCommentViewModel.RollerSkateMapLocationId < 1)
            {
                return BadRequest();
            }
            Comment comment = new Comment()
            {
                UserId = newCommentViewModel.UserId,
                RollerSkateMapLocationId = newCommentViewModel.RollerSkateMapLocationId,
                CommentText = newCommentViewModel.CommentText,
                CreatedDateTime = DateTime.Now
            };
            _commentRepository.AddComment(comment);
            return Json("Ok");
        }
        [Route("comment/{id}")]
        [HttpGet]
        public IActionResult GetCommentById(int id)
        {
            return Ok(_commentRepository.GetComment(id));
        }
        [Route("comment/update")]
        [HttpPost]
        public IActionResult UpdateComment([FromBody] Comment updatedComment)
        {
            _commentRepository.UpdateComment(updatedComment);
            return Ok();
        }
        [Route("comment/delete")]
        [HttpPost]
        public IActionResult DeleteComment(int id)
        {
            _commentRepository.DeleteComment(id);
            return Ok();
        }
    }
}
