using CC.Shared.Models;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Net;

namespace CC.WebAPIs.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"GEH - Method:{httpContext.Request.Method} - Path:{httpContext.Request.Path}, Message: {exception.Message} - StackTrace: {exception.StackTrace}");

            string message = "An unexpected error occurred, check logs for details or contact administrator.";

            if (exception.GetType() == typeof(ArgumentNullException)) 
            {
                message = exception.Message;
            }

            await httpContext.Response.WriteAsJsonAsync(new APIResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = message,
                Data = null
            });

            _logger.LogInformation("JSON RESPONSE from GlobalExceptionHandler");

            return true;
        }
    }
}
