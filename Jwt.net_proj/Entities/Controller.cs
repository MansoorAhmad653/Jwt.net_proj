    using Jwt.net_proj.Models;
using Jwt.net_proj.Entities;    
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Jwt.net_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new();

        [HttpPost("request")]

        public ActionResult<User> Register(UserDto request)
        {
            var hashedPasswords = new PasswordHasher<User>()
                .HashPassword(user, request.password);

                user.Username = request.Username;
                user.passwordhash = hashedPasswords;    
                return Ok(user);

        }
        [HttpPost("login")]

        public ActionResult<string> Login(UserDto request)
        {
           
            if(user.Username != request.Username)
            {
                return BadRequest("Invalid User");
            }
            var result = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.passwordhash, request.password);
            if (result == PasswordVerificationResult.Failed)
            {
                return BadRequest("Invalid Password");
            }
            string token = CreateToken(user);
            return Ok(token );
        }

        private string CreateToken(User user)
        {
            // Token creation logic would go here   
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("your_secret_key_here"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "your_issuer_here",
                audience: "your_audience_here",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            // This is a placeholder for the actual token generation logic
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
    