using CC.DataServices.Services.Interfaces;
using CC.WebAPIs.Infrastructure;

using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Text;

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
            ArgumentNullException.ThrowIfNull(to, "to");
            ArgumentNullException.ThrowIfNull(amount, "amount");

            var currenciesToExclude = new[] { "TRY", "PLN", "THB", "MXN" };
            var currencyArgs = new[] { from, to };
            var currenciesToValidate = new List<string>();
            bool valid = true;

            StringBuilder sb = new StringBuilder();
            foreach (var currencyArg in currencyArgs)
            {
                if (currencyArg != null)
                    currenciesToValidate.AddRange(currencyArg.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            }

            foreach (var currency in currenciesToValidate)
            {
                if (currenciesToExclude.Contains(currency))
                {
                    sb.Append(currency).Append(",");
                    valid = false;
                }
            }

            if (!valid)
            {
                string invaidCurrencies = sb.ToString().TrimEnd(',');
                string message = $"Conversion involving one or all of the specified currencies is not allowed ({invaidCurrencies}).";
                return TypedResults.Extensions.APIResult_BadRequest(message);
            }
            
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
                return TypedResults.Extensions.APIResultPage_Ok(res.currencyHistoricalEntity, res.pageNo, res.pageSize, res.totalRecords);

            return TypedResults.Extensions.APIResult_Ok(null);
        }
    }
}
