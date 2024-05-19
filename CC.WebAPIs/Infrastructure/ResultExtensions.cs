using MongoDB.Bson.Serialization.Serializers;

using System.Net;

namespace CC.WebAPIs.Infrastructure
{
    public static class ResultExtensions
    {
        public static IResult APIResult_Ok(this IResultExtensions resultExtensions, object data)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions);

            return new ResultOK(data);
        }

        public static IResult APIResultPage_Ok(this IResultExtensions resultExtensions, object data, int pageno, int pagesize, long totalrecords)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions);

            return new ResultPageOK(data, pageno, pagesize, totalrecords);
        }

        public static IResult APIResult_Error(this IResultExtensions resultExtensions)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions);

            return new ResultError();
        }

        public static IResult APIResult_BadRequest(this IResultExtensions resultExtensions)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions);

            return new ResultBadRequest();
        }
    }
}
