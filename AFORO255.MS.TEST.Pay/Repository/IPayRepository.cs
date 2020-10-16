using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public interface IPayRepository
    {
        public Task<Model.Pay> AddPay(Model.Pay pay);
    }
}
