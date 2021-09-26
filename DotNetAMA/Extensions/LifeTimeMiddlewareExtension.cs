using DotNetAMA.Svcs;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Extensions
{
    public static class LifeTimeMiddlewareExtension
    {
        public static IApplicationBuilder UseLifeTimeLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LifeTimeMiddleware>();
        }
    }
}
