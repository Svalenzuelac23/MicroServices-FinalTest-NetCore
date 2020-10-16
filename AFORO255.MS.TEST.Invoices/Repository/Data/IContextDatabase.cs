using AFORO255.MS.TEST.Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Invoices.Repository.Data
{
    public interface IContextDatabase
    {
        public DbSet<Invoice> Invoices { get; set; }
        public int SaveChanges();
        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
