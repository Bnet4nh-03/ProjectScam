namespace ATV_Common_WebAPI.Common.Models
{
    public class LoginModel
    {
        public class LdapServerConfig
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public string UserDomainName { get; set; }
            public string BaseDn { get; set; }
        }

        public class LdapConfig
        {
            public List<LdapServerConfig> Servers { get; set; }
        }

        public class LoginRequest
        {
            public string LdapName { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
            public string? AppInfo { get; set; }
        }

        public class User
        {
            public string UserId { get; set; }
            public string Password { get; set; }
            public string DisplayName { get; set; }
            public string Email { get; set; }
            public string BadgeNo { get; set; }
            public string Title { get; set; }
            public string Department { get; set; }
            public List<string>? UserRole { get; set; }
            public List<string>? UserConfig { get; set; }
        }

        public class LoginResponse
        {
            public required string Message { get; set; }
            public User? User { get; set; }
            public int? SetUserInfoStatus { get; set; }
        }

        public class JwtSettings
        {
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretKey { get; set; }
            public int TokenExpiryInSeconds { get; set; }
            public int RefreshTokenExpiryInDays { get; set; }
            public int ClockSkewInSeconds { get; set; }
        }

        public class JwtTokenInfo
        {
            public string Token { get; set; }
            public RefreshTokenResponse RefreshTokenInfo { get; set; }
        }

        public class RefreshTokenRequest
        {
            public required string BadgeNo { get; set; }
            public required string UserId { get; set; }
            public required string AppInfo { get; set; }
            public required string JwtToken { get; set; }
            public required string RefreshToken { get; set; }
        }

        public class RefreshTokenResponse
        {
            public required string RefreshToken { get; set; }
            public DateTime RefreshTokenExpiryTime { get; set; }
            public string StatusSetRefreshToken { get; set; }
        }
    }
}
