using Jex.Application.Companies.Models;
using Jex.Application.Contracts.Persistence;
using Jex.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Commands.CreateCompany
{
    public record CreateCompanyCommand : IRequest
    {
        public string Name { get; init; }
        public string Address { get; init; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                Name = request.Name,
                Address = request.Address                              
            };

            await _companyRepository.Add(company);
        }
    }
}
