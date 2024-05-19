
using CC.Shared.Models;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using System.Text.Json;


namespace CC.WebAPIs.Infrastructure
{
    public class ResultPageOK : IResult
    {

        private readonly object res;
        private readonly int pageno;
        private readonly int pagesize;
        private readonly long totalrecords;
        public ResultPageOK(object _res, int _pageno, int _pagesize, long _totalrecords)
        {
            res = _res;
            pageno = _pageno;
            pagesize = _pagesize;
            totalrecords = _totalrecords;
        }
        public Task ExecuteAsync(HttpContext httpContext)
        {
            var result = new APIPageResult();

            if (res != null)
            {
                result.Data = res;
                result.PageNo = pageno;
                result.PageSize = pagesize;
                result.TotalRecords = totalrecords;
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


            return httpContext.Response.WriteAsJsonAsync<APIPageResult>(result);

        }
    }
}
