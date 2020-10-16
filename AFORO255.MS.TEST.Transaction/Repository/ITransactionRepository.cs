using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public interface ITransactionRepository
    {
        IMongoCollection<Model.Transaction> History { get; }
    }
}
