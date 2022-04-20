using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, BaseDbContext>, ICompanyDal
    {
        public EfCompanyDal(BaseDbContext context) : base(context)
        {
        }

        public void UserCompanyAdd(int userId, int companyId)
        {
            UserCompany userCompany = new()
            {
                UserId = userId,
                CompanyId = companyId,
                AddedAt = DateTime.Now,
                IsActive = true,
            };
            BaseDbContext.UserCompanies.Add(userCompany);
            BaseDbContext.SaveChanges();
        }

        private BaseDbContext BaseDbContext => _context as BaseDbContext;
    }
}
