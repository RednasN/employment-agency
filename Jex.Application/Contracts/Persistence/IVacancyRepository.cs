using Jex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Contracts.Persistence
{
    public interface IVacancyRepository : IRepository<Domain.Entities.Vacancy>
    {
        Task<Domain.Entities.Vacancy?> GetById(int id);
    }
}
