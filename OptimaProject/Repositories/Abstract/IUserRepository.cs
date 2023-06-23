using OptimaProject.Entities.Concrete;
using System.Collections.Generic;

namespace OptimaProject.Repositories.Abstract
{
    public interface IUserRepository
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
