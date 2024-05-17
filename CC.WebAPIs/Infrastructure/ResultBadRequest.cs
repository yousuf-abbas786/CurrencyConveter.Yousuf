
using CC.Shared.Models;
using System.Net;

namespace CC.WebAPIs.Infrastructure
{
    public class ResultBadRequest : IResult
    {
        public Task ExecuteAsync(HttpContext httpContext)
        {
            var result = new APIResult
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = "Conversion involving specified currencies is not allowed.",
                Data = null
            };

            return httpContext.Response.WriteAsJsonAsync<APIResult>(result);
        }
    }
}
