using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Şirket adı boş geçilmemelidir.");
            RuleFor(c => c.Name).MinimumLength(4).WithMessage("Şirket adı en az 4 karakterden oluşmalıdır.");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Şirket adresi boş geçilmemelidir.");
        }
    }
}
