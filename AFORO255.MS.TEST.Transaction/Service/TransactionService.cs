using AFORO255.MS.TEST.Transaction.DTO;
using AFORO255.MS.TEST.Transaction.Repository;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;

        public TransactionService(
            ITransactionRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Add(Model.Transaction transaction)
        {
            await _repository.History.InsertOneAsync(transaction);
            return true;
        }

        public async Task<IEnumerable<TransactionResponse>> GetAll()
        {
            var data = await _repository.History.Find(_ => true).ToListAsync();
            var response = _mapper.Map<IEnumerable<TransactionResponse>>(data);

            return response;
        }
    }
}
