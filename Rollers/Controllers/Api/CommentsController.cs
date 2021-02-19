using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController: ControllerBase
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
        public IActionResult AddComment([FromBody] Comment newComment)
        {
            _commentRepository.AddComment(newComment);
            return Ok();
        }
        [Route("comment/{id}")]
        [HttpGet]
        public IActionResult GetCommentById(int id)
        {
            return Ok(_commentRepository.GetComment(id));
        }
    }
}
