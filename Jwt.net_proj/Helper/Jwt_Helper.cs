using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Jwt.net_proj.Models;
using Microsoft.IdentityModel.Tokens;

namespace Jwt.net_proj.Entities
{
    public static class Jwt_Helper
    {
        private static JwtSetting _jwtSetting;

        public static void Initialize(JwtSetting jwtSetting)
        {
            _jwtSetting = jwtSetting ?? throw new ArgumentNullException(nameof(jwtSetting));
        }

        public static string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
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
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
