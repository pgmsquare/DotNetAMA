using DotNetAMA.V7.Svcs;

namespace DotNetAMA.V7.Extensions
{
    public static class LifeTimeMiddlewareExtension
    {
        public static IApplicationBuilder UseLifeTimeLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LifeTimeMiddleware>();
        }
    }
}
