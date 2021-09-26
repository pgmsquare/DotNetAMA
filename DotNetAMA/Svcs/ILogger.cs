using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Svcs
{
    public interface ILogger
    {
        void LogInfo(string message, ControllerContext controlerContext = null);
        void LogTrace(string message, ControllerContext controlerContext = null);
        void LogWarn(string message, ControllerContext controlerContext = null);
        void LogDebug(string message, ControllerContext controlerContext = null);
        void LogError(string message, ControllerContext controlerContext = null);
    }
}
