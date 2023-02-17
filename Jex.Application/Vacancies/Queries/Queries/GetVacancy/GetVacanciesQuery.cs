using AutoMapper;
using Jex.Application.Contracts.Persistence;
using Jex.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jex.Application.Vacancies.Models;

namespace Jex.Application.Vacancy.Queries.GetVacancy
{
    public record GetVacanciesQuery() : IRequest<IEnumerable<VacancyDto>>;

    public class GetVacancyQueryHandler : IRequestHandler<GetVacanciesQuery, IEnumerable<VacancyDto>>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public GetVacancyQueryHandler(IVacancyRepository vacancyRepository, IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacancyDto>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {            
            var vacancies = await _vacancyRepository.Get();
            var vacancyDtos = _mapper.Map<IEnumerable<VacancyDto>>(vacancies);
            return vacancyDtos;
        }
    }
}
