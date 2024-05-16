using CC.Shared.Models;

namespace CC.WebAPIs.Infrastructure
{
    public class EndpointExceptionFilter : IEndpointFilter
    {
        private ILogger _logger;

        public EndpointExceptionFilter(ILogger<EndpointExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next)
        {
            _logger.LogInformation("filter before request process");

            var res = await next(efiContext);
            var result = new APIResult();

            if (res != null)
            {
                result.Data = res;
                //return Ok(result);
            }

            if (res == null)
            {
                result.Message = "No Data Found";
            }
            else if (res.Equals(true))
            {
                result.Message = "Data Created or Updated";
            }
            else if (res.Equals(false))
            {
                result.Message = "Data not Created or Updated";
            }

            _logger.LogInformation("filter after request process");

            return result;
        }
    }
}
