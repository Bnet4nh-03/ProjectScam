using ATV_Common_WebAPI.Common.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.Common.Interfaces;

public interface IAuthService
{
    Task<IResult> Login(string ldapName, string userId, string password);
    Task<IResult> Login(string ldapName, string userId, string password, string appInfo);
    Task<ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenResponse> RequestGenerateRefreshToken(ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenRequest request);
}
