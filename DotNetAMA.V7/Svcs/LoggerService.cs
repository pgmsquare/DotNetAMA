using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace DotNetAMA.V7.Svcs
{
    public class LoggerService : ILogger
    {
        private readonly NLog.ILogger _logger =
            LogManager.Setup().LoadConfigurationFromAppSettings()
                      .GetCurrentClassLogger();

        private string _actionName;

        private string GetActionName(ControllerContext controlerContext)
        {
            if (controlerContext == null)
            {
                return null;
            }

            return controlerContext.ActionDescriptor.ActionName;
        }

        public void LogDebug(string message, ControllerContext controlerContext = null)
        {
            _actionName = GetActionName(controlerContext);

            if (controlerContext != null
                && _actionName != null)
            {
                _logger.Debug($"[{_actionName}]" + message);
            }
            else
            {
                _logger.Debug(message);
            }            
        }

        public void LogError(string message, ControllerContext controlerContext = null)
        {
            _actionName = GetActionName(controlerContext);

            if (controlerContext != null
                && _actionName != null)
            {
                _logger.Error($"[{_actionName}]" + message);
            }
            else
            {
                _logger.Error(message);
            }
        }

        public void LogInfo(string message, ControllerContext controlerContext = null)
        {
            _actionName = GetActionName(controlerContext);

            if (controlerContext != null
                && _actionName != null)
            {
                _logger.Info($"[{_actionName}]" + message);
            }
            else
            {
                _logger.Info(message);
            }
        }

        public void LogTrace(string message, ControllerContext controlerContext = null)
        {
            _actionName = GetActionName(controlerContext);

            if (controlerContext != null
                && _actionName != null)
            {
                _logger.Trace($"[{_actionName}]" + message);
            }
            else
            {
                _logger.Trace(message);
            }
        }

        public void LogWarn(string message, ControllerContext controlerContext = null)
        {
            _actionName = GetActionName(controlerContext);

            if (controlerContext != null
                && _actionName != null)
            {
                _logger.Warn($"[{_actionName}]" + message);
            }
            else
            {
                _logger.Warn(message);
            }
        }
    }
}
