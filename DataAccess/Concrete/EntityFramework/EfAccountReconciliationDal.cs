using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAccountReconciliationDal : EfEntityRepositoryBase<AccountReconciliation, BaseDbContext>, IAccountReconciliationDal
    {
        public EfAccountReconciliationDal(BaseDbContext context) : base(context)
        {
        }

        public List<AccountReconciliationDto> GetAllDto(int companyId)
        {
            var result = from reconciliation in BaseDbContext.AccountReconciliations
                         join company in BaseDbContext.Companies
                         on reconciliation.CompanyId equals company.Id
                         join account in BaseDbContext.CurrencyAccounts
                         on reconciliation.CurrencyAccountId equals account.Id
                         join currency in BaseDbContext.Currencies
                         on reconciliation.CurrencyId equals currency.Id

                         select new AccountReconciliationDto
                         {
                             CompanyId = companyId,
                             CurrencyAccountId = account.Id,
                             AccountIdentityNumber = account.IdentityNumber,
                             AccountName = account.Name,
                             AccountTaxDepartment = account.TaxDepartment,
                             AccountTaxIdNumber = account.TaxIdNumber,
                             CompanyIdentityNumber = company.IdentityNumber,
                             CompanyName = company.Name,
                             CompanyTaxDepartment = company.TaxDepartment,
                             CompanyTaxIdNumber = company.TaxIdNumber,
                             CurrencyCredit = reconciliation.CurrencyCredit,
                             CurrencyDebit = reconciliation.CurrencyDebit,
                             CurrencyId = reconciliation.CurrencyId,
                             EmailReadDate = reconciliation.EmailReadDate,
                             EndingDate = reconciliation.EndingDate,
                             Guid = reconciliation.Guid,
                             Id = reconciliation.Id,
                             IsEmailRead = reconciliation.IsEmailRead,
                             IsResultSucceed = reconciliation.IsResultSucceed,
                             IsSendEmail = reconciliation.IsSendEmail,
                             ResultDate = reconciliation.ResultDate,
                             SendEmailDate = reconciliation.SendEmailDate,
                             ResultNote = reconciliation.ResultNote,
                             StartingDate = reconciliation.StartingDate,
                             AccountEmail = account.Email,
                             CurrencyCode = currency.Code
                         };

            return result.ToList();
        }

        public BaseDbContext BaseDbContext => _context as BaseDbContext;
    }
}
