using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator() {

            RuleFor(x => x.Address)
            .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty();
        }        
    }
}
