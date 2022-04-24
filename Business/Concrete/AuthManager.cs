using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ICompanyService _companyService;
        private readonly IMailService _mailService;
        private readonly IMailParameterService _mailParameterService;
        private readonly IMailTemplateService _mailTemplateService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICompanyService companyService, IMailService mailService, IMailParameterService mailParameterService, IMailTemplateService mailTemplateService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _companyService = companyService;
            _mailService = mailService;
            _mailParameterService = mailParameterService;
            _mailTemplateService = mailTemplateService;
        }

        public IResult CompanyExists(Company company)
        {
            var result = _companyService.CompanyExists(company);
            if (!result.Success)
                return new ErrorResult(Messages.Company.CompanyAlreadyExists);
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user, int companyId)
        {
            var claims = _userService.GetClaims(user, companyId);
            var accessToken = _tokenHelper.CreateToken(user, claims, companyId);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userService.GetById(id));
        }

        public IDataResult<User> GetByMailConfirmValue(string value)
        {
            return new SuccessDataResult<User>(_userService.GetByMailConfirmValue(value));
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck is null)
                return new ErrorDataResult<User>(Messages.User.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<User>(Messages.User.PasswordError);

            return new SuccessDataResult<User>(userToCheck, Messages.User.SuccessfulLogin);
        }

        public IDataResult<UserCompanyDto> Register(UserForRegisterDto userForRegisterDto, string password, Company company)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = userForRegisterDto.Name
            };

            _userService.Add(user);
            _companyService.Add(company);

            _companyService.UserCompanyAdd(user.Id, company.Id);

            UserCompanyDto userCompanyDto = new()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AddedAt = user.AddedAt,
                CompanyId = company.Id,
                IsActive = true,
                MailConfirm = user.MailConfirm,
                MailConfirmValue = user.MailConfirmValue,
                MailConfirmDate = user.MailConfirmDate,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };

            SendConfirmEmail(user);

            return new SuccessDataResult<UserCompanyDto>(userCompanyDto, Messages.User.UserRegistered);
        }

        void SendConfirmEmail(User user)
        {
            string subject = "Kullanıcı Kayıt Onay Maili";
            string body = "Kullanıcınız sisteme kayıt oldu. Kaydınızı tamamlamak için aşağıdaki linke tıklamanız gerekmektedir.";
            string link = "https://localhost:44368/api/Auth/confirmuser?value=" + user.MailConfirmValue;
            string linkDescription = "Kayıt Onaylamak İçin Tıklayın";

            var mailTemplate = _mailTemplateService.GetByTemplateName("Kayıt", 4);
            string templateBody = mailTemplate.Data.Value;
            templateBody = templateBody.Replace("{{title}}", subject);
            templateBody = templateBody.Replace("{{message}}", body);
            templateBody = templateBody.Replace("{{link}}", link);
            templateBody = templateBody.Replace("{{linkDescription}}", linkDescription);

            var mailParameter = _mailParameterService.Get(4);
            SendMailDto sendMailDto = new()
            {
                MailParameter = mailParameter.Data,
                Email = user.Email,
                Subject = "Kullanıcı kayıt onay maili",
                Body = templateBody
            };
            _mailService.SendMail(sendMailDto);

            user.MailConfirmDate = DateTime.Now;
            _userService.Update(user);
        }

        public IDataResult<User> RegisterSecondAccount(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = userForRegisterDto.Name
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.User.UserRegistered);
        }

        public IResult Update(User user)
        {
            _userService.Update(user);
            return new SuccessResult(Messages.User.UserMailConfirmSuccessful);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
                return new ErrorResult(Messages.User.UserAlreadyExists);
            return new SuccessResult();
        }

        IResult IAuthService.SendConfirmEmail(User user)
        {
            if (user.MailConfirm == true)
            {
                return new ErrorResult(Messages.User.MailAlreadyConfirm);
            }

            DateTime confirmMailDate = user.MailConfirmDate;
            DateTime now = DateTime.Now;
            if (confirmMailDate.ToShortDateString() == now.ToShortDateString())
            {
                if (confirmMailDate.Hour == now.Hour && confirmMailDate.AddMinutes(5).Minute <= now.Minute)
                {
                    SendConfirmEmail(user);
                    return new SuccessResult(Messages.User.MailConfirmSendSuccessful);
                }
                else
                {
                    return new ErrorResult(Messages.User.MailConfirmTimeHasNotExpired);
                }
            }
            SendConfirmEmail(user);
            return new SuccessResult(Messages.User.MailConfirmSendSuccessful);
        }
    }
}
