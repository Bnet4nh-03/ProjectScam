using Microsoft.Extensions.Options;

namespace ATV_Common_WebAPI.Common.Middleware
{
    public class IpBlockingConfig
    {
        public string[] BlockedIPs { get; set; } = Array.Empty<string>();
    }

    public class BlockIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _blockedIps;

        public BlockIpMiddleware(RequestDelegate next, IOptionsMonitor<IpBlockingConfig> blockedIpsOptions)
        {
            _next = next;
            _blockedIps = blockedIpsOptions.CurrentValue.BlockedIPs; // Get current config
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress?.ToString();
            if (_blockedIps.Contains(remoteIp))
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("[B] Not Found");
                return;
            }
            await _next(context);
        }
    }

}
