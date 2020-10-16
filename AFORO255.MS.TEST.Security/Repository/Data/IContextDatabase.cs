using AFORO255.MS.TEST.Security.Model;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Security.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<User> Users { get; set; }
    }
}
