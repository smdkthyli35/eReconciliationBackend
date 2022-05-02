using Business.Abstract;
using Business.Constants;
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
    public class AccountReconciliationDetailManager : IAccountReconciliationDetailService
    {
        private readonly IAccountReconciliationDetailDal _accountReconciliationDetailDal;

        public AccountReconciliationDetailManager(IAccountReconciliationDetailDal accountReconciliationDetailDal)
        {
            _accountReconciliationDetailDal = accountReconciliationDetailDal;
        }

        public IResult Add(AccountReconciliationDetail accountReconciliationDetail)
        {
            _accountReconciliationDetailDal.Add(accountReconciliationDetail);
            return new SuccessResult(Messages.AccountReconciliationDetail.AddedAccountReconciliationDetail);
        }

        public IResult AddToExcel(string filePath, int accountReconciliationId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string description = reader.GetString(1);

                        if (description != "Açıklama" && description != null)
                        {
                            DateTime date = reader.GetDateTime(0);
                            double currencyId = reader.GetDouble(2);
                            double debit = reader.GetDouble(3);
                            double credit = reader.GetDouble(4);

                            AccountReconciliationDetail accountReconciliationDetail = new()
                            {
                                AccountReconciliationId = accountReconciliationId,
                                Description = description,
                                Date = date,
                                CurrencyCredit = Convert.ToDecimal(credit),
                                CurrencyDebit = Convert.ToDecimal(debit),
                                CurrencyId = Convert.ToInt16(currencyId)
                            };

                            _accountReconciliationDetailDal.Add(accountReconciliationDetail);
                        }
                    }
                }
            }

            return new SuccessResult(Messages.AccountReconciliation.AddedAccountReconciliation);
        }

        public IResult Delete(AccountReconciliationDetail accountReconciliationDetail)
        {
            _accountReconciliationDetailDal.Delete(accountReconciliationDetail);
            return new SuccessResult(Messages.AccountReconciliationDetail.DeletedAccountReconciliationDetail);
        }

        public IDataResult<List<AccountReconciliationDetail>> GetAll(int accountReconciliationId)
        {
            return new SuccessDataResult<List<AccountReconciliationDetail>>(_accountReconciliationDetailDal.GetList(a => a.AccountReconciliationId == accountReconciliationId));
        }

        public IDataResult<AccountReconciliationDetail> GetById(int id)
        {
            return new SuccessDataResult<AccountReconciliationDetail>(_accountReconciliationDetailDal.Get(a => a.Id == id));
        }

        public IResult Update(AccountReconciliationDetail accountReconciliationDetail)
        {
            _accountReconciliationDetailDal.Update(accountReconciliationDetail);
            return new SuccessResult(Messages.AccountReconciliationDetail.UpdatedAccountReconciliationDetail);
        }
    }
}
