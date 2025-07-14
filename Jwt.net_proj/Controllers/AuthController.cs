using Jwt.net_proj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Jwt.net_proj.Entities; 
using Jwt.net_proj.Helper;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Normally: validate user credentials first
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Name, request.Email), // Fixed: Use Email property instead of Username
            new Claim(ClaimTypes.Role, "User")
        };

        var accessToken = Jwt_Helper.GenerateAccessToken(claims);
        var refreshToken = Jwt_Helper.GenerateRefreshToken();

        return Ok(new
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }
}
