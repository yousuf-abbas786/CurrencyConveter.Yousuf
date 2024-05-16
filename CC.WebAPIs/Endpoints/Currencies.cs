using CC.DataServices.ExtAPIs;
using CC.DataServices.Services;
using CC.WebAPIs.Infrastructure;

namespace CC.WebAPIs.Endpoints
{
    public class Currencies : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                //.RequireAuthorization()
                .MapGet(GetLatestRates);
        }

        public async Task<IResult> GetLatestRates(string from, ICurrencyService currencyServices)
        {
            ArgumentNullException.ThrowIfNull(from, "from");

            var res = await currencyServices.GetLatestRates(from);

            if (res != null)
                return TypedResults.Extensions.APIResult_Ok(res);

            return TypedResults.Extensions.APIResult_Ok(null);
        }
    }
}
