using System.Net;

namespace ATV_Common_WebAPI.Common.Utilities
{
    public class OtherUtility
    {
        public class ClientInfo
        {
            public string ClientIP { get; set; }
            public string ClientHostname { get; set; }
            public string UserAgent { get; set; }
            public IRequestCookieCollection Cookies {  get; set; }
        }

        public static async Task<ClientInfo> GetClientInfo(HttpContext context)
        {
            var clientIp = context.Connection.RemoteIpAddress?.ToString();
            string clientHostname = null;

            if (clientIp != null)
            {
                try
                {
                    var hostEntry = await Dns.GetHostEntryAsync(clientIp);
                    clientHostname = hostEntry.HostName;
                }
                catch (Exception ex)
                {
                    clientHostname = $"Could not resolve hostname: {ex.Message}";
                }
            }

            var userAgent = context.Request.Headers["User-Agent"].ToString();
            var cookies = context.Request.Cookies;

            return new ClientInfo
            { 
                ClientIP = clientIp, 
                ClientHostname = clientHostname,
                UserAgent = userAgent,
                Cookies = cookies
            };
        }
    }
}
