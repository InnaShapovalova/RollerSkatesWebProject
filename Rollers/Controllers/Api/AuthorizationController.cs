using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;

namespace Rollers.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private IUserRepository _userRepository = null;

        public AuthorizationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = _userRepository.GetAllUsers();
                User user = users.FirstOrDefault(u => u.Login == model.Login && u.Password == HashPassword(model.Password));
                if (user != null)
                {
                    await Authenticate(user); 

                    return Json("ok");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return BadRequest("something went wrong");
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userRepository.GetAllUsers().FirstOrDefault(u => u.Login == model.Login);
                if (user == null)
                {
                    User newUser = new User
                    {
                        Login = model.Login,
                        Password = HashPassword(model.Password),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserType = UserTypeEnum.Visitor
                    };
                    _userRepository.AddUser(newUser);
                    await Authenticate(newUser); 

                    return Json("ok");
                }
                else
                {
                    ModelState.AddModelError("", "User with the same login already exists");
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Json("ok");
        }

        #region Helpers

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserType.ToString()),
                new Claim("LastName", user.LastName),
                new Claim("FirstName", user.FirstName),
                new Claim("Email", user.Email),
                new Claim("UserId", user.Id.ToString())

            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private string HashPassword(string password)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, new byte[18], 100000);
            byte[] hash = pbkdf2.GetBytes(2);

            return Convert.ToBase64String(hash);
        }

        #endregion

    }
}