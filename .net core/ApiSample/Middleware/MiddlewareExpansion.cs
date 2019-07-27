using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    // 使用自定义中间件
    public static class MiddlewareExpansion
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder builder) => builder.UseMiddleware<LoggerMiddleware>();
    }
}