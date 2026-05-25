using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using static ATV_Common_WebAPI.Common.Services.DataService;
using static ATV_Common_WebAPI.Common.Utilities.OtherUtility;

namespace ATV_Common_WebAPI.Common.Interfaces;

public interface IDataService
{
    Task<string> GetRequestValidateCode();
    Task<List<Dictionary<string, object>>> CallSqlCommand(RequestSqlCommand requestSqlCommand);
    Task<string> CallSqlCommandGetJsonString(RequestSqlCommand requestSqlCommand);
    Task<List<object>> CallStoreProcedure(RequestStoreProcedure requestSP);
    Task<string> CallStoreProcedureGetJsonString(RequestStoreProcedure requestSP, string? returnType = "str");
    Task SetDbCallLog(ClientInfo clientInfo, RequestSqlCommand? sqlCommand, RequestStoreProcedure? requestStoreProcedure);
    Task SetDbCallLogEnCo(ClientInfo clientInfo, RequestSC? requestSc, RequestSP? requestSP);
    Task<List<Dictionary<string, object>>> CallSC(RequestSC requestSC);
    Task<List<object>> CallSP(RequestSP requestSP);
}