using Amazon.Auth.AccessControlPolicy;

using CC.Shared.Abstractions;
using CC.Shared.ExtAPIEntities;
using CC.Shared.ExtAPIEntities.CustomEntities;

using CC.DataServices.Configurations;

using Flurl.Http.Configuration;

using Microsoft.Extensions.Logging;

namespace CC.DataServices.ExtAPIs
{
    public class LiveKubeAPIServices : BaseAPIServices
    {
        public LiveKubeAPIServices(ILogger<LiveKubeAPIServices> logger, IFlurlClientCache clients) : base(logger, clients, "FranfurterAPI")
        {
        }

        public async Task<List<ExtMatches>> GetById(long id)
        {
            var response = await GetRequestData<APIResponse<List<ExtMatches>>>($"/match/getbyid", null, new Dictionary<string, string>
            {
                {"id", id.ToString() }
            });

            return response.data;
        }

        public async Task<List<MatchesEntity>> GetMatchesAsync(string homeName, string awayName, DateTime matchDate, int source, int sportId)
        {
            var response = await GetRequestData<APIResponse<List<MatchesEntity>>>($"/match/getbydate", null, new Dictionary<string, string>
            {
                {"homename", homeName },
                {"awayname", awayName },
                {"dt", matchDate.ToString("yyyy-MM-dd HH:mm:ss") },
                {"source", source.ToString() }
            });

            return response.data;
        }

        public async Task<long> AddNewMatch(ExtMatches entity)
        {
            //	var postDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
            //	postDic.Add("sourceProvidedID", postDic["sourceProvidedId"]);
            //	postDic.Remove("sourceProvidedId");

            var response = await PostRequestData<APIResponse<long>>("/match/add", entity);
            return response.data;
        }

        public class APIResponse<T>
        {
            public string status { get; set; }

            public string message { get; set; }

            public T data { get; set; }
        }
    }
}
