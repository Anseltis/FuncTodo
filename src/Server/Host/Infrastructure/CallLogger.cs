using System;
using System.Linq;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace ESystems.FuncTodo.Server.Host.Infrastructure
{
    public class CallLogger : IInterceptor
    {
        private readonly Lazy<ILogger> _loggerLazy;
        private ILogger Logger => _loggerLazy.Value;

        public CallLogger(ILoggerFactory loggerFactory)
        {
            _loggerLazy = new Lazy<ILogger>(() => loggerFactory.CreateLogger("my logger"));
        }

        public void Intercept(IInvocation invocation)
        {
            Logger.LogInformation("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(argument => (argument ?? "").ToString()).ToArray()));

            invocation.Proceed();

            Logger.LogInformation("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}
