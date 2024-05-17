
using CC.Shared.CurrencyAPIEntities;
using CC.Shared.Models;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using System.Text.Json;

namespace CC.WebAPIs.Infrastructure
{
    public class ResultOK : IResult
    {
        private readonly object res;
        public ResultOK(object _res)
        {
            res = _res;
        }

        public Task ExecuteAsync(HttpContext httpContext)
        {
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


            return httpContext.Response.WriteAsJsonAsync<APIResult>(result);

        }
    }

}
