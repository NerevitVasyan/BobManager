using BobManager.Helpers.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BobManager.Helpers.Extentions
{
    public class MiddlewareException
    {
        private readonly RequestDelegate next;
        private readonly GlobalExceptionManager exManager;

        public MiddlewareException(RequestDelegate next, GlobalExceptionManager exManager)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.exManager = exManager ?? throw new ArgumentNullException(nameof(exManager));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var res = exManager.MapExceptionToResultDto(context, ex);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(res));
            }
        }
    }
}