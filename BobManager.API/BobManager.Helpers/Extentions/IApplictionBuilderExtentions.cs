using Microsoft.AspNetCore.Builder;

namespace BobManager.Helpers.Extentions
{
    public static class MiddlewareExceptionsExtensions
    {
        public static IApplicationBuilder UseMiddlewareException(this IApplicationBuilder builder)
            => builder.UseMiddleware<MiddlewareException>();
    }
}