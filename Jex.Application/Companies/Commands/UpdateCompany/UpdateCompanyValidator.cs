using FluentValidation;

namespace Jex.Application.Companies.Commands.UpdateCompany
{
    public class UpdateVacancyValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateVacancyValidator() {

            RuleFor(x => x.Address)
            .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty();
        }        
    }
}
