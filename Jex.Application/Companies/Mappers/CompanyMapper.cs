using AutoMapper;
using Jex.Application.Companies.Models;
using Jex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Mappers
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(
                    dest => dest.Vacancies,
                    opt => opt.MapFrom(src => src.Vacancies));
        }
    }
}
