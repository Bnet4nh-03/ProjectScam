using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.Common.Interfaces;

public interface IEmailService
{
    Task<IResult> SendEmail(Models.EmailModel.EmailRequestModel emailContentInfo);
}
