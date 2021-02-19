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
    public class UsersController:Controller
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
        [Route("submit")]
        [HttpGet]
        public ActionResult Submit()
        {
            return View("Style");
            //return View(obj);
        }
        [Route("adduser")]
        [HttpPost]
        public IActionResult AddUser([FromBody]User newUser)
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
    }
}
