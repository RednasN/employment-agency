using Jex.Application.Contracts.Persistence;
using Jex.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Vacancies.Commands.DeleteVacancy
{
    public record DeleteVacancyCommand(int Id) : IRequest;

    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand>
    {
        private readonly ICompanyRepository _vacancyRepository;
        public DeleteVacancyCommandHandler(ICompanyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepository.GetById(request.Id);

            if (vacancy == null)
            {
                throw new ContentValidationException(nameof(request.Id), $"Vacancy with id {request.Id} does not exist");
            }

            await _vacancyRepository.Delete(vacancy);
        }
    }
}
