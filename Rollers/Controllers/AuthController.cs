using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rollers.Domain.Models.Auth;
using Rollers.Data.Interfaces;
using RollerSkatesWebProject.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Rollers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private IOptions<AuthOptions> _authOptions { get; set; }
        private IUserRepository _userRepository { get; set; }
        public AuthController(IUserRepository userRepository, IOptions<AuthOptions> authOptions)
        {
            _userRepository = userRepository;
            _authOptions = authOptions;
        }
        
        
        [HttpPost]
        [Route("")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            User user = _userRepository.GetUser(loginRequest.Email, loginRequest.Password);

            if (user != null)
            {
                string token = GenerateJWTToken(user);
                return Ok(new { accessToken = token });
            }
            return Unauthorized(); 
        }

        private string GenerateJWTToken(User user)
        {
            AuthOptions authParams = _authOptions.Value;
            SymmetricSecurityKey symmetricSecurityKey = null;
            try
            {
                symmetricSecurityKey = authParams.GetSummetricSecurityKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("role", user.UserType.ToString())
            };
            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
