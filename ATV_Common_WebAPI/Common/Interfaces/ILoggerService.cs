namespace ATV_Common_WebAPI.Common.Interfaces;

public interface ILoggerService
{
    void Log(string appInfo = "", string className = "", string methodName = "", string functionName = "", string logInfo = "");
}
