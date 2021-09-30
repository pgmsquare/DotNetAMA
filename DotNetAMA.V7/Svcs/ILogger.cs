using Microsoft.AspNetCore.Mvc;

namespace DotNetAMA.V7.Svcs
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
