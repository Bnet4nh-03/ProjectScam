using ATV_Common_WebAPI.Common.Interfaces;
using BCrypt.Net;

namespace ATV_Common_WebAPI.Common.Services
{
    public class HashService
    {
        public class PasswordHasherBCrypt
        {
            private readonly ILoggerService _loggerService;

            public PasswordHasherBCrypt(ILoggerService loggerService)
            {
                _loggerService = loggerService;
            }

            // Function to hash a password
            public string HashPassword(string password)
            {
                // Generate a salt and hash the password
                return BCrypt.Net.BCrypt.HashPassword(password);
            }

            // Function to verify a password
            public bool VerifyPassword(string hashedPassword, string providedPassword)
            {
                bool isMatchPassword = false;

                // Verify the provided password against the stored hash
                if (string.IsNullOrEmpty(hashedPassword))
                    return isMatchPassword;

                if (hashedPassword.Length != 60)
                    return isMatchPassword;

                if (!hashedPassword.StartsWith("$2a$") && !hashedPassword.StartsWith("$2b$") && !hashedPassword.StartsWith("$2y$"))
                    return isMatchPassword;

                try { isMatchPassword = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword); }
                catch (Exception e) 
                {
                    _loggerService.Log(appInfo: "Common_API", className: "Hash_Method", methodName: "VerifyPassword", logInfo: e.Message);
                }

                return isMatchPassword;
            }
        }
    }
}