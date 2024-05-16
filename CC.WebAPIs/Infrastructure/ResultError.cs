﻿
using CC.Shared.Models;

using System.Net;

namespace CC.WebAPIs.Infrastructure
{
    public class ResultError : IResult
    {
        public Task ExecuteAsync(HttpContext httpContext)
        {
            var result = new APIResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "An unexpected error occurred, check logs for details or contact administrator.",
                Data = null
            };

            return httpContext.Response.WriteAsJsonAsync<APIResult>(result);
        }
    }
}
