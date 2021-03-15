using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository = null;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
        [Route("user/delete")]
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
