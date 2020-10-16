using AFORO255.MS.TEST.Transaction.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public interface ITransactionService
    {
        public Task<IEnumerable<TransactionResponse>> GetAll();
        public Task<bool> Add(Model.Transaction transaction);
    }
}
