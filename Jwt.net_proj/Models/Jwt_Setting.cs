public class Jwt_Setting
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpirationMinutes { get; set; } = 60;
    public int RefreshTokenExpirationDays { get; set; } = 30;
    public Jwt_Setting() { }
    public Jwt_Setting(string secretKey, string issuer, string audience, int expirationMinutes, int refreshTokenExpirationDays)
    {
        SecretKey = secretKey;
        Issuer = issuer;
        Audience = audience;
        ExpirationMinutes = expirationMinutes;
        RefreshTokenExpirationDays = refreshTokenExpirationDays;    
    }
}
