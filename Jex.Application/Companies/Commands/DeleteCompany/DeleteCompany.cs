using Jex.Application.Contracts.Persistence;
using Jex.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Commands.DeleteCompany
{
    public record DeleteCompanyCommand(int Id) : IRequest;

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetById(request.Id);

            if (company == null)
            {
                throw new ContentValidationException(nameof(request.Id), $"Company with id {request.Id} does not exist");
            }

            await _companyRepository.Delete(company);
        }
    }
}
