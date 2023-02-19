﻿using Jex.Application.Vacancies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Models
{
    public class CompanyDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Address { get; set; } = String.Empty;

        [Required]
        public IEnumerable<VacancyDto> Vacancies { get; set; } = Enumerable.Empty<VacancyDto>();
    }
}
