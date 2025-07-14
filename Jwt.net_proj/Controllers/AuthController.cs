using Jwt.net_proj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Jwt.net_proj.Jwt_Helper;

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
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "User")
        };

        var accessToken = JwtHelper.GenerateAccessToken(claims);
        var refreshToken = JwtHelper.GenerateRefreshToken();

        return Ok(new
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }
}
    