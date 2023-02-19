using Jex.Application.Companies.Models;
using Jex.Application.Contracts.Persistence;
using Jex.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Vacancies.Commands.CreateVacancy
{
    public record CreateVacancyCommand : IRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; init; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; init; }
        public int CompanyId { get; init; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateVacancyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IVacancyRepository _vacancyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IVacancyRepository vacancyRepository)
        {
            _companyRepository = companyRepository;
            _vacancyRepository = vacancyRepository;
        }

        public async Task Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetById(request.CompanyId);

            var vacancy = new Domain.Entities.Vacancy
            {
                Title = request.Title,
                Description = request.Description,
                Company = company
            };

            await _vacancyRepository.Add(vacancy);
        }
    }
}
