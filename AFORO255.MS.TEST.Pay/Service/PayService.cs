using AFORO255.MS.TEST.Pay.Repository;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.Service
{
    public class PayService : IPayService
    {
        private readonly IPayRepository _repository;

        public PayService(
            IPayRepository repository
            )
        {
            _repository = repository;
        }
        public async Task<Model.Pay> AddPay(Model.Pay pay)
        {
            return await _repository.AddPay(pay);           
        }
    }
}
