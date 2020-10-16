using AFORO255.MS.TEST.Invoices.Model;
using AFORO255.MS.TEST.Invoices.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoices.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IContextDatabase _context;

        public InvoiceRepository(
            IContextDatabase context
            )
        {
            _context = context;
        }

        public async Task<Invoice> Get(int invoiceId)
        {
            return await _context.Invoices.Where(x => x.InvoiceId == invoiceId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
            return await _context.Invoices.OrderBy(x=>x.InvoiceId).ToListAsync();
        }

        public bool Update(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            _context.SaveChanges();
            return true;
        }
    }
}
