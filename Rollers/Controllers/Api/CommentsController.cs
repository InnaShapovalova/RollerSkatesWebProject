using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;
using System;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
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
                CommentCreatedDateTime = DateTime.Now
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
        public IActionResult UpdateComment([FromBody] UpdateCommentViewModel updateCommentViewModel)
        {
            if (updateCommentViewModel.Id < 1)
            {
                return BadRequest();
            }

            _commentRepository.UpdateCommentTextById(updateCommentViewModel.Id, updateCommentViewModel.CommentText);
            return Json("Ok");
        }

        [Route("comment/delete/{id}")]
        [HttpPost]
        public IActionResult DeleteComment([FromBody] int id)
        {
            _commentRepository.DeleteComment(id);
            return Json("Ok");
        }

        [Route("comment/addlike/{id}")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddLike(int id)
        {
            if (id < 0)
            {
                BadRequest("Comment Id can not be less then zero");
            }

            Comment comment = _commentRepository.GetComment(id);
            comment.Likes += 1;
            _commentRepository.UpdateComment(comment);

            return Json(" " + comment.Likes);
        }
        [Route("comment/adddislike/{id}")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddDislike(int id)
        {
            if (id < 0)
            {
                BadRequest("Comment Id can not be less then zero");
            }

            Comment comment = _commentRepository.GetComment(id);
            comment.Dislikes += 1;
            _commentRepository.UpdateComment(comment);

            return Json(" " + comment.Dislikes);
        }
    }
}
