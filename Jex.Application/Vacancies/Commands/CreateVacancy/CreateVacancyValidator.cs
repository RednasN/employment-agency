using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyValidator : AbstractValidator<CreateVacancyCommand>
    {
        public CreateVacancyValidator() {

            RuleFor(x => x.Title)
            .NotEmpty();

            RuleFor(x => x.Description)
            .NotEmpty();
        }
    }
}
