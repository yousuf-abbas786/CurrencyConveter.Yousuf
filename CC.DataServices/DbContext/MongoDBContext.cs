using CC.DataServices.Configurations;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.DbContext
{
    public class MongoDBContext
    {
        private readonly MongoConnectionString connectionString;
        public IMongoDatabase Database { get; private set; }

        public MongoDBContext(IOptions<MongoConnectionString> connstring)
        {
            ArgumentNullException.ThrowIfNull(connstring, "MongoConnectionString");
            connectionString = connstring.Value;

            var client = new MongoClient(connectionString.URL);
            Database = client.GetDatabase(connectionString.DBName);
        }
    }
}
