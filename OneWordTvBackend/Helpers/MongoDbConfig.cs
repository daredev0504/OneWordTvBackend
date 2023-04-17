using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace OneWordTvBackend.Helpers
{
    public class MongoDbConfig
    {
        public string Name { get; init; }
        public string Password { get; init; }
        public int Port { get; init; }
        public string programsCollectionName { get; init; }
        public string OneWordTvDbCollectionName { get; init; }
        public string ConnectionString => $"mongodb+srv://tosingh5544:{Password}@dami-cluster.rnomkso.mongodb.net/?retryWrites=true&w=majority";
     
    }
}
