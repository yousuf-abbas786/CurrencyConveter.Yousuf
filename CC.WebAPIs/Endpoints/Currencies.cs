using CC.DataServices.Services.Interfaces;
using CC.WebAPIs.Infrastructure;

using Microsoft.AspNetCore.Mvc.RazorPages;

using static MongoDB.Driver.WriteConcern;

namespace CC.WebAPIs.Endpoints
{
    public class Currencies : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetLatestRates, "latest")
                .MapGet(ConvertCurrency, "convert")
                .MapGet(GetHistoricalRates, "historical");
        }

        public async Task<IResult> GetLatestRates(string? from, string? to, ICurrencyService currencyServices)
        {
            var res = await currencyServices.GetLatestRatesAsync(from, to, 1);

            if (res != null)
                return TypedResults.Extensions.APIResult_Ok(res);

            return TypedResults.Extensions.APIResult_Ok(null);
        }

        public async Task<IResult> ConvertCurrency(string? from, string? to, double? amount, ICurrencyService currencyServices)
        {
            var currenciesToExclude = new[] { "TRY", "PLN", "THB", "MXN" };

            ArgumentNullException.ThrowIfNull(amount, "amount");

            if (currenciesToExclude.Contains(from) || currenciesToExclude.Contains(to))
                return TypedResults.Extensions.APIResult_BadRequest();
            
            var res = await currencyServices.GetLatestRatesAsync(from, to, amount.Value);

            if (res != null)
            { 
                foreach (var cur in currenciesToExclude)
                    res.Rates.Remove(cur);
                
                return TypedResults.Extensions.APIResult_Ok(res);
            }

            return TypedResults.Extensions.APIResult_Ok(null);
        }

        public async Task<IResult> GetHistoricalRates(string? from, string? to, DateTime? startDate, DateTime? endDate, int? page, int? pageSize, ICurrencyService currencyServices)
        {
            ArgumentNullException.ThrowIfNull(startDate, "startDate");

            page = page ?? 1;
            pageSize = pageSize ?? 10;
            var res = await currencyServices.GetHistoricalRatesAsync(from, to, startDate.Value, endDate, page.Value, pageSize.Value);

            if (res != null)
                return TypedResults.Extensions.APIResultPage_Ok(res, res.PageNo, res.PageSize, res.TotalRecords);

            return TypedResults.Extensions.APIResult_Ok(null);
        }
    }
}
