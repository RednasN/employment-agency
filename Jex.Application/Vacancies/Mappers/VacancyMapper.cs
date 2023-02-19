using AutoMapper;
using Jex.Application.Vacancies.Models;
using Jex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Vacancies.Mappers
{
    public class VacancyMapper : Profile
    {
        public VacancyMapper()
        {
            CreateMap<Domain.Entities.Vacancy, VacancyDto>();
        }
    }
}
