using CC.DataServices.ExtAPIs;
using CC.Shared.ExtAPIEntities;

using CC.WebAPIs.Infrastructure;

namespace CC.WebAPIs.Endpoints
{
    public class Matches : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                //.RequireAuthorization()
                .MapGet(GetMatchByID);
        }

        public async Task<IResult> GetMatchByID(string id, LiveKubeAPIServices liveKubeAPIServices)
        {
            ArgumentNullException.ThrowIfNull(id, "id");

            var res = await liveKubeAPIServices.GetById(long.Parse(id));

            if (res != null && res.Count > 0)
                return TypedResults.Extensions.APIResult_Ok(res.FirstOrDefault());

            return TypedResults.Extensions.APIResult_Ok(null);
        }
    }
}
