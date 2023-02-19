using Jex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<List<Company>> GetCompaniesWithVacancies();
        Task<Company?> GetById(int id);
    }
}
