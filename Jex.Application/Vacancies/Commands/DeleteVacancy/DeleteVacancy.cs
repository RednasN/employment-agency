using Jex.Application.Contracts.Persistence;
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
            var company = await _vacancyRepository.GetById(request.Id);

            if(company != null)
            {
                await _vacancyRepository.Delete(company);
            }
        }
    }
}
