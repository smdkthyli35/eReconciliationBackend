﻿using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheRemoveAspect("IUserService.Get")]
        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        [CacheAspect(60)]
        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        [CacheAspect(60)]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        [CacheAspect(60)]
        public User GetByMailConfirmValue(string value)
        {
            return _userDal.Get(u => u.MailConfirmValue == value);
        }

        public List<OperationClaim> GetClaims(User user, int companyId)
        {
            return _userDal.GetClaims(user, companyId);
        }

        [PerformanceAspect(3)]
        [SecuredOperation("User.Update,Admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
