using Assessment.Application.Constants;
using Assessment.Application.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net;

namespace Assessment.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly IOptions<AppSettings> _config;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IOptions<AppSettings> config)
        {
            _next = next;
            _logger = logger;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString(), e);
                if (_config.Value.IsTestEnvironment)
                {
                    var result = Result<object>.Failed(StatusCode.OperationFailed, e.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    return;
                }

                var exception = Result<object>.Failed(StatusCode.OperationFailed, ResponseMessages.ErrorOccured);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(exception));
                return;
            }
        }
    }
}
