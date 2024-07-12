using Microsoft.Extensions.Logging;
using ShopPro.Infraestructure.Logger.Interfaces;

namespace ShopPro.Infraestructure.Logger.Services
{
    public class LoggerService<T> : ILoggerService<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogError(string message, string exception) 
        {
            _logger.LogError(exception, message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
