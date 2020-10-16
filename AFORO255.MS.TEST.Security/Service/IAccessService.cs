using AFORO255.MS.TEST.Security.Model;
using System.Collections.Generic;

namespace AFORO255.MS.TEST.Security.Service
{
    public interface IAccessService
    {
        public IEnumerable<User> GetAll();
        public bool Validate(string userName, string password);
    }
}
