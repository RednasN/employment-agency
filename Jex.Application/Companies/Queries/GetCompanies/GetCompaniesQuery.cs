using AutoMapper;
using Jex.Application.Companies.Models;
using Jex.Application.Contracts.Persistence;
using Jex.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Queries.GetCompanies
{
    public record GetCompaniesQuery(Boolean IncludeVacancies) : IRequest<IEnumerable<CompanyDto>>;

    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = request.IncludeVacancies ? await _companyRepository.GetCompaniesWithVacancies() :
                                                        await _companyRepository.Get();

            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companyDtos;
        }
    }
}
