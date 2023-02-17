using FluentValidation;
using Jex.Application.Vacancy.Commands.UpdateVacancy;

namespace Jex.Application.Vacancies.Commands.UpdateVacancy
{
    public class UpdateVacancyValidator : AbstractValidator<UpdateVacancyCommand>
    {
        public UpdateVacancyValidator() {

            RuleFor(x => x.Title)
            .NotEmpty();

            RuleFor(x => x.Description)
            .NotEmpty();
        }        
    }
}
