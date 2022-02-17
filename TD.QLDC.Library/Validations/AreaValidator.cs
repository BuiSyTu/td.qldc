using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Validations
{
    public class AreaValidator : AbstractValidator<Area>
    {
        public AreaValidator()
        {
            RuleFor(x => x.Name).MaximumLength(256).WithMessage("Name must be less 256 characters");
            RuleFor(x => x.Code).MaximumLength(7).WithMessage("Code must be less than 7 characters");
        }
    }
}
