using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.Repository.Data
{
    public interface IContextDatabase
    {
        public DbSet<Model.Pay> Pays { get; set; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
