using Jex.Application.Contracts.Persistence;
using Jex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Infrastructure.Persistence
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(JexDbcontext jexDbContext) : base(jexDbContext)
        {

        }

        public async Task<List<Company>> GetCompaniesWithVacancies()
        {
            return await Get(null, y => y.Include(x => x.Vacancies));
        }

        public async Task<Company?> GetById(int id)
        {
            return (await Get(x => x.Id == id)).FirstOrDefault();
        }
    }
}
