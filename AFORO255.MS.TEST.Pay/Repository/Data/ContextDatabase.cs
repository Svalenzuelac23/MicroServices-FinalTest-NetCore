using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Pay.Repository.Data
{
    public class ContextDatabase : DbContext , IContextDatabase
    {
        public ContextDatabase(
            DbContextOptions<ContextDatabase> options
            ): base(options)
        {

        }
        public DbSet<Model.Pay> Pays { get; set; }

    }
}
