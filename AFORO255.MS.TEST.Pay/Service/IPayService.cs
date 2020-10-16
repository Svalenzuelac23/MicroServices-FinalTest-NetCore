using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.Service
{
    public interface IPayService
    {
        public Task<Model.Pay> AddPay(Model.Pay pay);
    }
}
