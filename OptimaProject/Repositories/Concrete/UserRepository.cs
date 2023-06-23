using Microsoft.EntityFrameworkCore;
using OptimaProject.DbContexts;
using OptimaProject.Entities.Abstract;
using OptimaProject.Entities.Concrete;
using OptimaProject.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace OptimaProject.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly OptimaDbContext _context;
        public UserRepository(OptimaDbContext context)
        {
            _context = context;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }

        public void Add(User user)
        {
            var addedUser = _context.Entry(user);
            addedUser.State = EntityState.Added;
            _context.SaveChanges();
        }

        public User GetByMail(string email)
        {
            return _context.Set<User>().SingleOrDefault(u => u.Email == email);
        }
    }
}
