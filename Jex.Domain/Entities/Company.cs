using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Jex.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}