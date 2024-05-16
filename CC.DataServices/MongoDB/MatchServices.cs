using Amazon.Runtime.Internal.Util;

using CC.Shared.DbContext;
using CC.Shared.MongoEntities;

using Microsoft.Extensions.Logging;

using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.DataServices.MongoDB
{
    public class MatchServices : BaseService<Matches>
    {
        private readonly ILogger<MatchServices> _logger;
        public MatchServices(ILogger<MatchServices> logger, MongoDBContext mongoDBContext) : base(mongoDBContext, "matches")
        {
            _logger = logger;
        }

        public Matches GetMatchByID(string objectId)
        {
            Matches result = null;
            try
            {
                var filter = Builders<Matches>.Filter.Eq(a => a._id, objectId);
                result = _Collection.Find(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetMatchByID for ID: {objectId}, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
            return result;
        }
    }
}
