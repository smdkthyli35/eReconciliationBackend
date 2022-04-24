using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserAndCompanyRegisterDto userAndCompanyRegisterDto)
        {
            var userExists = _authService.UserExists(userAndCompanyRegisterDto.UserForRegisterDto.Email);
            if (!userExists.Success)
                return BadRequest(userExists.Message);

            var companyExists = _authService.CompanyExists(userAndCompanyRegisterDto.Company);
            if (!companyExists.Success)
                return BadRequest(companyExists.Message);

            var registerResult = _authService.Register(userAndCompanyRegisterDto.UserForRegisterDto, userAndCompanyRegisterDto.UserForRegisterDto.Password, userAndCompanyRegisterDto.Company);

            var result = _authService.CreateAccessToken(registerResult.Data, registerResult.Data.CompanyId);

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(registerResult.Message);
        }

        [HttpPost("registerSecondAccount")]
        public IActionResult RegisterSecondAccount(UserForRegisterToSecondAccountDto userForRegister)
        {
            var userExists = _authService.UserExists(userForRegister.Email);

            if (!userExists.Success)
                return BadRequest(userExists.Message);

            var registerResult = _authService.RegisterSecondAccount(userForRegister, userForRegister.Password, userForRegister.CompanyId);

            var result = _authService.CreateAccessToken(registerResult.Data, userForRegister.CompanyId);

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(registerResult.Message);
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.Success)
                return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data, 0);

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("confirmuser")]
        public IActionResult ConfirmUser(string value)
        {
            var user = _authService.GetByMailConfirmValue(value).Data;
            user.MailConfirm = true;
            user.MailConfirmDate = DateTime.Now;

            var result = _authService.Update(user);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("sendconfirmemail")]
        public IActionResult SendConfirmEmail(int userId)
        {
            var user = _authService.GetById(userId).Data;
            var result = _authService.SendConfirmEmail(user);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
