using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserCompanyDto> Register(UserForRegisterDto userForRegisterDto, string password, Company company);
        IDataResult<User> RegisterSecondAccount(UserForRegisterDto userForRegisterDto, string password, int companyId);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> GetByMailConfirmValue(string value);
        IDataResult<User> GetById(int id);
        IDataResult<UserCompany> GetCompany(int userId);
        IResult UserExists(string email);
        IResult Update(User user);
        IResult CompanyExists(Company company);
        IResult SendConfirmEmail(User user);
        IDataResult<AccessToken> CreateAccessToken(User user, int companyId);
    }
}
