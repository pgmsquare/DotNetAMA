using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Svcs
{
    public class LifeTimeMiddleware
    {
        /// <summary>
        /// 요청수행이 완료되었으니 다음 task로 넘어가라.
        /// </summary>
        private readonly RequestDelegate _next;

        public LifeTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
                                      Svcs.ILogger logger,
                                      ISingletonLifeTime singletonLT,
                                      IScopedLifeTime scopedLT,
                                      ITransientLifeTime transientLT)
        {
            logger.LogInfo($"Singleton 수명 미들웨어 '{singletonLT._requestId}'를 요청 파이프라인에 등록하라.");
            logger.LogInfo($"Scoped 수명 미들웨어 '{scopedLT._requestId}'를 요청 파이프라인에 등록하라.");
            logger.LogInfo($"Transient 수명 미들웨어 '{transientLT._requestId}'를 요청 파이프라인에 등록하라.");

            await _next(context);
        }
    }
}
