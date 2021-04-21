using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.ViewModels;

namespace Rollers.Controllers.Admin
{
    [Authorize(Roles="Admin")]
    [Route("admin/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository = null;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }
        public IActionResult Index()
        {
            ViewBag.Current = "Admin";
            UsersViewModel usersViewModel = new UsersViewModel() { Users = _userRepository.GetAllUsers() };

            return View(usersViewModel);
        }
    }
}
