using System;
using System.Security.Claims;

namespace Jwt.net_proj.Models
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ClaimsIdentity? Username { get; internal set; }
    }
}