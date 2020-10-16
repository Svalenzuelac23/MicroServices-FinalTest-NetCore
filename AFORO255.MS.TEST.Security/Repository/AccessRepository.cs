using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Security.Repository
{
    public class AccessRepository : IAccessRepository
    {
        private readonly IContextDatabase _context;

        public AccessRepository(
            IContextDatabase context
            )
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
