using AFORO255.MS.TEST.Pay.Repository.Data;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public class PayRepository : IPayRepository
    {
        private readonly IContextDatabase _context;

        public PayRepository(
            IContextDatabase context
            )
        {
            _context = context;
        }

        public async Task<Model.Pay> AddPay(Model.Pay pay)
        {
            _context.Pays.Add(pay);
            await _context.SaveChangesAsync();
            return pay;             
        }
    }
}
