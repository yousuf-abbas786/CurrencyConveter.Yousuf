using Amazon.Runtime.Internal.Util;

using CC.Shared.DbContext;

using Microsoft.Extensions.Logging;

using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.DataServices.MongoDB
{
    public abstract class BaseService<T>
    {
        protected IMongoCollection<T> _Collection { get; private set; }

        public BaseService(MongoDBContext mongoDBContext, string collectionName)
        {
            _Collection = mongoDBContext.Database.GetCollection<T>(collectionName);
        }
    }
}
