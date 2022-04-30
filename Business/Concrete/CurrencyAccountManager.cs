using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
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

        [ValidationAspect(typeof(CurrencyAccountValidator))]
        public IResult Add(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Add(currencyAccount);
            return new SuccessResult(Messages.CurrencyAccount.AddedCurrencyAccount);
        }

        [ValidationAspect(typeof(CurrencyAccountValidator))]
        [TransactionScopeAspect]
        public IResult AddToExcel(string filePath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        string taxDepartment = reader.GetString(3);
                        string taxIdNumber = reader.GetString(4);
                        string identityNumber = reader.GetString(5);
                        string email = reader.GetString(6);
                        string authorized = reader.GetString(7);

                        if (code != "Cari Kodu")
                        {
                            CurrencyAccount currencyAccount = new()
                            {
                                Name = name,
                                Address = address,
                                TaxDepartment = taxDepartment,
                                TaxIdNumber = taxIdNumber,
                                IdentityNumber = identityNumber,
                                Email = email,
                                Authorized = authorized,
                                AddedAt = DateTime.Now,
                                Code = code,
                                CompanyId = companyId,
                                IsActive = true
                            };

                            _currencyAccountDal.Add(currencyAccount);
                        }
                    }
                }
            }

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

        [ValidationAspect(typeof(CurrencyAccountValidator))]
        public IResult Update(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Messages.CurrencyAccount.UpdatedCurrencyAccount);
        }
    }
}
