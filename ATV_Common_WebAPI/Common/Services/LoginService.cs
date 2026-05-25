using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ATV_Common_WebAPI.Common.Services
{
    public class LoginService
    {
        public class AuthService : IAuthService
        {
            private readonly IConfiguration _configuration;
            private readonly ATV_Common_WebAPI.Common.Models.LoginModel.LdapConfig _ldapConfig;
            private readonly ATV_Common_WebAPI.Common.Models.LoginModel.JwtSettings _jwtSetting;
            private readonly DatabaseUtility _dbUtil;
            private readonly HashService.PasswordHasherBCrypt _passwordHasher;

            public AuthService(IConfiguration configuration, DatabaseUtility dbUtility, HashService.PasswordHasherBCrypt passwordHasher)
            {
                _configuration = configuration;
                _ldapConfig = _configuration.GetSection("Ldap").Get<ATV_Common_WebAPI.Common.Models.LoginModel.LdapConfig>();
                _jwtSetting = _configuration.GetSection("JwtSettings").Get<ATV_Common_WebAPI.Common.Models.LoginModel.JwtSettings>();
                _dbUtil = dbUtility;
                _passwordHasher = passwordHasher;
            }

            public ATV_Common_WebAPI.Common.Models.LoginModel.User GetUserInfoFromDb(string? badgeNo, string? userId)
            {
                var sqlParamList = new List<SqlParameter>
                {
                    new SqlParameter("@badgeno", badgeNo),
                    new SqlParameter("@user_id", userId)
                };

                var dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Common_API_Get_User", sqlParamList);

                if (dataSet.Tables[0]?.Rows.Count > 0)
                {
                    var dataRow = dataSet.Tables[0].Rows[0];

                    var userConfig = dataRow["user_config"].ToString().Trim();
                    var lstReturn = userConfig.Split(';').Where(config => !string.IsNullOrEmpty(config)).ToList();

                    var userRole = dataRow["user_role"].ToString().Trim();
                    var lstUserRole = userRole.Split(';').Where(config => !string.IsNullOrEmpty(config)).ToList();
                    var returnData = new ATV_Common_WebAPI.Common.Models.LoginModel.User
                    {
                        UserId = dataRow["user_id"].ToString().Trim(),
                        Password = dataRow["password"].ToString().Trim(),
                        DisplayName = dataRow["username"].ToString().Trim(),
                        Email = dataRow["email"].ToString().Trim(),
                        BadgeNo = dataRow["badgeno"].ToString().Trim(),
                        Title = dataRow["user_title"].ToString().Trim(),
                        Department = dataRow["user_group"].ToString().Trim(),
                        UserRole = lstUserRole,
                        UserConfig = lstReturn
                    };

                    return returnData;
                }
                return null;
            }

            public int SetUserInfoToDb(ATV_Common_WebAPI.Common.Models.LoginModel.User userInfo, string ldapName, string? loginMethod = "LDAP")
            {
                var sqlParamList = new List<SqlParameter>
                {
                    new SqlParameter("@badgeno", userInfo.BadgeNo),
                    new SqlParameter("@user_id", userInfo.UserId),
                    new SqlParameter("@username", userInfo.DisplayName),
                    new SqlParameter("@password", userInfo.Password),
                    new SqlParameter("@user_title", userInfo.Title),
                    new SqlParameter("@user_role", "User"),
                    new SqlParameter("@user_group", userInfo.Department),
                    new SqlParameter("@email", userInfo.Email),
                    new SqlParameter("@login_method", loginMethod),
                    new SqlParameter("@site_login", ldapName),
                    new SqlParameter("@onflag", 1),
                    new SqlParameter("@change_factor", "API")
                };

                var dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Common_API_Set_User", sqlParamList);

                if (dataSet.Tables[0]?.Rows.Count > 0)
                {
                    var dataRow = dataSet.Tables[0].Rows[0];
                    return int.Parse(dataRow["result"].ToString().Trim());
                }

                return -1;
            }

            public ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse ValidateLogin(string ldapName, string userId, string password)
            {
                ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse loginResult = new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = "Unauthorized" };
                if (ldapName.ToUpper() == "LOCAL")
                {
                    // Local login
                    loginResult = LoginLocal(userId, password);
                }
                else
                {
                    // LDAP login
                    loginResult = LoginLdap(ldapName.ToUpper(), userId, password);
                }
                
                if (loginResult.Message.Contains("Login successful")) loginResult.User.Password = null;
                return loginResult;
            }

            public async Task<IResult> Login(string ldapName, string userId, string password)
            {
                var loginResult = ValidateLogin(ldapName, userId, password);

                if (!loginResult.Message.Contains("Login successful")) return Results.BadRequest(loginResult);

                return Results.Ok(loginResult);
            }

            public async Task<IResult> Login(string ldapName, string userId, string password, string appInfo)
            {
                var loginResult = ValidateLogin(ldapName, userId, password);

                if (!loginResult.Message.Contains("Login successful")) return Results.BadRequest(loginResult);

                string jwtToken = GenerateJwtToken(loginResult.User, appInfo);
                var refreshTokenInfo = await SetRefreshTokenAsync(loginResult.User.BadgeNo, userId, appInfo);

                ATV_Common_WebAPI.Common.Models.LoginModel.JwtTokenInfo jwtTokenInfo = new ATV_Common_WebAPI.Common.Models.LoginModel.JwtTokenInfo { Token = jwtToken, RefreshTokenInfo = refreshTokenInfo };

                return Results.Ok(new { loginResult.Message, loginResult.User, loginResult.SetUserInfoStatus, jwtTokenInfo });
            }

            public ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse LoginLocal(string userId, string password)
            {
                ATV_Common_WebAPI.Common.Models.LoginModel.User result = LoginLocalDbCheck(userId, password);
                if (result != null)
                {
                    if (result.UserId == null) return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = $"User {userId} does not exist" };

                    var userInfo = new ATV_Common_WebAPI.Common.Models.LoginModel.User
                    {
                        UserId = userId,
                        Password = result.Password,
                        DisplayName = result.DisplayName,
                        Email = result.Email,
                        BadgeNo = result.BadgeNo,
                        Title = result.Title,
                        Department = result.Department,
                        UserRole = result.UserRole,
                        UserConfig = result.UserConfig,
                    };
                    int setUserInfoStatus = 0;

                    return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = "Login successful", User = userInfo, SetUserInfoStatus = setUserInfoStatus };
                }

                return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = "Error authenticating local user - wrong password" };
            }
            public ATV_Common_WebAPI.Common.Models.LoginModel.User LoginLocalDbCheck(string userId, string password)
            {
                ATV_Common_WebAPI.Common.Models.LoginModel.User userInfoFromDb = GetUserInfoFromDb(null, userId);

                string hashedPasswordDb = "";
                bool isValid = false;

                if (userInfoFromDb == null) return new ATV_Common_WebAPI.Common.Models.LoginModel.User();
                hashedPasswordDb = userInfoFromDb.Password;

                if (hashedPasswordDb != "") isValid = _passwordHasher.VerifyPassword(hashedPasswordDb, password);
                if (isValid) return userInfoFromDb;

                return null;
            }

            public ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse LoginLdap(string ldapName, string userId, string password)
            {
                var ldapServer = _ldapConfig.Servers.FirstOrDefault(s => s.Name.Equals(ldapName, StringComparison.OrdinalIgnoreCase));
                if (ldapServer == null)
                {
                    return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = "Invalid LDAP server name" };
                }

                try
                {
                    using (var entry = new DirectoryEntry(ldapServer.Path, ldapServer.UserDomainName + "\\" + userId, password))
                    {
                        // Bind to the LDAP server to authenticate the user, This line will throw an exception if authentication fails
                        var nativeObject = entry.NativeObject;

                        // Create a DirectorySearcher with the base DN
                        using (var searcher = new DirectorySearcher(entry))
                        {
                            searcher.SearchRoot = new DirectoryEntry(ldapServer.Path + "/" + ldapServer.BaseDn, ldapServer.UserDomainName + "\\" + userId, password);
                            searcher.Filter = $"(&(objectClass=user)(sAMAccountName={userId}))";
                            searcher.PropertiesToLoad.AddRange(["displayName", "mail", "pager", "title", "department", "employeeNumber"]);

                            var result = searcher.FindOne();
                            if (result != null)
                            {
                                var userInfo = new ATV_Common_WebAPI.Common.Models.LoginModel.User
                                {
                                    UserId = userId,
                                    DisplayName = result.Properties["displayName"].Count > 0 ? result.Properties["displayName"][0].ToString() : null,
                                    Password = _passwordHasher.HashPassword(password),
                                    Email = result.Properties["mail"].Count > 0 ? result.Properties["mail"][0].ToString() : null,
                                    BadgeNo = result.Properties["pager"].Count > 0 ? result.Properties["pager"][0].ToString() : userId,
                                    Title = result.Properties["title"].Count > 0 ? result.Properties["title"][0].ToString() : null,
                                    Department = result.Properties["department"].Count > 0 ? result.Properties["department"][0].ToString() : null,
                                };

                                int setUserInfoStatus = LoginLdapDbSet(ldapName, userId, password, userInfo);
                                if (setUserInfoStatus == 0 || setUserInfoStatus == 2) userInfo = GetUserInfoFromDb(null, userId);

                                return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = "Login successful", User = userInfo, SetUserInfoStatus = setUserInfoStatus };
                            }
                        }
                    }
                }
                catch (DirectoryServicesCOMException ex)
                {
                    // Handle specific LDAP errors
                    return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = $"LDAP error authenticating user. {ex.Message}" };
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = $"Other error authenticating user. {ex.Message}" };
                }

                return new ATV_Common_WebAPI.Common.Models.LoginModel.LoginResponse { Message = "Invalid credentials" };
            }

            public int LoginLdapDbSet(string ldapName, string userId, string password, ATV_Common_WebAPI.Common.Models.LoginModel.User userInfo)
            {
                var userInfoInDb = GetUserInfoFromDb(null, userId);
                int setUserInfoStatus = 0;
                bool isCorrectPassword = false;

                if (userInfoInDb != null)
                {
                    isCorrectPassword = _passwordHasher.VerifyPassword(userInfoInDb.Password, password);
                    if (!isCorrectPassword) setUserInfoStatus = SetUserInfoToDb(userInfo, ldapName);
                    else
                    {
                        var userInfoChange = CompareUserInfo(userInfoInDb, userInfo);
                        if (userInfoChange != null) SetUserInfoToDb(userInfoChange, ldapName);
                    }
                }
                else
                {
                    setUserInfoStatus = SetUserInfoToDb(userInfo, ldapName);
                }

                return setUserInfoStatus;
            }

            public ATV_Common_WebAPI.Common.Models.LoginModel.User? CompareUserInfo(ATV_Common_WebAPI.Common.Models.LoginModel.User user1, ATV_Common_WebAPI.Common.Models.LoginModel.User user2)
            {
                var changes = new ATV_Common_WebAPI.Common.Models.LoginModel.User();

                bool hasChanges = false;

       
                void AddChange(string propName, string oldValue, string newValue)
                {
                    typeof(ATV_Common_WebAPI.Common.Models.LoginModel.User).GetProperty(propName)?.SetValue(changes, newValue);
                    hasChanges = true;
                }

                //if (user1.UserId == user2.UserId) AddChange(nameof(user1.UserId), user1.UserId, user2.UserId);
                changes.BadgeNo = user1.BadgeNo;
                //if (user1.Password != user2.Password) AddChange(nameof(user1.Password), user1.Password, user2.Password);
                if (user1.DisplayName != user2.DisplayName) AddChange(nameof(user1.DisplayName), user1.DisplayName, user2.DisplayName);
                if (user1.Email != user2.Email) AddChange(nameof(user1.Email), user1.Email, user2.Email);
                //if (user1.BadgeNo != user2.BadgeNo) AddChange(nameof(user1.BadgeNo), user1.BadgeNo, user2.BadgeNo);
                if (user1.Title != user2.Title) AddChange(nameof(user1.Title), user1.Title, user2.Title);
                if (user1.Department != user2.Department) AddChange(nameof(user1.Department), user1.Department, user2.Department);
                //if (user1.UserConfig != null && user2.UserConfig != null && !user1.UserConfig.SequenceEqual(user2.UserConfig))
                //    AddChange(nameof(user1.UserConfig), string.Join(", ", user1.UserConfig), string.Join(", ", user2.UserConfig));

                return hasChanges ? changes : null;
            }

            public string GenerateJwtToken(ATV_Common_WebAPI.Common.Models.LoginModel.User userInfo, string appInfo)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_jwtSetting.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("userId", userInfo.UserId.ToString()),
                        new Claim("userConfig", string.Join(",", userInfo.UserConfig)),
                        new Claim("appInfo", appInfo),
                    }),

                    Expires = DateTime.UtcNow.AddSeconds(_jwtSetting.TokenExpiryInSeconds),
                    Issuer = _jwtSetting.Issuer,
                    Audience = _jwtSetting.Audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }

            string GenerateRefreshToken()
            {
                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            }

            public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _jwtSetting.Issuer,
                    ValidAudience = _jwtSetting.Audience,
                    ClockSkew = TimeSpan.FromSeconds(_jwtSetting.ClockSkewInSeconds),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey))
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }

                return principal;
            }

            public async Task<ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenResponse> SetRefreshTokenAsync(string badgeNo, string userId, string appInfo)
            {
                var refreshToken = GenerateRefreshToken();
                var expiryTime = DateTime.Now.AddDays(_jwtSetting.RefreshTokenExpiryInDays);

                var sqlParamList = new List<SqlParameter>
                {
                    new SqlParameter("@badgeno", badgeNo),
                    new SqlParameter("@user_id", userId),
                    new SqlParameter("@app_info", appInfo),
                    new SqlParameter("@refresh_token", refreshToken),
                    new SqlParameter("@refresh_token_expiry_time", expiryTime)
                };

                DataSet dataSet = await _dbUtil.GetDataSetByStoredProcedureAsync("ATV_Common.dbo.USP_Set_Common_API_User_Refresh_Token", sqlParamList);

                string SetRefreshTokenStatus = string.Empty;
                if (dataSet.Tables[0]?.Rows.Count > 0)
                {
                    var dataRow = dataSet.Tables[0].Rows[0];
                    SetRefreshTokenStatus = dataRow["result"].ToString().Trim();
                }

                return new ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenResponse { RefreshToken = refreshToken, RefreshTokenExpiryTime = expiryTime, StatusSetRefreshToken = SetRefreshTokenStatus };
            }

            public async Task<bool> ValidateRefreshTokenAsync(ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenRequest refreshTokenInfo)
            {
                string appInfo = refreshTokenInfo.AppInfo.Replace("'", "");
                string refreshToken = refreshTokenInfo.RefreshToken.Replace("'", "");

                string sqlQuery = $"SELECT COUNT(*) AS Count FROM ATV_Common.dbo.Common_API_User_Refresh_Token WHERE refresh_token = '{refreshToken}' " +
                                  $"AND app_info = '{appInfo}' AND refresh_token_expiry_time > '{DateTime.Now}'";
                DataTable dataTable = new DataTable();
                dataTable = await _dbUtil.GetDataTableByQueryAsync(sqlQuery);
                int count = 0;

                if (dataTable.Rows.Count > 0)
                {
                    count = int.Parse(dataTable.Rows[0]["Count"].ToString());
                }

                return count > 0;
            }

            public async Task<(string, string)> GetBadgeNoUserIdByRefreshTokenAsync(ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenRequest refreshTokenInfo)
            {
                string appInfo = refreshTokenInfo.AppInfo.Replace("'", "");
                string refreshToken = refreshTokenInfo.RefreshToken.Replace("'", "");

                string sqlQuery = $"SELECT badgeno, user_id FROM ATV_Common.dbo.Common_API_User_Refresh_Token WHERE app_info = '{appInfo}' AND refresh_token = '{refreshToken}'";
                DataTable dataTable = new DataTable();
                dataTable = await _dbUtil.GetDataTableByQueryAsync(sqlQuery);
                string badgeNo = string.Empty, userId = string.Empty;

                if (dataTable.Rows.Count > 0)
                {
                    badgeNo = dataTable.Rows[0]["badgeno"].ToString();
                    userId = dataTable.Rows[0]["user_id"].ToString();
                }
                return (badgeNo, userId);
            }

            public async Task<ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenResponse> RequestGenerateRefreshToken(ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenRequest request)
            {
                // Extract the principal from the expired JWT token and Retrieve the userId from the principal's claims
                var principal = GetPrincipalFromExpiredToken(request.JwtToken); 
                string userIdFromPrincipal = principal.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

                // Validate the refresh token
                if (!await ValidateRefreshTokenAsync(request))
                {
                    throw new SecurityTokenException("Invalid refresh token");
                }

                // Get badge number and userId associated with the refresh token, Check if the provided badge number and userId match the expected values
                var (badgeNo, userId) = await GetBadgeNoUserIdByRefreshTokenAsync(request);
                if (badgeNo != request.BadgeNo || userId != request.UserId || userId != userIdFromPrincipal)
                {
                    throw new SecurityTokenException("Invalid refresh token");
                }

                // Get user info from DB
                ATV_Common_WebAPI.Common.Models.LoginModel.User userInfo = GetUserInfoFromDb(null, request.UserId);

                // Generate a new JWT token, Set a new refresh token (Generate new refresh token inside SetRefreshTokenAsync)
                string jwtToken = GenerateJwtToken(userInfo, request.AppInfo);
                ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenResponse refreshToken = await SetRefreshTokenAsync(request.BadgeNo, request.UserId, request.AppInfo);

                // Return the new JWT token and refresh token
                return refreshToken;
            }
        }
    }
}