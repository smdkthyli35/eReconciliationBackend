﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CurrencyAccountManager : ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal _currencyAccountDal;

        public CurrencyAccountManager(ICurrencyAccountDal currencyAccountDal)
        {
            _currencyAccountDal = currencyAccountDal;
        }

        public IResult Add(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Add(currencyAccount);
            return new SuccessResult(Messages.CurrencyAccount.AddedCurrencyAccount);
        }

        public IResult Delete(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Delete(currencyAccount);
            return new SuccessResult(Messages.CurrencyAccount.DeletedCurrencyAccount);
        }

        public IDataResult<List<CurrencyAccount>> GetAll(int companyId)
        {
            return new SuccessDataResult<List<CurrencyAccount>>(_currencyAccountDal.GetList(c => c.CompanyId == companyId));
        }

        public IDataResult<CurrencyAccount> GetById(int id)
        {
            return new SuccessDataResult<CurrencyAccount>(_currencyAccountDal.Get(c => c.Id == id));
        }

        public IResult Update(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Messages.CurrencyAccount.UpdatedCurrencyAccount);
        }
    }
}
