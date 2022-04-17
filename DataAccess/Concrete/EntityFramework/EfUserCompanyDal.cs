﻿using Core.DataAccess.EntityFramework;
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
    public class EfUserCompanyDal : EfEntityRepositoryBase<UserCompany, BaseDbContext>, IUserCompanyDal
    {
        public EfUserCompanyDal(BaseDbContext context) : base(context)
        {
        }
    }
}
