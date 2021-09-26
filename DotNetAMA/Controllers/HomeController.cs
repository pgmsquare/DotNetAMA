using DotNetAMA.Models;
using DotNetAMA.Svcs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Svcs.ILogger _nLogger;

        public HomeController(ILogger<HomeController> logger,
                              Svcs.ILogger nLogger)
        {
            _logger = logger;
            _nLogger = nLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            string action = ControllerContext.RouteData.Values["action"].ToString();
            /*
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            _logger.LogInformation($"[{actionName}] Test the logger.");

            _logger.LogTrace($"[{actionName}] Test the logger.");
            _logger.LogWarning($"[{actionName}] Test the logger.");
            _logger.LogDebug($"[{actionName}] Test the logger.");
            _logger.LogError($"[{actionName}] Test the logger.");
            */
            _nLogger.LogInfo("Test the logger.", ControllerContext);
            _nLogger.LogTrace("Test the logger.", ControllerContext);
            _nLogger.LogWarn("Test the logger.", ControllerContext);
            _nLogger.LogDebug("Test the logger.", ControllerContext);
            _nLogger.LogError("Test the logger.", ControllerContext);

            return View();
        }

        public IActionResult LifeTime([FromServices]
                                        ISingletonLifeTime singletonLT,
                                      [FromServices]
                                        IScopedLifeTime scopedLT,
                                      [FromServices]
                                        ITransientLifeTime transientLT)
        {
            var dicList = new Dictionary<string, string>();
            dicList.Add("singleton", singletonLT._requestId);
            dicList.Add("scoped", scopedLT._requestId);
            dicList.Add("transient", transientLT._requestId);

            return View(dicList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
