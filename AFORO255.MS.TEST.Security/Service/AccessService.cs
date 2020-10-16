using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Security.Service
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _repository;

        public AccessService(
            IAccessRepository repository
            )
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Validate(string userName, string password)
        {
            var users = _repository.GetAll();
            var access = users.Where(x => x.Username == userName && x.Password == password).FirstOrDefault();
            if (access != null)
                return true;
            return false;
        }
    }
}
