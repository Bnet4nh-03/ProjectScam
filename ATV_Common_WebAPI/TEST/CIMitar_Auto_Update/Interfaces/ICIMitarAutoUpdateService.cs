using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Interfaces;

public interface ICIMitarAutoUpdateService
{
    string GetVersion();
    string GetChangeLog();
    IResult GetLatestATVCIMitar();
    Task<IResult> UpdateLatestATVCIMitar(Models.CIMitarUploadModel model);
}
