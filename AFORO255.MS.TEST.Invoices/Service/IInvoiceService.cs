using AFORO255.MS.TEST.Invoices.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoices.Service
{
    public interface IInvoiceService
    {
        public Task<IEnumerable<Invoice>> GetAll();
        public Task<Invoice> Get(int invoiceId);
        public bool ChangeState(Invoice invoice);

    }
}
