using CC.DataServices.ExtAPIs;
using CC.DataServices.Services.Interfaces;
using CC.WebAPIs.Infrastructure;

namespace CC.WebAPIs.Endpoints
{
    public class Currencies : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                //.RequireAuthorization()
                .MapGet(GetLatestRates, "latest")
                .MapGet(ConvertCurrency, "convert");
        }

        public async Task<IResult> GetLatestRates(string? from, ICurrencyService currencyServices)
        {

            var res = await currencyServices.GetLatestRates(from);

            if (res != null)
                return TypedResults.Extensions.APIResult_Ok(res);

            return TypedResults.Extensions.APIResult_Ok(null);
        }

        public async Task<IResult> ConvertCurrency(string? from, string? to, double? amount, ICurrencyService currencyServices)
        {
            var currenciesToExclude = new[] { "TRY", "PLN", "THB", "MXN" };

            ArgumentNullException.ThrowIfNull(amount, "amount");

            if (currenciesToExclude.Contains(from) || currenciesToExclude.Contains(to))
            {
                return TypedResults.Extensions.APIResult_BadRequest();
            }

            var res = await currencyServices.ConvertCurrency(from, to, amount.Value);

            if (res != null)
            { 
                foreach (var cur in currenciesToExclude)
                    res.Rates.Remove(cur);
                
                return TypedResults.Extensions.APIResult_Ok(res);
            }

            return TypedResults.Extensions.APIResult_Ok(null);
        }
    }
}
