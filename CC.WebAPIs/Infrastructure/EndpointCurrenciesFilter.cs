using CC.DataServices.Services.Interfaces;
using CC.Shared.Models;

using Microsoft.AspNetCore.Http;

using System.Linq;
using System.Net;
using System.Text;

namespace CC.WebAPIs.Infrastructure
{
    public class EndpointCurrenciesFilter : IEndpointFilter
    {
        private ILogger _logger;
        private readonly ICurrencyService _currencyServices;
        public EndpointCurrenciesFilter(ILogger<EndpointCurrenciesFilter> logger, ICurrencyService currencyServices)
        {
            _logger = logger;
            _currencyServices = currencyServices;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next)
        {
            var currencies = await _currencyServices.GetCurrencies();
            var queryCollection = efiContext.HttpContext.Request.Query;

            var currencyArgs = new[] { "from", "to" };
            var currenciesToValidate = new List<string>();
            bool valid = true;

            StringBuilder sb = new StringBuilder();
            foreach (var currencyArg in currencyArgs)
            {
                string arg = queryCollection[currencyArg];
                if (!string.IsNullOrEmpty(arg))
                {
                    currenciesToValidate.AddRange(arg.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)); 
                }
            }

            foreach (var currency in currenciesToValidate)
            {
                if (!currencies.Keys.Contains(currency))
                {
                    sb.Append(currency).Append(",");
                    valid = false;
                }
            }

            if (!valid)
            {
                string invaidCurrencies = sb.ToString().TrimEnd(',');
                return new APIResult
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = $"Conversion involving one or all of the specified currencies is not allowed ({invaidCurrencies}).",
                    Data = null
                };
            }

            _logger.LogInformation("JSON RESPONSE from EndpointCurrenciesFilter");

            return await next(efiContext);
        }
    }
}
