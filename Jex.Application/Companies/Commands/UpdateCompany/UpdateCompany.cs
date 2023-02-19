using AutoMapper;
using Jex.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Commands.UpdateCompany
{
    public record UpdateCompanyCommand : IRequest
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }
        [Required(AllowEmptyStrings = false)]
        public string Address { get; init; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetById(request.Id);

            if(company != null)
            {
                company.Address = request.Address;
                company.Name = request.Name;
                await _companyRepository.Update(company);
            }
        }
    }
}
