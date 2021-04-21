using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository = null;
        private readonly ICommentRepository _commentRepository = null;
        private readonly IRollerSkateMapLocationRepository _locationRepository = null;
        public UsersController(IUserRepository userRepository, ICommentRepository commentRepository, IRollerSkateMapLocationRepository rollerSkateMapLocationRepository)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _locationRepository = rollerSkateMapLocationRepository;
        }
        [Route("")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAllUsers());
        }
        [Route("adduser")]
        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            _userRepository.AddUser(newUser);
            return Ok();
        }
        [Route("user/{id}")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetUser(id));
        }

        [Route("user/update")]
        [HttpPost]
        public IActionResult UpdateUser([FromBody] User updatedUser)
        {
            _userRepository.UpdateUser(updatedUser);
            return Ok();
        }
        [Route("user/delete/{id}")]
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            List<Comment> comments = _commentRepository.GetAllComments().Where(x => x.UserId == id).ToList();
            List<RollerSkateMapLocation> locations = _locationRepository.GetAllRollerSkateMapLocations().Where(x => x.UserId == id).ToList();

            foreach (var comment in comments)
            {
                comment.UserId = null;
                _commentRepository.UpdateComment(comment);
            }

            foreach (var location in locations)
            {
                location.UserId = null;
                _locationRepository.UpdateRollerSkateMapLocation(location);
            }

            _userRepository.DeleteUser(id);

            return Json("Ok");
        }

        [Route("{id}/role/{role}")]
        [HttpPost]
        public IActionResult SetUserRoleById(int id, int role)
        {
            if (!Enum.IsDefined(typeof(UserTypeEnum), (UserTypeEnum)role)) {
                return BadRequest("There is no such role");
            }

            var user = _userRepository.GetUser(id);
            user.UserType = (UserTypeEnum) role;
            _userRepository.UpdateUser(user);

            return Json("Ok");
        }
    }
}
