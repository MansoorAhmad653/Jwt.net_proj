namespace Jwt.net_proj.Models
{
    public class JwtSetting
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
        public int RefreshTokenExpiryDays { get; set; } 
    }
}