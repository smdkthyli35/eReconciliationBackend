using Core.DataAccess.EntityFramework;
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
    public class EfBaBsReconciliationDetailDal : EfEntityRepositoryBase<BaBsReconciliationDetail, BaseDbContext>, IBaBsReconciliationDetailDal
    {
        public EfBaBsReconciliationDetailDal(BaseDbContext context) : base(context)
        {
        }
    }
}
