using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilmemelidir.");
            RuleFor(u => u.Name).MinimumLength(4).WithMessage("Kullanıcı adı en az 4 karakterden oluşmalıdır.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("E-posta adresi boş geçilmemelidir.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
        }
    }
}
