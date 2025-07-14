using system Security.Claims;
using Jwt.net_proj.Models;


using System;

namespace Jwt.net_proj.Entities


{
    public static class Jwt_Helper
{
	public static Jwt_Helper()
	{
			private static JwtSetting _jwtSetting;
		public static	void Initialize(JwtSetting jwtSetting)
		{
			_jwtSetting = jwtSetting ?? throw new ArgumentNullException(nameof(jwtSetting),

	    }

	public static string GenerateAccessToken( IEnumerable<claim> claims)
		{
			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				issuer: _jwtSetting.Issuer,
				audience: _jwtSetting.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_jwtSetting.ExpirationMinutes),
				signingCredentials: creds
				);
			return new JwtSecurityTokenHandler().WriteToken(token);

        }
	public static string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
			{
				rng.GetBytes(randomNumber);
				var refreshToken = Convert.ToBase64String(randomNumber);
			
            }
                
		}
																													
    }

}
	
