using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMongoDatabase _database = null;

        public TransactionRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["cnmongo"]);
            if (client != null)
                _database = client.GetDatabase(configuration["mongodatabase"]);
        }
        public IMongoCollection<Model.Transaction> History
        {
            get
            {
                return _database.GetCollection<Model.Transaction>("Transaction");
            }
        }
    }
}
