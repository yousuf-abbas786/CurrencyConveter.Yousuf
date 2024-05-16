using CC.WebAPIs.Infrastructure;

namespace CC.WebAPIs.Endpoints
{
    public class Teams : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                //.RequireAuthorization()
                ;
        }
    }
}
