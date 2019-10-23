using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BobManager.Helpers.Extentions
{
    public class MiddlewareException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;
        public MiddlewareException(RequestDelegate next, ILogger logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"[{DateTime.Now.ToString()}][{context.Connection.RemoteIpAddress.MapToIPv4()}]: " + ex.Message);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<b>SERVER ERROR</b>");
            }
        }
    }
}