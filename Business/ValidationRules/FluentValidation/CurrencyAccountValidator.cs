using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CurrencyAccountValidator : AbstractValidator<CurrencyAccount>
    {
        public CurrencyAccountValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Firma adı boş geçilmemelidir.");
            RuleFor(c => c.Name).MinimumLength(4).WithMessage("Firma adı en az 4 karakterden oluşmalıdır.");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Firma adresi boş geçilmemelidir.");
            RuleFor(c => c.Address).MinimumLength(4).WithMessage("Firma adresi en az 4 karakterden oluşmalıdır.");
            RuleFor(c => c.Code).NotEmpty().WithMessage("Firma kodu boş geçilmemelidir.");
            RuleFor(c => c.Code).MinimumLength(4).WithMessage("Firma kodu en az 4 karakterden oluşmalıdır.");
        }
    }
}
