namespace CC.WebAPIs.Infrastructure
{
    public class EndpointDateFilter : IEndpointFilter
    {
        private ILogger _logger;

        public EndpointDateFilter(ILogger<EndpointDateFilter> logger)
        {
            _logger = logger;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next)
        {
            _logger.LogInformation("filter before request process");


            return await next(efiContext);

        }
    }
}
