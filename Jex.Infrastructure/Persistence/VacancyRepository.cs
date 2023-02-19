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
    public class VacancyRepository : BaseRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(JexDbcontext jexDbContext) : base(jexDbContext)
        {

        }

        public async Task<Vacancy?> GetById(int id)
        {
            return (await Get(x => x.Id == id)).FirstOrDefault();
        }
    }
}
