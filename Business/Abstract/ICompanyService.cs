using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<UserCompany> GetCompany(int userId);
        IResult Add(Company company);
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userId, int companyId);
    }
}
