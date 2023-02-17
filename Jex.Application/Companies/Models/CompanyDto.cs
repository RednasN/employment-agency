using Jex.Application.Vacancies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Companies.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public List<VacancyDto> Vacancies { get; set; }
    }
}
