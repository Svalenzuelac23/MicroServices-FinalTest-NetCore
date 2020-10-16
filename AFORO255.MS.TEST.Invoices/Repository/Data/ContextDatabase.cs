using AFORO255.MS.TEST.Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Invoices.Repository.Data
{
    public class ContextDatabase : DbContext,  IContextDatabase
    {
        public ContextDatabase(
            DbContextOptions<ContextDatabase> options
            ): base(options)
        {

        }
        public DbSet<Invoice> Invoices { get; set; }

    }
}
