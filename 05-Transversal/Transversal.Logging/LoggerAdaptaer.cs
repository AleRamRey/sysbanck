using Transversal.Common;
using Microsoft.Extensions.Logging;

namespace Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            //Se puede persistir en una bd xml o archivo de texto  
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            //Se puede persistir en una bd xml o archivo de texto
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            //Se puede persistir en una bd xml o archivo de texto
            _logger.LogError(message, args);
        }
    }
}

