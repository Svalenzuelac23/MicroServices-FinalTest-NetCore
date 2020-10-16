using AFORO255.MS.TEST.Invoices.Model;
using AFORO255.MS.TEST.Invoices.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoices.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceService(
            IInvoiceRepository repository
            )
        {
            _repository = repository;
        }

        public async Task<Invoice> Get(int invoiceId)
        {
            return await _repository.Get(invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
            return await _repository.GetAll();
        }

        public bool ChangeState(Invoice invoice)
        {
            return _repository.Update(invoice);

        }
    }
}
