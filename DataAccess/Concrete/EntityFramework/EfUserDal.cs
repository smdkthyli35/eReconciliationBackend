using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BaseDbContext>, IUserDal
    {
        public EfUserDal(BaseDbContext context) : base(context)
        {
        }

        public List<OperationClaim> GetClaims(User user, int companyId)
        {
            var result = from operationClaim in BaseDbContext.OperationClaims
                         join userOperationClaim in BaseDbContext.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.CompanyId == companyId && userOperationClaim.UserId == user.Id
                         select new OperationClaim
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name
                         };

            return result.ToList();
        }

        public BaseDbContext BaseDbContext => _context as BaseDbContext;
    }
}
